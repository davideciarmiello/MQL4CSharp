/*
Copyright 2016 Jason Separovic

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

using System.Web.Script.Serialization;
using MQL4CSharp.Base.MQL;
using Newtonsoft.Json;

namespace mql4sharp.helpers
{
    public static class JSONHelper
    {
        //public static string ToJSON(this object obj)
        //{
        //    JavaScriptSerializer serializer = new JavaScriptSerializer();
        //    return serializer.Serialize(obj);
        //}

        //public static string ToJSON(this object obj, int recursionDepth)
        //{
        //    JavaScriptSerializer serializer = new JavaScriptSerializer();
        //    serializer.RecursionLimit = recursionDepth;
        //    return serializer.Serialize(obj);
        //}




        #region Json

        public static string ToJson<T>(this T value, bool indented = false)
        {
            var settings = new JsonSerializerSettings { Formatting = indented ? Formatting.Indented : Formatting.None };
            var str = JsonConvert.SerializeObject(value, settings);
            return str;
        }

        public static T FromJson<T>(this string value)
        {
            var res = JsonConvert.DeserializeObject<T>(value);
            return res;
        }

        #endregion
    }
}
