using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQL4CSharp.Util
{
    internal static class Extensions
    {
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
