using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MQL4CSharp.Util
{
    internal static class Extensions
    {
        public static decimal? ParseDecimalNFromJsStr(this string saldoText)
        {
            if (string.IsNullOrEmpty(saldoText) || saldoText.Trim() == "-")
                return null;
            return ParseDecimalFromJsStr(saldoText);
        }
        /// <summary>
        /// esegue parse di numero con . come separatore di decimali
        /// </summary>
        /// <param name="saldoText"></param>
        /// <returns></returns>
        public static decimal ParseDecimalFromJsStr(this string saldoText)
        {
            var value = decimal.Parse(saldoText, Decimali99SeparatorePuntoMigliaiaVirgola);
            return value;
        }

        public static readonly NumberFormatInfo Decimali99SeparatorePuntoMigliaiaVuoto = _GetNewNumberFormat(99, ".", "");
        public static readonly NumberFormatInfo Decimali99SeparatorePuntoMigliaiaVirgola = _GetNewNumberFormat(99, ".", ",");
        public static readonly NumberFormatInfo Decimali99SeparatoreVirgolaMigliaiaVuoto = _GetNewNumberFormat(99, ",", "");
        public static readonly NumberFormatInfo Decimali99SeparatoreVirgolaMigliaiaPunto = _GetNewNumberFormat(99, ",", ".");
        internal static NumberFormatInfo _GetNewNumberFormat(int numeroDecimali, string separatoreDecimali, string separatoreMigliaia)
        {
            var format = CultureInfo.InvariantCulture.NumberFormat.Clone() as NumberFormatInfo;
            format.NumberDecimalDigits = numeroDecimali;
            format.NumberDecimalSeparator = separatoreDecimali;
            format.NumberGroupSeparator = separatoreMigliaia;

            format.CurrencyDecimalDigits = numeroDecimali;
            format.CurrencyDecimalSeparator = separatoreDecimali;
            format.CurrencyGroupSeparator = separatoreMigliaia;

            return format;
        }

        public static int ToInt(this string str)
        {
            return Convert.ToInt32(str);
        }
        public static int? ToIntNTry(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return null;
            int v;
            if (int.TryParse(str, out v))
                return v;
            return null;
        }

        #region Dictionary
        public static T GetValueOrDefault<TKey, T>(this ConcurrentDictionary<TKey, T> dictionary, TKey key) //where T : class
        {
            T value;
            return dictionary.TryGetValue(key, out value) ? value : default(T);
        }
        public static ConcurrentDictionary<TKey, TValue> AsConcurrent<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
        {
            var res = dictionary as ConcurrentDictionary<TKey, TValue>;
            if (res != null)
                return res;
            var comparer = (dictionary as Dictionary<TKey, TValue>)?.Comparer;
            return comparer == null ? new ConcurrentDictionary<TKey, TValue>(dictionary) : new ConcurrentDictionary<TKey, TValue>(dictionary, comparer);
        }
        public static ConcurrentDictionary<TKey, TSource> ToConcurrentDictionary<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            return source.ToConcurrentDictionary(keySelector, x => x, (IEqualityComparer<TKey>)null);
        }
        public static ConcurrentDictionary<TKey, TElement> ToConcurrentDictionary<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
        {
            return source.ToConcurrentDictionary(keySelector, elementSelector, (IEqualityComparer<TKey>)null);
        }
        public static ConcurrentDictionary<TKey, TElement> ToConcurrentDictionary<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
        {
            var pairs = source.Select(i => new KeyValuePair<TKey, TElement>(keySelector(i), elementSelector(i)));
            return comparer == null ? new ConcurrentDictionary<TKey, TElement>(pairs) : new ConcurrentDictionary<TKey, TElement>(pairs, comparer);
        }

        #endregion

        public static string Join(this IEnumerable<string> source, string separator, string resultIfSourceEmpty = "")
        {
            if (resultIfSourceEmpty != "")
            {
                var sourceLst = source.ToList();
                return sourceLst.Count == 0 ? resultIfSourceEmpty : string.Join(separator, sourceLst);
            }
            return string.Join(separator, source);
        }

        public static IEnumerable<KeyValuePair<string, string>> SplitAsKeyValuePairs(this string str, string keySeparator = ",", string keyValueSeparator = "=")
        {
            var items = (str + "").Split(new[] { keySeparator }, StringSplitOptions.None)
                .Select(x => x.Split(new[] { keyValueSeparator }, 2, StringSplitOptions.None))
                .Where(x => x.Length == 2)
                .Select(x => new KeyValuePair<string, string>(x[0], x[1]))
                .ToList();
            return items;
        }

        public static string AsNullIfEmpty(this string str)
        {
            return string.IsNullOrEmpty(str) ? null : str;
        }
        public static bool IsInteger(this string str)
        {
            str = str?.Trim();
            return !string.IsNullOrEmpty(str) && str.All(char.IsDigit);
        }

        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            return source.DistinctBy(keySelector, null);
        }
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (keySelector == null) throw new ArgumentNullException("keySelector");
            var knownKeys = new HashSet<TKey>(comparer);
            foreach (var element in source)
            {
                if (knownKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }

        public static IEnumerable<Exception> GetWithAllInnerExceptions(this Exception ex)
        {
            if (ex == null)
                yield break;
            var hash = new HashSet<Exception>();
            yield return ex;
            hash.Add(ex);
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
                if (!hash.Add(ex))
                    yield break;
                yield return ex;
            }
        }

        const int ERROR_SHARING_VIOLATION = 32;
        const int ERROR_LOCK_VIOLATION = 33;
        private static bool IsFileLocked(Exception exception)
        {
            if ((exception.HResult & 0x0000FFFF) == ERROR_SHARING_VIOLATION)
                return true;
            int errorCode = Marshal.GetHRForException(exception) & ((1 << 16) - 1);
            return errorCode == ERROR_SHARING_VIOLATION || errorCode == ERROR_LOCK_VIOLATION;
        }
        public static bool IsFileLocked(this FileInfo file)
        {
            try
            {
                using (var stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                    if (stream != null) stream.Close();
            }
            catch (DirectoryNotFoundException)
            {
                return false;
            }
            catch (IOException ex)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                if (IsFileLocked(ex))
                {
                    return true;
                }
            }

            //file is not locked
            return false;
        }


        public static bool Match(this DateTime date, object value)
        {
            if (value == null)
                return false;
            var vdt = value as DateTime?;
            if (vdt != null)
            {
                return vdt == date;
            }

            var vdouble = value as double?;
            if (vdouble == null && (value is long || value is decimal || value is int))
                vdouble = Convert.ToDouble(value);
            if (vdouble != null)
            {
                var odata = date.ToOADate();
                return odata == vdouble.Value;
            }

            var vstr = value.ToString();
            if (vstr == date.ToString() || vstr == date.ToShortDateString() || vstr == date.ToLongTimeString())
                return true;
            return false;
        }
    }
}
