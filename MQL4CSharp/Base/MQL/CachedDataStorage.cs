using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MQL4CSharp.Base.MQL
{
    public static class CachedDataStorageInstance
    {
        public static string TerminalDataPath { get; set; }

        public static string GetTerminalDataPath()
        {
            if (!string.IsNullOrEmpty(TerminalDataPath))
                return TerminalDataPath;
            var assembly = new FileInfo(Assembly.GetAssembly(typeof(CachedDataStorageInstance)).Location);
            if (assembly.Directory?.Name == "Libraries" && assembly.Directory.Parent?.Name == "MQL4")
            {
                var dir = assembly.Directory.Parent.Parent?.FullName;
                if (!string.IsNullOrEmpty(dir))
                    return dir;
            }
            throw new Exception("TerminalDataPath not defined");
        }

        private static string _cacheStorageFileName;
        private static DateTime? _cacheStorageWriteDate;
        private static CachedDataStorage _cacheStorage;
        private static string _cacheStorageText;
        public static CachedDataStorage GetCacheStorage()
        {
            if (string.IsNullOrEmpty(_cacheStorageFileName))
                _cacheStorageFileName = Path.Combine(GetTerminalDataPath(), "history", "mql4csharp.json");
            if (_cacheStorage == null && !File.Exists(_cacheStorageFileName))
            {
                _cacheStorage = new CachedDataStorage();
                CacheStorageWrite();
            }
            var lastWrite = File.GetLastWriteTime(_cacheStorageFileName);
            if (_cacheStorage == null || lastWrite > _cacheStorageWriteDate)
            {
                _cacheStorageText = File.ReadAllText(_cacheStorageFileName);
                _cacheStorage = JsonConvert.DeserializeObject<CachedDataStorage>(_cacheStorageText);
                _cacheStorageWriteDate = lastWrite;
            }
            return _cacheStorage;
        }
        private static object _lockObj = new object();
        public static void CacheStorageWrite()
        {
            if (_cacheStorage == null)
                return;
            var settings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            var data = JsonConvert.SerializeObject(_cacheStorage, settings);
            lock (_lockObj)
            {
                if (data == _cacheStorageText)
                    return;
                File.WriteAllText(_cacheStorageFileName, data);
                _cacheStorageText = data;
                _cacheStorageWriteDate = File.GetLastWriteTime(_cacheStorageFileName);
            }
        }
    }

    public class CachedDataStorage
    {
        public int? AccountNumber { get; set; }
        public string AccountName { get; set; }
        public string AccountServer { get; set; }
        public string TerminalPath { get; set; }
        public int? TerminalPID { get; set; }
        public string ApiUrl { get; set; }
        public ConcurrentDictionary<long, Mt4CharmModel> Charts { get; set; }
    }

    public class Mt4CharmModel
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
