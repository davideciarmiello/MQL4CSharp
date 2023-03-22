using Grapevine.Interfaces.Server;
using MQL4CSharp.Base.Exceptions;
using MQL4CSharp.Base.MQL;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grapevine.Shared;
using Newtonsoft.Json;
using MQL4CSharp.Base.Enums;
using System.Threading;
using System.IO;

namespace MQL4CSharp.Base.REST
{
    public abstract class MQLRESTBase
    {

        int DEFAULT_CHART_ID = 0;


        protected virtual long GetChartId(IHttpContext context)
        {
            long chartid = long.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            return chartid;
        }
        protected virtual IHttpContext SendJsonResponse(IHttpContext context, Func<MQLRestContext, Task<JObject>> getter)
        {
            return SendJsonResponse(context, DEFAULT_CHART_ID, getter);
        }
        protected virtual IHttpContext SendJsonResponse(IHttpContext context, long chartId, Func<MQLRestContext, Task<JObject>> getter)
        {
            var ctx = new MQLRestContext();
            try
            {
                ctx.Result = new JObject();
                ctx.CommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
                try
                {
                    if (context.Request.Payload != null)
                        ctx.JsonPayload = JObject.Parse(context.Request.Payload);
                }
                catch
                {
                }
                //nella versione legacy 4.2 non c'è la gestione dell'async su rest, allora avvio il task manualmente
                AsyncHelper.RunSyncWithNewThread(async () =>
                {
                    ctx.Result = await getter(ctx) ?? ctx.Result;
                });
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
                if (ctx.CommandToRemove)
                    try { GetCommandResult(ctx); }
                    catch {/**/}
            }
            var bytes = context.Request.ContentEncoding.GetBytes(ctx.Result.ToString(Formatting.Indented));
            context.Response.ContentType = ContentType.JSON;
            context.Response.ContentEncoding = Encoding.UTF8;
            context.Response.SendResponse(bytes);
            return context;
        }

        public void ParamAdd(MQLRestContext context, List<object> parameters, string paramName)
        {
            if (context.CommandParameters != parameters)
            {
                context.CommandParameters = parameters;
                context.CommandParametersNames = new List<string>();
            }
            context.CommandParametersNames.Add(paramName);
            object value = null;
            var jToken = context.JsonPayload[paramName];
            if (jToken != null)
            {
                var jValue = (jToken as JValue);
                value = jValue == null ? jToken.ToString() : jValue.Value;
            }
            parameters.Add(value);
        }
        public async Task<int> ExecCommandAsync(MQLRestContext context, MQLCommand command, List<object> parameters, int timeout = 30000)
        {
            var tsc = new TaskCompletionSource<object>();
            context.CommandToRemove = false;
            var id = context.CommandManager.ExecCommand(command, parameters ?? new List<object>(), tsc);
            context.CommandToRemove = true;
            context.CommandId = id;
            await TimeoutAfter(tsc.Task, TimeSpan.FromMilliseconds(timeout));
            context.CommandToRemove = false;
            context.CommandManager.throwExceptionIfErrorResponse(id);
            context.CommandToRemove = true;
            return id;
        }
        private static async Task<TResult> TimeoutAfter<TResult>(Task<TResult> task, TimeSpan timeout)
        {
            using (var timeoutCancellationTokenSource = new CancellationTokenSource())
            {
                var completedTask = await Task.WhenAny(task, Task.Delay(timeout, timeoutCancellationTokenSource.Token));
                if (completedTask == task)
                {
                    timeoutCancellationTokenSource.Cancel();
                    return await task;  // Very important in order to propagate exceptions
                }
                else
                {
                    throw new TimeoutException($"{nameof(TimeoutAfter)}: The operation has timed out after {timeout:mm\\:ss}");
                }
            }
        }
        public object GetCommandResult(MQLRestContext context)
        {
            var res = context.CommandManager.GetCommandResult(context.CommandId);
            context.CommandToRemove = false;
            return res;
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

        protected async Task SetFileNameInfoAsOutput(MQLRestContext context, string directory, string extension)
        {
            await SetFileNameFull(context, directory, extension);
            context.PayloadFileNameAsOutput = true;
        }

        protected async Task SetFileNameInfoAsInput(MQLRestContext context, string directory, string extension)
        {
            var payload = context.JsonPayload;
            byte[] fileContent = null;
            var fileContentBase64 = payload.Value<string>("filecontent");
            if (fileContentBase64 != null)
                fileContent = Convert.FromBase64String(fileContentBase64);
            if (fileContent == null)
            {
                var fileContentString = payload.Value<string>("filecontentstring") as string;
                if (fileContentString != null)
                    fileContent = Encoding.UTF8.GetBytes(fileContentString);
            }

            if (fileContent != null)
            {
                await SetFileNameFull(context, directory, extension);
                File.WriteAllBytes(context.PayloadFileNameFull, fileContent);
            }

            context.PayloadFileNameAsOutput = false;
        }

        protected async Task SetFileNameFull(MQLRestContext context, string directory, string fileExtension)
        {
            var payload = context.JsonPayload;
            var fileName = payload.Value<string>("filename") as string;
            var parameters = new List<object>();
            parameters.Add((int)TERMINAL_INFO_STRING.TERMINAL_DATA_PATH);
            await ExecCommandAsync(context, MQLCommand.TerminalInfoString_1, parameters);
            var dataPath = (string)GetCommandResult(context);
            if (string.IsNullOrEmpty(fileName))
            {
                payload["filename_todelete"] = true;
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
            var toDelete = context.JsonPayload.Value<bool?>("filename_todelete");
            if (toDelete != true)
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
        public bool CommandToRemove { get; set; }
    }
}
