using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Grapevine.Interfaces.Server;
using Grapevine.Server;
using log4net;
using Grapevine.Server.Attributes;
using Grapevine.Shared;
using MQL4CSharp.Base.MQL;
using MQL4CSharp.UserDefined.Strategy;
using MQL4CSharp.Util;
using Namotion.Reflection;
using System.Resources;
using System.Threading;
using System.Threading.Tasks;
using MQL4CSharp.Base.Enums;
using MQL4CSharp.UserDefined.Input;
using MQL4CSharp.UserDefined.Managers;

namespace MQL4CSharp.Base.REST
{
    [RestResource]
    public sealed class MQLRESTResource : MQLRESTBase
    {

        private static readonly ILog LOG = LogManager.GetLogger(typeof(MQLRESTResource));

        //da lasciare per abilitare la scansione di questa classe
        [RestRoute(PathInfo = @"^/([0-9]+/)?(?i)help$")]
        public IHttpContext Help(IHttpContext context)
        {
            var baseUrl = $"{context.Request.Url.OriginalString.Replace(context.Request.Url.PathAndQuery, "/").TrimEnd('/')}/";
            var allmethods = AddedRoutesMethods.OrderBy(x => x.Key)
                .SelectMany(pair => pair.Value, (pair, info) =>
                {
                    var comment = info.GetXmlDocsSummary();
                    return $"Api Url: {baseUrl}{info.Name.ToLowerInvariant()} or {baseUrl}chartid/{info.Name.ToLowerInvariant()}\r\n{(string.IsNullOrEmpty(comment) ? comment : comment + "\r\n")}{GetMethodDescr(info)}";
                })
                .ToList();
            context.Response.SendResponse($"All Methods:\r\n{allmethods.Join("\r\n\r\n")}");
            return context;
        }

        public override void OnServerInit(RestServer server)
        {
            base.OnServerInit(server);

            try
            {
                var assembly = Assembly.GetAssembly(typeof(MQLRESTResource));
                var file = assembly.Location.Replace(".dll", ".xml");
                using (var input = assembly.GetManifestResourceStream("MQL4CSharp.MQL4CSharp.xml"))
                using (var ms = new MemoryStream())
                {
                    input.CopyTo(ms);
                    var bytes = ms.ToArray();
                    File.WriteAllBytes(file, bytes);
                }
            }
            catch { }

            var allMethods = GetExpertByChartId(0).GetType().GetMethods();
            var methods = allMethods
                    .Where(x => x.DeclaringType != typeof(MQLExpert))
                    .Where(x => !x.Name.StartsWith("get_") && !x.Name.StartsWith("set_"))
                    .Where(x => x.Name != nameof(MQLRESTStrategy.OnInit))
                    .Where(x => x.Name != nameof(MQLRESTStrategy.OnDeinit))
                    .Where(x => x.Name != nameof(MQLRESTStrategy.OnTick))
                    .Where(x => x.Name != nameof(MQLRESTStrategy.OnTimer))
                    .Where(x => x.DeclaringType == typeof(MQLBase) || x.DeclaringType == typeof(MQLBaseExtended) || x.GetCustomAttributes<MqlRestDynamicMethodRoute>().Any())
                    .ToList()
                ;
            AddRoutesFromStandardMethods(server, c => GetExpertByChartId(c.ChartId), methods);

            methods = this.GetType().GetMethods()
                .Where(x => x.GetCustomAttributes<MqlRestDynamicMethodRoute>().Any())
                .ToList();
            AddRoutesFromStandardMethods(server, c => this, methods);
        }

        [MqlRestDynamicMethodRoute]
        public List<OrderDef> OrdersList(MQLRestContext context)
        {
            var ordersLogger = GetOrdersLogger(context);
            if (ordersLogger != null)
                return ordersLogger.Orders;
            var expert = GetExpertByChartId(context.ChartId);
            var lst = GetTradeOrders((MQLBaseExtended)expert, false);
            return lst;
        }

        [MqlRestDynamicMethodRoute]
        public List<OrderDef> OrdersHistoryTodayList(MQLRestContext context)
        {
            var ordersLogger = GetOrdersLogger(context);
            if (ordersLogger != null)
                return ordersLogger.HistoryOrdersForCurrentDay;
            var lst = OrdersHistoryList(context);
            lst = lst.Where(x => x.closetime?.Date == DateTime.Today).ToList();
            return lst;
        }

        [MqlRestDynamicMethodRoute]
        public List<OrderDef> OrdersHistoryList(MQLRestContext context)
        {
            var ordersLogger = GetOrdersLogger(context);
            if (ordersLogger != null)
                return ordersLogger.HistoryOrders;
            var expert = GetExpertByChartId(context.ChartId);
            var lst = GetTradeOrders((MQLBaseExtended)expert, true);
            return lst;
        }

        private int accountNumber;
        private OrdersLogger GetOrdersLogger(MQLRestContext context)
        {
            if (accountNumber == 0)
            {
                var expert = GetExpertByChartId(context.ChartId);
                accountNumber = (expert as MQLBaseExtended)?._lastAccountNumber ?? 0;
                if (accountNumber == 0)
                    accountNumber = expert.AccountNumber();
            }
            var logger = OrdersLoggerStaticMethods.OrdersLoggerPerChart.Values
                .Where(x => x.AccountNumber == accountNumber)
                .OrderByDescending(x => x.TimeCurrent).FirstOrDefault();
            if (logger != null && logger.TimeCurrent.AddSeconds(10) > DateTime.Now)
                return logger;
            return null;
        }

        readonly SemaphoreSlim ordersLock = new SemaphoreSlim(1, 1);
        private List<OrderDef> GetTradeOrders(MQLBaseExtended mqlBase, bool history = false)
        {
            var tentativi = 10;
            for (var tentativo = 0; tentativo <= tentativi; tentativo++)
            {
                ordersLock.Wait();
                try
                {
                    var res = new List<OrderDef>();
                    var total = (history ? mqlBase.OrdersHistoryTotal() : mqlBase.OrdersTotal());
                    if (total == 0)
                        return res;
                    var hashsetTickets = new HashSet<int>();
                    for (int i = 0; i < total; i++)
                    {
                        if (!mqlBase.OrderSelect(i, (int)SELECTION_TYPE.SELECT_BY_POS, (int)(history ? SELECTION_POOL.MODE_HISTORY : SELECTION_POOL.MODE_TRADES)))
                        {
                            var error = mqlBase.GetLastError();
                            throw new Exception(error.ToString());
                        }
                        var order = mqlBase.OrderGetOrderDefModel();
                        var oderTicket = order.ticket;
                        if (!hashsetTickets.Add(oderTicket))
                            throw new Exception("Order already exists");
                        res.Add(order);
                    }
                    var newtotal = (history ? mqlBase.OrdersHistoryTotal() : mqlBase.OrdersTotal());
                    if (newtotal != total)
                        throw new Exception("Orders changed");
                    return res;
                }
                catch (Exception ex)
                {
                    if (ex is OperationCanceledException)
                        throw;
                    if (tentativo == tentativi)
                        throw;
                    Thread.Sleep(100);
                }
                finally
                {
                    ordersLock.Release();
                }
            }
            return null;
        }




    }
}