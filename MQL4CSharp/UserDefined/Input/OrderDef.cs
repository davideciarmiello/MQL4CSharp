using System;
using System.Linq;
using MQL4CSharp.Util;
using mqlsharp.Util;
using MQL4CSharp.Base.Enums;

namespace MQL4CSharp.UserDefined.Input
{
    public class OrderDef
    {
        public int ticket { get; set; }           // for existing orders/positions, the local ticket number of the order/position
        //public string positionId { get; set; }       // the external position ID, from the sender
        public TRADE_OPERATION type { get; set; }             // type of order/position, using the MT4 values: 0=buy, 1=sell, 2=buy-limit, 3=sell-limit, 4=buy-stop, 5=sell-stop
        public string symbol { get; set; }
        public double volume { get; set; }           // For the sender's order, the *NOTIONAL VOLUME*: lots x contract size. For receiver orders, the local lot size.
        public double openprice { get; set; }
        public double closeprice { get; set; }         // As in MT4&5: current/close price. Opposite side of spread for market orders; same side of spread for pending orders
        public DateTime opentime { get; set; }
        public DateTime? closetime { get; set; }
        //public long? closetimevalue { get; set; }
        public double sl { get; set; }
        public double tp { get; set; }
        public double profit { get; set; }
        public double swap { get; set; }
        public double commission { get; set; }
        public string comment { get; set; }          // DO NOT ALTER unless you also turn on UseOriginalOrderComments or UseCustomOrderComment (and then override the comment here). This can orphan positions, and make the copier close them because they cannot be reconciled against the sender's heartbeat
        public int magic { get; set; }

        public DateTime updateDate { get; set; }

        private string _lastStrDef;
        private bool _readonly;
        // Deserialization of a string into an OrderDef
        public static OrderDef ConvertStringToOrderDef(string strDef, Func<int, OrderDef> instanceCreator = null, Func<DateTime> dateNowGetter = null)
        {
            //formato esempio: "TICKET\u0002100374899\u0001POSITIONID\u0002\u0001SYMBOL\u0002AUDCAD.r";
            var keyValues = strDef.SplitAsKeyValuePairs("\u0001", "\u0002").ToList();
            var ticket = keyValues.Where(x => x.Key == "TICKET").Take(1).Select(x => x.Value.ToIntNTry() ?? 0).FirstOrDefault();
            var instance = instanceCreator == null ? new OrderDef() : instanceCreator(ticket);
            if (instance == null || instance._readonly || instance._lastStrDef == strDef)
                return instance;
            foreach (var keyValue in keyValues)
                instance.SetKeyValue(keyValue.Key, keyValue.Value);
            if (instance.closetime.HasValue)
                instance._readonly = true;
            instance.updateDate = dateNowGetter?.Invoke() ?? DateTime.Now;
            instance._lastStrDef = strDef;
            return instance;
        }

        public virtual void SetKeyValue(string key, string value)
        {
            if (_readonly)
                return;
            switch (key)
            {
                case "TICKET":
                    ticket = Convert.ToInt32(value);
                    break;
                case "POSITIONID":
                    //positionId = value;
                    break;
                case "SYMBOL":
                    symbol = value;
                    break;
                case "TYPE":
                    type = (TRADE_OPERATION)Convert.ToInt32(value);
                    break;
                case "VOLUME":
                    volume = StringToDouble(value);
                    break;
                case "OPENPRICE":
                    openprice = StringToDouble(value);
                    break;
                case "SL":
                    sl = StringToDouble(value);
                    break;
                case "TP":
                    tp = StringToDouble(value);
                    break;
                case "CLOSEPRICE":
                    closeprice = StringToDouble(value);
                    break;
                case "OPENTIME":
                    opentime = DateUtil.FromUnixTime(Convert.ToInt64(value));
                    break;
                case "CLOSETIME":
                {
                    var valuelong = string.IsNullOrEmpty(value) ? 0 : Convert.ToInt64(value);
                    //closetimevalue = valuelong;
                    closetime = valuelong > 0 ? DateUtil.FromUnixTime(valuelong) : (DateTime?)null;
                    break;
                }
                case "COMMENT":
                    comment = value;
                    break;
                case "MAGIC":
                    magic = (int)Convert.ToInt32(value);
                    break;
                case "PROFIT":
                    profit = StringToDouble(value);
                    break;
                case "SWAP":
                    swap = StringToDouble(value);
                    break;
                case "COMMISSION":
                    commission = StringToDouble(value);
                    break;
            }
        }
        private static double StringToDouble(string text)
        {
            if (string.IsNullOrEmpty(text))
                return 0;
            var value = double.Parse(text, Extensions.Decimali99SeparatorePuntoMigliaiaVirgola);
            return value;
        }


    }
}
