using Grapevine.Interfaces.Server;
using MQL4CSharp.Base.Exceptions;
using MQL4CSharp.Base.MQL;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grapevine.Shared;
using Newtonsoft.Json;
using MQL4CSharp.Base.Enums;
using System.Threading;
using System.IO;
using System.Reflection;
using Grapevine.Server;
using MQL4CSharp.UserDefined.Strategy;
using MQL4CSharp.Util;

namespace MQL4CSharp.Base.REST
{
    public abstract class MQLRESTBase
    {

        public virtual void OnServerInit(RestServer server)
        {

        }

        public static ConcurrentDictionary<string, List<MethodInfo>> AddedRoutesMethods = new ConcurrentDictionary<string, List<MethodInfo>>();

        /// <summary>
        /// add routes to call directly methods of MQLBase
        /// </summary>
        /// <param name="server"></param>
        /// <param name="instanceGetter"></param>
        /// <param name="methods"></param>
        public virtual void AddRoutesFromStandardMethods(RestServer server, Func<MQLRestContext, object> instanceGetter, IEnumerable<MethodInfo> methods)
        {
            var routeAdded = new HashSet<string>(server.Router.RoutingTable.Select(x => x.PathInfo));
            foreach (var methodInfo in methods)
            {
                var methodName = methodInfo.Name;
                var pathInfo = $@"^/([0-9]+/)?(?i){methodInfo.Name.ToLowerInvariant()}$";
                var lstInfo = AddedRoutesMethods.GetOrAdd(pathInfo, s => new List<MethodInfo>());
                if (!lstInfo.Contains(methodInfo))
                    lstInfo.Add(methodInfo);
                if (!routeAdded.Add(pathInfo))
                    continue;
                var route = new Route(context =>
                {
                    return SendJsonResponse(context, GetChartId(context), restContext =>
                    {
                        var target = instanceGetter(restContext);
                        SetResultFromMethodName(restContext, target, methodName);
                        return restContext.Result;
                    });
                }, HttpMethod.POST, pathInfo);
                server.Router.Register(route);
            }
        }

        int DEFAULT_CHART_ID = 0;


        protected virtual long GetChartId(IHttpContext context)
        {
            var firstSegment = context.Request.Url.Segments[1].Trim('/');
            var chartid = firstSegment.All(char.IsDigit) ? long.Parse(firstSegment) : DEFAULT_CHART_ID;
            return chartid;
        }

        protected virtual void SetResultFromMethodName(MQLRestContext context, object target, string methodName)
        {
            var methods = MethodInfoExtended.GetByMethodName(target.GetType(), methodName);
            if (methods.Count > 1)
            {
                var matchmethods = methods.Where(x => x.ParametersForRestApi.All(p => HaveParam(context, p.Name))).ToList();
                if (matchmethods.Count != 1)
                {
                    var propertiesCount = context.JsonPayload?.Properties().Count();
                    matchmethods = methods.Where(x => propertiesCount > 0 && x.ParametersForRestApi.Length == propertiesCount).ToList();
                }
                if (matchmethods.Count != 1)
                    throw new Exception($"Found many methods {methods[0].Method.Name}. Pass all parameters to match correct method.\r\n"
                    + methods.Select((extended, i) => $"{i}: {GetMethodDescr(extended.Method)}").Join("\r\n"));
                methods = matchmethods;
            }
            var method = methods.Single();
            SetResultFromMethod(context, target, method);
        }
        protected virtual void SetResultFromMethod(MQLRestContext context, object target, MethodInfoExtended method)
        {
            var parameters = new List<object>();
            if (method.ParametersForRestApi.Any(p => !HaveParam(context, p.Name)))
            {
                if (!TrySetParametersAsOrder(context, method))
                    throw new Exception($"Input paramters not valid. Method Info: {GetMethodDescr(method.Method)}.");
            }
            foreach (var methodParameter in method.Parameters)
                ParamAdd(context, parameters, methodParameter.Name, methodParameter.ParameterType);
            if (method.ParametersForRestApi.Any() && PayloadNotValid(context))
                return;
            var output = method.InvokeFast(target, parameters);
            output = (method.Method.ReturnType == typeof(void)) ? "" : output;
            if (output != null)
                output = ConvertValueToRest(method.Method.ReturnType, output);
            try
            {
                if (output is string || output is double || output is decimal || output is int || output is long || output is DateTime)
                    context.Result["result"] = new JValue(output);
                else
                    context.Result["result"] = JToken.FromObject(output);
            }
            catch (ArgumentException)
            {
                context.Result["result"] = JToken.FromObject(output);
            }
        }

        private static bool TrySetParametersAsOrder(MQLRestContext context, MethodInfoExtended method)
        {
            var payload = context.JsonPayload ?? new JObject();
            var properties = payload.Properties().ToList();
            if (properties.Count != method.ParametersForRestApi.Length)
                return false;
            for (int i = 0; i < method.ParametersForRestApi.Length; i++)
                context.JsonPayload[method.ParametersForRestApi[i].Name] = properties[i].Value;
            return true;
        }

