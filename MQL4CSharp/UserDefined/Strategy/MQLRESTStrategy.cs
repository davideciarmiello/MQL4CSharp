using MQL4CSharp.Base.MQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MQL4CSharp.Util;

namespace MQL4CSharp.UserDefined.Strategy
{
    /// <summary>
    /// Attach this one to your chart just to enable the REST API.
    /// It does nothing, but every MQLExpert has a REST endpoint
    /// </summary>
    public class MQLRESTStrategy : Base.MQLBaseExtended
    {
        public MQLRESTStrategy(long ix) : base(ix)
        {
        }

        public override void OnInit()
        {
        }

        public override void OnDeinit()
        {
            RestServerHelper.RestServerStop(ix);
        }

        private bool _storageInfoInizialized;
        public override void OnTick()
        {
            if (_storageInfoInizialized)
                return;
            _storageInfoInizialized = true;
            InitStorageInfo();
            try
            {
                var s = RestServerHelper.Instances.GetValueOrDefault(ix);
                if (s?.IsListening == true)
                {
                    var address = (s.UseHttps ? "https" : "http") + "://" + (string.IsNullOrEmpty(s.Host) ? "127.0.0.1" : s.Host);
                    if (!string.IsNullOrEmpty(s.Port) && s.Port != (s.UseHttps ? "443" : "80"))
                        address += $":{s.Port}";
                    var storage = CachedDataStorageInstance.GetCacheStorage();
                    if (storage.ApiUrl != address)
                    {
                        storage.ApiUrl = address;
                        CachedDataStorageInstance.CacheStorageWrite();
                    }
                }
            }
            catch { /**/ }
        }

        public override void OnTimer()
        {
        }
    }
}
