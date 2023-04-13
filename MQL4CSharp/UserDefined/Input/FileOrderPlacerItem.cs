using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQL4CSharp.UserDefined.Input
{
    public class FileOrderPlacerItem
    {
        public int? ticket
        {
            get => string.IsNullOrEmpty(mt4state) ? (int?)null : Convert.ToInt32(mt4state);
            set => mt4state = value.ToString();
        }

        public string externalid { get; set; }
        public string mt4state { get; set; }
        public string type { get; set; }
        public DateTime openDate { get; set; }
        public string symbol { get; set; }
        public double size { get; set; }
        public double openPrice { get; set; }
        public double? sl { get; set; }
        public double? tp { get; set; }
        public DateTime? closeDate { get; set; }
        public double? closePrice { get; set; }
        public DateTime? insertDate { get; set; }
    }
}
