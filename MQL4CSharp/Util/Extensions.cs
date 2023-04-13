using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
