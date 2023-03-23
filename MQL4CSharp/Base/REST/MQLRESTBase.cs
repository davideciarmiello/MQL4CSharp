using Grapevine.Interfaces.Server;
using MQL4CSharp.Base.Exceptions;
using MQL4CSharp.Base.MQL;
using Newtonsoft.Json.Linq;
using System;
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
                var matchmethods = methods.Where(x => x.Parameters.All(p => HaveParam(context, p.Name))).ToList();
                if (matchmethods.Count != 1)
                {
                    var propertiesCount = context.JsonPayload?.Properties().Count();
                    matchmethods = methods.Where(x => propertiesCount > 0 && x.Parameters.Length == propertiesCount).ToList();
                }
                if (matchmethods.Count != 1)
                    throw new Exception($"Found many methods {methods[0].Method.Name}. Pass all parameters to match correct method.\r\n"
                    + methods.Select((extended, i) => $"{i}: {GetMethodDescr(extended)}").Join("\r\n"));
                methods = matchmethods;
            }
            var method = methods.Single();
            SetResultFromMethod(context, target, method);
        }
        protected virtual void SetResultFromMethod(MQLRestContext context, object target, MethodInfoExtended method)
        {
            var parameters = new List<object>();
            if (method.Parameters.Any(p => !HaveParam(context, p.Name)))
            {
                if (!TrySetParametersAsOrder(context, method))
                    throw new Exception($"Input paramters not valid. Method Info: {GetMethodDescr(method)}.");
            }
            foreach (var methodParameter in method.Parameters)
                ParamAdd(context, parameters, methodParameter.Name, methodParameter.ParameterType);
            if (parameters.Any() && PayloadNotValid(context))
                return;
            var output = method.InvokeFast(target, parameters);
            output = (method.Method.ReturnType == typeof(void)) ? "" : output;
            context.Result["result"] = new JValue(output);
        }

        private static bool TrySetParametersAsOrder(MQLRestContext context, MethodInfoExtended method)
        {
            var payload = context.JsonPayload ?? new JObject();
            var properties = payload.Properties().ToList();
            if (properties.Count != method.Parameters.Length)
                return false;
            for (int i = 0; i < method.Parameters.Length; i++)
                context.JsonPayload[method.Parameters[i].Name] = properties[i].Value;
            return true;
        }

        private string GetMethodDescr(MethodInfoExtended method)
        {
            var str = $"{{ {method.Parameters.Select(x => $"\"{x.Name}\": {x.ParameterType.Name.ToLowerInvariant()}").Join(", ")} }}";
            return str;
        }

        protected virtual IHttpContext SendJsonResponse(IHttpContext context, long chartId, Func<MQLRestContext, JObject> getter)
        {
            var ctx = new MQLRestContext();
            try
            {
                ctx.Result = new JObject();
                ctx.CommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
                ctx.Strategy = new MQLRESTStrategy(chartId) { ExecCommandTimeout = 30000 };
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
            finally
            {
                EndFileNameProcess(ctx);
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
                    value = Convert.ChangeType(value, paramType);
            }
            parameters.Add(value);
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

        protected void SetFileNameInfoAsOutput(MQLRestContext context, string directory, string extension)
        {
            SetFileNameFull(context, directory, extension);
            context.PayloadFileNameAsOutput = true;
        }

        protected void SetFileNameInfoAsInput(MQLRestContext context, string directory, string extension)
        {
            var payload = context.JsonPayload ?? new JObject();
            byte[] fileContent = null;
            var fileContentBase64 = payload.Value<string>("filecontent");
            if (fileContentBase64 != null)
            {
                fileContent = Convert.FromBase64String(fileContentBase64);
                payload.Remove("filecontent");
            }
            if (fileContent == null)
            {
                var fileContentString = payload.Value<string>("filecontentstring") as string;
                if (fileContentString != null)
                {
                    payload.Remove("filecontentstring");
                    fileContent = Encoding.UTF8.GetBytes(fileContentString);
                }
            }

            if (fileContent != null)
            {
                SetFileNameFull(context, directory, extension);
                File.WriteAllBytes(context.PayloadFileNameFull, fileContent);
            }

            context.PayloadFileNameAsOutput = false;
        }

        protected void SetFileNameFull(MQLRestContext context, string directory, string fileExtension)
        {
            if (context.JsonPayload == null)
                context.JsonPayload = new JObject();
            var payload = context.JsonPayload;
            var fileName = payload.Value<string>("filename") as string;
            var dataPath = context.Strategy.TerminalInfoString((int)TERMINAL_INFO_STRING.TERMINAL_DATA_PATH);
            if (string.IsNullOrEmpty(fileName))
            {
                context.PayloadFileNameToDelete = true;
                fileName = $"tmp_{Guid.NewGuid().ToString().Replace("-", "")}";
            }
            var extsAllowed = fileExtension.Split(',');
            if (!extsAllowed.Any(x => fileName.EndsWith($".{x}")))
                fileName = $"{Path.GetFileNameWithoutExtension(fileName)}.{extsAllowed.First()}";
            payload["filename"] = fileName;
            var fileInfo = new FileInfo(Path.Combine(dataPath, directory, fileName));
            context.PayloadFileNameFull = fileInfo.FullName;
        }

        protected void EndFileNameProcess(MQLRestContext context)
        {
            if (context.PayloadFileNameFull == null)
                return;
            var res = context.Result.Value<bool?>("result");
            if (res == true && context.PayloadFileNameAsOutput)
            {
                var fileContent = File.ReadAllBytes(context.PayloadFileNameFull);
                context.Result["result_filecontent"] = Convert.ToBase64String(fileContent);
            }
            if (context.PayloadFileNameToDelete != true)
                return;
            var fileName = context.PayloadFileNameFull;
            if (context.PayloadFileNameAsOutput && FnDeleteFile(2, fileName))
                return;
            //l'eliminazione la faccio dopo 30 secondi, altrimenti ApplyTemplate non sempre funziona, elimina il file mentre lo sta caricando
            new Task(() =>
            {
                Thread.Sleep(TimeSpan.FromSeconds(30));
                FnDeleteFile(10, fileName);
            }).Start();
        }

        private bool FnDeleteFile(int tentativi, string fileName)
        {
            for (int i = 0; i < tentativi; i++)
            {
                try
                {
                    if (File.Exists(fileName))
                        File.Delete(fileName);
                    return true;
                }
                catch
                {
                    Thread.Sleep(50);
                }
            }

            return false;
        }
    }

    public class MQLRestContext
    {
        public JObject Result { get; set; }
        public IHttpRequest Request { get; set; }
        public MQLCommandManager CommandManager { get; set; }
        public int CommandId { get; set; }
        public List<string> CommandParametersNames { get; set; }
        public List<object> CommandParameters { get; set; }
        public JObject JsonPayload { get; set; }
        public string PayloadFileNameFull { get; set; }
        public bool PayloadFileNameAsOutput { get; set; }
        public bool PayloadFileNameToDelete { get; set; }
        public MQLRESTStrategy Strategy { get; set; }
    }
}
