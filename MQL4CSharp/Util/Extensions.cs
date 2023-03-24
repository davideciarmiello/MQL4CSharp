using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQL4CSharp.Util
{
    internal static class Extensions
    {
        public static T GetValueOrDefault<TKey, T>(this ConcurrentDictionary<TKey, T> dictionary, TKey key) //where T : class
        {
            T value;
            return dictionary.TryGetValue(key, out value) ? value : default(T);
        }
        public static string Join(this IEnumerable<string> source, string separator, string resultIfSourceEmpty = "")
        {
            if (resultIfSourceEmpty != "")
            {
                var sourceLst = source.ToList();
                return sourceLst.Count == 0 ? resultIfSourceEmpty : string.Join(separator, sourceLst);
            }
            return string.Join(separator, source);
        }
    }
}
