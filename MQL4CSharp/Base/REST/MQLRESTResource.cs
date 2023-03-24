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
            var allmethods = AddedRoutesMethods.OrderBy(x => x.Key)
                .SelectMany(pair => pair.Value, (pair, info) =>
                {
                    var comment = info.GetXmlDocsSummary();
                    return $"Api Url: {pair.Key}\r\n{(string.IsNullOrEmpty(comment) ? comment : comment + "\r\n")}{GetMethodDescr(info)}";
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
        }


    }
}