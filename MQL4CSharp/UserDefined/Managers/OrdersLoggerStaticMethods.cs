using System.Collections.Concurrent;
using System.Runtime.InteropServices;
using MQL4CSharp.Util;
using mqlsharp.Util;
using RGiesecke.DllExport;

namespace MQL4CSharp.UserDefined.Managers
{
    public static class OrdersLoggerStaticMethods
    {
        internal static readonly ConcurrentDictionary<long, OrdersLogger> OrdersLoggerPerChart = new ConcurrentDictionary<long, OrdersLogger>();

        public static OrdersLogger GetOrdersLoggerInstance(long chartId, bool createIfNotExists = true)
        {
            var instance = createIfNotExists ? OrdersLoggerPerChart.GetOrAdd(chartId, l => new OrdersLogger(l))
                    : OrdersLoggerPerChart.GetValueOrDefault(chartId);
            return instance;
        }

        [DllExport("OrdersLoggerInit", CallingConvention = CallingConvention.StdCall)]
        public static void OrdersLoggerInit(long chartId, int accountNumber, [MarshalAs(UnmanagedType.LPWStr)] string reportFileName, int marketOpenHour
            , [MarshalAs(UnmanagedType.LPWStr)] string reportSheetNameTemplate
            , [MarshalAs(UnmanagedType.LPWStr)] string reportSheetNameFilters
            , [MarshalAs(UnmanagedType.LPWStr)] string magicMapping
        )
        {
            var instance = GetOrdersLoggerInstance(chartId);
            instance.Init(accountNumber, reportFileName, marketOpenHour, reportSheetNameTemplate, reportSheetNameFilters, magicMapping);
        }

        [DllExport("OrdersLoggerDeInit", CallingConvention = CallingConvention.StdCall)]
        public static void OrdersLoggerDeInit(long chartId)
        {
            var instance = OrdersLoggerPerChart.GetValueOrDefault(chartId);
            instance?.Dispose();
            OrdersLoggerPerChart.TryRemove(chartId, out instance);
        }

        [DllExport("OrdersLoggerSetCurrentInfo", CallingConvention = CallingConvention.StdCall)]
        public static void OrdersLoggerSetCurrentInfo(long chartId, long timeCurrent, double accountEquity, double accountBalance)
        {
            var instance = GetOrdersLoggerInstance(chartId);
            instance.SetCurrentInfo(DateUtil.FromUnixTime(timeCurrent), accountEquity, accountBalance);
        }


        [DllExport("OrdersLoggerSetOrdersHistoryTotal", CallingConvention = CallingConvention.StdCall)]
        public static bool OrdersLoggerSetOrdersHistoryTotal(long chartId, int count)
        {
            var instance = GetOrdersLoggerInstance(chartId);
            return instance.OrdersHistoryFiller.SetOrdersTotal(count);
        }

        [DllExport("OrdersLoggerSetOrdersHistoryDef", CallingConvention = CallingConvention.StdCall)]
        public static void OrdersLoggerSetOrdersHistoryDef(long chartId, int orderIndex, [MarshalAs(UnmanagedType.LPWStr)] string orderDef)
        {
            var instance = GetOrdersLoggerInstance(chartId);
            instance.OrdersHistoryFiller.SetOrderDef(orderIndex, orderDef);
        }

        [DllExport("OrdersLoggerSetOrdersTotal", CallingConvention = CallingConvention.StdCall)]
        public static bool OrdersLoggerSetOrdersTotal(long chartId, int count)
        {
            var instance = GetOrdersLoggerInstance(chartId);
            return instance.OrdersTradeFiller.SetOrdersTotal(count);
        }

        [DllExport("OrdersLoggerSetOrdersDef", CallingConvention = CallingConvention.StdCall)]
        public static void OrdersLoggerSetOrdersDef(long chartId, int orderIndex, [MarshalAs(UnmanagedType.LPWStr)] string orderDef)
        {
            var instance = GetOrdersLoggerInstance(chartId);
            instance.OrdersTradeFiller.SetOrderDef(orderIndex, orderDef);
        }
    }
}