        protected string GetMethodDescr(MethodInfo method)
        {
            Func<Type, string> getParamType = type => type.IsEnum ? $"int32 (Enum {type.Name})" : type == typeof(byte[]) ? "string (base64)" : type.Name.ToLowerInvariant();
            var str = $"Input: {{ {method.GetParameters().Where(x => x.ParameterType != typeof(MQLRestContext)).Select(x => $"\"{x.Name}\": {getParamType(x.ParameterType)}").Join(", ")} }} - Result: {getParamType(method.ReturnType)}";
            return str;
        }

        public static ConcurrentDictionary<long, MQLBase> Expers = new ConcurrentDictionary<long, MQLBase>();
        public virtual MQLBase GetExpertByChartId(long chartId)
        {
            return Expers.GetOrAdd(chartId, l =>
            {
                try
                {
                    var expert = (MQLBase)DLLObjectWrapper.getInstance().getMQLExpert(chartId);
                    expert = (MQLBase)Activator.CreateInstance(expert.GetType(), l);
                    expert.ExecCommandTimeout = 30000;
                    return expert;
                }
                catch { /**/ }
                return new MQLRESTStrategy(l) { ExecCommandTimeout = 30000 };
            });
        }

        protected virtual IHttpContext SendJsonResponse(IHttpContext context, long chartId, Func<MQLRestContext, JObject> getter)
        {
            var ctx = new MQLRestContext() { RestServerContext = context };
            try
            {
                ctx.Result = new JObject();
                ctx.ChartId = chartId;
                ctx.CommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
                try
                {
                    if (context.Request.Payload != null)
                        ctx.JsonPayload = JObject.Parse(context.Request.Payload);
                }
                catch
                {
                }
                //nella versione legacy 4.2 non c'è la gestione dell'async su rest
                ctx.Result = getter(ctx) ?? ctx.Result;
            }
            catch (Exception e)
            {
                var msg = MQLExceptions.convertRESTException(e.ToString());
                if (ctx.CommandParametersNames?.Count > 0)
                    msg = msg.Replace(e.Message, $"{e.Message} - Parameters: {string.Join(", ", ctx.CommandParametersNames)}");
                ctx.Result["error"] = msg;
            }
            var bytes = context.Request.ContentEncoding.GetBytes(ctx.Result.ToString(Formatting.Indented));
            context.Response.ContentType = ContentType.JSON;
            context.Response.ContentEncoding = Encoding.UTF8;
            context.Response.SendResponse(bytes);
            return context;
        }

        public bool HaveParam(MQLRestContext context, string paramName)
        {
            var jToken = context.JsonPayload?[paramName];
            return jToken != null;
        }
        public void ParamAdd(MQLRestContext context, List<object> parameters, string paramName, Type paramType)
        {
            if (paramType == typeof(MQLRestContext))
            {
                parameters.Add(context);
                return;
            }
            if (context.CommandParameters != parameters)
            {
                context.CommandParameters = parameters;
                context.CommandParametersNames = new List<string>();
            }
            context.CommandParametersNames.Add(paramName);
            object value = null;
            var jToken = context.JsonPayload?[paramName];
            if (jToken != null)
            {
                var jValue = (jToken as JValue);
                value = jValue == null ? jToken.ToString() : jValue.Value;
                if (value != null)
                    value = ConvertValueFromRest(paramType, value);
            }
            parameters.Add(value);
        }

        private static object ConvertValueToRest(Type type, object output)
        {
            if (output != null && type.IsEnum)
                output = Convert.ToInt32(output);
            var bytes = output as byte[];
            if (output != null && bytes != null)
                output = Convert.ToBase64String(bytes);
            return output;
        }

        private static object ConvertValueFromRest(Type paramType, object value)
        {
            if (value != null && paramType.IsEnum)
            {
                try
                {
                    value = Enum.Parse(paramType, value.ToString());
                }
                catch
                {
                    value = Enum.ToObject(paramType, Convert.ToInt32(value));
                }
            }

            if (value != null && value.GetType() != paramType)
            {
                if (paramType == typeof(byte[]))
                    value = Convert.FromBase64String(value.ToString());
                else
                    value = Convert.ChangeType(value, paramType);
            }

            return value;
        }

        private String PARSE_ERROR = "JSON Parse Error. Check the input format";

        public bool PayloadNotValid(MQLRestContext context)
        {
            if (context.JsonPayload != null)
                return false;
            context.Result["result"] = PARSE_ERROR;
            context.Result["error"] = PARSE_ERROR;
            return true;
        }

    }

    public class MQLRestContext
    {
        public IHttpContext RestServerContext { get; set; }
        public long ChartId { get; set; }
        public JObject Result { get; set; }
        public MQLCommandManager CommandManager { get; set; }
        public List<string> CommandParametersNames { get; set; }
        public List<object> CommandParameters { get; set; }
        public JObject JsonPayload { get; set; }
    }
}
