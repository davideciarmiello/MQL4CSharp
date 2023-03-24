using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQL4CSharp.Base.MQL
{
    internal class CachedDataStorage
    {
        public ConcurrentDictionary<long, Mt4CharmModel> Charts { get; set; }
    }
    
    internal class Mt4CharmModel
    {
        public override string ToString()
        {
            return $"{Symbol} - EA: {EAName} ({(EAEnabled ? "Enabled" : "Disabled")})";
        }
        public long Id { get; set; }
        public string Symbol { get; set; }
        public string Period { get; set; }

        public bool EAEnabled { get; set; }
        public string EAName { get; set; }
        public string EASettings { get; set; }

    }
}
