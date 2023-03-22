using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Grapevine;
using Grapevine.Interfaces.Server;
using Grapevine.Server;
using log4net;
using MQL4CSharp.Base.Enums;
using MQL4CSharp.Base.MQL;
using Newtonsoft.Json.Linq;
using MQL4CSharp.Base.Exceptions;
using Grapevine.Server.Attributes;
using Grapevine.Shared;
using Newtonsoft.Json;

namespace MQL4CSharp.Base.REST
{
    [RestResource]
    public sealed class MQLRESTResource : MQLRESTBase
    {
        private static readonly ILog LOG = LogManager.GetLogger(typeof(MQLRESTResource));

        /// <summary>
        /// <b>Function:</b> Alert<br>
        /// <b>Description:</b> Displays a message in a separate window.<br>
        /// <b>URL:</b> http://docs.mql4.com/common/alert.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>argument</b> :  </li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/alert$")]
        public IHttpContext Handle_Alert_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), Alert_1);
        }

        /// <summary>
        /// <b>Function:</b> Alert<br>
        /// <b>Description:</b> Displays a message in a separate window.<br>
        /// <b>URL:</b> http://docs.mql4.com/common/alert.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>argument</b> :  </li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/alert$")]
        public IHttpContext Handle_Alert_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, Alert_1);
        }

        private async Task<JObject> Alert_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "argument");
            await ExecCommandAsync(context, MQLCommand.Alert_1, parameters); // MQLCommand ENUM = 1

            result["result"] = "";

            return result;
        }
        /// <summary>
        /// <b>Function:</b> Comment<br>
        /// <b>Description:</b> This function outputs a comment defined by a user in the top left corner of a chart.<br>
        /// <b>URL:</b> http://docs.mql4.com/common/comment.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>argument</b> :  [in] Any values, separated by commas. To delimit output information into several lines, a line break symbol "\n" or "\r\n" is used. Number of parameters cannot exceed 64. Total length of the input comment (including invisible symbols) cannot exceed 2045 characters (excess symbols will be cut out during output).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/comment$")]
        public IHttpContext Handle_Comment_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), Comment_1);
        }

        /// <summary>
        /// <b>Function:</b> Comment<br>
        /// <b>Description:</b> This function outputs a comment defined by a user in the top left corner of a chart.<br>
        /// <b>URL:</b> http://docs.mql4.com/common/comment.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>argument</b> :  [in] Any values, separated by commas. To delimit output information into several lines, a line break symbol "\n" or "\r\n" is used. Number of parameters cannot exceed 64. Total length of the input comment (including invisible symbols) cannot exceed 2045 characters (excess symbols will be cut out during output).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/comment$")]
        public IHttpContext Handle_Comment_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, Comment_1);
        }

        private async Task<JObject> Comment_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "argument");
            await ExecCommandAsync(context, MQLCommand.Comment_1, parameters); // MQLCommand ENUM = 2

            result["result"] = "";

            return result;
        }
        /// <summary>
        /// <b>Function:</b> SendFTP<br>
        /// <b>Description:</b> Sends a file at the address, specified in the setting window of the "FTP" tab.<br>
        /// <b>URL:</b> http://docs.mql4.com/common/sendftp.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>filename</b> :  [in] Name of sent file.</li>
        /// <li><b>ftp_path</b> :  [in] FTP catalog. If a directory is not specified, directory described in settings is used.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/sendftp$")]
        public IHttpContext Handle_SendFTP_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), SendFTP_1);
        }

        /// <summary>
        /// <b>Function:</b> SendFTP<br>
        /// <b>Description:</b> Sends a file at the address, specified in the setting window of the "FTP" tab.<br>
        /// <b>URL:</b> http://docs.mql4.com/common/sendftp.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>filename</b> :  [in] Name of sent file.</li>
        /// <li><b>ftp_path</b> :  [in] FTP catalog. If a directory is not specified, directory described in settings is used.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/sendftp$")]
        public IHttpContext Handle_SendFTP_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, SendFTP_1);
        }

        private async Task<JObject> SendFTP_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "filename");
            ParamAdd(context, parameters, "ftp_path");
            await ExecCommandAsync(context, MQLCommand.SendFTP_1, parameters); // MQLCommand ENUM = 3

            result["result"] = (bool)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> SendNotification<br>
        /// <b>Description:</b> Sends push notifications to the mobile terminals, whose MetaQuotes IDs are specified in the "Notifications" tab.<br>
        /// <b>URL:</b> http://docs.mql4.com/common/sendnotification.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>text</b> :  [in] The text of the notification. The message length should not exceed 255 characters.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/sendnotification$")]
        public IHttpContext Handle_SendNotification_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), SendNotification_1);
        }

        /// <summary>
        /// <b>Function:</b> SendNotification<br>
        /// <b>Description:</b> Sends push notifications to the mobile terminals, whose MetaQuotes IDs are specified in the "Notifications" tab.<br>
        /// <b>URL:</b> http://docs.mql4.com/common/sendnotification.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>text</b> :  [in] The text of the notification. The message length should not exceed 255 characters.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/sendnotification$")]
        public IHttpContext Handle_SendNotification_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, SendNotification_1);
        }

        private async Task<JObject> SendNotification_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "text");
            await ExecCommandAsync(context, MQLCommand.SendNotification_1, parameters); // MQLCommand ENUM = 4

            result["result"] = (bool)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> SendMail<br>
        /// <b>Description:</b> Sends an email at the address specified in the settings window of the "Email" tab.<br>
        /// <b>URL:</b> http://docs.mql4.com/common/sendmail.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>subject</b> :  [in] Email header.</li>
        /// <li><b>some_text</b> :  [in] Email body.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/sendmail$")]
        public IHttpContext Handle_SendMail_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), SendMail_1);
        }

        /// <summary>
        /// <b>Function:</b> SendMail<br>
        /// <b>Description:</b> Sends an email at the address specified in the settings window of the "Email" tab.<br>
        /// <b>URL:</b> http://docs.mql4.com/common/sendmail.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>subject</b> :  [in] Email header.</li>
        /// <li><b>some_text</b> :  [in] Email body.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/sendmail$")]
        public IHttpContext Handle_SendMail_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, SendMail_1);
        }

        private async Task<JObject> SendMail_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "subject");
            ParamAdd(context, parameters, "some_text");
            await ExecCommandAsync(context, MQLCommand.SendMail_1, parameters); // MQLCommand ENUM = 5

            result["result"] = (bool)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> AccountInfoDouble<br>
        /// <b>Description:</b> Returns the value of the corresponding account property.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountinfodouble.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>property_id</b> :  [in] Identifier of the property. The value can be one of the values of .</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/accountinfodouble$")]
        public IHttpContext Handle_AccountInfoDouble_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), AccountInfoDouble_1);
        }

        /// <summary>
        /// <b>Function:</b> AccountInfoDouble<br>
        /// <b>Description:</b> Returns the value of the corresponding account property.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountinfodouble.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>property_id</b> :  [in] Identifier of the property. The value can be one of the values of .</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/accountinfodouble$")]
        public IHttpContext Handle_AccountInfoDouble_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, AccountInfoDouble_1);
        }

        private async Task<JObject> AccountInfoDouble_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "property_id");
            await ExecCommandAsync(context, MQLCommand.AccountInfoDouble_1, parameters); // MQLCommand ENUM = 6

            result["result"] = Convert.ToDecimal(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> AccountInfoInteger<br>
        /// <b>Description:</b> Returns the value of the properties of the account.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountinfointeger.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>property_id</b> :  [in] Identifier of the property. The value can be one of the values of .</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/accountinfointeger$")]
        public IHttpContext Handle_AccountInfoInteger_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), AccountInfoInteger_1);
        }

        /// <summary>
        /// <b>Function:</b> AccountInfoInteger<br>
        /// <b>Description:</b> Returns the value of the properties of the account.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountinfointeger.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>property_id</b> :  [in] Identifier of the property. The value can be one of the values of .</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/accountinfointeger$")]
        public IHttpContext Handle_AccountInfoInteger_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, AccountInfoInteger_1);
        }

        private async Task<JObject> AccountInfoInteger_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "property_id");
            await ExecCommandAsync(context, MQLCommand.AccountInfoInteger_1, parameters); // MQLCommand ENUM = 7

            result["result"] = Convert.ToInt64(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> AccountInfoString<br>
        /// <b>Description:</b> Returns the value of the corresponding account property.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountinfostring.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>property_id</b> :  [in] Identifier of the property. The value can be one of the values of .</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/accountinfostring$")]
        public IHttpContext Handle_AccountInfoString_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), AccountInfoString_1);
        }

        /// <summary>
        /// <b>Function:</b> AccountInfoString<br>
        /// <b>Description:</b> Returns the value of the corresponding account property.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountinfostring.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>property_id</b> :  [in] Identifier of the property. The value can be one of the values of .</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/accountinfostring$")]
        public IHttpContext Handle_AccountInfoString_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, AccountInfoString_1);
        }

        private async Task<JObject> AccountInfoString_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "property_id");
            await ExecCommandAsync(context, MQLCommand.AccountInfoString_1, parameters); // MQLCommand ENUM = 8

            result["result"] = (string)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> AccountBalance<br>
        /// <b>Description:</b> Returns balance value of the current account.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountbalance.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/accountbalance$")]
        public IHttpContext Handle_AccountBalance_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), AccountBalance_1);
        }

        /// <summary>
        /// <b>Function:</b> AccountBalance<br>
        /// <b>Description:</b> Returns balance value of the current account.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountbalance.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/accountbalance$")]
        public IHttpContext Handle_AccountBalance_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, AccountBalance_1);
        }

        private async Task<JObject> AccountBalance_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.AccountBalance_1, parameters); // MQLCommand ENUM = 9

            result["result"] = Convert.ToDecimal(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> AccountCredit<br>
        /// <b>Description:</b> Returns credit value of the current account.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountcredit.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/accountcredit$")]
        public IHttpContext Handle_AccountCredit_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), AccountCredit_1);
        }

        /// <summary>
        /// <b>Function:</b> AccountCredit<br>
        /// <b>Description:</b> Returns credit value of the current account.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountcredit.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/accountcredit$")]
        public IHttpContext Handle_AccountCredit_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, AccountCredit_1);
        }

        private async Task<JObject> AccountCredit_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.AccountCredit_1, parameters); // MQLCommand ENUM = 10

            result["result"] = Convert.ToDecimal(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> AccountCompany<br>
        /// <b>Description:</b> Returns the brokerage company name where the current account was registered.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountcompany.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/accountcompany$")]
        public IHttpContext Handle_AccountCompany_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), AccountCompany_1);
        }

        /// <summary>
        /// <b>Function:</b> AccountCompany<br>
        /// <b>Description:</b> Returns the brokerage company name where the current account was registered.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountcompany.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/accountcompany$")]
        public IHttpContext Handle_AccountCompany_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, AccountCompany_1);
        }

        private async Task<JObject> AccountCompany_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.AccountCompany_1, parameters); // MQLCommand ENUM = 11

            result["result"] = (string)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> AccountCurrency<br>
        /// <b>Description:</b> Returns currency name of the current account.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountcurrency.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/accountcurrency$")]
        public IHttpContext Handle_AccountCurrency_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), AccountCurrency_1);
        }

        /// <summary>
        /// <b>Function:</b> AccountCurrency<br>
        /// <b>Description:</b> Returns currency name of the current account.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountcurrency.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/accountcurrency$")]
        public IHttpContext Handle_AccountCurrency_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, AccountCurrency_1);
        }

        private async Task<JObject> AccountCurrency_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.AccountCurrency_1, parameters); // MQLCommand ENUM = 12

            result["result"] = (string)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> AccountEquity<br>
        /// <b>Description:</b> Returns equity value of the current account.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountequity.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/accountequity$")]
        public IHttpContext Handle_AccountEquity_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), AccountEquity_1);
        }

        /// <summary>
        /// <b>Function:</b> AccountEquity<br>
        /// <b>Description:</b> Returns equity value of the current account.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountequity.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/accountequity$")]
        public IHttpContext Handle_AccountEquity_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, AccountEquity_1);
        }

        private async Task<JObject> AccountEquity_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.AccountEquity_1, parameters); // MQLCommand ENUM = 13

            result["result"] = Convert.ToDecimal(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> AccountFreeMargin<br>
        /// <b>Description:</b> Returns free margin value of the current account.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountfreemargin.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/accountfreemargin$")]
        public IHttpContext Handle_AccountFreeMargin_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), AccountFreeMargin_1);
        }

        /// <summary>
        /// <b>Function:</b> AccountFreeMargin<br>
        /// <b>Description:</b> Returns free margin value of the current account.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountfreemargin.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/accountfreemargin$")]
        public IHttpContext Handle_AccountFreeMargin_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, AccountFreeMargin_1);
        }

        private async Task<JObject> AccountFreeMargin_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.AccountFreeMargin_1, parameters); // MQLCommand ENUM = 14

            result["result"] = Convert.ToDecimal(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> AccountFreeMarginCheck<br>
        /// <b>Description:</b> Returns free margin that remains after the specified order has been opened at the current price on the current account.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountfreemargincheck.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol for trading operation.</li>
        /// <li><b>cmd</b> :  [in] Operation type. It can be either OP_BUY or OP_SELL.</li>
        /// <li><b>volume</b> :  [in] Number of lots.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/accountfreemargincheck$")]
        public IHttpContext Handle_AccountFreeMarginCheck_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), AccountFreeMarginCheck_1);
        }

        /// <summary>
        /// <b>Function:</b> AccountFreeMarginCheck<br>
        /// <b>Description:</b> Returns free margin that remains after the specified order has been opened at the current price on the current account.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountfreemargincheck.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol for trading operation.</li>
        /// <li><b>cmd</b> :  [in] Operation type. It can be either OP_BUY or OP_SELL.</li>
        /// <li><b>volume</b> :  [in] Number of lots.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/accountfreemargincheck$")]
        public IHttpContext Handle_AccountFreeMarginCheck_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, AccountFreeMarginCheck_1);
        }

        private async Task<JObject> AccountFreeMarginCheck_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "symbol");
            ParamAdd(context, parameters, "cmd");
            ParamAdd(context, parameters, "volume");
            await ExecCommandAsync(context, MQLCommand.AccountFreeMarginCheck_1, parameters); // MQLCommand ENUM = 15

            result["result"] = Convert.ToDecimal(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> AccountFreeMarginMode<br>
        /// <b>Description:</b> Returns the calculation mode of free margin allowed to open orders on the current account.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountfreemarginmode.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/accountfreemarginmode$")]
        public IHttpContext Handle_AccountFreeMarginMode_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), AccountFreeMarginMode_1);
        }

        /// <summary>
        /// <b>Function:</b> AccountFreeMarginMode<br>
        /// <b>Description:</b> Returns the calculation mode of free margin allowed to open orders on the current account.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountfreemarginmode.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/accountfreemarginmode$")]
        public IHttpContext Handle_AccountFreeMarginMode_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, AccountFreeMarginMode_1);
        }

        private async Task<JObject> AccountFreeMarginMode_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.AccountFreeMarginMode_1, parameters); // MQLCommand ENUM = 16

            result["result"] = Convert.ToDecimal(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> AccountLeverage<br>
        /// <b>Description:</b> Returns leverage of the current account.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountleverage.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/accountleverage$")]
        public IHttpContext Handle_AccountLeverage_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), AccountLeverage_1);
        }

        /// <summary>
        /// <b>Function:</b> AccountLeverage<br>
        /// <b>Description:</b> Returns leverage of the current account.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountleverage.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/accountleverage$")]
        public IHttpContext Handle_AccountLeverage_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, AccountLeverage_1);
        }

        private async Task<JObject> AccountLeverage_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.AccountLeverage_1, parameters); // MQLCommand ENUM = 17

            result["result"] = Convert.ToInt32(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> AccountMargin<br>
        /// <b>Description:</b> Returns margin value of the current account.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountmargin.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/accountmargin$")]
        public IHttpContext Handle_AccountMargin_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), AccountMargin_1);
        }

        /// <summary>
        /// <b>Function:</b> AccountMargin<br>
        /// <b>Description:</b> Returns margin value of the current account.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountmargin.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/accountmargin$")]
        public IHttpContext Handle_AccountMargin_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, AccountMargin_1);
        }

        private async Task<JObject> AccountMargin_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.AccountMargin_1, parameters); // MQLCommand ENUM = 18

            result["result"] = Convert.ToDecimal(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> AccountName<br>
        /// <b>Description:</b> Returns the current account name.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountname.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/accountname$")]
        public IHttpContext Handle_AccountName_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), AccountName_1);
        }

        /// <summary>
        /// <b>Function:</b> AccountName<br>
        /// <b>Description:</b> Returns the current account name.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountname.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/accountname$")]
        public IHttpContext Handle_AccountName_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, AccountName_1);
        }

        private async Task<JObject> AccountName_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.AccountName_1, parameters); // MQLCommand ENUM = 19

            result["result"] = (string)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> AccountNumber<br>
        /// <b>Description:</b> Returns the current account number.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountnumber.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/accountnumber$")]
        public IHttpContext Handle_AccountNumber_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), AccountNumber_1);
        }

        /// <summary>
        /// <b>Function:</b> AccountNumber<br>
        /// <b>Description:</b> Returns the current account number.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountnumber.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/accountnumber$")]
        public IHttpContext Handle_AccountNumber_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, AccountNumber_1);
        }

        private async Task<JObject> AccountNumber_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.AccountNumber_1, parameters); // MQLCommand ENUM = 20

            result["result"] = Convert.ToInt32(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> AccountProfit<br>
        /// <b>Description:</b> Returns profit value of the current account.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountprofit.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/accountprofit$")]
        public IHttpContext Handle_AccountProfit_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), AccountProfit_1);
        }

        /// <summary>
        /// <b>Function:</b> AccountProfit<br>
        /// <b>Description:</b> Returns profit value of the current account.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountprofit.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/accountprofit$")]
        public IHttpContext Handle_AccountProfit_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, AccountProfit_1);
        }

        private async Task<JObject> AccountProfit_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.AccountProfit_1, parameters); // MQLCommand ENUM = 21

            result["result"] = Convert.ToDecimal(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> AccountServer<br>
        /// <b>Description:</b> Returns the connected server name.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountserver.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/accountserver$")]
        public IHttpContext Handle_AccountServer_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), AccountServer_1);
        }

        /// <summary>
        /// <b>Function:</b> AccountServer<br>
        /// <b>Description:</b> Returns the connected server name.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountserver.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/accountserver$")]
        public IHttpContext Handle_AccountServer_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, AccountServer_1);
        }

        private async Task<JObject> AccountServer_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.AccountServer_1, parameters); // MQLCommand ENUM = 22

            result["result"] = (string)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> AccountStopoutLevel<br>
        /// <b>Description:</b> Returns the value of the Stop Out level.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountstopoutlevel.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/accountstopoutlevel$")]
        public IHttpContext Handle_AccountStopoutLevel_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), AccountStopoutLevel_1);
        }

        /// <summary>
        /// <b>Function:</b> AccountStopoutLevel<br>
        /// <b>Description:</b> Returns the value of the Stop Out level.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountstopoutlevel.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/accountstopoutlevel$")]
        public IHttpContext Handle_AccountStopoutLevel_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, AccountStopoutLevel_1);
        }

        private async Task<JObject> AccountStopoutLevel_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.AccountStopoutLevel_1, parameters); // MQLCommand ENUM = 23

            result["result"] = Convert.ToInt32(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> AccountStopoutMode<br>
        /// <b>Description:</b> Returns the calculation mode for the Stop Out level.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountstopoutmode.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/accountstopoutmode$")]
        public IHttpContext Handle_AccountStopoutMode_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), AccountStopoutMode_1);
        }

        /// <summary>
        /// <b>Function:</b> AccountStopoutMode<br>
        /// <b>Description:</b> Returns the calculation mode for the Stop Out level.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountstopoutmode.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/accountstopoutmode$")]
        public IHttpContext Handle_AccountStopoutMode_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, AccountStopoutMode_1);
        }

        private async Task<JObject> AccountStopoutMode_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.AccountStopoutMode_1, parameters); // MQLCommand ENUM = 24

            result["result"] = Convert.ToInt32(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> GetLastError<br>
        /// <b>Description:</b> Returns the contents of the<br>
        /// <b>URL:</b> http://docs.mql4.com/check/getlasterror.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/getlasterror$")]
        public IHttpContext Handle_GetLastError_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), GetLastError_1);
        }

        /// <summary>
        /// <b>Function:</b> GetLastError<br>
        /// <b>Description:</b> Returns the contents of the<br>
        /// <b>URL:</b> http://docs.mql4.com/check/getlasterror.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/getlasterror$")]
        public IHttpContext Handle_GetLastError_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, GetLastError_1);
        }

        private async Task<JObject> GetLastError_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.GetLastError_1, parameters); // MQLCommand ENUM = 25

            result["result"] = Convert.ToInt32(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> IsStopped<br>
        /// <b>Description:</b> Checks the forced shutdown of an mql4 program.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/isstopped.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/isstopped$")]
        public IHttpContext Handle_IsStopped_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), IsStopped_1);
        }

        /// <summary>
        /// <b>Function:</b> IsStopped<br>
        /// <b>Description:</b> Checks the forced shutdown of an mql4 program.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/isstopped.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/isstopped$")]
        public IHttpContext Handle_IsStopped_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, IsStopped_1);
        }

        private async Task<JObject> IsStopped_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.IsStopped_1, parameters); // MQLCommand ENUM = 26

            result["result"] = (bool)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> UninitializeReason<br>
        /// <b>Description:</b> Returns the code of a<br>
        /// <b>URL:</b> http://docs.mql4.com/check/uninitializereason.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/uninitializereason$")]
        public IHttpContext Handle_UninitializeReason_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), UninitializeReason_1);
        }

        /// <summary>
        /// <b>Function:</b> UninitializeReason<br>
        /// <b>Description:</b> Returns the code of a<br>
        /// <b>URL:</b> http://docs.mql4.com/check/uninitializereason.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/uninitializereason$")]
        public IHttpContext Handle_UninitializeReason_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, UninitializeReason_1);
        }

        private async Task<JObject> UninitializeReason_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.UninitializeReason_1, parameters); // MQLCommand ENUM = 27

            result["result"] = Convert.ToInt32(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> MQLInfoInteger<br>
        /// <b>Description:</b> Returns the value of a corresponding property of a running mql4 program.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/mqlinfointeger.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>property_id</b> :  [in] Identifier of a property. Can be one of values of the enumeration.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/mqlinfointeger$")]
        public IHttpContext Handle_MQLInfoInteger_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), MQLInfoInteger_1);
        }

        /// <summary>
        /// <b>Function:</b> MQLInfoInteger<br>
        /// <b>Description:</b> Returns the value of a corresponding property of a running mql4 program.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/mqlinfointeger.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>property_id</b> :  [in] Identifier of a property. Can be one of values of the enumeration.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/mqlinfointeger$")]
        public IHttpContext Handle_MQLInfoInteger_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, MQLInfoInteger_1);
        }

        private async Task<JObject> MQLInfoInteger_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "property_id");
            await ExecCommandAsync(context, MQLCommand.MQLInfoInteger_1, parameters); // MQLCommand ENUM = 28

            result["result"] = Convert.ToInt32(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> MQLInfoString<br>
        /// <b>Description:</b> Returns the value of a corresponding property of a running MQL4 program.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/mqlinfostring.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>property_id</b> :  [in] Identifier of a property. Can be one of the enumeration.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/mqlinfostring$")]
        public IHttpContext Handle_MQLInfoString_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), MQLInfoString_1);
        }

        /// <summary>
        /// <b>Function:</b> MQLInfoString<br>
        /// <b>Description:</b> Returns the value of a corresponding property of a running MQL4 program.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/mqlinfostring.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>property_id</b> :  [in] Identifier of a property. Can be one of the enumeration.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/mqlinfostring$")]
        public IHttpContext Handle_MQLInfoString_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, MQLInfoString_1);
        }

        private async Task<JObject> MQLInfoString_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "property_id");
            await ExecCommandAsync(context, MQLCommand.MQLInfoString_1, parameters); // MQLCommand ENUM = 29

            result["result"] = (string)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> MQLSetInteger<br>
        /// <b>Description:</b> Sets the value of the<br>
        /// <b>URL:</b> http://docs.mql4.com/check/mqlsetinteger.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>property_id</b> :  [in] Identifier of a property. Only is supported, as other properties cannot be changed.</li>
        /// <li><b>property_value</b> :  [in] Value of property. Can be one of the .</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/mqlsetinteger$")]
        public IHttpContext Handle_MQLSetInteger_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), MQLSetInteger_1);
        }

        /// <summary>
        /// <b>Function:</b> MQLSetInteger<br>
        /// <b>Description:</b> Sets the value of the<br>
        /// <b>URL:</b> http://docs.mql4.com/check/mqlsetinteger.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>property_id</b> :  [in] Identifier of a property. Only is supported, as other properties cannot be changed.</li>
        /// <li><b>property_value</b> :  [in] Value of property. Can be one of the .</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/mqlsetinteger$")]
        public IHttpContext Handle_MQLSetInteger_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, MQLSetInteger_1);
        }

        private async Task<JObject> MQLSetInteger_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "property_id");
            ParamAdd(context, parameters, "property_value");
            await ExecCommandAsync(context, MQLCommand.MQLSetInteger_1, parameters); // MQLCommand ENUM = 30

            result["result"] = "";

            return result;
        }
        /// <summary>
        /// <b>Function:</b> TerminalInfoInteger<br>
        /// <b>Description:</b> Returns the value of a corresponding property of the mql4 program environment.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/terminalinfointeger.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>property_id</b> :  [in] Identifier of a property. Can be one of the values of the enumeration.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/terminalinfointeger$")]
        public IHttpContext Handle_TerminalInfoInteger_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), TerminalInfoInteger_1);
        }

        /// <summary>
        /// <b>Function:</b> TerminalInfoInteger<br>
        /// <b>Description:</b> Returns the value of a corresponding property of the mql4 program environment.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/terminalinfointeger.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>property_id</b> :  [in] Identifier of a property. Can be one of the values of the enumeration.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/terminalinfointeger$")]
        public IHttpContext Handle_TerminalInfoInteger_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, TerminalInfoInteger_1);
        }

        private async Task<JObject> TerminalInfoInteger_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "property_id");
            await ExecCommandAsync(context, MQLCommand.TerminalInfoInteger_1, parameters); // MQLCommand ENUM = 31

            result["result"] = Convert.ToInt32(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> TerminalInfoDouble<br>
        /// <b>Description:</b> Returns the value of a corresponding property of the mql4 program environment.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/terminalinfodouble.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>property_id</b> :  [in] Identifier of a property. Can be one of the values of the enumeration.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/terminalinfodouble$")]
        public IHttpContext Handle_TerminalInfoDouble_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), TerminalInfoDouble_1);
        }

        /// <summary>
        /// <b>Function:</b> TerminalInfoDouble<br>
        /// <b>Description:</b> Returns the value of a corresponding property of the mql4 program environment.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/terminalinfodouble.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>property_id</b> :  [in] Identifier of a property. Can be one of the values of the enumeration.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/terminalinfodouble$")]
        public IHttpContext Handle_TerminalInfoDouble_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, TerminalInfoDouble_1);
        }

        private async Task<JObject> TerminalInfoDouble_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "property_id");
            await ExecCommandAsync(context, MQLCommand.TerminalInfoDouble_1, parameters); // MQLCommand ENUM = 32

            result["result"] = Convert.ToDecimal(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> TerminalInfoString<br>
        /// <b>Description:</b> Returns the value of a corresponding property of the mql4 program environment. The property must be of string type.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/terminalinfostring.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>property_id</b> :  [in] Identifier of a property. Can be one of the values of the enumeration.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/terminalinfostring$")]
        public IHttpContext Handle_TerminalInfoString_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), TerminalInfoString_1);
        }

        /// <summary>
        /// <b>Function:</b> TerminalInfoString<br>
        /// <b>Description:</b> Returns the value of a corresponding property of the mql4 program environment. The property must be of string type.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/terminalinfostring.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>property_id</b> :  [in] Identifier of a property. Can be one of the values of the enumeration.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/terminalinfostring$")]
        public IHttpContext Handle_TerminalInfoString_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, TerminalInfoString_1);
        }

        private async Task<JObject> TerminalInfoString_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "property_id");
            await ExecCommandAsync(context, MQLCommand.TerminalInfoString_1, parameters); // MQLCommand ENUM = 33

            result["result"] = (string)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> Symbol<br>
        /// <b>Description:</b> Returns the name of a symbol of the current chart.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/symbol.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/symbol$")]
        public IHttpContext Handle_Symbol_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), Symbol_1);
        }

        /// <summary>
        /// <b>Function:</b> Symbol<br>
        /// <b>Description:</b> Returns the name of a symbol of the current chart.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/symbol.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/symbol$")]
        public IHttpContext Handle_Symbol_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, Symbol_1);
        }

        private async Task<JObject> Symbol_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.Symbol_1, parameters); // MQLCommand ENUM = 34

            result["result"] = (string)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> Period<br>
        /// <b>Description:</b> Returns the current chart timeframe.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/period.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/period$")]
        public IHttpContext Handle_Period_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), Period_1);
        }

        /// <summary>
        /// <b>Function:</b> Period<br>
        /// <b>Description:</b> Returns the current chart timeframe.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/period.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/period$")]
        public IHttpContext Handle_Period_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, Period_1);
        }

        private async Task<JObject> Period_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.Period_1, parameters); // MQLCommand ENUM = 35

            result["result"] = Convert.ToInt32(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> Digits<br>
        /// <b>Description:</b> Returns the number of decimal digits determining the accuracy of price of the current chart symbol.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/digits.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/digits$")]
        public IHttpContext Handle_Digits_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), Digits_1);
        }

        /// <summary>
        /// <b>Function:</b> Digits<br>
        /// <b>Description:</b> Returns the number of decimal digits determining the accuracy of price of the current chart symbol.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/digits.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/digits$")]
        public IHttpContext Handle_Digits_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, Digits_1);
        }

        private async Task<JObject> Digits_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.Digits_1, parameters); // MQLCommand ENUM = 36

            result["result"] = Convert.ToInt32(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> Point<br>
        /// <b>Description:</b> Returns the point size of the current symbol in the quote currency.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/point.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/point$")]
        public IHttpContext Handle_Point_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), Point_1);
        }

        /// <summary>
        /// <b>Function:</b> Point<br>
        /// <b>Description:</b> Returns the point size of the current symbol in the quote currency.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/point.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/point$")]
        public IHttpContext Handle_Point_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, Point_1);
        }

        private async Task<JObject> Point_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.Point_1, parameters); // MQLCommand ENUM = 37

            result["result"] = Convert.ToDecimal(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> IsConnected<br>
        /// <b>Description:</b> Checks connection between client terminal and server.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/isconnected.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/isconnected$")]
        public IHttpContext Handle_IsConnected_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), IsConnected_1);
        }

        /// <summary>
        /// <b>Function:</b> IsConnected<br>
        /// <b>Description:</b> Checks connection between client terminal and server.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/isconnected.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/isconnected$")]
        public IHttpContext Handle_IsConnected_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, IsConnected_1);
        }

        private async Task<JObject> IsConnected_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.IsConnected_1, parameters); // MQLCommand ENUM = 38

            result["result"] = (bool)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> IsDemo<br>
        /// <b>Description:</b> Checks if the Expert Advisor runs on a demo account.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/isdemo.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/isdemo$")]
        public IHttpContext Handle_IsDemo_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), IsDemo_1);
        }

        /// <summary>
        /// <b>Function:</b> IsDemo<br>
        /// <b>Description:</b> Checks if the Expert Advisor runs on a demo account.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/isdemo.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/isdemo$")]
        public IHttpContext Handle_IsDemo_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, IsDemo_1);
        }

        private async Task<JObject> IsDemo_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.IsDemo_1, parameters); // MQLCommand ENUM = 39

            result["result"] = (bool)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> IsDllsAllowed<br>
        /// <b>Description:</b> Checks if the DLL function call is allowed for the Expert Advisor.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/isdllsallowed.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/isdllsallowed$")]
        public IHttpContext Handle_IsDllsAllowed_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), IsDllsAllowed_1);
        }

        /// <summary>
        /// <b>Function:</b> IsDllsAllowed<br>
        /// <b>Description:</b> Checks if the DLL function call is allowed for the Expert Advisor.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/isdllsallowed.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/isdllsallowed$")]
        public IHttpContext Handle_IsDllsAllowed_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, IsDllsAllowed_1);
        }

        private async Task<JObject> IsDllsAllowed_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.IsDllsAllowed_1, parameters); // MQLCommand ENUM = 40

            result["result"] = (bool)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> IsExpertEnabled<br>
        /// <b>Description:</b> Checks if Expert Advisors are enabled for running.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/isexpertenabled.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/isexpertenabled$")]
        public IHttpContext Handle_IsExpertEnabled_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), IsExpertEnabled_1);
        }

        /// <summary>
        /// <b>Function:</b> IsExpertEnabled<br>
        /// <b>Description:</b> Checks if Expert Advisors are enabled for running.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/isexpertenabled.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/isexpertenabled$")]
        public IHttpContext Handle_IsExpertEnabled_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, IsExpertEnabled_1);
        }

        private async Task<JObject> IsExpertEnabled_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.IsExpertEnabled_1, parameters); // MQLCommand ENUM = 41

            result["result"] = (bool)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> IsLibrariesAllowed<br>
        /// <b>Description:</b> Checks if the Expert Advisor can call library function.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/islibrariesallowed.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/islibrariesallowed$")]
        public IHttpContext Handle_IsLibrariesAllowed_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), IsLibrariesAllowed_1);
        }

        /// <summary>
        /// <b>Function:</b> IsLibrariesAllowed<br>
        /// <b>Description:</b> Checks if the Expert Advisor can call library function.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/islibrariesallowed.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/islibrariesallowed$")]
        public IHttpContext Handle_IsLibrariesAllowed_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, IsLibrariesAllowed_1);
        }

        private async Task<JObject> IsLibrariesAllowed_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.IsLibrariesAllowed_1, parameters); // MQLCommand ENUM = 42

            result["result"] = (bool)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> IsOptimization<br>
        /// <b>Description:</b> Checks if Expert Advisor runs in the Strategy Tester optimization mode.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/isoptimization.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/isoptimization$")]
        public IHttpContext Handle_IsOptimization_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), IsOptimization_1);
        }

        /// <summary>
        /// <b>Function:</b> IsOptimization<br>
        /// <b>Description:</b> Checks if Expert Advisor runs in the Strategy Tester optimization mode.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/isoptimization.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/isoptimization$")]
        public IHttpContext Handle_IsOptimization_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, IsOptimization_1);
        }

        private async Task<JObject> IsOptimization_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.IsOptimization_1, parameters); // MQLCommand ENUM = 43

            result["result"] = (bool)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> IsTesting<br>
        /// <b>Description:</b> Checks<br>
        /// <b>URL:</b> http://docs.mql4.com/check/istesting.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/istesting$")]
        public IHttpContext Handle_IsTesting_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), IsTesting_1);
        }

        /// <summary>
        /// <b>Function:</b> IsTesting<br>
        /// <b>Description:</b> Checks<br>
        /// <b>URL:</b> http://docs.mql4.com/check/istesting.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/istesting$")]
        public IHttpContext Handle_IsTesting_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, IsTesting_1);
        }

        private async Task<JObject> IsTesting_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.IsTesting_1, parameters); // MQLCommand ENUM = 44

            result["result"] = (bool)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> IsTradeAllowed<br>
        /// <b>Description:</b> Checks<br>
        /// <b>URL:</b> http://docs.mql4.com/check/istradeallowed.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/istradeallowed$")]
        public IHttpContext Handle_IsTradeAllowed_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), IsTradeAllowed_1);
        }

        /// <summary>
        /// <b>Function:</b> IsTradeAllowed<br>
        /// <b>Description:</b> Checks<br>
        /// <b>URL:</b> http://docs.mql4.com/check/istradeallowed.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/istradeallowed$")]
        public IHttpContext Handle_IsTradeAllowed_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, IsTradeAllowed_1);
        }

        private async Task<JObject> IsTradeAllowed_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.IsTradeAllowed_1, parameters); // MQLCommand ENUM = 45

            result["result"] = (bool)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> IsTradeAllowed<br>
        /// <b>Description:</b> Checks<br>
        /// <b>URL:</b> http://docs.mql4.com/check/istradeallowed.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol.</li>
        /// <li><b>tested_time</b> :  [in] Time to check status.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/istradeallowed$")]
        public IHttpContext Handle_IsTradeAllowed_2(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), IsTradeAllowed_2);
        }

        /// <summary>
        /// <b>Function:</b> IsTradeAllowed<br>
        /// <b>Description:</b> Checks<br>
        /// <b>URL:</b> http://docs.mql4.com/check/istradeallowed.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol.</li>
        /// <li><b>tested_time</b> :  [in] Time to check status.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/istradeallowed$")]
        public IHttpContext Handle_IsTradeAllowed_2_Default(IHttpContext context)
        {
            return SendJsonResponse(context, IsTradeAllowed_2);
        }

        private async Task<JObject> IsTradeAllowed_2(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "symbol");
            ParamAdd(context, parameters, "tested_time");
            await ExecCommandAsync(context, MQLCommand.IsTradeAllowed_2, parameters); // MQLCommand ENUM = 45

            result["result"] = (bool)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> IsTradeContextBusy<br>
        /// <b>Description:</b> Returns the information about trade context.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/istradecontextbusy.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/istradecontextbusy$")]
        public IHttpContext Handle_IsTradeContextBusy_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), IsTradeContextBusy_1);
        }

        /// <summary>
        /// <b>Function:</b> IsTradeContextBusy<br>
        /// <b>Description:</b> Returns the information about trade context.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/istradecontextbusy.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/istradecontextbusy$")]
        public IHttpContext Handle_IsTradeContextBusy_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, IsTradeContextBusy_1);
        }

        private async Task<JObject> IsTradeContextBusy_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.IsTradeContextBusy_1, parameters); // MQLCommand ENUM = 46

            result["result"] = (bool)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> IsVisualMode<br>
        /// <b>Description:</b> Checks<br>
        /// <b>URL:</b> http://docs.mql4.com/check/isvisualmode.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/isvisualmode$")]
        public IHttpContext Handle_IsVisualMode_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), IsVisualMode_1);
        }

        /// <summary>
        /// <b>Function:</b> IsVisualMode<br>
        /// <b>Description:</b> Checks<br>
        /// <b>URL:</b> http://docs.mql4.com/check/isvisualmode.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/isvisualmode$")]
        public IHttpContext Handle_IsVisualMode_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, IsVisualMode_1);
        }

        private async Task<JObject> IsVisualMode_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.IsVisualMode_1, parameters); // MQLCommand ENUM = 47

            result["result"] = (bool)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> TerminalCompany<br>
        /// <b>Description:</b> Returns the name of company owning the client terminal.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/terminalcompany.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/terminalcompany$")]
        public IHttpContext Handle_TerminalCompany_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), TerminalCompany_1);
        }

        /// <summary>
        /// <b>Function:</b> TerminalCompany<br>
        /// <b>Description:</b> Returns the name of company owning the client terminal.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/terminalcompany.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/terminalcompany$")]
        public IHttpContext Handle_TerminalCompany_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, TerminalCompany_1);
        }

        private async Task<JObject> TerminalCompany_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.TerminalCompany_1, parameters); // MQLCommand ENUM = 48

            result["result"] = (string)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> TerminalName<br>
        /// <b>Description:</b> Returns client terminal name.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/terminalname.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/terminalname$")]
        public IHttpContext Handle_TerminalName_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), TerminalName_1);
        }

        /// <summary>
        /// <b>Function:</b> TerminalName<br>
        /// <b>Description:</b> Returns client terminal name.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/terminalname.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/terminalname$")]
        public IHttpContext Handle_TerminalName_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, TerminalName_1);
        }

        private async Task<JObject> TerminalName_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.TerminalName_1, parameters); // MQLCommand ENUM = 49

            result["result"] = (string)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> TerminalPath<br>
        /// <b>Description:</b> Returns the directory, from which the client terminal was launched.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/terminalpath.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/terminalpath$")]
        public IHttpContext Handle_TerminalPath_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), TerminalPath_1);
        }

        /// <summary>
        /// <b>Function:</b> TerminalPath<br>
        /// <b>Description:</b> Returns the directory, from which the client terminal was launched.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/terminalpath.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/terminalpath$")]
        public IHttpContext Handle_TerminalPath_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, TerminalPath_1);
        }

        private async Task<JObject> TerminalPath_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.TerminalPath_1, parameters); // MQLCommand ENUM = 50

            result["result"] = (string)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> MarketInfo<br>
        /// <b>Description:</b> Returns various data about securities listed in the "Market Watch" window.<br>
        /// <b>URL:</b> http://docs.mql4.com/marketinformation/marketinfo.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name.</li>
        /// <li><b>type</b> :  [in] Request of information to be returned. Can be any of values of request identifiers.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/marketinfo$")]
        public IHttpContext Handle_MarketInfo_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), MarketInfo_1);
        }

        /// <summary>
        /// <b>Function:</b> MarketInfo<br>
        /// <b>Description:</b> Returns various data about securities listed in the "Market Watch" window.<br>
        /// <b>URL:</b> http://docs.mql4.com/marketinformation/marketinfo.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name.</li>
        /// <li><b>type</b> :  [in] Request of information to be returned. Can be any of values of request identifiers.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/marketinfo$")]
        public IHttpContext Handle_MarketInfo_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, MarketInfo_1);
        }

        private async Task<JObject> MarketInfo_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "symbol");
            ParamAdd(context, parameters, "type");
            await ExecCommandAsync(context, MQLCommand.MarketInfo_1, parameters); // MQLCommand ENUM = 51

            result["result"] = Convert.ToDecimal(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> SymbolsTotal<br>
        /// <b>Description:</b> Returns the number of available (selected in Market Watch or all) symbols.<br>
        /// <b>URL:</b> http://docs.mql4.com/marketinformation/symbolstotal.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>selected</b> :  [in] Request mode. Can be true or false.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/symbolstotal$")]
        public IHttpContext Handle_SymbolsTotal_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), SymbolsTotal_1);
        }

        /// <summary>
        /// <b>Function:</b> SymbolsTotal<br>
        /// <b>Description:</b> Returns the number of available (selected in Market Watch or all) symbols.<br>
        /// <b>URL:</b> http://docs.mql4.com/marketinformation/symbolstotal.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>selected</b> :  [in] Request mode. Can be true or false.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/symbolstotal$")]
        public IHttpContext Handle_SymbolsTotal_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, SymbolsTotal_1);
        }

        private async Task<JObject> SymbolsTotal_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "selected");
            await ExecCommandAsync(context, MQLCommand.SymbolsTotal_1, parameters); // MQLCommand ENUM = 52

            result["result"] = Convert.ToInt32(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> SymbolName<br>
        /// <b>Description:</b> Returns the name of a symbol.<br>
        /// <b>URL:</b> http://docs.mql4.com/marketinformation/symbolname.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>pos</b> :  [in] Order number of a symbol.</li>
        /// <li><b>selected</b> :  [in] Request mode. If the value is true, the symbol is taken from the list of symbols selected in MarketWatch. If the value is false, the symbol is taken from the general list.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/symbolname$")]
        public IHttpContext Handle_SymbolName_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), SymbolName_1);
        }

        /// <summary>
        /// <b>Function:</b> SymbolName<br>
        /// <b>Description:</b> Returns the name of a symbol.<br>
        /// <b>URL:</b> http://docs.mql4.com/marketinformation/symbolname.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>pos</b> :  [in] Order number of a symbol.</li>
        /// <li><b>selected</b> :  [in] Request mode. If the value is true, the symbol is taken from the list of symbols selected in MarketWatch. If the value is false, the symbol is taken from the general list.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/symbolname$")]
        public IHttpContext Handle_SymbolName_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, SymbolName_1);
        }

        private async Task<JObject> SymbolName_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "pos");
            ParamAdd(context, parameters, "selected");
            await ExecCommandAsync(context, MQLCommand.SymbolName_1, parameters); // MQLCommand ENUM = 53

            result["result"] = (string)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> SymbolSelect<br>
        /// <b>Description:</b> Selects a symbol in the Market Watch window or removes a symbol from the window.<br>
        /// <b>URL:</b> http://docs.mql4.com/marketinformation/symbolselect.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>name</b> :  [in] Symbol name.</li>
        /// <li><b>select</b> :  [in] Switch. If the value is false, a symbol should be removed from MarketWatch, otherwise a symbol should be selected in this window. A symbol can't be removed if the symbol chart is open, or there are open orders for this symbol.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/symbolselect$")]
        public IHttpContext Handle_SymbolSelect_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), SymbolSelect_1);
        }

        /// <summary>
        /// <b>Function:</b> SymbolSelect<br>
        /// <b>Description:</b> Selects a symbol in the Market Watch window or removes a symbol from the window.<br>
        /// <b>URL:</b> http://docs.mql4.com/marketinformation/symbolselect.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>name</b> :  [in] Symbol name.</li>
        /// <li><b>select</b> :  [in] Switch. If the value is false, a symbol should be removed from MarketWatch, otherwise a symbol should be selected in this window. A symbol can't be removed if the symbol chart is open, or there are open orders for this symbol.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/symbolselect$")]
        public IHttpContext Handle_SymbolSelect_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, SymbolSelect_1);
        }

        private async Task<JObject> SymbolSelect_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "name");
            ParamAdd(context, parameters, "select");
            await ExecCommandAsync(context, MQLCommand.SymbolSelect_1, parameters); // MQLCommand ENUM = 54

            result["result"] = (bool)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> RefreshRates<br>
        /// <b>Description:</b> Refreshing of data in pre-defined variables and series arrays.<br>
        /// <b>URL:</b> http://docs.mql4.com/series/refreshrates.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/refreshrates$")]
        public IHttpContext Handle_RefreshRates_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), RefreshRates_1);
        }

        /// <summary>
        /// <b>Function:</b> RefreshRates<br>
        /// <b>Description:</b> Refreshing of data in pre-defined variables and series arrays.<br>
        /// <b>URL:</b> http://docs.mql4.com/series/refreshrates.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/refreshrates$")]
        public IHttpContext Handle_RefreshRates_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, RefreshRates_1);
        }

        private async Task<JObject> RefreshRates_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.RefreshRates_1, parameters); // MQLCommand ENUM = 55

            result["result"] = (bool)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> Bars<br>
        /// <b>Description:</b> Returns the number of bars count in the history for a specified symbol and period. There are 2 variants of functions calls.<br>
        /// <b>URL:</b> http://docs.mql4.com/series/barsfunction.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol_name</b> :  [in] Symbol name.</li>
        /// <li><b>timeframe</b> :  [in] Period.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/bars$")]
        public IHttpContext Handle_Bars_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), Bars_1);
        }

        /// <summary>
        /// <b>Function:</b> Bars<br>
        /// <b>Description:</b> Returns the number of bars count in the history for a specified symbol and period. There are 2 variants of functions calls.<br>
        /// <b>URL:</b> http://docs.mql4.com/series/barsfunction.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol_name</b> :  [in] Symbol name.</li>
        /// <li><b>timeframe</b> :  [in] Period.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/bars$")]
        public IHttpContext Handle_Bars_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, Bars_1);
        }

        private async Task<JObject> Bars_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "symbol_name");
            ParamAdd(context, parameters, "timeframe");
            await ExecCommandAsync(context, MQLCommand.Bars_1, parameters); // MQLCommand ENUM = 56

            result["result"] = Convert.ToInt32(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> Bars<br>
        /// <b>Description:</b> Returns the number of bars count in the history for a specified symbol and period. There are 2 variants of functions calls.<br>
        /// <b>URL:</b> http://docs.mql4.com/series/barsfunction.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol_name</b> :  [in] Symbol name.</li>
        /// <li><b>timeframe</b> :  [in] Period.</li>
        /// <li><b>start_time</b> :  [in] Bar time corresponding to the first element.</li>
        /// <li><b>stop_time</b> :  [in] Bar time corresponding to the last element.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/bars$")]
        public IHttpContext Handle_Bars_2(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), Bars_2);
        }

        /// <summary>
        /// <b>Function:</b> Bars<br>
        /// <b>Description:</b> Returns the number of bars count in the history for a specified symbol and period. There are 2 variants of functions calls.<br>
        /// <b>URL:</b> http://docs.mql4.com/series/barsfunction.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol_name</b> :  [in] Symbol name.</li>
        /// <li><b>timeframe</b> :  [in] Period.</li>
        /// <li><b>start_time</b> :  [in] Bar time corresponding to the first element.</li>
        /// <li><b>stop_time</b> :  [in] Bar time corresponding to the last element.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/bars$")]
        public IHttpContext Handle_Bars_2_Default(IHttpContext context)
        {
            return SendJsonResponse(context, Bars_2);
        }

        private async Task<JObject> Bars_2(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "symbol_name");
            ParamAdd(context, parameters, "timeframe");
            ParamAdd(context, parameters, "start_time");
            ParamAdd(context, parameters, "stop_time");
            await ExecCommandAsync(context, MQLCommand.Bars_2, parameters); // MQLCommand ENUM = 56

            result["result"] = Convert.ToInt32(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> iBars<br>
        /// <b>Description:</b> Returns the number of bars on the specified chart.<br>
        /// <b>URL:</b> http://docs.mql4.com/series/ibars.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol the data of which should be used to calculate indicator. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/ibars$")]
        public IHttpContext Handle_iBars_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), iBars_1);
        }

        /// <summary>
        /// <b>Function:</b> iBars<br>
        /// <b>Description:</b> Returns the number of bars on the specified chart.<br>
        /// <b>URL:</b> http://docs.mql4.com/series/ibars.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol the data of which should be used to calculate indicator. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/ibars$")]
        public IHttpContext Handle_iBars_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, iBars_1);
        }

        private async Task<JObject> iBars_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "symbol");
            ParamAdd(context, parameters, "timeframe");
            await ExecCommandAsync(context, MQLCommand.iBars_1, parameters); // MQLCommand ENUM = 57

            result["result"] = Convert.ToInt32(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> iBarShift<br>
        /// <b>Description:</b> Search for a bar by its time. The function returns the index of the bar which covers the specified time.<br>
        /// <b>URL:</b> http://docs.mql4.com/series/ibarshift.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>time</b> :  [in] Time value for searching.</li>
        /// <li><b>exact</b> :  [in] Return mode when the bar is not found (false - iBarShift returns the nearest, true - iBarShift returns -1).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/ibarshift$")]
        public IHttpContext Handle_iBarShift_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), iBarShift_1);
        }

        /// <summary>
        /// <b>Function:</b> iBarShift<br>
        /// <b>Description:</b> Search for a bar by its time. The function returns the index of the bar which covers the specified time.<br>
        /// <b>URL:</b> http://docs.mql4.com/series/ibarshift.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>time</b> :  [in] Time value for searching.</li>
        /// <li><b>exact</b> :  [in] Return mode when the bar is not found (false - iBarShift returns the nearest, true - iBarShift returns -1).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/ibarshift$")]
        public IHttpContext Handle_iBarShift_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, iBarShift_1);
        }

        private async Task<JObject> iBarShift_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "symbol");
            ParamAdd(context, parameters, "timeframe");
            ParamAdd(context, parameters, "time");
            ParamAdd(context, parameters, "exact");
            await ExecCommandAsync(context, MQLCommand.iBarShift_1, parameters); // MQLCommand ENUM = 58

            result["result"] = Convert.ToInt32(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> iClose<br>
        /// <b>Description:</b> Returns Close price value for the bar of specified symbol with timeframe and shift.<br>
        /// <b>URL:</b> http://docs.mql4.com/series/iclose.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/iclose$")]
        public IHttpContext Handle_iClose_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), iClose_1);
        }

        /// <summary>
        /// <b>Function:</b> iClose<br>
        /// <b>Description:</b> Returns Close price value for the bar of specified symbol with timeframe and shift.<br>
        /// <b>URL:</b> http://docs.mql4.com/series/iclose.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/iclose$")]
        public IHttpContext Handle_iClose_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, iClose_1);
        }

        private async Task<JObject> iClose_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "symbol");
            ParamAdd(context, parameters, "timeframe");
            ParamAdd(context, parameters, "shift");
            await ExecCommandAsync(context, MQLCommand.iClose_1, parameters); // MQLCommand ENUM = 59

            result["result"] = Convert.ToDecimal(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> iHigh<br>
        /// <b>Description:</b> Returns High price value for the bar of specified symbol with timeframe and shift.<br>
        /// <b>URL:</b> http://docs.mql4.com/series/ihigh.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/ihigh$")]
        public IHttpContext Handle_iHigh_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), iHigh_1);
        }

        /// <summary>
        /// <b>Function:</b> iHigh<br>
        /// <b>Description:</b> Returns High price value for the bar of specified symbol with timeframe and shift.<br>
        /// <b>URL:</b> http://docs.mql4.com/series/ihigh.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/ihigh$")]
        public IHttpContext Handle_iHigh_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, iHigh_1);
        }

        private async Task<JObject> iHigh_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "symbol");
            ParamAdd(context, parameters, "timeframe");
            ParamAdd(context, parameters, "shift");
            await ExecCommandAsync(context, MQLCommand.iHigh_1, parameters); // MQLCommand ENUM = 60

            result["result"] = Convert.ToDecimal(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> iHighest<br>
        /// <b>Description:</b> Returns the shift of the maximum value over a specific number of bars depending on type.<br>
        /// <b>URL:</b> http://docs.mql4.com/series/ihighest.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol the data of which should be used for search. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>type</b> :  [in] Series array identifier. It can be any of the enumeration values.</li>
        /// <li><b>count</b> :  [in] Number of bars (in direction from the start bar to the back one) on which the search is carried out.</li>
        /// <li><b>start</b> :  [in] Shift showing the bar, relative to the current bar, that the data should be taken from.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/ihighest$")]
        public IHttpContext Handle_iHighest_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), iHighest_1);
        }

        /// <summary>
        /// <b>Function:</b> iHighest<br>
        /// <b>Description:</b> Returns the shift of the maximum value over a specific number of bars depending on type.<br>
        /// <b>URL:</b> http://docs.mql4.com/series/ihighest.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol the data of which should be used for search. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>type</b> :  [in] Series array identifier. It can be any of the enumeration values.</li>
        /// <li><b>count</b> :  [in] Number of bars (in direction from the start bar to the back one) on which the search is carried out.</li>
        /// <li><b>start</b> :  [in] Shift showing the bar, relative to the current bar, that the data should be taken from.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/ihighest$")]
        public IHttpContext Handle_iHighest_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, iHighest_1);
        }

        private async Task<JObject> iHighest_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "symbol");
            ParamAdd(context, parameters, "timeframe");
            ParamAdd(context, parameters, "type");
            ParamAdd(context, parameters, "count");
            ParamAdd(context, parameters, "start");
            await ExecCommandAsync(context, MQLCommand.iHighest_1, parameters); // MQLCommand ENUM = 61

            result["result"] = Convert.ToInt32(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> iLow<br>
        /// <b>Description:</b> Returns Low price value for the bar of indicated symbol with timeframe and shift.<br>
        /// <b>URL:</b> http://docs.mql4.com/series/ilow.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/ilow$")]
        public IHttpContext Handle_iLow_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), iLow_1);
        }

        /// <summary>
        /// <b>Function:</b> iLow<br>
        /// <b>Description:</b> Returns Low price value for the bar of indicated symbol with timeframe and shift.<br>
        /// <b>URL:</b> http://docs.mql4.com/series/ilow.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/ilow$")]
        public IHttpContext Handle_iLow_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, iLow_1);
        }

        private async Task<JObject> iLow_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "symbol");
            ParamAdd(context, parameters, "timeframe");
            ParamAdd(context, parameters, "shift");
            await ExecCommandAsync(context, MQLCommand.iLow_1, parameters); // MQLCommand ENUM = 62

            result["result"] = Convert.ToDecimal(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> iLowest<br>
        /// <b>Description:</b> Returns the shift of the lowest value over a specific number of bars depending on type.<br>
        /// <b>URL:</b> http://docs.mql4.com/series/ilowest.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>type</b> :  [in] Series array identifier. It can be any of the enumeration values.</li>
        /// <li><b>count</b> :  [in] Number of bars (in direction from the start bar to the back one) on which the search is carried out.</li>
        /// <li><b>start</b> :  [in] Shift showing the bar, relative to the current bar, that the data should be taken from.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/ilowest$")]
        public IHttpContext Handle_iLowest_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), iLowest_1);
        }

        /// <summary>
        /// <b>Function:</b> iLowest<br>
        /// <b>Description:</b> Returns the shift of the lowest value over a specific number of bars depending on type.<br>
        /// <b>URL:</b> http://docs.mql4.com/series/ilowest.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>type</b> :  [in] Series array identifier. It can be any of the enumeration values.</li>
        /// <li><b>count</b> :  [in] Number of bars (in direction from the start bar to the back one) on which the search is carried out.</li>
        /// <li><b>start</b> :  [in] Shift showing the bar, relative to the current bar, that the data should be taken from.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/ilowest$")]
        public IHttpContext Handle_iLowest_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, iLowest_1);
        }

        private async Task<JObject> iLowest_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "symbol");
            ParamAdd(context, parameters, "timeframe");
            ParamAdd(context, parameters, "type");
            ParamAdd(context, parameters, "count");
            ParamAdd(context, parameters, "start");
            await ExecCommandAsync(context, MQLCommand.iLowest_1, parameters); // MQLCommand ENUM = 63

            result["result"] = Convert.ToInt32(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> iOpen<br>
        /// <b>Description:</b> Returns Open price value for the bar of specified symbol with timeframe and shift.<br>
        /// <b>URL:</b> http://docs.mql4.com/series/iopen.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/iopen$")]
        public IHttpContext Handle_iOpen_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), iOpen_1);
        }

        /// <summary>
        /// <b>Function:</b> iOpen<br>
        /// <b>Description:</b> Returns Open price value for the bar of specified symbol with timeframe and shift.<br>
        /// <b>URL:</b> http://docs.mql4.com/series/iopen.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/iopen$")]
        public IHttpContext Handle_iOpen_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, iOpen_1);
        }

        private async Task<JObject> iOpen_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "symbol");
            ParamAdd(context, parameters, "timeframe");
            ParamAdd(context, parameters, "shift");
            await ExecCommandAsync(context, MQLCommand.iOpen_1, parameters); // MQLCommand ENUM = 64

            result["result"] = Convert.ToDecimal(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> iTime<br>
        /// <b>Description:</b> Returns Time value for the bar of specified symbol with timeframe and shift.<br>
        /// <b>URL:</b> http://docs.mql4.com/series/itime.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/itime$")]
        public IHttpContext Handle_iTime_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), iTime_1);
        }

        /// <summary>
        /// <b>Function:</b> iTime<br>
        /// <b>Description:</b> Returns Time value for the bar of specified symbol with timeframe and shift.<br>
        /// <b>URL:</b> http://docs.mql4.com/series/itime.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/itime$")]
        public IHttpContext Handle_iTime_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, iTime_1);
        }

        private async Task<JObject> iTime_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "symbol");
            ParamAdd(context, parameters, "timeframe");
            ParamAdd(context, parameters, "shift");
            await ExecCommandAsync(context, MQLCommand.iTime_1, parameters); // MQLCommand ENUM = 65

            result["result"] = (DateTime)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> iVolume<br>
        /// <b>Description:</b> Returns Tick Volume value for the bar of specified symbol with timeframe and shift.<br>
        /// <b>URL:</b> http://docs.mql4.com/series/ivolume.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/ivolume$")]
        public IHttpContext Handle_iVolume_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), iVolume_1);
        }

        /// <summary>
        /// <b>Function:</b> iVolume<br>
        /// <b>Description:</b> Returns Tick Volume value for the bar of specified symbol with timeframe and shift.<br>
        /// <b>URL:</b> http://docs.mql4.com/series/ivolume.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/ivolume$")]
        public IHttpContext Handle_iVolume_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, iVolume_1);
        }

        private async Task<JObject> iVolume_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "symbol");
            ParamAdd(context, parameters, "timeframe");
            ParamAdd(context, parameters, "shift");
            await ExecCommandAsync(context, MQLCommand.iVolume_1, parameters); // MQLCommand ENUM = 66

            result["result"] = Convert.ToInt64(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> ChartApplyTemplate<br>
        /// <b>Description:</b> Applies a specific template from a specified file to the chart. The command is added to chart message queue and executed only after all previous commands have been processed.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartapplytemplate.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart ID. 0 means the current chart.</li>
        /// <li><b>filename</b> :  [in] The name of the file containing the template.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartapplytemplate$")]
        public IHttpContext Handle_ChartApplyTemplate_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), ChartApplyTemplate_1);
        }

        /// <summary>
        /// <b>Function:</b> ChartApplyTemplate<br>
        /// <b>Description:</b> Applies a specific template from a specified file to the chart. The command is added to chart message queue and executed only after all previous commands have been processed.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartapplytemplate.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart ID. 0 means the current chart.</li>
        /// <li><b>filename</b> :  [in] The name of the file containing the template.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/chartapplytemplate$")]
        public IHttpContext Handle_ChartApplyTemplate_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, ChartApplyTemplate_1);
        }

        private async Task<JObject> ChartApplyTemplate_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            await SetFileNameInfoAsInput(context, "templates", "tpl");
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "chart_id");
            ParamAdd(context, parameters, "filename");
            await ExecCommandAsync(context, MQLCommand.ChartApplyTemplate_1, parameters); // MQLCommand ENUM = 67

            result["result"] = (bool)GetCommandResult(context);

            return result;
        }




        /// <summary>
        /// <b>Function:</b> ChartSaveTemplate<br>
        /// <b>Description:</b> Saves current chart settings in a template with a specified name. The command is added to chart message queue and executed only after all previous commands have been processed.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartsavetemplate.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart ID. 0 means the current chart.</li>
        /// <li><b>filename</b> :  [in] The filename to save the template. The ".tpl" extension will be added to the filename automatically; there is no need to specify it. The template is saved in terminal_directory\Profiles\Templates\ and can be used for manual application in the terminal. If a template with the same filename already exists, the contents of this file will be overwritten.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartsavetemplate$")]
        public IHttpContext Handle_ChartSaveTemplate_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), ChartSaveTemplate_1);
        }

        /// <summary>
        /// <b>Function:</b> ChartSaveTemplate<br>
        /// <b>Description:</b> Saves current chart settings in a template with a specified name. The command is added to chart message queue and executed only after all previous commands have been processed.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartsavetemplate.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart ID. 0 means the current chart.</li>
        /// <li><b>filename</b> :  [in] The filename to save the template. The ".tpl" extension will be added to the filename automatically; there is no need to specify it. The template is saved in terminal_directory\Profiles\Templates\ and can be used for manual application in the terminal. If a template with the same filename already exists, the contents of this file will be overwritten.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/chartsavetemplate$")]
        public IHttpContext Handle_ChartSaveTemplate_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, ChartSaveTemplate_1);
        }

        private async Task<JObject> ChartSaveTemplate_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;

            await SetFileNameInfoAsOutput(context, "templates", "tpl");
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "chart_id");
            ParamAdd(context, parameters, "filename");
            await ExecCommandAsync(context, MQLCommand.ChartSaveTemplate_1, parameters); // MQLCommand ENUM = 68

            result["result"] = (bool)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> ChartWindowFind<br>
        /// <b>Description:</b> The function returns the number of a subwindow where an indicator is drawn. There are 2 variants of the function.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartwindowfind.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart ID. 0 denotes the current chart.</li>
        /// <li><b>indicator_shortname</b> :  [in] Short name of the indicator.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartwindowfind$")]
        public IHttpContext Handle_ChartWindowFind_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), ChartWindowFind_1);
        }

        /// <summary>
        /// <b>Function:</b> ChartWindowFind<br>
        /// <b>Description:</b> The function returns the number of a subwindow where an indicator is drawn. There are 2 variants of the function.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartwindowfind.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart ID. 0 denotes the current chart.</li>
        /// <li><b>indicator_shortname</b> :  [in] Short name of the indicator.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/chartwindowfind$")]
        public IHttpContext Handle_ChartWindowFind_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, ChartWindowFind_1);
        }

        private async Task<JObject> ChartWindowFind_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "chart_id");
            ParamAdd(context, parameters, "indicator_shortname");
            await ExecCommandAsync(context, MQLCommand.ChartWindowFind_1, parameters); // MQLCommand ENUM = 69

            result["result"] = Convert.ToInt32(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> ChartWindowFind<br>
        /// <b>Description:</b> The function returns the number of a subwindow where an indicator is drawn. There are 2 variants of the function.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartwindowfind.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartwindowfind$")]
        public IHttpContext Handle_ChartWindowFind_2(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), ChartWindowFind_2);
        }

        /// <summary>
        /// <b>Function:</b> ChartWindowFind<br>
        /// <b>Description:</b> The function returns the number of a subwindow where an indicator is drawn. There are 2 variants of the function.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartwindowfind.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/chartwindowfind$")]
        public IHttpContext Handle_ChartWindowFind_2_Default(IHttpContext context)
        {
            return SendJsonResponse(context, ChartWindowFind_2);
        }

        private async Task<JObject> ChartWindowFind_2(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.ChartWindowFind_2, parameters); // MQLCommand ENUM = 69

            result["result"] = Convert.ToInt32(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> ChartOpen<br>
        /// <b>Description:</b> Opens a new chart with the specified symbol and period. The command is added to chart message queue and executed only after all previous commands have been processed.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartopen.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Chart symbol. means the symbol of the current chart (the Expert Advisor is attached to).</li>
        /// <li><b>period</b> :  [in] Chart period (timeframe). Can be one of the values. 0 means the current chart period.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartopen$")]
        public IHttpContext Handle_ChartOpen_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), ChartOpen_1);
        }

        /// <summary>
        /// <b>Function:</b> ChartOpen<br>
        /// <b>Description:</b> Opens a new chart with the specified symbol and period. The command is added to chart message queue and executed only after all previous commands have been processed.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartopen.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Chart symbol. means the symbol of the current chart (the Expert Advisor is attached to).</li>
        /// <li><b>period</b> :  [in] Chart period (timeframe). Can be one of the values. 0 means the current chart period.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/chartopen$")]
        public IHttpContext Handle_ChartOpen_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, ChartOpen_1);
        }

        private async Task<JObject> ChartOpen_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "symbol");
            ParamAdd(context, parameters, "period");
            await ExecCommandAsync(context, MQLCommand.ChartOpen_1, parameters); // MQLCommand ENUM = 70

            result["result"] = Convert.ToInt64(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> ChartFirst<br>
        /// <b>Description:</b> Returns the ID of the first chart of the client terminal.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartfirst.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartfirst$")]
        public IHttpContext Handle_ChartFirst_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), ChartFirst_1);
        }

        /// <summary>
        /// <b>Function:</b> ChartFirst<br>
        /// <b>Description:</b> Returns the ID of the first chart of the client terminal.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartfirst.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/chartfirst$")]
        public IHttpContext Handle_ChartFirst_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, ChartFirst_1);
        }

        private async Task<JObject> ChartFirst_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.ChartFirst_1, parameters); // MQLCommand ENUM = 71

            result["result"] = Convert.ToInt64(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> ChartNext<br>
        /// <b>Description:</b> Returns the chart ID of the chart next to the specified one.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartnext.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart ID. 0 does not mean the current chart. 0 means "return the first chart ID".</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartnext$")]
        public IHttpContext Handle_ChartNext_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), ChartNext_1);
        }

        /// <summary>
        /// <b>Function:</b> ChartNext<br>
        /// <b>Description:</b> Returns the chart ID of the chart next to the specified one.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartnext.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart ID. 0 does not mean the current chart. 0 means "return the first chart ID".</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/chartnext$")]
        public IHttpContext Handle_ChartNext_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, ChartNext_1);
        }

        private async Task<JObject> ChartNext_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "chart_id");
            await ExecCommandAsync(context, MQLCommand.ChartNext_1, parameters); // MQLCommand ENUM = 72

            result["result"] = Convert.ToInt64(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> ChartClose<br>
        /// <b>Description:</b> Closes the specified chart.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartclose.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart ID. 0 means the current chart.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartclose$")]
        public IHttpContext Handle_ChartClose_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), ChartClose_1);
        }

        /// <summary>
        /// <b>Function:</b> ChartClose<br>
        /// <b>Description:</b> Closes the specified chart.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartclose.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart ID. 0 means the current chart.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/chartclose$")]
        public IHttpContext Handle_ChartClose_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, ChartClose_1);
        }

        private async Task<JObject> ChartClose_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "chart_id");
            await ExecCommandAsync(context, MQLCommand.ChartClose_1, parameters); // MQLCommand ENUM = 73

            result["result"] = (bool)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> ChartSymbol<br>
        /// <b>Description:</b> Returns the symbol name for the specified chart.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartsymbol.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart ID. 0 means the current chart.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartsymbol$")]
        public IHttpContext Handle_ChartSymbol_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), ChartSymbol_1);
        }

        /// <summary>
        /// <b>Function:</b> ChartSymbol<br>
        /// <b>Description:</b> Returns the symbol name for the specified chart.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartsymbol.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart ID. 0 means the current chart.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/chartsymbol$")]
        public IHttpContext Handle_ChartSymbol_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, ChartSymbol_1);
        }

        private async Task<JObject> ChartSymbol_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "chart_id");
            await ExecCommandAsync(context, MQLCommand.ChartSymbol_1, parameters); // MQLCommand ENUM = 74

            result["result"] = (string)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> ChartRedraw<br>
        /// <b>Description:</b> This function calls a forced redrawing of a specified chart.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartredraw.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart ID. 0 means the current chart.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartredraw$")]
        public IHttpContext Handle_ChartRedraw_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), ChartRedraw_1);
        }

        /// <summary>
        /// <b>Function:</b> ChartRedraw<br>
        /// <b>Description:</b> This function calls a forced redrawing of a specified chart.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartredraw.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart ID. 0 means the current chart.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/chartredraw$")]
        public IHttpContext Handle_ChartRedraw_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, ChartRedraw_1);
        }

        private async Task<JObject> ChartRedraw_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "chart_id");
            await ExecCommandAsync(context, MQLCommand.ChartRedraw_1, parameters); // MQLCommand ENUM = 75

            result["result"] = "";

            return result;
        }
        /// <summary>
        /// <b>Function:</b> ChartSetDouble<br>
        /// <b>Description:</b> Sets a value for a corresponding property of the specified chart. Chart property should be of a<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartsetdouble.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart ID. 0 means the current chart.</li>
        /// <li><b>prop_id</b> :  [in] Chart property ID. Can be one of the values (except the read-only properties).</li>
        /// <li><b>value</b> :  [in] Property value.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartsetdouble$")]
        public IHttpContext Handle_ChartSetDouble_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), ChartSetDouble_1);
        }

        /// <summary>
        /// <b>Function:</b> ChartSetDouble<br>
        /// <b>Description:</b> Sets a value for a corresponding property of the specified chart. Chart property should be of a<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartsetdouble.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart ID. 0 means the current chart.</li>
        /// <li><b>prop_id</b> :  [in] Chart property ID. Can be one of the values (except the read-only properties).</li>
        /// <li><b>value</b> :  [in] Property value.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/chartsetdouble$")]
        public IHttpContext Handle_ChartSetDouble_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, ChartSetDouble_1);
        }

        private async Task<JObject> ChartSetDouble_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "chart_id");
            ParamAdd(context, parameters, "prop_id");
            ParamAdd(context, parameters, "value");
            await ExecCommandAsync(context, MQLCommand.ChartSetDouble_1, parameters); // MQLCommand ENUM = 76

            result["result"] = (bool)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> ChartSetInteger<br>
        /// <b>Description:</b> Sets a value for a corresponding property of the specified chart. Chart property must be<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartsetinteger.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart ID. 0 means the current chart.</li>
        /// <li><b>prop_id</b> :  [in] Chart property ID. It can be one of the value (except the read-only properties).</li>
        /// <li><b>value</b> :  [in] Property value.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartsetinteger$")]
        public IHttpContext Handle_ChartSetInteger_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), ChartSetInteger_1);
        }

        /// <summary>
        /// <b>Function:</b> ChartSetInteger<br>
        /// <b>Description:</b> Sets a value for a corresponding property of the specified chart. Chart property must be<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartsetinteger.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart ID. 0 means the current chart.</li>
        /// <li><b>prop_id</b> :  [in] Chart property ID. It can be one of the value (except the read-only properties).</li>
        /// <li><b>value</b> :  [in] Property value.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/chartsetinteger$")]
        public IHttpContext Handle_ChartSetInteger_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, ChartSetInteger_1);
        }

        private async Task<JObject> ChartSetInteger_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "chart_id");
            ParamAdd(context, parameters, "prop_id");
            ParamAdd(context, parameters, "value");
            await ExecCommandAsync(context, MQLCommand.ChartSetInteger_1, parameters); // MQLCommand ENUM = 77

            result["result"] = (bool)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> ChartSetInteger<br>
        /// <b>Description:</b> Sets a value for a corresponding property of the specified chart. Chart property must be<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartsetinteger.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart ID. 0 means the current chart.</li>
        /// <li><b>property_id</b> :  </li>
        /// <li><b>sub_window</b> :  [in] Chart subwindow.</li>
        /// <li><b>value</b> :  [in] Property value.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartsetinteger$")]
        public IHttpContext Handle_ChartSetInteger_2(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), ChartSetInteger_2);
        }

        /// <summary>
        /// <b>Function:</b> ChartSetInteger<br>
        /// <b>Description:</b> Sets a value for a corresponding property of the specified chart. Chart property must be<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartsetinteger.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart ID. 0 means the current chart.</li>
        /// <li><b>property_id</b> :  </li>
        /// <li><b>sub_window</b> :  [in] Chart subwindow.</li>
        /// <li><b>value</b> :  [in] Property value.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/chartsetinteger$")]
        public IHttpContext Handle_ChartSetInteger_2_Default(IHttpContext context)
        {
            return SendJsonResponse(context, ChartSetInteger_2);
        }

        private async Task<JObject> ChartSetInteger_2(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "chart_id");
            ParamAdd(context, parameters, "property_id");
            ParamAdd(context, parameters, "sub_window");
            ParamAdd(context, parameters, "value");
            await ExecCommandAsync(context, MQLCommand.ChartSetInteger_2, parameters); // MQLCommand ENUM = 77

            result["result"] = (bool)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> ChartSetString<br>
        /// <b>Description:</b> Sets a value for a corresponding property of the specified chart. Chart property must be of the string type. The command is added to chart message queue and executed only after all previous commands have been processed.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartsetstring.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart ID. 0 means the current chart.</li>
        /// <li><b>prop_id</b> :  [in] Chart property ID. Its value can be one of the values (except the read-only properties).</li>
        /// <li><b>str_value</b> :  [in] Property value string. String length cannot exceed 2045 characters (extra characters will be truncated).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartsetstring$")]
        public IHttpContext Handle_ChartSetString_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), ChartSetString_1);
        }

        /// <summary>
        /// <b>Function:</b> ChartSetString<br>
        /// <b>Description:</b> Sets a value for a corresponding property of the specified chart. Chart property must be of the string type. The command is added to chart message queue and executed only after all previous commands have been processed.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartsetstring.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart ID. 0 means the current chart.</li>
        /// <li><b>prop_id</b> :  [in] Chart property ID. Its value can be one of the values (except the read-only properties).</li>
        /// <li><b>str_value</b> :  [in] Property value string. String length cannot exceed 2045 characters (extra characters will be truncated).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/chartsetstring$")]
        public IHttpContext Handle_ChartSetString_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, ChartSetString_1);
        }

        private async Task<JObject> ChartSetString_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "chart_id");
            ParamAdd(context, parameters, "prop_id");
            ParamAdd(context, parameters, "str_value");
            await ExecCommandAsync(context, MQLCommand.ChartSetString_1, parameters); // MQLCommand ENUM = 78

            result["result"] = (bool)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> ChartNavigate<br>
        /// <b>Description:</b> Performs shift of the specified chart by the specified number of bars relative to the specified position in the chart. The command is added to chart message queue and executed only after all previous commands have been processed.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartnavigate.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart ID. 0 means the current chart.</li>
        /// <li><b>position</b> :  [in] Chart position to perform a shift. Can be one of the values.</li>
        /// <li><b>shift</b> :  [in] Number of bars to shift the chart. Positive value means the right shift (to the end of chart), negative value means the left shift (to the beginning of chart). The zero shift can be used to navigate to the beginning or end of chart.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartnavigate$")]
        public IHttpContext Handle_ChartNavigate_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), ChartNavigate_1);
        }

        /// <summary>
        /// <b>Function:</b> ChartNavigate<br>
        /// <b>Description:</b> Performs shift of the specified chart by the specified number of bars relative to the specified position in the chart. The command is added to chart message queue and executed only after all previous commands have been processed.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartnavigate.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart ID. 0 means the current chart.</li>
        /// <li><b>position</b> :  [in] Chart position to perform a shift. Can be one of the values.</li>
        /// <li><b>shift</b> :  [in] Number of bars to shift the chart. Positive value means the right shift (to the end of chart), negative value means the left shift (to the beginning of chart). The zero shift can be used to navigate to the beginning or end of chart.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/chartnavigate$")]
        public IHttpContext Handle_ChartNavigate_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, ChartNavigate_1);
        }

        private async Task<JObject> ChartNavigate_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "chart_id");
            ParamAdd(context, parameters, "position");
            ParamAdd(context, parameters, "shift");
            await ExecCommandAsync(context, MQLCommand.ChartNavigate_1, parameters); // MQLCommand ENUM = 79

            result["result"] = (bool)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> ChartID<br>
        /// <b>Description:</b> Returns the ID of the current chart.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartid.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartid$")]
        public IHttpContext Handle_ChartID_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), ChartID_1);
        }

        /// <summary>
        /// <b>Function:</b> ChartID<br>
        /// <b>Description:</b> Returns the ID of the current chart.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartid.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/chartid$")]
        public IHttpContext Handle_ChartID_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, ChartID_1);
        }

        private async Task<JObject> ChartID_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.ChartID_1, parameters); // MQLCommand ENUM = 80

            result["result"] = Convert.ToInt64(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> ChartIndicatorDelete<br>
        /// <b>Description:</b> Removes an indicator with a specified name from the specified chart window. The command is added to chart message queue and executed only after all previous commands have been processed.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartindicatordelete.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart ID. 0 denotes the current chart.</li>
        /// <li><b>sub_window</b> :  [in] Number of the chart subwindow. 0 denotes the main chart subwindow.</li>
        /// <li><b>indicator_shortname</b> :  </li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartindicatordelete$")]
        public IHttpContext Handle_ChartIndicatorDelete_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), ChartIndicatorDelete_1);
        }

        /// <summary>
        /// <b>Function:</b> ChartIndicatorDelete<br>
        /// <b>Description:</b> Removes an indicator with a specified name from the specified chart window. The command is added to chart message queue and executed only after all previous commands have been processed.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartindicatordelete.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart ID. 0 denotes the current chart.</li>
        /// <li><b>sub_window</b> :  [in] Number of the chart subwindow. 0 denotes the main chart subwindow.</li>
        /// <li><b>indicator_shortname</b> :  </li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/chartindicatordelete$")]
        public IHttpContext Handle_ChartIndicatorDelete_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, ChartIndicatorDelete_1);
        }

        private async Task<JObject> ChartIndicatorDelete_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "chart_id");
            ParamAdd(context, parameters, "sub_window");
            ParamAdd(context, parameters, "indicator_shortname");
            await ExecCommandAsync(context, MQLCommand.ChartIndicatorDelete_1, parameters); // MQLCommand ENUM = 81

            result["result"] = (bool)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> ChartIndicatorName<br>
        /// <b>Description:</b> Returns the short name of the indicator by the number in the indicators list on the specified chart window.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartindicatorname.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart ID. 0 denotes the current chart.</li>
        /// <li><b>sub_window</b> :  [in] Number of the chart subwindow. 0 denotes the main chart subwindow.</li>
        /// <li><b>index</b> :  [in] the index of the indicator in the list of indicators. The numeration of indicators start with zero, i.e. the first indicator in the list has the 0 index. To obtain the number of indicators in the list use the function.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartindicatorname$")]
        public IHttpContext Handle_ChartIndicatorName_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), ChartIndicatorName_1);
        }

        /// <summary>
        /// <b>Function:</b> ChartIndicatorName<br>
        /// <b>Description:</b> Returns the short name of the indicator by the number in the indicators list on the specified chart window.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartindicatorname.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart ID. 0 denotes the current chart.</li>
        /// <li><b>sub_window</b> :  [in] Number of the chart subwindow. 0 denotes the main chart subwindow.</li>
        /// <li><b>index</b> :  [in] the index of the indicator in the list of indicators. The numeration of indicators start with zero, i.e. the first indicator in the list has the 0 index. To obtain the number of indicators in the list use the function.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/chartindicatorname$")]
        public IHttpContext Handle_ChartIndicatorName_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, ChartIndicatorName_1);
        }

        private async Task<JObject> ChartIndicatorName_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "chart_id");
            ParamAdd(context, parameters, "sub_window");
            ParamAdd(context, parameters, "index");
            await ExecCommandAsync(context, MQLCommand.ChartIndicatorName_1, parameters); // MQLCommand ENUM = 82

            result["result"] = (string)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> ChartIndicatorsTotal<br>
        /// <b>Description:</b> Returns the number of all indicators applied to the specified chart window.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartindicatorstotal.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart ID. 0 denotes the current chart.</li>
        /// <li><b>sub_window</b> :  [in] Number of the chart subwindow. 0 denotes the main chart subwindow.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartindicatorstotal$")]
        public IHttpContext Handle_ChartIndicatorsTotal_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), ChartIndicatorsTotal_1);
        }

        /// <summary>
        /// <b>Function:</b> ChartIndicatorsTotal<br>
        /// <b>Description:</b> Returns the number of all indicators applied to the specified chart window.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartindicatorstotal.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart ID. 0 denotes the current chart.</li>
        /// <li><b>sub_window</b> :  [in] Number of the chart subwindow. 0 denotes the main chart subwindow.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/chartindicatorstotal$")]
        public IHttpContext Handle_ChartIndicatorsTotal_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, ChartIndicatorsTotal_1);
        }

        private async Task<JObject> ChartIndicatorsTotal_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "chart_id");
            ParamAdd(context, parameters, "sub_window");
            await ExecCommandAsync(context, MQLCommand.ChartIndicatorsTotal_1, parameters); // MQLCommand ENUM = 83

            result["result"] = Convert.ToInt32(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> ChartWindowOnDropped<br>
        /// <b>Description:</b> Returns the number (index) of the chart subwindow the Expert Advisor or script has been dropped to. 0 means the main chart window.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartwindowondropped.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartwindowondropped$")]
        public IHttpContext Handle_ChartWindowOnDropped_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), ChartWindowOnDropped_1);
        }

        /// <summary>
        /// <b>Function:</b> ChartWindowOnDropped<br>
        /// <b>Description:</b> Returns the number (index) of the chart subwindow the Expert Advisor or script has been dropped to. 0 means the main chart window.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartwindowondropped.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/chartwindowondropped$")]
        public IHttpContext Handle_ChartWindowOnDropped_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, ChartWindowOnDropped_1);
        }

        private async Task<JObject> ChartWindowOnDropped_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.ChartWindowOnDropped_1, parameters); // MQLCommand ENUM = 84

            result["result"] = Convert.ToInt32(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> ChartPriceOnDropped<br>
        /// <b>Description:</b> Returns the price coordinate corresponding to the chart point the Expert Advisor or script has been dropped to.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartpriceondropped.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartpriceondropped$")]
        public IHttpContext Handle_ChartPriceOnDropped_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), ChartPriceOnDropped_1);
        }

        /// <summary>
        /// <b>Function:</b> ChartPriceOnDropped<br>
        /// <b>Description:</b> Returns the price coordinate corresponding to the chart point the Expert Advisor or script has been dropped to.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartpriceondropped.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/chartpriceondropped$")]
        public IHttpContext Handle_ChartPriceOnDropped_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, ChartPriceOnDropped_1);
        }

        private async Task<JObject> ChartPriceOnDropped_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.ChartPriceOnDropped_1, parameters); // MQLCommand ENUM = 85

            result["result"] = Convert.ToDecimal(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> ChartTimeOnDropped<br>
        /// <b>Description:</b> Returns the time coordinate corresponding to the chart point the Expert Advisor or script has been dropped to.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/charttimeondropped.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/charttimeondropped$")]
        public IHttpContext Handle_ChartTimeOnDropped_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), ChartTimeOnDropped_1);
        }

        /// <summary>
        /// <b>Function:</b> ChartTimeOnDropped<br>
        /// <b>Description:</b> Returns the time coordinate corresponding to the chart point the Expert Advisor or script has been dropped to.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/charttimeondropped.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/charttimeondropped$")]
        public IHttpContext Handle_ChartTimeOnDropped_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, ChartTimeOnDropped_1);
        }

        private async Task<JObject> ChartTimeOnDropped_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.ChartTimeOnDropped_1, parameters); // MQLCommand ENUM = 86

            result["result"] = (DateTime)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> ChartXOnDropped<br>
        /// <b>Description:</b> Returns the X coordinate of the chart point the Expert Advisor or script has been dropped to.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartxondropped.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartxondropped$")]
        public IHttpContext Handle_ChartXOnDropped_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), ChartXOnDropped_1);
        }

        /// <summary>
        /// <b>Function:</b> ChartXOnDropped<br>
        /// <b>Description:</b> Returns the X coordinate of the chart point the Expert Advisor or script has been dropped to.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartxondropped.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/chartxondropped$")]
        public IHttpContext Handle_ChartXOnDropped_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, ChartXOnDropped_1);
        }

        private async Task<JObject> ChartXOnDropped_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.ChartXOnDropped_1, parameters); // MQLCommand ENUM = 87

            result["result"] = Convert.ToInt32(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> ChartYOnDropped<br>
        /// <b>Description:</b> Returns the Y coordinateof the chart point the Expert Advisor or script has been dropped to.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartyondropped.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartyondropped$")]
        public IHttpContext Handle_ChartYOnDropped_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), ChartYOnDropped_1);
        }

        /// <summary>
        /// <b>Function:</b> ChartYOnDropped<br>
        /// <b>Description:</b> Returns the Y coordinateof the chart point the Expert Advisor or script has been dropped to.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartyondropped.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/chartyondropped$")]
        public IHttpContext Handle_ChartYOnDropped_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, ChartYOnDropped_1);
        }

        private async Task<JObject> ChartYOnDropped_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.ChartYOnDropped_1, parameters); // MQLCommand ENUM = 88

            result["result"] = Convert.ToInt32(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> ChartSetSymbolPeriod<br>
        /// <b>Description:</b> Changes the symbol and period of the specified chart. The function is asynchronous, i.e. it sends the command and does not wait for its execution completion. The command is added to chart message queue and executed only after all previous commands have been processed.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartsetsymbolperiod.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart ID. 0 means the current chart.</li>
        /// <li><b>symbol</b> :  [in] Chart symbol. value means the current chart symbol (Expert Advisor is attached to)</li>
        /// <li><b>period</b> :  [in] Chart period (timeframe). Can be one of the values. 0 means the current chart period.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartsetsymbolperiod$")]
        public IHttpContext Handle_ChartSetSymbolPeriod_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), ChartSetSymbolPeriod_1);
        }

        /// <summary>
        /// <b>Function:</b> ChartSetSymbolPeriod<br>
        /// <b>Description:</b> Changes the symbol and period of the specified chart. The function is asynchronous, i.e. it sends the command and does not wait for its execution completion. The command is added to chart message queue and executed only after all previous commands have been processed.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartsetsymbolperiod.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart ID. 0 means the current chart.</li>
        /// <li><b>symbol</b> :  [in] Chart symbol. value means the current chart symbol (Expert Advisor is attached to)</li>
        /// <li><b>period</b> :  [in] Chart period (timeframe). Can be one of the values. 0 means the current chart period.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/chartsetsymbolperiod$")]
        public IHttpContext Handle_ChartSetSymbolPeriod_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, ChartSetSymbolPeriod_1);
        }

        private async Task<JObject> ChartSetSymbolPeriod_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "chart_id");
            ParamAdd(context, parameters, "symbol");
            ParamAdd(context, parameters, "period");
            await ExecCommandAsync(context, MQLCommand.ChartSetSymbolPeriod_1, parameters); // MQLCommand ENUM = 89

            result["result"] = (bool)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> ChartScreenShot<br>
        /// <b>Description:</b> Saves current chart screen shot as a GIF, PNG or BMP file depending on specified extension. The command is added to chart message queue and executed only after all previous commands have been processed.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartscreenshot.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart ID. 0 means the current chart.</li>
        /// <li><b>filename</b> :  [in] Screenshot file name. Cannot exceed 63 characters. Screenshot files are placed in the \Files directory.</li>
        /// <li><b>width</b> :  [in] Screenshot width in pixels.</li>
        /// <li><b>height</b> :  [in] Screenshot height in pixels.</li>
        /// <li><b>align_mode</b> :  [in] Output mode of a narrow screenshot. A value of the enumeration. ALIGN_RIGHT means align to the right margin (the output from the end). ALIGN_LEFT means Left justify.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartscreenshot$")]
        public IHttpContext Handle_ChartScreenShot_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), ChartScreenShot_1);
        }

        /// <summary>
        /// <b>Function:</b> ChartScreenShot<br>
        /// <b>Description:</b> Saves current chart screen shot as a GIF, PNG or BMP file depending on specified extension. The command is added to chart message queue and executed only after all previous commands have been processed.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartscreenshot.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart ID. 0 means the current chart.</li>
        /// <li><b>filename</b> :  [in] Screenshot file name. Cannot exceed 63 characters. Screenshot files are placed in the \Files directory.</li>
        /// <li><b>width</b> :  [in] Screenshot width in pixels.</li>
        /// <li><b>height</b> :  [in] Screenshot height in pixels.</li>
        /// <li><b>align_mode</b> :  [in] Output mode of a narrow screenshot. A value of the enumeration. ALIGN_RIGHT means align to the right margin (the output from the end). ALIGN_LEFT means Left justify.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/chartscreenshot$")]
        public IHttpContext Handle_ChartScreenShot_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, ChartScreenShot_1);
        }

        private async Task<JObject> ChartScreenShot_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;

            await SetFileNameInfoAsOutput(context, "MQL4\\Files", "png,gif,bmp");
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "chart_id");
            ParamAdd(context, parameters, "filename");
            ParamAdd(context, parameters, "width");
            ParamAdd(context, parameters, "height");
            ParamAdd(context, parameters, "align_mode");
            await ExecCommandAsync(context, MQLCommand.ChartScreenShot_1, parameters); // MQLCommand ENUM = 90

            result["result"] = (bool)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> WindowBarsPerChart<br>
        /// <b>Description:</b> Returns the amount of bars visible on the chart.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/windowbarsperchart.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/windowbarsperchart$")]
        public IHttpContext Handle_WindowBarsPerChart_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), WindowBarsPerChart_1);
        }

        /// <summary>
        /// <b>Function:</b> WindowBarsPerChart<br>
        /// <b>Description:</b> Returns the amount of bars visible on the chart.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/windowbarsperchart.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/windowbarsperchart$")]
        public IHttpContext Handle_WindowBarsPerChart_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, WindowBarsPerChart_1);
        }

        private async Task<JObject> WindowBarsPerChart_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.WindowBarsPerChart_1, parameters); // MQLCommand ENUM = 91

            result["result"] = Convert.ToInt32(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> WindowExpertName<br>
        /// <b>Description:</b> Returns the name of the executed Expert Advisor, script, custom indicator, or library.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/windowexpertname.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/windowexpertname$")]
        public IHttpContext Handle_WindowExpertName_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), WindowExpertName_1);
        }

        /// <summary>
        /// <b>Function:</b> WindowExpertName<br>
        /// <b>Description:</b> Returns the name of the executed Expert Advisor, script, custom indicator, or library.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/windowexpertname.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/windowexpertname$")]
        public IHttpContext Handle_WindowExpertName_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, WindowExpertName_1);
        }

        private async Task<JObject> WindowExpertName_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.WindowExpertName_1, parameters); // MQLCommand ENUM = 92

            result["result"] = (string)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> WindowFind<br>
        /// <b>Description:</b> Returns the window index containing this specified indicator.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/windowfind.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>name</b> :  [in] Indicator short name.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/windowfind$")]
        public IHttpContext Handle_WindowFind_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), WindowFind_1);
        }

        /// <summary>
        /// <b>Function:</b> WindowFind<br>
        /// <b>Description:</b> Returns the window index containing this specified indicator.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/windowfind.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>name</b> :  [in] Indicator short name.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/windowfind$")]
        public IHttpContext Handle_WindowFind_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, WindowFind_1);
        }

        private async Task<JObject> WindowFind_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "name");
            await ExecCommandAsync(context, MQLCommand.WindowFind_1, parameters); // MQLCommand ENUM = 93

            result["result"] = Convert.ToInt32(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> WindowFirstVisibleBar<br>
        /// <b>Description:</b> Returns index of the first visible bar in the current chart window.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/windowfirstvisiblebar.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/windowfirstvisiblebar$")]
        public IHttpContext Handle_WindowFirstVisibleBar_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), WindowFirstVisibleBar_1);
        }

        /// <summary>
        /// <b>Function:</b> WindowFirstVisibleBar<br>
        /// <b>Description:</b> Returns index of the first visible bar in the current chart window.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/windowfirstvisiblebar.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/windowfirstvisiblebar$")]
        public IHttpContext Handle_WindowFirstVisibleBar_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, WindowFirstVisibleBar_1);
        }

        private async Task<JObject> WindowFirstVisibleBar_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.WindowFirstVisibleBar_1, parameters); // MQLCommand ENUM = 94

            result["result"] = Convert.ToInt32(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> WindowHandle<br>
        /// <b>Description:</b> Returns the system handle of the chart window.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/windowhandle.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/windowhandle$")]
        public IHttpContext Handle_WindowHandle_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), WindowHandle_1);
        }

        /// <summary>
        /// <b>Function:</b> WindowHandle<br>
        /// <b>Description:</b> Returns the system handle of the chart window.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/windowhandle.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/windowhandle$")]
        public IHttpContext Handle_WindowHandle_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, WindowHandle_1);
        }

        private async Task<JObject> WindowHandle_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "symbol");
            ParamAdd(context, parameters, "timeframe");
            await ExecCommandAsync(context, MQLCommand.WindowHandle_1, parameters); // MQLCommand ENUM = 95

            result["result"] = Convert.ToInt32(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> WindowIsVisible<br>
        /// <b>Description:</b> Returns the visibility flag of the chart subwindow.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/windowisvisible.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>index</b> :  [in] Subwindow index.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/windowisvisible$")]
        public IHttpContext Handle_WindowIsVisible_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), WindowIsVisible_1);
        }

        /// <summary>
        /// <b>Function:</b> WindowIsVisible<br>
        /// <b>Description:</b> Returns the visibility flag of the chart subwindow.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/windowisvisible.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>index</b> :  [in] Subwindow index.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/windowisvisible$")]
        public IHttpContext Handle_WindowIsVisible_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, WindowIsVisible_1);
        }

        private async Task<JObject> WindowIsVisible_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "index");
            await ExecCommandAsync(context, MQLCommand.WindowIsVisible_1, parameters); // MQLCommand ENUM = 96

            result["result"] = Convert.ToInt32(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> WindowOnDropped<br>
        /// <b>Description:</b> Returns the window index where Expert Advisor, custom indicator or script was dropped.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/windowondropped.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/windowondropped$")]
        public IHttpContext Handle_WindowOnDropped_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), WindowOnDropped_1);
        }

        /// <summary>
        /// <b>Function:</b> WindowOnDropped<br>
        /// <b>Description:</b> Returns the window index where Expert Advisor, custom indicator or script was dropped.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/windowondropped.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/windowondropped$")]
        public IHttpContext Handle_WindowOnDropped_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, WindowOnDropped_1);
        }

        private async Task<JObject> WindowOnDropped_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.WindowOnDropped_1, parameters); // MQLCommand ENUM = 97

            result["result"] = Convert.ToInt32(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> WindowPriceMax<br>
        /// <b>Description:</b> Returns the maximal value of the vertical scale of the specified subwindow of the current chart.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/windowpricemax.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>index</b> :  [in] Chart subwindow index (0 - main chart window).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/windowpricemax$")]
        public IHttpContext Handle_WindowPriceMax_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), WindowPriceMax_1);
        }

        /// <summary>
        /// <b>Function:</b> WindowPriceMax<br>
        /// <b>Description:</b> Returns the maximal value of the vertical scale of the specified subwindow of the current chart.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/windowpricemax.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>index</b> :  [in] Chart subwindow index (0 - main chart window).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/windowpricemax$")]
        public IHttpContext Handle_WindowPriceMax_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, WindowPriceMax_1);
        }

        private async Task<JObject> WindowPriceMax_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "index");
            await ExecCommandAsync(context, MQLCommand.WindowPriceMax_1, parameters); // MQLCommand ENUM = 98

            result["result"] = Convert.ToInt32(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> WindowPriceMin<br>
        /// <b>Description:</b> Returns the minimal value of the vertical scale of the specified subwindow of the current chart.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/windowpricemin.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>index</b> :  [in] Chart subwindow index (0 - main chart window).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/windowpricemin$")]
        public IHttpContext Handle_WindowPriceMin_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), WindowPriceMin_1);
        }

        /// <summary>
        /// <b>Function:</b> WindowPriceMin<br>
        /// <b>Description:</b> Returns the minimal value of the vertical scale of the specified subwindow of the current chart.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/windowpricemin.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>index</b> :  [in] Chart subwindow index (0 - main chart window).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/windowpricemin$")]
        public IHttpContext Handle_WindowPriceMin_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, WindowPriceMin_1);
        }

        private async Task<JObject> WindowPriceMin_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "index");
            await ExecCommandAsync(context, MQLCommand.WindowPriceMin_1, parameters); // MQLCommand ENUM = 99

            result["result"] = Convert.ToInt32(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> WindowPriceOnDropped<br>
        /// <b>Description:</b> Returns the price of the chart point where Expert Advisor or script was dropped.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/windowpriceondropped.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/windowpriceondropped$")]
        public IHttpContext Handle_WindowPriceOnDropped_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), WindowPriceOnDropped_1);
        }

        /// <summary>
        /// <b>Function:</b> WindowPriceOnDropped<br>
        /// <b>Description:</b> Returns the price of the chart point where Expert Advisor or script was dropped.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/windowpriceondropped.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/windowpriceondropped$")]
        public IHttpContext Handle_WindowPriceOnDropped_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, WindowPriceOnDropped_1);
        }

        private async Task<JObject> WindowPriceOnDropped_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.WindowPriceOnDropped_1, parameters); // MQLCommand ENUM = 100

            result["result"] = Convert.ToDecimal(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> WindowRedraw<br>
        /// <b>Description:</b> Redraws the current chart forcedly.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/windowredraw.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/windowredraw$")]
        public IHttpContext Handle_WindowRedraw_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), WindowRedraw_1);
        }

        /// <summary>
        /// <b>Function:</b> WindowRedraw<br>
        /// <b>Description:</b> Redraws the current chart forcedly.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/windowredraw.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/windowredraw$")]
        public IHttpContext Handle_WindowRedraw_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, WindowRedraw_1);
        }

        private async Task<JObject> WindowRedraw_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.WindowRedraw_1, parameters); // MQLCommand ENUM = 101

            result["result"] = "";

            return result;
        }
        /// <summary>
        /// <b>Function:</b> WindowScreenShot<br>
        /// <b>Description:</b> Saves current chart screen shot as a GIF file.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/windowscreenshot.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>filename</b> :  [in] Screen shot file name. Screenshot is saved to \Files folder.</li>
        /// <li><b>size_x</b> :  [in] Screen shot width in pixels.</li>
        /// <li><b>size_y</b> :  [in] Screen shot height in pixels.</li>
        /// <li><b>start_bar</b> :  [in] Index of the first visible bar in the screen shot. If 0 value is set, the current first visible bar will be shot. If no value or negative value has been set, the end-of-chart screen shot will be produced, indent being taken into consideration.</li>
        /// <li><b>chart_scale</b> :  [in] Horizontal chart scale for screen shot. Can be in the range from 0 to 5. If no value or negative value has been set, the current chart scale will be used.</li>
        /// <li><b>chart_mode</b> :  [in] Chart displaying mode. It can take the following values: CHART_BAR (0 is a sequence of bars), CHART_CANDLE (1 is a sequence of candlesticks), CHART_LINE (2 is a close prices line). If no value or negative value has been set, the chart will be shown in its current mode.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/windowscreenshot$")]
        public IHttpContext Handle_WindowScreenShot_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), WindowScreenShot_1);
        }

        /// <summary>
        /// <b>Function:</b> WindowScreenShot<br>
        /// <b>Description:</b> Saves current chart screen shot as a GIF file.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/windowscreenshot.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>filename</b> :  [in] Screen shot file name. Screenshot is saved to \Files folder.</li>
        /// <li><b>size_x</b> :  [in] Screen shot width in pixels.</li>
        /// <li><b>size_y</b> :  [in] Screen shot height in pixels.</li>
        /// <li><b>start_bar</b> :  [in] Index of the first visible bar in the screen shot. If 0 value is set, the current first visible bar will be shot. If no value or negative value has been set, the end-of-chart screen shot will be produced, indent being taken into consideration.</li>
        /// <li><b>chart_scale</b> :  [in] Horizontal chart scale for screen shot. Can be in the range from 0 to 5. If no value or negative value has been set, the current chart scale will be used.</li>
        /// <li><b>chart_mode</b> :  [in] Chart displaying mode. It can take the following values: CHART_BAR (0 is a sequence of bars), CHART_CANDLE (1 is a sequence of candlesticks), CHART_LINE (2 is a close prices line). If no value or negative value has been set, the chart will be shown in its current mode.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/windowscreenshot$")]
        public IHttpContext Handle_WindowScreenShot_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, WindowScreenShot_1);
        }

        private async Task<JObject> WindowScreenShot_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "filename");
            ParamAdd(context, parameters, "size_x");
            ParamAdd(context, parameters, "size_y");
            ParamAdd(context, parameters, "start_bar");
            ParamAdd(context, parameters, "chart_scale");
            ParamAdd(context, parameters, "chart_mode");
            await ExecCommandAsync(context, MQLCommand.WindowScreenShot_1, parameters); // MQLCommand ENUM = 102

            result["result"] = (bool)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> WindowTimeOnDropped<br>
        /// <b>Description:</b> Returns the time of the chart point where Expert Advisor or script was dropped.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/windowtimeondropped.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/windowtimeondropped$")]
        public IHttpContext Handle_WindowTimeOnDropped_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), WindowTimeOnDropped_1);
        }

        /// <summary>
        /// <b>Function:</b> WindowTimeOnDropped<br>
        /// <b>Description:</b> Returns the time of the chart point where Expert Advisor or script was dropped.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/windowtimeondropped.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/windowtimeondropped$")]
        public IHttpContext Handle_WindowTimeOnDropped_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, WindowTimeOnDropped_1);
        }

        private async Task<JObject> WindowTimeOnDropped_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.WindowTimeOnDropped_1, parameters); // MQLCommand ENUM = 103

            result["result"] = (DateTime)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> WindowsTotal<br>
        /// <b>Description:</b> Returns total number of indicator windows on the chart.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/windowstotal.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/windowstotal$")]
        public IHttpContext Handle_WindowsTotal_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), WindowsTotal_1);
        }

        /// <summary>
        /// <b>Function:</b> WindowsTotal<br>
        /// <b>Description:</b> Returns total number of indicator windows on the chart.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/windowstotal.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/windowstotal$")]
        public IHttpContext Handle_WindowsTotal_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, WindowsTotal_1);
        }

        private async Task<JObject> WindowsTotal_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.WindowsTotal_1, parameters); // MQLCommand ENUM = 104

            result["result"] = Convert.ToInt32(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> WindowXOnDropped<br>
        /// <b>Description:</b> Returns the value at X axis in pixels for the chart window client area point at which the Expert Advisor or script was dropped.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/windowxondropped.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/windowxondropped$")]
        public IHttpContext Handle_WindowXOnDropped_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), WindowXOnDropped_1);
        }

        /// <summary>
        /// <b>Function:</b> WindowXOnDropped<br>
        /// <b>Description:</b> Returns the value at X axis in pixels for the chart window client area point at which the Expert Advisor or script was dropped.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/windowxondropped.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/windowxondropped$")]
        public IHttpContext Handle_WindowXOnDropped_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, WindowXOnDropped_1);
        }

        private async Task<JObject> WindowXOnDropped_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.WindowXOnDropped_1, parameters); // MQLCommand ENUM = 105

            result["result"] = Convert.ToInt32(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> WindowYOnDropped<br>
        /// <b>Description:</b> Returns the value at Y axis in pixels for the chart window client area point at which the Expert Advisor or script was dropped.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/windowyondropped.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/windowyondropped$")]
        public IHttpContext Handle_WindowYOnDropped_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), WindowYOnDropped_1);
        }

        /// <summary>
        /// <b>Function:</b> WindowYOnDropped<br>
        /// <b>Description:</b> Returns the value at Y axis in pixels for the chart window client area point at which the Expert Advisor or script was dropped.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/windowyondropped.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/windowyondropped$")]
        public IHttpContext Handle_WindowYOnDropped_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, WindowYOnDropped_1);
        }

        private async Task<JObject> WindowYOnDropped_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.WindowYOnDropped_1, parameters); // MQLCommand ENUM = 106

            result["result"] = Convert.ToInt32(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> OrderClose<br>
        /// <b>Description:</b> Closes opened order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/orderclose.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>ticket</b> :  [in] Unique number of the order ticket.</li>
        /// <li><b>lots</b> :  [in] Number of lots.</li>
        /// <li><b>price</b> :  [in] Closing price.</li>
        /// <li><b>slippage</b> :  [in] Value of the maximum price slippage in points.</li>
        /// <li><b>arrow_color</b> :  [in] Color of the closing arrow on the chart. If the parameter is missing or has CLR_NONE value closing arrow will not be drawn on the chart.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/orderclose$")]
        public IHttpContext Handle_OrderClose_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), OrderClose_1);
        }

        /// <summary>
        /// <b>Function:</b> OrderClose<br>
        /// <b>Description:</b> Closes opened order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/orderclose.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>ticket</b> :  [in] Unique number of the order ticket.</li>
        /// <li><b>lots</b> :  [in] Number of lots.</li>
        /// <li><b>price</b> :  [in] Closing price.</li>
        /// <li><b>slippage</b> :  [in] Value of the maximum price slippage in points.</li>
        /// <li><b>arrow_color</b> :  [in] Color of the closing arrow on the chart. If the parameter is missing or has CLR_NONE value closing arrow will not be drawn on the chart.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/orderclose$")]
        public IHttpContext Handle_OrderClose_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, OrderClose_1);
        }

        private async Task<JObject> OrderClose_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "ticket");
            ParamAdd(context, parameters, "lots");
            ParamAdd(context, parameters, "price");
            ParamAdd(context, parameters, "slippage");
            ParamAdd(context, parameters, "arrow_color");
            await ExecCommandAsync(context, MQLCommand.OrderClose_1, parameters); // MQLCommand ENUM = 107

            result["result"] = (bool)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> OrderCloseBy<br>
        /// <b>Description:</b> Closes an opened order by another opposite opened order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/ordercloseby.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>ticket</b> :  [in] Unique number of the order ticket.</li>
        /// <li><b>opposite</b> :  [in] Unique number of the opposite order ticket.</li>
        /// <li><b>arrow_color</b> :  [in] Color of the closing arrow on the chart. If the parameter is missing or has CLR_NONE value closing arrow will not be drawn on the chart.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/ordercloseby$")]
        public IHttpContext Handle_OrderCloseBy_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), OrderCloseBy_1);
        }

        /// <summary>
        /// <b>Function:</b> OrderCloseBy<br>
        /// <b>Description:</b> Closes an opened order by another opposite opened order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/ordercloseby.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>ticket</b> :  [in] Unique number of the order ticket.</li>
        /// <li><b>opposite</b> :  [in] Unique number of the opposite order ticket.</li>
        /// <li><b>arrow_color</b> :  [in] Color of the closing arrow on the chart. If the parameter is missing or has CLR_NONE value closing arrow will not be drawn on the chart.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/ordercloseby$")]
        public IHttpContext Handle_OrderCloseBy_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, OrderCloseBy_1);
        }

        private async Task<JObject> OrderCloseBy_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "ticket");
            ParamAdd(context, parameters, "opposite");
            ParamAdd(context, parameters, "arrow_color");
            await ExecCommandAsync(context, MQLCommand.OrderCloseBy_1, parameters); // MQLCommand ENUM = 108

            result["result"] = (bool)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> OrderClosePrice<br>
        /// <b>Description:</b> Returns close price of the currently selected order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/ordercloseprice.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/ordercloseprice$")]
        public IHttpContext Handle_OrderClosePrice_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), OrderClosePrice_1);
        }

        /// <summary>
        /// <b>Function:</b> OrderClosePrice<br>
        /// <b>Description:</b> Returns close price of the currently selected order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/ordercloseprice.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/ordercloseprice$")]
        public IHttpContext Handle_OrderClosePrice_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, OrderClosePrice_1);
        }

        private async Task<JObject> OrderClosePrice_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.OrderClosePrice_1, parameters); // MQLCommand ENUM = 109

            result["result"] = Convert.ToDecimal(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> OrderCloseTime<br>
        /// <b>Description:</b> Returns close time of the currently selected order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/orderclosetime.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/orderclosetime$")]
        public IHttpContext Handle_OrderCloseTime_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), OrderCloseTime_1);
        }

        /// <summary>
        /// <b>Function:</b> OrderCloseTime<br>
        /// <b>Description:</b> Returns close time of the currently selected order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/orderclosetime.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/orderclosetime$")]
        public IHttpContext Handle_OrderCloseTime_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, OrderCloseTime_1);
        }

        private async Task<JObject> OrderCloseTime_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.OrderCloseTime_1, parameters); // MQLCommand ENUM = 110

            result["result"] = (DateTime)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> OrderComment<br>
        /// <b>Description:</b> Returns comment of the currently selected order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/ordercomment.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/ordercomment$")]
        public IHttpContext Handle_OrderComment_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), OrderComment_1);
        }

        /// <summary>
        /// <b>Function:</b> OrderComment<br>
        /// <b>Description:</b> Returns comment of the currently selected order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/ordercomment.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/ordercomment$")]
        public IHttpContext Handle_OrderComment_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, OrderComment_1);
        }

        private async Task<JObject> OrderComment_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.OrderComment_1, parameters); // MQLCommand ENUM = 111

            result["result"] = (string)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> OrderCommission<br>
        /// <b>Description:</b> Returns calculated commission of the currently selected order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/ordercommission.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/ordercommission$")]
        public IHttpContext Handle_OrderCommission_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), OrderCommission_1);
        }

        /// <summary>
        /// <b>Function:</b> OrderCommission<br>
        /// <b>Description:</b> Returns calculated commission of the currently selected order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/ordercommission.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/ordercommission$")]
        public IHttpContext Handle_OrderCommission_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, OrderCommission_1);
        }

        private async Task<JObject> OrderCommission_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.OrderCommission_1, parameters); // MQLCommand ENUM = 112

            result["result"] = Convert.ToDecimal(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> OrderDelete<br>
        /// <b>Description:</b> Deletes previously opened pending order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/orderdelete.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>ticket</b> :  [in] Unique number of the order ticket.</li>
        /// <li><b>arrow_color</b> :  [in] Color of the arrow on the chart. If the parameter is missing or has CLR_NONE value arrow will not be drawn on the chart.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/orderdelete$")]
        public IHttpContext Handle_OrderDelete_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), OrderDelete_1);
        }

        /// <summary>
        /// <b>Function:</b> OrderDelete<br>
        /// <b>Description:</b> Deletes previously opened pending order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/orderdelete.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>ticket</b> :  [in] Unique number of the order ticket.</li>
        /// <li><b>arrow_color</b> :  [in] Color of the arrow on the chart. If the parameter is missing or has CLR_NONE value arrow will not be drawn on the chart.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/orderdelete$")]
        public IHttpContext Handle_OrderDelete_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, OrderDelete_1);
        }

        private async Task<JObject> OrderDelete_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "ticket");
            ParamAdd(context, parameters, "arrow_color");
            await ExecCommandAsync(context, MQLCommand.OrderDelete_1, parameters); // MQLCommand ENUM = 113

            result["result"] = (bool)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> OrderExpiration<br>
        /// <b>Description:</b> Returns expiration date of the selected pending order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/orderexpiration.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/orderexpiration$")]
        public IHttpContext Handle_OrderExpiration_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), OrderExpiration_1);
        }

        /// <summary>
        /// <b>Function:</b> OrderExpiration<br>
        /// <b>Description:</b> Returns expiration date of the selected pending order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/orderexpiration.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/orderexpiration$")]
        public IHttpContext Handle_OrderExpiration_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, OrderExpiration_1);
        }

        private async Task<JObject> OrderExpiration_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.OrderExpiration_1, parameters); // MQLCommand ENUM = 114

            result["result"] = (DateTime)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> OrderLots<br>
        /// <b>Description:</b> Returns amount of lots of the selected order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/orderlots.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/orderlots$")]
        public IHttpContext Handle_OrderLots_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), OrderLots_1);
        }

        /// <summary>
        /// <b>Function:</b> OrderLots<br>
        /// <b>Description:</b> Returns amount of lots of the selected order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/orderlots.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/orderlots$")]
        public IHttpContext Handle_OrderLots_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, OrderLots_1);
        }

        private async Task<JObject> OrderLots_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.OrderLots_1, parameters); // MQLCommand ENUM = 115

            result["result"] = Convert.ToDecimal(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> OrderMagicNumber<br>
        /// <b>Description:</b> Returns an identifying (magic) number of the currently selected order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/ordermagicnumber.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/ordermagicnumber$")]
        public IHttpContext Handle_OrderMagicNumber_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), OrderMagicNumber_1);
        }

        /// <summary>
        /// <b>Function:</b> OrderMagicNumber<br>
        /// <b>Description:</b> Returns an identifying (magic) number of the currently selected order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/ordermagicnumber.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/ordermagicnumber$")]
        public IHttpContext Handle_OrderMagicNumber_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, OrderMagicNumber_1);
        }

        private async Task<JObject> OrderMagicNumber_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.OrderMagicNumber_1, parameters); // MQLCommand ENUM = 116

            result["result"] = Convert.ToInt32(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> OrderModify<br>
        /// <b>Description:</b> Modification of characteristics of the previously opened or pending orders.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/ordermodify.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>ticket</b> :  [in] Unique number of the order ticket.</li>
        /// <li><b>price</b> :  [in] New open price of the pending order.</li>
        /// <li><b>stoploss</b> :  [in] New StopLoss level.</li>
        /// <li><b>takeprofit</b> :  [in] New TakeProfit level.</li>
        /// <li><b>expiration</b> :  [in] Pending order expiration time.</li>
        /// <li><b>arrow_color</b> :  [in] Arrow color for StopLoss/TakeProfit modifications in the chart. If the parameter is missing or has CLR_NONE value, the arrows will not be shown in the chart.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/ordermodify$")]
        public IHttpContext Handle_OrderModify_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), OrderModify_1);
        }

        /// <summary>
        /// <b>Function:</b> OrderModify<br>
        /// <b>Description:</b> Modification of characteristics of the previously opened or pending orders.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/ordermodify.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>ticket</b> :  [in] Unique number of the order ticket.</li>
        /// <li><b>price</b> :  [in] New open price of the pending order.</li>
        /// <li><b>stoploss</b> :  [in] New StopLoss level.</li>
        /// <li><b>takeprofit</b> :  [in] New TakeProfit level.</li>
        /// <li><b>expiration</b> :  [in] Pending order expiration time.</li>
        /// <li><b>arrow_color</b> :  [in] Arrow color for StopLoss/TakeProfit modifications in the chart. If the parameter is missing or has CLR_NONE value, the arrows will not be shown in the chart.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/ordermodify$")]
        public IHttpContext Handle_OrderModify_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, OrderModify_1);
        }

        private async Task<JObject> OrderModify_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "ticket");
            ParamAdd(context, parameters, "price");
            ParamAdd(context, parameters, "stoploss");
            ParamAdd(context, parameters, "takeprofit");
            ParamAdd(context, parameters, "expiration");
            ParamAdd(context, parameters, "arrow_color");
            await ExecCommandAsync(context, MQLCommand.OrderModify_1, parameters); // MQLCommand ENUM = 117

            result["result"] = (bool)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> OrderOpenPrice<br>
        /// <b>Description:</b> Returns open price of the currently selected order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/orderopenprice.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/orderopenprice$")]
        public IHttpContext Handle_OrderOpenPrice_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), OrderOpenPrice_1);
        }

        /// <summary>
        /// <b>Function:</b> OrderOpenPrice<br>
        /// <b>Description:</b> Returns open price of the currently selected order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/orderopenprice.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/orderopenprice$")]
        public IHttpContext Handle_OrderOpenPrice_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, OrderOpenPrice_1);
        }

        private async Task<JObject> OrderOpenPrice_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.OrderOpenPrice_1, parameters); // MQLCommand ENUM = 118

            result["result"] = Convert.ToDecimal(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> OrderOpenTime<br>
        /// <b>Description:</b> Returns open time of the currently selected order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/orderopentime.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/orderopentime$")]
        public IHttpContext Handle_OrderOpenTime_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), OrderOpenTime_1);
        }

        /// <summary>
        /// <b>Function:</b> OrderOpenTime<br>
        /// <b>Description:</b> Returns open time of the currently selected order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/orderopentime.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/orderopentime$")]
        public IHttpContext Handle_OrderOpenTime_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, OrderOpenTime_1);
        }

        private async Task<JObject> OrderOpenTime_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.OrderOpenTime_1, parameters); // MQLCommand ENUM = 119

            result["result"] = (DateTime)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> OrderPrint<br>
        /// <b>Description:</b> Prints information about the selected order in the log.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/orderprint.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/orderprint$")]
        public IHttpContext Handle_OrderPrint_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), OrderPrint_1);
        }

        /// <summary>
        /// <b>Function:</b> OrderPrint<br>
        /// <b>Description:</b> Prints information about the selected order in the log.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/orderprint.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/orderprint$")]
        public IHttpContext Handle_OrderPrint_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, OrderPrint_1);
        }

        private async Task<JObject> OrderPrint_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.OrderPrint_1, parameters); // MQLCommand ENUM = 120

            result["result"] = "";

            return result;
        }
        /// <summary>
        /// <b>Function:</b> OrderProfit<br>
        /// <b>Description:</b> Returns profit of the currently selected order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/orderprofit.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/orderprofit$")]
        public IHttpContext Handle_OrderProfit_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), OrderProfit_1);
        }

        /// <summary>
        /// <b>Function:</b> OrderProfit<br>
        /// <b>Description:</b> Returns profit of the currently selected order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/orderprofit.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/orderprofit$")]
        public IHttpContext Handle_OrderProfit_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, OrderProfit_1);
        }

        private async Task<JObject> OrderProfit_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.OrderProfit_1, parameters); // MQLCommand ENUM = 121

            result["result"] = Convert.ToDecimal(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> OrderSelect<br>
        /// <b>Description:</b> The function selects an order for further processing.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/orderselect.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>index</b> :  </li>
        /// <li><b>select</b> :  [in] Selecting flags. It can be any of the following values:</li>
        /// <li><b>pool</b> :  SELECT_BY_POS - index in the order pool, SELECT_BY_TICKET - index is order ticket.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/orderselect$")]
        public IHttpContext Handle_OrderSelect_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), OrderSelect_1);
        }

        /// <summary>
        /// <b>Function:</b> OrderSelect<br>
        /// <b>Description:</b> The function selects an order for further processing.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/orderselect.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>index</b> :  </li>
        /// <li><b>select</b> :  [in] Selecting flags. It can be any of the following values:</li>
        /// <li><b>pool</b> :  SELECT_BY_POS - index in the order pool, SELECT_BY_TICKET - index is order ticket.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/orderselect$")]
        public IHttpContext Handle_OrderSelect_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, OrderSelect_1);
        }

        private async Task<JObject> OrderSelect_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "index");
            ParamAdd(context, parameters, "select");
            ParamAdd(context, parameters, "pool");
            await ExecCommandAsync(context, MQLCommand.OrderSelect_1, parameters); // MQLCommand ENUM = 122

            result["result"] = (bool)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> OrderSend<br>
        /// <b>Description:</b> The main function used to open market or place a pending order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/ordersend.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol for trading.</li>
        /// <li><b>cmd</b> :  [in] Operation type. It can be any of the enumeration.</li>
        /// <li><b>volume</b> :  [in] Number of lots.</li>
        /// <li><b>price</b> :  [in] Order price.</li>
        /// <li><b>slippage</b> :  [in] Maximum price slippage for buy or sell orders.</li>
        /// <li><b>stoploss</b> :  [in] Stop loss level.</li>
        /// <li><b>takeprofit</b> :  [in] Take profit level.</li>
        /// <li><b>comment</b> :  [in] Order comment text. Last part of the comment may be changed by server.</li>
        /// <li><b>magic</b> :  [in] Order magic number. May be used as user defined identifier.</li>
        /// <li><b>expiration</b> :  [in] Order expiration time (for pending orders only).</li>
        /// <li><b>arrow_color</b> :  [in] Color of the opening arrow on the chart. If parameter is missing or has CLR_NONE value opening arrow is not drawn on the chart.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/ordersend$")]
        public IHttpContext Handle_OrderSend_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), OrderSend_1);
        }

        /// <summary>
        /// <b>Function:</b> OrderSend<br>
        /// <b>Description:</b> The main function used to open market or place a pending order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/ordersend.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol for trading.</li>
        /// <li><b>cmd</b> :  [in] Operation type. It can be any of the enumeration.</li>
        /// <li><b>volume</b> :  [in] Number of lots.</li>
        /// <li><b>price</b> :  [in] Order price.</li>
        /// <li><b>slippage</b> :  [in] Maximum price slippage for buy or sell orders.</li>
        /// <li><b>stoploss</b> :  [in] Stop loss level.</li>
        /// <li><b>takeprofit</b> :  [in] Take profit level.</li>
        /// <li><b>comment</b> :  [in] Order comment text. Last part of the comment may be changed by server.</li>
        /// <li><b>magic</b> :  [in] Order magic number. May be used as user defined identifier.</li>
        /// <li><b>expiration</b> :  [in] Order expiration time (for pending orders only).</li>
        /// <li><b>arrow_color</b> :  [in] Color of the opening arrow on the chart. If parameter is missing or has CLR_NONE value opening arrow is not drawn on the chart.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/ordersend$")]
        public IHttpContext Handle_OrderSend_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, OrderSend_1);
        }

        private async Task<JObject> OrderSend_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "symbol");
            ParamAdd(context, parameters, "cmd");
            ParamAdd(context, parameters, "volume");
            ParamAdd(context, parameters, "price");
            ParamAdd(context, parameters, "slippage");
            ParamAdd(context, parameters, "stoploss");
            ParamAdd(context, parameters, "takeprofit");
            ParamAdd(context, parameters, "comment");
            ParamAdd(context, parameters, "magic");
            ParamAdd(context, parameters, "expiration");
            ParamAdd(context, parameters, "arrow_color");
            await ExecCommandAsync(context, MQLCommand.OrderSend_1, parameters); // MQLCommand ENUM = 123

            result["result"] = Convert.ToInt32(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> OrdersHistoryTotal<br>
        /// <b>Description:</b> Returns the number of closed orders in the account history loaded into the terminal.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/ordershistorytotal.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/ordershistorytotal$")]
        public IHttpContext Handle_OrdersHistoryTotal_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), OrdersHistoryTotal_1);
        }

        /// <summary>
        /// <b>Function:</b> OrdersHistoryTotal<br>
        /// <b>Description:</b> Returns the number of closed orders in the account history loaded into the terminal.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/ordershistorytotal.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/ordershistorytotal$")]
        public IHttpContext Handle_OrdersHistoryTotal_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, OrdersHistoryTotal_1);
        }

        private async Task<JObject> OrdersHistoryTotal_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.OrdersHistoryTotal_1, parameters); // MQLCommand ENUM = 124

            result["result"] = Convert.ToInt32(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> OrderStopLoss<br>
        /// <b>Description:</b> Returns stop loss value of the currently selected order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/orderstoploss.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/orderstoploss$")]
        public IHttpContext Handle_OrderStopLoss_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), OrderStopLoss_1);
        }

        /// <summary>
        /// <b>Function:</b> OrderStopLoss<br>
        /// <b>Description:</b> Returns stop loss value of the currently selected order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/orderstoploss.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/orderstoploss$")]
        public IHttpContext Handle_OrderStopLoss_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, OrderStopLoss_1);
        }

        private async Task<JObject> OrderStopLoss_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.OrderStopLoss_1, parameters); // MQLCommand ENUM = 125

            result["result"] = Convert.ToDecimal(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> OrdersTotal<br>
        /// <b>Description:</b> Returns the number of market and pending orders.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/orderstotal.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/orderstotal$")]
        public IHttpContext Handle_OrdersTotal_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), OrdersTotal_1);
        }

        /// <summary>
        /// <b>Function:</b> OrdersTotal<br>
        /// <b>Description:</b> Returns the number of market and pending orders.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/orderstotal.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/orderstotal$")]
        public IHttpContext Handle_OrdersTotal_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, OrdersTotal_1);
        }

        private async Task<JObject> OrdersTotal_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.OrdersTotal_1, parameters); // MQLCommand ENUM = 126

            result["result"] = Convert.ToInt32(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> OrderSwap<br>
        /// <b>Description:</b> Returns swap value of the currently selected order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/orderswap.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/orderswap$")]
        public IHttpContext Handle_OrderSwap_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), OrderSwap_1);
        }

        /// <summary>
        /// <b>Function:</b> OrderSwap<br>
        /// <b>Description:</b> Returns swap value of the currently selected order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/orderswap.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/orderswap$")]
        public IHttpContext Handle_OrderSwap_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, OrderSwap_1);
        }

        private async Task<JObject> OrderSwap_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.OrderSwap_1, parameters); // MQLCommand ENUM = 127

            result["result"] = Convert.ToDecimal(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> OrderSymbol<br>
        /// <b>Description:</b> Returns symbol name of the currently selected order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/ordersymbol.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/ordersymbol$")]
        public IHttpContext Handle_OrderSymbol_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), OrderSymbol_1);
        }

        /// <summary>
        /// <b>Function:</b> OrderSymbol<br>
        /// <b>Description:</b> Returns symbol name of the currently selected order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/ordersymbol.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/ordersymbol$")]
        public IHttpContext Handle_OrderSymbol_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, OrderSymbol_1);
        }

        private async Task<JObject> OrderSymbol_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.OrderSymbol_1, parameters); // MQLCommand ENUM = 128

            result["result"] = (string)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> OrderTakeProfit<br>
        /// <b>Description:</b> Returns take profit value of the currently selected order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/ordertakeprofit.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/ordertakeprofit$")]
        public IHttpContext Handle_OrderTakeProfit_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), OrderTakeProfit_1);
        }

        /// <summary>
        /// <b>Function:</b> OrderTakeProfit<br>
        /// <b>Description:</b> Returns take profit value of the currently selected order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/ordertakeprofit.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/ordertakeprofit$")]
        public IHttpContext Handle_OrderTakeProfit_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, OrderTakeProfit_1);
        }

        private async Task<JObject> OrderTakeProfit_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.OrderTakeProfit_1, parameters); // MQLCommand ENUM = 129

            result["result"] = Convert.ToDecimal(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> OrderTicket<br>
        /// <b>Description:</b> Returns ticket number of the currently selected order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/orderticket.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/orderticket$")]
        public IHttpContext Handle_OrderTicket_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), OrderTicket_1);
        }

        /// <summary>
        /// <b>Function:</b> OrderTicket<br>
        /// <b>Description:</b> Returns ticket number of the currently selected order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/orderticket.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/orderticket$")]
        public IHttpContext Handle_OrderTicket_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, OrderTicket_1);
        }

        private async Task<JObject> OrderTicket_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.OrderTicket_1, parameters); // MQLCommand ENUM = 130

            result["result"] = Convert.ToInt32(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> OrderType<br>
        /// <b>Description:</b> Returns order operation type of the currently selected order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/ordertype.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/ordertype$")]
        public IHttpContext Handle_OrderType_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), OrderType_1);
        }

        /// <summary>
        /// <b>Function:</b> OrderType<br>
        /// <b>Description:</b> Returns order operation type of the currently selected order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/ordertype.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/ordertype$")]
        public IHttpContext Handle_OrderType_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, OrderType_1);
        }

        private async Task<JObject> OrderType_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.OrderType_1, parameters); // MQLCommand ENUM = 131

            result["result"] = Convert.ToInt32(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> SignalBaseGetDouble<br>
        /// <b>Description:</b> Returns the value of<br>
        /// <b>URL:</b> http://docs.mql4.com/signals/signalbasegetdouble.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>property_id</b> :  [in] Signal property identifier. The value can be one of the values of the enumeration.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/signalbasegetdouble$")]
        public IHttpContext Handle_SignalBaseGetDouble_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), SignalBaseGetDouble_1);
        }

        /// <summary>
        /// <b>Function:</b> SignalBaseGetDouble<br>
        /// <b>Description:</b> Returns the value of<br>
        /// <b>URL:</b> http://docs.mql4.com/signals/signalbasegetdouble.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>property_id</b> :  [in] Signal property identifier. The value can be one of the values of the enumeration.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/signalbasegetdouble$")]
        public IHttpContext Handle_SignalBaseGetDouble_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, SignalBaseGetDouble_1);
        }

        private async Task<JObject> SignalBaseGetDouble_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "property_id");
            await ExecCommandAsync(context, MQLCommand.SignalBaseGetDouble_1, parameters); // MQLCommand ENUM = 132

            result["result"] = Convert.ToDecimal(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> SignalBaseGetInteger<br>
        /// <b>Description:</b> Returns the value of<br>
        /// <b>URL:</b> http://docs.mql4.com/signals/signalbasegetinteger.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>property_id</b> :  [in] Signal property identifier. The value can be one of the values of the enumeration.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/signalbasegetinteger$")]
        public IHttpContext Handle_SignalBaseGetInteger_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), SignalBaseGetInteger_1);
        }

        /// <summary>
        /// <b>Function:</b> SignalBaseGetInteger<br>
        /// <b>Description:</b> Returns the value of<br>
        /// <b>URL:</b> http://docs.mql4.com/signals/signalbasegetinteger.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>property_id</b> :  [in] Signal property identifier. The value can be one of the values of the enumeration.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/signalbasegetinteger$")]
        public IHttpContext Handle_SignalBaseGetInteger_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, SignalBaseGetInteger_1);
        }

        private async Task<JObject> SignalBaseGetInteger_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "property_id");
            await ExecCommandAsync(context, MQLCommand.SignalBaseGetInteger_1, parameters); // MQLCommand ENUM = 133

            result["result"] = Convert.ToInt64(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> SignalBaseGetString<br>
        /// <b>Description:</b> Returns the value of<br>
        /// <b>URL:</b> http://docs.mql4.com/signals/signalbasegetstring.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>property_id</b> :  [in] Signal property identifier. The value can be one of the values of the enumeration.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/signalbasegetstring$")]
        public IHttpContext Handle_SignalBaseGetString_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), SignalBaseGetString_1);
        }

        /// <summary>
        /// <b>Function:</b> SignalBaseGetString<br>
        /// <b>Description:</b> Returns the value of<br>
        /// <b>URL:</b> http://docs.mql4.com/signals/signalbasegetstring.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>property_id</b> :  [in] Signal property identifier. The value can be one of the values of the enumeration.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/signalbasegetstring$")]
        public IHttpContext Handle_SignalBaseGetString_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, SignalBaseGetString_1);
        }

        private async Task<JObject> SignalBaseGetString_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "property_id");
            await ExecCommandAsync(context, MQLCommand.SignalBaseGetString_1, parameters); // MQLCommand ENUM = 134

            result["result"] = (string)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> SignalBaseSelect<br>
        /// <b>Description:</b> Selects a signal from signals, available in terminal for further working with it.<br>
        /// <b>URL:</b> http://docs.mql4.com/signals/signalbaseselect.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>index</b> :  [in] Signal index in base of trading signals.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/signalbaseselect$")]
        public IHttpContext Handle_SignalBaseSelect_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), SignalBaseSelect_1);
        }

        /// <summary>
        /// <b>Function:</b> SignalBaseSelect<br>
        /// <b>Description:</b> Selects a signal from signals, available in terminal for further working with it.<br>
        /// <b>URL:</b> http://docs.mql4.com/signals/signalbaseselect.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>index</b> :  [in] Signal index in base of trading signals.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/signalbaseselect$")]
        public IHttpContext Handle_SignalBaseSelect_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, SignalBaseSelect_1);
        }

        private async Task<JObject> SignalBaseSelect_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "index");
            await ExecCommandAsync(context, MQLCommand.SignalBaseSelect_1, parameters); // MQLCommand ENUM = 135

            result["result"] = (bool)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> SignalBaseTotal<br>
        /// <b>Description:</b> Returns the total amount of signals, available in terminal.<br>
        /// <b>URL:</b> http://docs.mql4.com/signals/signalbasetotal.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/signalbasetotal$")]
        public IHttpContext Handle_SignalBaseTotal_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), SignalBaseTotal_1);
        }

        /// <summary>
        /// <b>Function:</b> SignalBaseTotal<br>
        /// <b>Description:</b> Returns the total amount of signals, available in terminal.<br>
        /// <b>URL:</b> http://docs.mql4.com/signals/signalbasetotal.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/signalbasetotal$")]
        public IHttpContext Handle_SignalBaseTotal_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, SignalBaseTotal_1);
        }

        private async Task<JObject> SignalBaseTotal_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.SignalBaseTotal_1, parameters); // MQLCommand ENUM = 136

            result["result"] = Convert.ToInt32(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> SignalInfoGetDouble<br>
        /// <b>Description:</b> Returns the value of<br>
        /// <b>URL:</b> http://docs.mql4.com/signals/signalinfogetdouble.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>property_id</b> :  [in] Signal copy settings property identifier. The value can be one of the values of the enumeration.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/signalinfogetdouble$")]
        public IHttpContext Handle_SignalInfoGetDouble_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), SignalInfoGetDouble_1);
        }

        /// <summary>
        /// <b>Function:</b> SignalInfoGetDouble<br>
        /// <b>Description:</b> Returns the value of<br>
        /// <b>URL:</b> http://docs.mql4.com/signals/signalinfogetdouble.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>property_id</b> :  [in] Signal copy settings property identifier. The value can be one of the values of the enumeration.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/signalinfogetdouble$")]
        public IHttpContext Handle_SignalInfoGetDouble_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, SignalInfoGetDouble_1);
        }

        private async Task<JObject> SignalInfoGetDouble_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "property_id");
            await ExecCommandAsync(context, MQLCommand.SignalInfoGetDouble_1, parameters); // MQLCommand ENUM = 137

            result["result"] = Convert.ToDecimal(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> SignalInfoGetInteger<br>
        /// <b>Description:</b> Returns the value of<br>
        /// <b>URL:</b> http://docs.mql4.com/signals/signalinfogetinteger.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>property_id</b> :  [in] Signal copy settings property identifier. The value can be one of the values of the enumeration.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/signalinfogetinteger$")]
        public IHttpContext Handle_SignalInfoGetInteger_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), SignalInfoGetInteger_1);
        }

        /// <summary>
        /// <b>Function:</b> SignalInfoGetInteger<br>
        /// <b>Description:</b> Returns the value of<br>
        /// <b>URL:</b> http://docs.mql4.com/signals/signalinfogetinteger.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>property_id</b> :  [in] Signal copy settings property identifier. The value can be one of the values of the enumeration.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/signalinfogetinteger$")]
        public IHttpContext Handle_SignalInfoGetInteger_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, SignalInfoGetInteger_1);
        }

        private async Task<JObject> SignalInfoGetInteger_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "property_id");
            await ExecCommandAsync(context, MQLCommand.SignalInfoGetInteger_1, parameters); // MQLCommand ENUM = 138

            result["result"] = Convert.ToInt64(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> SignalInfoGetString<br>
        /// <b>Description:</b> Returns the value of<br>
        /// <b>URL:</b> http://docs.mql4.com/signals/signalinfogetstring.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>property_id</b> :  [in] Signal copy settings property identifier. The value can be one of the values of the enumeration.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/signalinfogetstring$")]
        public IHttpContext Handle_SignalInfoGetString_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), SignalInfoGetString_1);
        }

        /// <summary>
        /// <b>Function:</b> SignalInfoGetString<br>
        /// <b>Description:</b> Returns the value of<br>
        /// <b>URL:</b> http://docs.mql4.com/signals/signalinfogetstring.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>property_id</b> :  [in] Signal copy settings property identifier. The value can be one of the values of the enumeration.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/signalinfogetstring$")]
        public IHttpContext Handle_SignalInfoGetString_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, SignalInfoGetString_1);
        }

        private async Task<JObject> SignalInfoGetString_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "property_id");
            await ExecCommandAsync(context, MQLCommand.SignalInfoGetString_1, parameters); // MQLCommand ENUM = 139

            result["result"] = (string)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> SignalInfoSetDouble<br>
        /// <b>Description:</b> Sets the value of<br>
        /// <b>URL:</b> http://docs.mql4.com/signals/signalinfosetdouble.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>property_id</b> :  [in] Signal copy settings property identifier. The value can be one of the values of the enumeration.</li>
        /// <li><b>value</b> :  [in] The value of signal copy settings property.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/signalinfosetdouble$")]
        public IHttpContext Handle_SignalInfoSetDouble_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), SignalInfoSetDouble_1);
        }

        /// <summary>
        /// <b>Function:</b> SignalInfoSetDouble<br>
        /// <b>Description:</b> Sets the value of<br>
        /// <b>URL:</b> http://docs.mql4.com/signals/signalinfosetdouble.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>property_id</b> :  [in] Signal copy settings property identifier. The value can be one of the values of the enumeration.</li>
        /// <li><b>value</b> :  [in] The value of signal copy settings property.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/signalinfosetdouble$")]
        public IHttpContext Handle_SignalInfoSetDouble_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, SignalInfoSetDouble_1);
        }

        private async Task<JObject> SignalInfoSetDouble_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "property_id");
            ParamAdd(context, parameters, "value");
            await ExecCommandAsync(context, MQLCommand.SignalInfoSetDouble_1, parameters); // MQLCommand ENUM = 140

            result["result"] = (bool)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> SignalInfoSetInteger<br>
        /// <b>Description:</b> Sets the value of<br>
        /// <b>URL:</b> http://docs.mql4.com/signals/signalinfosetinteger.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>property_id</b> :  [in] Signal copy settings property identifier. The value can be one of the values of the enumeration.</li>
        /// <li><b>value</b> :  [in] The value of signal copy settings property.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/signalinfosetinteger$")]
        public IHttpContext Handle_SignalInfoSetInteger_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), SignalInfoSetInteger_1);
        }

        /// <summary>
        /// <b>Function:</b> SignalInfoSetInteger<br>
        /// <b>Description:</b> Sets the value of<br>
        /// <b>URL:</b> http://docs.mql4.com/signals/signalinfosetinteger.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>property_id</b> :  [in] Signal copy settings property identifier. The value can be one of the values of the enumeration.</li>
        /// <li><b>value</b> :  [in] The value of signal copy settings property.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/signalinfosetinteger$")]
        public IHttpContext Handle_SignalInfoSetInteger_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, SignalInfoSetInteger_1);
        }

        private async Task<JObject> SignalInfoSetInteger_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "property_id");
            ParamAdd(context, parameters, "value");
            await ExecCommandAsync(context, MQLCommand.SignalInfoSetInteger_1, parameters); // MQLCommand ENUM = 141

            result["result"] = (bool)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> SignalSubscribe<br>
        /// <b>Description:</b> Subscribes to the trading signal.<br>
        /// <b>URL:</b> http://docs.mql4.com/signals/signalsubscribe.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>signal_id</b> :  [in] Signal identifier.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/signalsubscribe$")]
        public IHttpContext Handle_SignalSubscribe_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), SignalSubscribe_1);
        }

        /// <summary>
        /// <b>Function:</b> SignalSubscribe<br>
        /// <b>Description:</b> Subscribes to the trading signal.<br>
        /// <b>URL:</b> http://docs.mql4.com/signals/signalsubscribe.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>signal_id</b> :  [in] Signal identifier.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/signalsubscribe$")]
        public IHttpContext Handle_SignalSubscribe_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, SignalSubscribe_1);
        }

        private async Task<JObject> SignalSubscribe_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "signal_id");
            await ExecCommandAsync(context, MQLCommand.SignalSubscribe_1, parameters); // MQLCommand ENUM = 142

            result["result"] = (bool)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> SignalUnsubscribe<br>
        /// <b>Description:</b> Cancels subscription.<br>
        /// <b>URL:</b> http://docs.mql4.com/signals/signalunsubscribe.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/signalunsubscribe$")]
        public IHttpContext Handle_SignalUnsubscribe_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), SignalUnsubscribe_1);
        }

        /// <summary>
        /// <b>Function:</b> SignalUnsubscribe<br>
        /// <b>Description:</b> Cancels subscription.<br>
        /// <b>URL:</b> http://docs.mql4.com/signals/signalunsubscribe.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/signalunsubscribe$")]
        public IHttpContext Handle_SignalUnsubscribe_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, SignalUnsubscribe_1);
        }

        private async Task<JObject> SignalUnsubscribe_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.SignalUnsubscribe_1, parameters); // MQLCommand ENUM = 143

            result["result"] = (bool)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> GlobalVariableCheck<br>
        /// <b>Description:</b> Checks the existence of a global variable with the specified name<br>
        /// <b>URL:</b> http://docs.mql4.com/globals/globalvariablecheck.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>name</b> :  [in] Global variable name.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/globalvariablecheck$")]
        public IHttpContext Handle_GlobalVariableCheck_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), GlobalVariableCheck_1);
        }

        /// <summary>
        /// <b>Function:</b> GlobalVariableCheck<br>
        /// <b>Description:</b> Checks the existence of a global variable with the specified name<br>
        /// <b>URL:</b> http://docs.mql4.com/globals/globalvariablecheck.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>name</b> :  [in] Global variable name.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/globalvariablecheck$")]
        public IHttpContext Handle_GlobalVariableCheck_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, GlobalVariableCheck_1);
        }

        private async Task<JObject> GlobalVariableCheck_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "name");
            await ExecCommandAsync(context, MQLCommand.GlobalVariableCheck_1, parameters); // MQLCommand ENUM = 144

            result["result"] = (bool)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> GlobalVariableTime<br>
        /// <b>Description:</b> Returns the time when the global variable was last accessed.<br>
        /// <b>URL:</b> http://docs.mql4.com/globals/globalvariabletime.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>name</b> :  [in] Name of the global variable.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/globalvariabletime$")]
        public IHttpContext Handle_GlobalVariableTime_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), GlobalVariableTime_1);
        }

        /// <summary>
        /// <b>Function:</b> GlobalVariableTime<br>
        /// <b>Description:</b> Returns the time when the global variable was last accessed.<br>
        /// <b>URL:</b> http://docs.mql4.com/globals/globalvariabletime.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>name</b> :  [in] Name of the global variable.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/globalvariabletime$")]
        public IHttpContext Handle_GlobalVariableTime_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, GlobalVariableTime_1);
        }

        private async Task<JObject> GlobalVariableTime_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "name");
            await ExecCommandAsync(context, MQLCommand.GlobalVariableTime_1, parameters); // MQLCommand ENUM = 145

            result["result"] = (DateTime)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> GlobalVariableDel<br>
        /// <b>Description:</b> Deletes a global variable from the client terminal<br>
        /// <b>URL:</b> http://docs.mql4.com/globals/globalvariabledel.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>name</b> :  [in] Global variable name.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/globalvariabledel$")]
        public IHttpContext Handle_GlobalVariableDel_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), GlobalVariableDel_1);
        }

        /// <summary>
        /// <b>Function:</b> GlobalVariableDel<br>
        /// <b>Description:</b> Deletes a global variable from the client terminal<br>
        /// <b>URL:</b> http://docs.mql4.com/globals/globalvariabledel.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>name</b> :  [in] Global variable name.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/globalvariabledel$")]
        public IHttpContext Handle_GlobalVariableDel_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, GlobalVariableDel_1);
        }

        private async Task<JObject> GlobalVariableDel_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "name");
            await ExecCommandAsync(context, MQLCommand.GlobalVariableDel_1, parameters); // MQLCommand ENUM = 146

            result["result"] = (bool)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> GlobalVariableGet<br>
        /// <b>Description:</b> Returns the value of an existing global variable of the client terminal. There are 2 variants of the function.<br>
        /// <b>URL:</b> http://docs.mql4.com/globals/globalvariableget.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>name</b> :  [in] Global variable name.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/globalvariableget$")]
        public IHttpContext Handle_GlobalVariableGet_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), GlobalVariableGet_1);
        }

        /// <summary>
        /// <b>Function:</b> GlobalVariableGet<br>
        /// <b>Description:</b> Returns the value of an existing global variable of the client terminal. There are 2 variants of the function.<br>
        /// <b>URL:</b> http://docs.mql4.com/globals/globalvariableget.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>name</b> :  [in] Global variable name.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/globalvariableget$")]
        public IHttpContext Handle_GlobalVariableGet_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, GlobalVariableGet_1);
        }

        private async Task<JObject> GlobalVariableGet_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "name");
            await ExecCommandAsync(context, MQLCommand.GlobalVariableGet_1, parameters); // MQLCommand ENUM = 147

            result["result"] = Convert.ToDecimal(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> GlobalVariableName<br>
        /// <b>Description:</b> Returns the name of a global variable by its ordinal number.<br>
        /// <b>URL:</b> http://docs.mql4.com/globals/globalvariablename.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>index</b> :  [in] Sequence number in the list of global variables. It should be greater than or equal to 0 and less than .</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/globalvariablename$")]
        public IHttpContext Handle_GlobalVariableName_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), GlobalVariableName_1);
        }

        /// <summary>
        /// <b>Function:</b> GlobalVariableName<br>
        /// <b>Description:</b> Returns the name of a global variable by its ordinal number.<br>
        /// <b>URL:</b> http://docs.mql4.com/globals/globalvariablename.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>index</b> :  [in] Sequence number in the list of global variables. It should be greater than or equal to 0 and less than .</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/globalvariablename$")]
        public IHttpContext Handle_GlobalVariableName_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, GlobalVariableName_1);
        }

        private async Task<JObject> GlobalVariableName_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "index");
            await ExecCommandAsync(context, MQLCommand.GlobalVariableName_1, parameters); // MQLCommand ENUM = 148

            result["result"] = (string)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> GlobalVariableSet<br>
        /// <b>Description:</b> Sets a new value for a global variable. If the variable does not exist, the system creates a new global variable.<br>
        /// <b>URL:</b> http://docs.mql4.com/globals/globalvariableset.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>name</b> :  [in] Global variable name.</li>
        /// <li><b>value</b> :  [in] The new numerical value.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/globalvariableset$")]
        public IHttpContext Handle_GlobalVariableSet_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), GlobalVariableSet_1);
        }

        /// <summary>
        /// <b>Function:</b> GlobalVariableSet<br>
        /// <b>Description:</b> Sets a new value for a global variable. If the variable does not exist, the system creates a new global variable.<br>
        /// <b>URL:</b> http://docs.mql4.com/globals/globalvariableset.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>name</b> :  [in] Global variable name.</li>
        /// <li><b>value</b> :  [in] The new numerical value.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/globalvariableset$")]
        public IHttpContext Handle_GlobalVariableSet_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, GlobalVariableSet_1);
        }

        private async Task<JObject> GlobalVariableSet_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "name");
            ParamAdd(context, parameters, "value");
            await ExecCommandAsync(context, MQLCommand.GlobalVariableSet_1, parameters); // MQLCommand ENUM = 149

            result["result"] = (DateTime)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> GlobalVariablesFlush<br>
        /// <b>Description:</b> Forcibly saves contents of all global variables to a disk.<br>
        /// <b>URL:</b> http://docs.mql4.com/globals/globalvariablesflush.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/globalvariablesflush$")]
        public IHttpContext Handle_GlobalVariablesFlush_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), GlobalVariablesFlush_1);
        }

        /// <summary>
        /// <b>Function:</b> GlobalVariablesFlush<br>
        /// <b>Description:</b> Forcibly saves contents of all global variables to a disk.<br>
        /// <b>URL:</b> http://docs.mql4.com/globals/globalvariablesflush.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/globalvariablesflush$")]
        public IHttpContext Handle_GlobalVariablesFlush_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, GlobalVariablesFlush_1);
        }

        private async Task<JObject> GlobalVariablesFlush_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.GlobalVariablesFlush_1, parameters); // MQLCommand ENUM = 150

            result["result"] = "";

            return result;
        }
        /// <summary>
        /// <b>Function:</b> GlobalVariableTemp<br>
        /// <b>Description:</b> The function attempts to create a temporary global variable. If the variable doesn't exist, the system creates a new temporary global variable.<br>
        /// <b>URL:</b> http://docs.mql4.com/globals/globalvariabletemp.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>name</b> :  [in] The name of a temporary global variable.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/globalvariabletemp$")]
        public IHttpContext Handle_GlobalVariableTemp_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), GlobalVariableTemp_1);
        }

        /// <summary>
        /// <b>Function:</b> GlobalVariableTemp<br>
        /// <b>Description:</b> The function attempts to create a temporary global variable. If the variable doesn't exist, the system creates a new temporary global variable.<br>
        /// <b>URL:</b> http://docs.mql4.com/globals/globalvariabletemp.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>name</b> :  [in] The name of a temporary global variable.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/globalvariabletemp$")]
        public IHttpContext Handle_GlobalVariableTemp_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, GlobalVariableTemp_1);
        }

        private async Task<JObject> GlobalVariableTemp_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "name");
            await ExecCommandAsync(context, MQLCommand.GlobalVariableTemp_1, parameters); // MQLCommand ENUM = 151

            result["result"] = (bool)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> GlobalVariableSetOnCondition<br>
        /// <b>Description:</b> Sets the new value of the existing global variable if the current value equals to the third parameter check_value. If there is no global variable, the function will generate an error ERR_GLOBALVARIABLE_NOT_FOUND (4501) and return false.<br>
        /// <b>URL:</b> http://docs.mql4.com/globals/globalvariablesetoncondition.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>name</b> :  [in] The name of a global variable.</li>
        /// <li><b>value</b> :  [in] New value.</li>
        /// <li><b>check_value</b> :  [in] The value to check the current value of the global variable.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/globalvariablesetoncondition$")]
        public IHttpContext Handle_GlobalVariableSetOnCondition_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), GlobalVariableSetOnCondition_1);
        }

        /// <summary>
        /// <b>Function:</b> GlobalVariableSetOnCondition<br>
        /// <b>Description:</b> Sets the new value of the existing global variable if the current value equals to the third parameter check_value. If there is no global variable, the function will generate an error ERR_GLOBALVARIABLE_NOT_FOUND (4501) and return false.<br>
        /// <b>URL:</b> http://docs.mql4.com/globals/globalvariablesetoncondition.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>name</b> :  [in] The name of a global variable.</li>
        /// <li><b>value</b> :  [in] New value.</li>
        /// <li><b>check_value</b> :  [in] The value to check the current value of the global variable.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/globalvariablesetoncondition$")]
        public IHttpContext Handle_GlobalVariableSetOnCondition_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, GlobalVariableSetOnCondition_1);
        }

        private async Task<JObject> GlobalVariableSetOnCondition_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "name");
            ParamAdd(context, parameters, "value");
            ParamAdd(context, parameters, "check_value");
            await ExecCommandAsync(context, MQLCommand.GlobalVariableSetOnCondition_1, parameters); // MQLCommand ENUM = 152

            result["result"] = (bool)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> GlobalVariablesDeleteAll<br>
        /// <b>Description:</b> Deletes global variables of the client terminal.<br>
        /// <b>URL:</b> http://docs.mql4.com/globals/globalvariablesdeleteall.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>prefix_name</b> :  [in] Name prefix global variables to remove. If you specify a prefix NULL or empty string, then all variables that meet the data criterion will be deleted.</li>
        /// <li><b>limit_data</b> :  [in] Optional parameter. Date to select global variables by the time of their last modification. The function removes global variables, which were changed before this date. If the parameter is zero, then all variables that meet the first criterion (prefix) are deleted.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/globalvariablesdeleteall$")]
        public IHttpContext Handle_GlobalVariablesDeleteAll_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), GlobalVariablesDeleteAll_1);
        }

        /// <summary>
        /// <b>Function:</b> GlobalVariablesDeleteAll<br>
        /// <b>Description:</b> Deletes global variables of the client terminal.<br>
        /// <b>URL:</b> http://docs.mql4.com/globals/globalvariablesdeleteall.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>prefix_name</b> :  [in] Name prefix global variables to remove. If you specify a prefix NULL or empty string, then all variables that meet the data criterion will be deleted.</li>
        /// <li><b>limit_data</b> :  [in] Optional parameter. Date to select global variables by the time of their last modification. The function removes global variables, which were changed before this date. If the parameter is zero, then all variables that meet the first criterion (prefix) are deleted.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/globalvariablesdeleteall$")]
        public IHttpContext Handle_GlobalVariablesDeleteAll_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, GlobalVariablesDeleteAll_1);
        }

        private async Task<JObject> GlobalVariablesDeleteAll_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "prefix_name");
            ParamAdd(context, parameters, "limit_data");
            await ExecCommandAsync(context, MQLCommand.GlobalVariablesDeleteAll_1, parameters); // MQLCommand ENUM = 153

            result["result"] = Convert.ToInt32(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> GlobalVariablesTotal<br>
        /// <b>Description:</b> Returns the total number of global variables of the client terminal.<br>
        /// <b>URL:</b> http://docs.mql4.com/globals/globalvariablestotal.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/globalvariablestotal$")]
        public IHttpContext Handle_GlobalVariablesTotal_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), GlobalVariablesTotal_1);
        }

        /// <summary>
        /// <b>Function:</b> GlobalVariablesTotal<br>
        /// <b>Description:</b> Returns the total number of global variables of the client terminal.<br>
        /// <b>URL:</b> http://docs.mql4.com/globals/globalvariablestotal.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/globalvariablestotal$")]
        public IHttpContext Handle_GlobalVariablesTotal_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, GlobalVariablesTotal_1);
        }

        private async Task<JObject> GlobalVariablesTotal_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.GlobalVariablesTotal_1, parameters); // MQLCommand ENUM = 154

            result["result"] = Convert.ToInt32(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> HideTestIndicators<br>
        /// <b>Description:</b> The function sets a flag hiding indicators called by the Expert Advisor.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/hidetestindicators.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>hide</b> :  [in] Hiding flag.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/hidetestindicators$")]
        public IHttpContext Handle_HideTestIndicators_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), HideTestIndicators_1);
        }

        /// <summary>
        /// <b>Function:</b> HideTestIndicators<br>
        /// <b>Description:</b> The function sets a flag hiding indicators called by the Expert Advisor.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/hidetestindicators.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>hide</b> :  [in] Hiding flag.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/hidetestindicators$")]
        public IHttpContext Handle_HideTestIndicators_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, HideTestIndicators_1);
        }

        private async Task<JObject> HideTestIndicators_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "hide");
            await ExecCommandAsync(context, MQLCommand.HideTestIndicators_1, parameters); // MQLCommand ENUM = 155

            result["result"] = "";

            return result;
        }
        /// <summary>
        /// <b>Function:</b> IndicatorSetDouble<br>
        /// <b>Description:</b> The function sets the value of the corresponding indicator property. Indicator property must be of the double type. There are two variants of the function.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/indicatorsetdouble.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>prop_id</b> :  [in] Identifier of the indicator property. The value can be one of the values of the enumeration.</li>
        /// <li><b>prop_value</b> :  [in] Value of property.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/indicatorsetdouble$")]
        public IHttpContext Handle_IndicatorSetDouble_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), IndicatorSetDouble_1);
        }

        /// <summary>
        /// <b>Function:</b> IndicatorSetDouble<br>
        /// <b>Description:</b> The function sets the value of the corresponding indicator property. Indicator property must be of the double type. There are two variants of the function.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/indicatorsetdouble.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>prop_id</b> :  [in] Identifier of the indicator property. The value can be one of the values of the enumeration.</li>
        /// <li><b>prop_value</b> :  [in] Value of property.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/indicatorsetdouble$")]
        public IHttpContext Handle_IndicatorSetDouble_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, IndicatorSetDouble_1);
        }

        private async Task<JObject> IndicatorSetDouble_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "prop_id");
            ParamAdd(context, parameters, "prop_value");
            await ExecCommandAsync(context, MQLCommand.IndicatorSetDouble_1, parameters); // MQLCommand ENUM = 156

            result["result"] = (bool)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> IndicatorSetDouble<br>
        /// <b>Description:</b> The function sets the value of the corresponding indicator property. Indicator property must be of the double type. There are two variants of the function.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/indicatorsetdouble.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>prop_id</b> :  [in] Identifier of the indicator property. The value can be one of the values of the enumeration.</li>
        /// <li><b>prop_modifier</b> :  [in] Modifier of the specified property. Only level properties require a modifier. Numbering of levels starts from 0. It means that in order to set property for the second level you need to specify 1 (1 less than when using ).</li>
        /// <li><b>prop_value</b> :  [in] Value of property.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/indicatorsetdouble$")]
        public IHttpContext Handle_IndicatorSetDouble_2(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), IndicatorSetDouble_2);
        }

        /// <summary>
        /// <b>Function:</b> IndicatorSetDouble<br>
        /// <b>Description:</b> The function sets the value of the corresponding indicator property. Indicator property must be of the double type. There are two variants of the function.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/indicatorsetdouble.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>prop_id</b> :  [in] Identifier of the indicator property. The value can be one of the values of the enumeration.</li>
        /// <li><b>prop_modifier</b> :  [in] Modifier of the specified property. Only level properties require a modifier. Numbering of levels starts from 0. It means that in order to set property for the second level you need to specify 1 (1 less than when using ).</li>
        /// <li><b>prop_value</b> :  [in] Value of property.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/indicatorsetdouble$")]
        public IHttpContext Handle_IndicatorSetDouble_2_Default(IHttpContext context)
        {
            return SendJsonResponse(context, IndicatorSetDouble_2);
        }

        private async Task<JObject> IndicatorSetDouble_2(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "prop_id");
            ParamAdd(context, parameters, "prop_modifier");
            ParamAdd(context, parameters, "prop_value");
            await ExecCommandAsync(context, MQLCommand.IndicatorSetDouble_2, parameters); // MQLCommand ENUM = 156

            result["result"] = (bool)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> IndicatorSetInteger<br>
        /// <b>Description:</b> The function sets the value of the corresponding indicator property. Indicator property must be of the int or color type. There are two variants of the function.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/indicatorsetinteger.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>prop_id</b> :  [in] Identifier of the indicator property. The value can be one of the values of the enumeration.</li>
        /// <li><b>prop_value</b> :  [in] Value of property.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/indicatorsetinteger$")]
        public IHttpContext Handle_IndicatorSetInteger_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), IndicatorSetInteger_1);
        }

        /// <summary>
        /// <b>Function:</b> IndicatorSetInteger<br>
        /// <b>Description:</b> The function sets the value of the corresponding indicator property. Indicator property must be of the int or color type. There are two variants of the function.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/indicatorsetinteger.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>prop_id</b> :  [in] Identifier of the indicator property. The value can be one of the values of the enumeration.</li>
        /// <li><b>prop_value</b> :  [in] Value of property.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/indicatorsetinteger$")]
        public IHttpContext Handle_IndicatorSetInteger_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, IndicatorSetInteger_1);
        }

        private async Task<JObject> IndicatorSetInteger_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "prop_id");
            ParamAdd(context, parameters, "prop_value");
            await ExecCommandAsync(context, MQLCommand.IndicatorSetInteger_1, parameters); // MQLCommand ENUM = 157

            result["result"] = (bool)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> IndicatorSetInteger<br>
        /// <b>Description:</b> The function sets the value of the corresponding indicator property. Indicator property must be of the int or color type. There are two variants of the function.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/indicatorsetinteger.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>prop_id</b> :  [in] Identifier of the indicator property. The value can be one of the values of the enumeration.</li>
        /// <li><b>prop_modifier</b> :  [in] Modifier of the specified property. Only level properties require a modifier.</li>
        /// <li><b>prop_value</b> :  [in] Value of property.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/indicatorsetinteger$")]
        public IHttpContext Handle_IndicatorSetInteger_2(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), IndicatorSetInteger_2);
        }

        /// <summary>
        /// <b>Function:</b> IndicatorSetInteger<br>
        /// <b>Description:</b> The function sets the value of the corresponding indicator property. Indicator property must be of the int or color type. There are two variants of the function.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/indicatorsetinteger.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>prop_id</b> :  [in] Identifier of the indicator property. The value can be one of the values of the enumeration.</li>
        /// <li><b>prop_modifier</b> :  [in] Modifier of the specified property. Only level properties require a modifier.</li>
        /// <li><b>prop_value</b> :  [in] Value of property.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/indicatorsetinteger$")]
        public IHttpContext Handle_IndicatorSetInteger_2_Default(IHttpContext context)
        {
            return SendJsonResponse(context, IndicatorSetInteger_2);
        }

        private async Task<JObject> IndicatorSetInteger_2(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "prop_id");
            ParamAdd(context, parameters, "prop_modifier");
            ParamAdd(context, parameters, "prop_value");
            await ExecCommandAsync(context, MQLCommand.IndicatorSetInteger_2, parameters); // MQLCommand ENUM = 157

            result["result"] = (bool)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> IndicatorSetString<br>
        /// <b>Description:</b> The function sets the value of the corresponding indicator property. Indicator property must be of the string type. There are two variants of the function.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/indicatorsetstring.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>prop_id</b> :  [in] Identifier of the indicator property. The value can be one of the values of the enumeration.</li>
        /// <li><b>prop_value</b> :  [in] Value of property.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/indicatorsetstring$")]
        public IHttpContext Handle_IndicatorSetString_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), IndicatorSetString_1);
        }

        /// <summary>
        /// <b>Function:</b> IndicatorSetString<br>
        /// <b>Description:</b> The function sets the value of the corresponding indicator property. Indicator property must be of the string type. There are two variants of the function.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/indicatorsetstring.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>prop_id</b> :  [in] Identifier of the indicator property. The value can be one of the values of the enumeration.</li>
        /// <li><b>prop_value</b> :  [in] Value of property.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/indicatorsetstring$")]
        public IHttpContext Handle_IndicatorSetString_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, IndicatorSetString_1);
        }

        private async Task<JObject> IndicatorSetString_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "prop_id");
            ParamAdd(context, parameters, "prop_value");
            await ExecCommandAsync(context, MQLCommand.IndicatorSetString_1, parameters); // MQLCommand ENUM = 158

            result["result"] = (bool)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> IndicatorSetString<br>
        /// <b>Description:</b> The function sets the value of the corresponding indicator property. Indicator property must be of the string type. There are two variants of the function.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/indicatorsetstring.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>prop_id</b> :  [in] Identifier of the indicator property. The value can be one of the values of the enumeration.</li>
        /// <li><b>prop_modifier</b> :  [in] Modifier of the specified property. Only level properties require a modifier.</li>
        /// <li><b>prop_value</b> :  [in] Value of property.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/indicatorsetstring$")]
        public IHttpContext Handle_IndicatorSetString_2(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), IndicatorSetString_2);
        }

        /// <summary>
        /// <b>Function:</b> IndicatorSetString<br>
        /// <b>Description:</b> The function sets the value of the corresponding indicator property. Indicator property must be of the string type. There are two variants of the function.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/indicatorsetstring.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>prop_id</b> :  [in] Identifier of the indicator property. The value can be one of the values of the enumeration.</li>
        /// <li><b>prop_modifier</b> :  [in] Modifier of the specified property. Only level properties require a modifier.</li>
        /// <li><b>prop_value</b> :  [in] Value of property.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/indicatorsetstring$")]
        public IHttpContext Handle_IndicatorSetString_2_Default(IHttpContext context)
        {
            return SendJsonResponse(context, IndicatorSetString_2);
        }

        private async Task<JObject> IndicatorSetString_2(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "prop_id");
            ParamAdd(context, parameters, "prop_modifier");
            ParamAdd(context, parameters, "prop_value");
            await ExecCommandAsync(context, MQLCommand.IndicatorSetString_2, parameters); // MQLCommand ENUM = 158

            result["result"] = (bool)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> IndicatorBuffers<br>
        /// <b>Description:</b> Allocates memory for buffers used for custom indicator calculations.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/indicatorbuffers.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>count</b> :  [in] Amount of buffers to be allocated. Should be within the range between indicator_buffers and 512 buffers.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/indicatorbuffers$")]
        public IHttpContext Handle_IndicatorBuffers_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), IndicatorBuffers_1);
        }

        /// <summary>
        /// <b>Function:</b> IndicatorBuffers<br>
        /// <b>Description:</b> Allocates memory for buffers used for custom indicator calculations.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/indicatorbuffers.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>count</b> :  [in] Amount of buffers to be allocated. Should be within the range between indicator_buffers and 512 buffers.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/indicatorbuffers$")]
        public IHttpContext Handle_IndicatorBuffers_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, IndicatorBuffers_1);
        }

        private async Task<JObject> IndicatorBuffers_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "count");
            await ExecCommandAsync(context, MQLCommand.IndicatorBuffers_1, parameters); // MQLCommand ENUM = 159

            result["result"] = (bool)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> IndicatorCounted<br>
        /// <b>Description:</b> The function returns the amount of bars not changed after the indicator had been launched last.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/indicatorcounted.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/indicatorcounted$")]
        public IHttpContext Handle_IndicatorCounted_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), IndicatorCounted_1);
        }

        /// <summary>
        /// <b>Function:</b> IndicatorCounted<br>
        /// <b>Description:</b> The function returns the amount of bars not changed after the indicator had been launched last.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/indicatorcounted.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/indicatorcounted$")]
        public IHttpContext Handle_IndicatorCounted_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, IndicatorCounted_1);
        }

        private async Task<JObject> IndicatorCounted_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            List<Object> parameters = new List<Object>();
            await ExecCommandAsync(context, MQLCommand.IndicatorCounted_1, parameters); // MQLCommand ENUM = 160

            result["result"] = Convert.ToInt32(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> IndicatorDigits<br>
        /// <b>Description:</b> Sets precision format (the count of digits after decimal point) to visualize indicator values.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/indicatordigits.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>digits</b> :  [in] Precision format, the count of digits after decimal point.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/indicatordigits$")]
        public IHttpContext Handle_IndicatorDigits_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), IndicatorDigits_1);
        }

        /// <summary>
        /// <b>Function:</b> IndicatorDigits<br>
        /// <b>Description:</b> Sets precision format (the count of digits after decimal point) to visualize indicator values.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/indicatordigits.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>digits</b> :  [in] Precision format, the count of digits after decimal point.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/indicatordigits$")]
        public IHttpContext Handle_IndicatorDigits_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, IndicatorDigits_1);
        }

        private async Task<JObject> IndicatorDigits_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "digits");
            await ExecCommandAsync(context, MQLCommand.IndicatorDigits_1, parameters); // MQLCommand ENUM = 161

            result["result"] = "";

            return result;
        }
        /// <summary>
        /// <b>Function:</b> IndicatorShortName<br>
        /// <b>Description:</b> Sets the "short" name of a custom indicator to be shown in the DataWindow and in the chart subwindow.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/indicatorshortname.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>name</b> :  [in] New short name.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/indicatorshortname$")]
        public IHttpContext Handle_IndicatorShortName_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), IndicatorShortName_1);
        }

        /// <summary>
        /// <b>Function:</b> IndicatorShortName<br>
        /// <b>Description:</b> Sets the "short" name of a custom indicator to be shown in the DataWindow and in the chart subwindow.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/indicatorshortname.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>name</b> :  [in] New short name.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/indicatorshortname$")]
        public IHttpContext Handle_IndicatorShortName_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, IndicatorShortName_1);
        }

        private async Task<JObject> IndicatorShortName_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "name");
            await ExecCommandAsync(context, MQLCommand.IndicatorShortName_1, parameters); // MQLCommand ENUM = 162

            result["result"] = "";

            return result;
        }
        /// <summary>
        /// <b>Function:</b> SetIndexArrow<br>
        /// <b>Description:</b> Sets an arrow symbol for indicators line of the DRAW_ARROW type.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/setindexarrow.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>index</b> :  [in] Line index. Must lie between 0 and 7.</li>
        /// <li><b>code</b> :  [in] Symbol code from or predefined .</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/setindexarrow$")]
        public IHttpContext Handle_SetIndexArrow_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), SetIndexArrow_1);
        }

        /// <summary>
        /// <b>Function:</b> SetIndexArrow<br>
        /// <b>Description:</b> Sets an arrow symbol for indicators line of the DRAW_ARROW type.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/setindexarrow.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>index</b> :  [in] Line index. Must lie between 0 and 7.</li>
        /// <li><b>code</b> :  [in] Symbol code from or predefined .</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/setindexarrow$")]
        public IHttpContext Handle_SetIndexArrow_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, SetIndexArrow_1);
        }

        private async Task<JObject> SetIndexArrow_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "index");
            ParamAdd(context, parameters, "code");
            await ExecCommandAsync(context, MQLCommand.SetIndexArrow_1, parameters); // MQLCommand ENUM = 163

            result["result"] = "";

            return result;
        }
        /// <summary>
        /// <b>Function:</b> SetIndexDrawBegin<br>
        /// <b>Description:</b> Sets the bar number (from the data beginning) from which the drawing of the given indicator line must start.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/setindexdrawbegin.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>index</b> :  [in] Line index. Must lie between 0 and 7.</li>
        /// <li><b>begin</b> :  [in] First drawing bar position number.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/setindexdrawbegin$")]
        public IHttpContext Handle_SetIndexDrawBegin_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), SetIndexDrawBegin_1);
        }

        /// <summary>
        /// <b>Function:</b> SetIndexDrawBegin<br>
        /// <b>Description:</b> Sets the bar number (from the data beginning) from which the drawing of the given indicator line must start.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/setindexdrawbegin.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>index</b> :  [in] Line index. Must lie between 0 and 7.</li>
        /// <li><b>begin</b> :  [in] First drawing bar position number.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/setindexdrawbegin$")]
        public IHttpContext Handle_SetIndexDrawBegin_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, SetIndexDrawBegin_1);
        }

        private async Task<JObject> SetIndexDrawBegin_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "index");
            ParamAdd(context, parameters, "begin");
            await ExecCommandAsync(context, MQLCommand.SetIndexDrawBegin_1, parameters); // MQLCommand ENUM = 164

            result["result"] = "";

            return result;
        }
        /// <summary>
        /// <b>Function:</b> SetIndexEmptyValue<br>
        /// <b>Description:</b> Sets drawing line empty value.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/setindexemptyvalue.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>index</b> :  [in] Line index. Must lie between 0 and 7.</li>
        /// <li><b>value</b> :  [in] New "empty" value.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/setindexemptyvalue$")]
        public IHttpContext Handle_SetIndexEmptyValue_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), SetIndexEmptyValue_1);
        }

        /// <summary>
        /// <b>Function:</b> SetIndexEmptyValue<br>
        /// <b>Description:</b> Sets drawing line empty value.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/setindexemptyvalue.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>index</b> :  [in] Line index. Must lie between 0 and 7.</li>
        /// <li><b>value</b> :  [in] New "empty" value.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/setindexemptyvalue$")]
        public IHttpContext Handle_SetIndexEmptyValue_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, SetIndexEmptyValue_1);
        }

        private async Task<JObject> SetIndexEmptyValue_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "index");
            ParamAdd(context, parameters, "value");
            await ExecCommandAsync(context, MQLCommand.SetIndexEmptyValue_1, parameters); // MQLCommand ENUM = 165

            result["result"] = "";

            return result;
        }
        /// <summary>
        /// <b>Function:</b> SetIndexLabel<br>
        /// <b>Description:</b> Sets drawing line description for showing in the DataWindow and in the tooltip.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/setindexlabel.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>index</b> :  [in] Line index. Must lie between 0 and 7.</li>
        /// <li><b>text</b> :  [in] Label text. NULL means that index value is not shown in the DataWindow.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/setindexlabel$")]
        public IHttpContext Handle_SetIndexLabel_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), SetIndexLabel_1);
        }

        /// <summary>
        /// <b>Function:</b> SetIndexLabel<br>
        /// <b>Description:</b> Sets drawing line description for showing in the DataWindow and in the tooltip.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/setindexlabel.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>index</b> :  [in] Line index. Must lie between 0 and 7.</li>
        /// <li><b>text</b> :  [in] Label text. NULL means that index value is not shown in the DataWindow.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/setindexlabel$")]
        public IHttpContext Handle_SetIndexLabel_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, SetIndexLabel_1);
        }

        private async Task<JObject> SetIndexLabel_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "index");
            ParamAdd(context, parameters, "text");
            await ExecCommandAsync(context, MQLCommand.SetIndexLabel_1, parameters); // MQLCommand ENUM = 166

            result["result"] = "";

            return result;
        }
        /// <summary>
        /// <b>Function:</b> SetIndexShift<br>
        /// <b>Description:</b> Sets offset for the drawing line.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/setindexshift.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>index</b> :  [in] Line index. Must lie between 0 and 7.</li>
        /// <li><b>shift</b> :  [in] Shift value in bars.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/setindexshift$")]
        public IHttpContext Handle_SetIndexShift_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), SetIndexShift_1);
        }

        /// <summary>
        /// <b>Function:</b> SetIndexShift<br>
        /// <b>Description:</b> Sets offset for the drawing line.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/setindexshift.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>index</b> :  [in] Line index. Must lie between 0 and 7.</li>
        /// <li><b>shift</b> :  [in] Shift value in bars.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/setindexshift$")]
        public IHttpContext Handle_SetIndexShift_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, SetIndexShift_1);
        }

        private async Task<JObject> SetIndexShift_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "index");
            ParamAdd(context, parameters, "shift");
            await ExecCommandAsync(context, MQLCommand.SetIndexShift_1, parameters); // MQLCommand ENUM = 167

            result["result"] = "";

            return result;
        }
        /// <summary>
        /// <b>Function:</b> SetIndexStyle<br>
        /// <b>Description:</b> Sets the new type, style, width and color for a given indicator line.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/setindexstyle.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>index</b> :  [in] Line index. Must lie between 0 and 7.</li>
        /// <li><b>type</b> :  [in] Shape style. Can be one of listed.</li>
        /// <li><b>style</b> :  [in] Drawing style. It is used for one-pixel thick lines. It can be one of the listed. EMPTY value means that the style will not be changed.</li>
        /// <li><b>width</b> :  [in] Line width. Valid values are: 1,2,3,4,5. EMPTY value means that width will not be changed.</li>
        /// <li><b>clr</b> :  [in] Line color. Absence of this parameter means that the color will not be changed.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/setindexstyle$")]
        public IHttpContext Handle_SetIndexStyle_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), SetIndexStyle_1);
        }

        /// <summary>
        /// <b>Function:</b> SetIndexStyle<br>
        /// <b>Description:</b> Sets the new type, style, width and color for a given indicator line.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/setindexstyle.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>index</b> :  [in] Line index. Must lie between 0 and 7.</li>
        /// <li><b>type</b> :  [in] Shape style. Can be one of listed.</li>
        /// <li><b>style</b> :  [in] Drawing style. It is used for one-pixel thick lines. It can be one of the listed. EMPTY value means that the style will not be changed.</li>
        /// <li><b>width</b> :  [in] Line width. Valid values are: 1,2,3,4,5. EMPTY value means that width will not be changed.</li>
        /// <li><b>clr</b> :  [in] Line color. Absence of this parameter means that the color will not be changed.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/setindexstyle$")]
        public IHttpContext Handle_SetIndexStyle_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, SetIndexStyle_1);
        }

        private async Task<JObject> SetIndexStyle_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "index");
            ParamAdd(context, parameters, "type");
            ParamAdd(context, parameters, "style");
            ParamAdd(context, parameters, "width");
            ParamAdd(context, parameters, "clr");
            await ExecCommandAsync(context, MQLCommand.SetIndexStyle_1, parameters); // MQLCommand ENUM = 168

            result["result"] = "";

            return result;
        }
        /// <summary>
        /// <b>Function:</b> SetLevelStyle<br>
        /// <b>Description:</b> The function sets a new style, width and color of horizontal levels of indicator to be output in a separate window.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/setlevelstyle.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>draw_style</b> :  [in] Drawing style. Can be one of the listed. EMPTY value means that the style will not be changed.</li>
        /// <li><b>line_width</b> :  [in] Line width. Valid values are 1,2,3,4,5. EMPTY value indicates that the width will not be changed.</li>
        /// <li><b>clr</b> :  [in] Line color. Empty value CLR_NONE means that the color will not be changed.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/setlevelstyle$")]
        public IHttpContext Handle_SetLevelStyle_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), SetLevelStyle_1);
        }

        /// <summary>
        /// <b>Function:</b> SetLevelStyle<br>
        /// <b>Description:</b> The function sets a new style, width and color of horizontal levels of indicator to be output in a separate window.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/setlevelstyle.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>draw_style</b> :  [in] Drawing style. Can be one of the listed. EMPTY value means that the style will not be changed.</li>
        /// <li><b>line_width</b> :  [in] Line width. Valid values are 1,2,3,4,5. EMPTY value indicates that the width will not be changed.</li>
        /// <li><b>clr</b> :  [in] Line color. Empty value CLR_NONE means that the color will not be changed.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/setlevelstyle$")]
        public IHttpContext Handle_SetLevelStyle_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, SetLevelStyle_1);
        }

        private async Task<JObject> SetLevelStyle_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "draw_style");
            ParamAdd(context, parameters, "line_width");
            ParamAdd(context, parameters, "clr");
            await ExecCommandAsync(context, MQLCommand.SetLevelStyle_1, parameters); // MQLCommand ENUM = 169

            result["result"] = "";

            return result;
        }
        /// <summary>
        /// <b>Function:</b> SetLevelValue<br>
        /// <b>Description:</b> The function sets a value for a given horizontal level of the indicator to be output in a separate window.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/setlevelvalue.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>level</b> :  [in] Level index (0-31).</li>
        /// <li><b>value</b> :  [in] Value for the given indicator level.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/setlevelvalue$")]
        public IHttpContext Handle_SetLevelValue_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), SetLevelValue_1);
        }

        /// <summary>
        /// <b>Function:</b> SetLevelValue<br>
        /// <b>Description:</b> The function sets a value for a given horizontal level of the indicator to be output in a separate window.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/setlevelvalue.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>level</b> :  [in] Level index (0-31).</li>
        /// <li><b>value</b> :  [in] Value for the given indicator level.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/setlevelvalue$")]
        public IHttpContext Handle_SetLevelValue_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, SetLevelValue_1);
        }

        private async Task<JObject> SetLevelValue_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "level");
            ParamAdd(context, parameters, "value");
            await ExecCommandAsync(context, MQLCommand.SetLevelValue_1, parameters); // MQLCommand ENUM = 170

            result["result"] = "";

            return result;
        }
        /// <summary>
        /// <b>Function:</b> ObjectCreate<br>
        /// <b>Description:</b> The function creates an object with the specified name, type, and the initial coordinates in the specified chart subwindow of the specified chart. There are two variants of the function:<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectcreate.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart identifier.</li>
        /// <li><b>object_name</b> :  [in] Name of the object. The name must be unique within a chart, including its subwindows.</li>
        /// <li><b>object_type</b> :  [in] Object type. The value can be one of the values of the enumeration.</li>
        /// <li><b>sub_window</b> :  [in] Number of the chart subwindow. 0 means the main chart window. The specified subwindow must exist (window index must be greater or equal to 0 and less than ), otherwise the function returns false.</li>
        /// <li><b>time1</b> :  [in] The time coordinate of the first anchor point.</li>
        /// <li><b>price1</b> :  [in] The price coordinate of the first anchor point.</li>
        /// <li><b>timeN</b> :  [in] The time coordinate of the N-th anchor point.</li>
        /// <li><b>priceN</b> :  [in] The price coordinate of the N-th anchor point.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectcreate$")]
        public IHttpContext Handle_ObjectCreate_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), ObjectCreate_1);
        }

        /// <summary>
        /// <b>Function:</b> ObjectCreate<br>
        /// <b>Description:</b> The function creates an object with the specified name, type, and the initial coordinates in the specified chart subwindow of the specified chart. There are two variants of the function:<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectcreate.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart identifier.</li>
        /// <li><b>object_name</b> :  [in] Name of the object. The name must be unique within a chart, including its subwindows.</li>
        /// <li><b>object_type</b> :  [in] Object type. The value can be one of the values of the enumeration.</li>
        /// <li><b>sub_window</b> :  [in] Number of the chart subwindow. 0 means the main chart window. The specified subwindow must exist (window index must be greater or equal to 0 and less than ), otherwise the function returns false.</li>
        /// <li><b>time1</b> :  [in] The time coordinate of the first anchor point.</li>
        /// <li><b>price1</b> :  [in] The price coordinate of the first anchor point.</li>
        /// <li><b>timeN</b> :  [in] The time coordinate of the N-th anchor point.</li>
        /// <li><b>priceN</b> :  [in] The price coordinate of the N-th anchor point.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/objectcreate$")]
        public IHttpContext Handle_ObjectCreate_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, ObjectCreate_1);
        }

        private async Task<JObject> ObjectCreate_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "chart_id");
            ParamAdd(context, parameters, "object_name");
            ParamAdd(context, parameters, "object_type");
            ParamAdd(context, parameters, "sub_window");
            ParamAdd(context, parameters, "time1");
            ParamAdd(context, parameters, "price1");
            ParamAdd(context, parameters, "timeN");
            ParamAdd(context, parameters, "priceN");
            await ExecCommandAsync(context, MQLCommand.ObjectCreate_1, parameters); // MQLCommand ENUM = 171

            result["result"] = (bool)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> ObjectCreate<br>
        /// <b>Description:</b> The function creates an object with the specified name, type, and the initial coordinates in the specified chart subwindow of the specified chart. There are two variants of the function:<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectcreate.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>object_name</b> :  [in] Name of the object. The name must be unique within a chart, including its subwindows.</li>
        /// <li><b>object_type</b> :  [in] Object type. The value can be one of the values of the enumeration.</li>
        /// <li><b>sub_window</b> :  [in] Number of the chart subwindow. 0 means the main chart window. The specified subwindow must exist (window index must be greater or equal to 0 and less than ), otherwise the function returns false.</li>
        /// <li><b>time1</b> :  [in] The time coordinate of the first anchor point.</li>
        /// <li><b>price1</b> :  [in] The price coordinate of the first anchor point.</li>
        /// <li><b>time2</b> :  [in] The time coordinate of the second anchor point.</li>
        /// <li><b>price2</b> :  [in] The price coordinate of the second anchor point.</li>
        /// <li><b>time3</b> :  [in] The time coordinate of the third anchor point.</li>
        /// <li><b>price3</b> :  [in] The price coordinate of the third anchor point.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectcreate$")]
        public IHttpContext Handle_ObjectCreate_2(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), ObjectCreate_2);
        }

        /// <summary>
        /// <b>Function:</b> ObjectCreate<br>
        /// <b>Description:</b> The function creates an object with the specified name, type, and the initial coordinates in the specified chart subwindow of the specified chart. There are two variants of the function:<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectcreate.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>object_name</b> :  [in] Name of the object. The name must be unique within a chart, including its subwindows.</li>
        /// <li><b>object_type</b> :  [in] Object type. The value can be one of the values of the enumeration.</li>
        /// <li><b>sub_window</b> :  [in] Number of the chart subwindow. 0 means the main chart window. The specified subwindow must exist (window index must be greater or equal to 0 and less than ), otherwise the function returns false.</li>
        /// <li><b>time1</b> :  [in] The time coordinate of the first anchor point.</li>
        /// <li><b>price1</b> :  [in] The price coordinate of the first anchor point.</li>
        /// <li><b>time2</b> :  [in] The time coordinate of the second anchor point.</li>
        /// <li><b>price2</b> :  [in] The price coordinate of the second anchor point.</li>
        /// <li><b>time3</b> :  [in] The time coordinate of the third anchor point.</li>
        /// <li><b>price3</b> :  [in] The price coordinate of the third anchor point.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/objectcreate$")]
        public IHttpContext Handle_ObjectCreate_2_Default(IHttpContext context)
        {
            return SendJsonResponse(context, ObjectCreate_2);
        }

        private async Task<JObject> ObjectCreate_2(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "object_name");
            ParamAdd(context, parameters, "object_type");
            ParamAdd(context, parameters, "sub_window");
            ParamAdd(context, parameters, "time1");
            ParamAdd(context, parameters, "price1");
            ParamAdd(context, parameters, "time2");
            ParamAdd(context, parameters, "price2");
            ParamAdd(context, parameters, "time3");
            ParamAdd(context, parameters, "price3");
            await ExecCommandAsync(context, MQLCommand.ObjectCreate_2, parameters); // MQLCommand ENUM = 171

            result["result"] = (bool)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> ObjectName<br>
        /// <b>Description:</b> The function returns the name of the corresponding object by its index in the objects list.<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectname.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>object_index</b> :  [in] Object index. This value must be greater or equal to 0 and less than .</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectname$")]
        public IHttpContext Handle_ObjectName_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), ObjectName_1);
        }

        /// <summary>
        /// <b>Function:</b> ObjectName<br>
        /// <b>Description:</b> The function returns the name of the corresponding object by its index in the objects list.<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectname.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>object_index</b> :  [in] Object index. This value must be greater or equal to 0 and less than .</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/objectname$")]
        public IHttpContext Handle_ObjectName_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, ObjectName_1);
        }

        private async Task<JObject> ObjectName_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "object_index");
            await ExecCommandAsync(context, MQLCommand.ObjectName_1, parameters); // MQLCommand ENUM = 172

            result["result"] = (string)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> ObjectDelete<br>
        /// <b>Description:</b> The function removes the object with the specified name at the specified chart. There are two variants of the function:<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectdelete.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart identifier.</li>
        /// <li><b>object_name</b> :  [in] Name of object to be deleted.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectdelete$")]
        public IHttpContext Handle_ObjectDelete_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), ObjectDelete_1);
        }

        /// <summary>
        /// <b>Function:</b> ObjectDelete<br>
        /// <b>Description:</b> The function removes the object with the specified name at the specified chart. There are two variants of the function:<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectdelete.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart identifier.</li>
        /// <li><b>object_name</b> :  [in] Name of object to be deleted.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/objectdelete$")]
        public IHttpContext Handle_ObjectDelete_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, ObjectDelete_1);
        }

        private async Task<JObject> ObjectDelete_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "chart_id");
            ParamAdd(context, parameters, "object_name");
            await ExecCommandAsync(context, MQLCommand.ObjectDelete_1, parameters); // MQLCommand ENUM = 173

            result["result"] = (bool)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> ObjectDelete<br>
        /// <b>Description:</b> The function removes the object with the specified name at the specified chart. There are two variants of the function:<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectdelete.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>object_name</b> :  [in] Name of object to be deleted.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectdelete$")]
        public IHttpContext Handle_ObjectDelete_2(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), ObjectDelete_2);
        }

        /// <summary>
        /// <b>Function:</b> ObjectDelete<br>
        /// <b>Description:</b> The function removes the object with the specified name at the specified chart. There are two variants of the function:<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectdelete.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>object_name</b> :  [in] Name of object to be deleted.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/objectdelete$")]
        public IHttpContext Handle_ObjectDelete_2_Default(IHttpContext context)
        {
            return SendJsonResponse(context, ObjectDelete_2);
        }

        private async Task<JObject> ObjectDelete_2(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "object_name");
            await ExecCommandAsync(context, MQLCommand.ObjectDelete_2, parameters); // MQLCommand ENUM = 173

            result["result"] = (bool)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> ObjectsDeleteAll<br>
        /// <b>Description:</b> Removes all objects from the specified chart, specified chart subwindow, of the specified type.<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectsdeleteall.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart identifier.</li>
        /// <li><b>sub_window</b> :  [in] Number of the chart window. Must be greater or equal to -1 (-1 mean all subwindows, 0 means the main chart window) and less than .</li>
        /// <li><b>object_type</b> :  [in] Type of the object. The value can be one of the values of the enumeration. EMPTY (-1) means all types.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectsdeleteall$")]
        public IHttpContext Handle_ObjectsDeleteAll_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), ObjectsDeleteAll_1);
        }

        /// <summary>
        /// <b>Function:</b> ObjectsDeleteAll<br>
        /// <b>Description:</b> Removes all objects from the specified chart, specified chart subwindow, of the specified type.<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectsdeleteall.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart identifier.</li>
        /// <li><b>sub_window</b> :  [in] Number of the chart window. Must be greater or equal to -1 (-1 mean all subwindows, 0 means the main chart window) and less than .</li>
        /// <li><b>object_type</b> :  [in] Type of the object. The value can be one of the values of the enumeration. EMPTY (-1) means all types.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/objectsdeleteall$")]
        public IHttpContext Handle_ObjectsDeleteAll_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, ObjectsDeleteAll_1);
        }

        private async Task<JObject> ObjectsDeleteAll_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "chart_id");
            ParamAdd(context, parameters, "sub_window");
            ParamAdd(context, parameters, "object_type");
            await ExecCommandAsync(context, MQLCommand.ObjectsDeleteAll_1, parameters); // MQLCommand ENUM = 174

            result["result"] = Convert.ToInt32(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> ObjectsDeleteAll<br>
        /// <b>Description:</b> Removes all objects from the specified chart, specified chart subwindow, of the specified type.<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectsdeleteall.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>sub_window</b> :  [in] Number of the chart window. Must be greater or equal to -1 (-1 mean all subwindows, 0 means the main chart window) and less than .</li>
        /// <li><b>object_type</b> :  [in] Type of the object. The value can be one of the values of the enumeration. EMPTY (-1) means all types.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectsdeleteall$")]
        public IHttpContext Handle_ObjectsDeleteAll_2(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), ObjectsDeleteAll_2);
        }

        /// <summary>
        /// <b>Function:</b> ObjectsDeleteAll<br>
        /// <b>Description:</b> Removes all objects from the specified chart, specified chart subwindow, of the specified type.<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectsdeleteall.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>sub_window</b> :  [in] Number of the chart window. Must be greater or equal to -1 (-1 mean all subwindows, 0 means the main chart window) and less than .</li>
        /// <li><b>object_type</b> :  [in] Type of the object. The value can be one of the values of the enumeration. EMPTY (-1) means all types.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/objectsdeleteall$")]
        public IHttpContext Handle_ObjectsDeleteAll_2_Default(IHttpContext context)
        {
            return SendJsonResponse(context, ObjectsDeleteAll_2);
        }

        private async Task<JObject> ObjectsDeleteAll_2(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "sub_window");
            ParamAdd(context, parameters, "object_type");
            await ExecCommandAsync(context, MQLCommand.ObjectsDeleteAll_2, parameters); // MQLCommand ENUM = 174

            result["result"] = Convert.ToInt32(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> ObjectsDeleteAll<br>
        /// <b>Description:</b> Removes all objects from the specified chart, specified chart subwindow, of the specified type.<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectsdeleteall.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart identifier.</li>
        /// <li><b>prefix</b> :  [in] Prefix in object names. All objects whose names start with this set of characters will be removed from chart. You can specify prefix as 'name' or 'name*' both variants will work the same. If an empty string is specified as the prefix, objects with all possible names will be removed.</li>
        /// <li><b>sub_window</b> :  [in] Number of the chart window. Must be greater or equal to -1 (-1 mean all subwindows, 0 means the main chart window) and less than .</li>
        /// <li><b>object_type</b> :  [in] Type of the object. The value can be one of the values of the enumeration. EMPTY (-1) means all types.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectsdeleteall$")]
        public IHttpContext Handle_ObjectsDeleteAll_3(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), ObjectsDeleteAll_3);
        }

        /// <summary>
        /// <b>Function:</b> ObjectsDeleteAll<br>
        /// <b>Description:</b> Removes all objects from the specified chart, specified chart subwindow, of the specified type.<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectsdeleteall.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart identifier.</li>
        /// <li><b>prefix</b> :  [in] Prefix in object names. All objects whose names start with this set of characters will be removed from chart. You can specify prefix as 'name' or 'name*' both variants will work the same. If an empty string is specified as the prefix, objects with all possible names will be removed.</li>
        /// <li><b>sub_window</b> :  [in] Number of the chart window. Must be greater or equal to -1 (-1 mean all subwindows, 0 means the main chart window) and less than .</li>
        /// <li><b>object_type</b> :  [in] Type of the object. The value can be one of the values of the enumeration. EMPTY (-1) means all types.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/objectsdeleteall$")]
        public IHttpContext Handle_ObjectsDeleteAll_3_Default(IHttpContext context)
        {
            return SendJsonResponse(context, ObjectsDeleteAll_3);
        }

        private async Task<JObject> ObjectsDeleteAll_3(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "chart_id");
            ParamAdd(context, parameters, "prefix");
            ParamAdd(context, parameters, "sub_window");
            ParamAdd(context, parameters, "object_type");
            await ExecCommandAsync(context, MQLCommand.ObjectsDeleteAll_3, parameters); // MQLCommand ENUM = 174

            result["result"] = Convert.ToInt32(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> ObjectFind<br>
        /// <b>Description:</b> The function searches for an object having the specified name. There are two variants of the function:<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectfind.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart identifier.</li>
        /// <li><b>object_name</b> :  [in] The name of the object to find.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectfind$")]
        public IHttpContext Handle_ObjectFind_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), ObjectFind_1);
        }

        /// <summary>
        /// <b>Function:</b> ObjectFind<br>
        /// <b>Description:</b> The function searches for an object having the specified name. There are two variants of the function:<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectfind.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart identifier.</li>
        /// <li><b>object_name</b> :  [in] The name of the object to find.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/objectfind$")]
        public IHttpContext Handle_ObjectFind_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, ObjectFind_1);
        }

        private async Task<JObject> ObjectFind_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "chart_id");
            ParamAdd(context, parameters, "object_name");
            await ExecCommandAsync(context, MQLCommand.ObjectFind_1, parameters); // MQLCommand ENUM = 175

            result["result"] = Convert.ToInt32(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> ObjectFind<br>
        /// <b>Description:</b> The function searches for an object having the specified name. There are two variants of the function:<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectfind.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>object_name</b> :  [in] The name of the object to find.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectfind$")]
        public IHttpContext Handle_ObjectFind_2(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), ObjectFind_2);
        }

        /// <summary>
        /// <b>Function:</b> ObjectFind<br>
        /// <b>Description:</b> The function searches for an object having the specified name. There are two variants of the function:<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectfind.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>object_name</b> :  [in] The name of the object to find.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/objectfind$")]
        public IHttpContext Handle_ObjectFind_2_Default(IHttpContext context)
        {
            return SendJsonResponse(context, ObjectFind_2);
        }

        private async Task<JObject> ObjectFind_2(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "object_name");
            await ExecCommandAsync(context, MQLCommand.ObjectFind_2, parameters); // MQLCommand ENUM = 175

            result["result"] = Convert.ToInt32(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> ObjectGetTimeByValue<br>
        /// <b>Description:</b> The function returns the time value for the specified price value of the specified object.<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectgettimebyvalue.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>object_name</b> :  [in] Name of the object.</li>
        /// <li><b>value</b> :  [in] Price value.</li>
        /// <li><b>line_id</b> :  [in] Line identifier.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectgettimebyvalue$")]
        public IHttpContext Handle_ObjectGetTimeByValue_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), ObjectGetTimeByValue_1);
        }

        /// <summary>
        /// <b>Function:</b> ObjectGetTimeByValue<br>
        /// <b>Description:</b> The function returns the time value for the specified price value of the specified object.<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectgettimebyvalue.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>object_name</b> :  [in] Name of the object.</li>
        /// <li><b>value</b> :  [in] Price value.</li>
        /// <li><b>line_id</b> :  [in] Line identifier.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/objectgettimebyvalue$")]
        public IHttpContext Handle_ObjectGetTimeByValue_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, ObjectGetTimeByValue_1);
        }

        private async Task<JObject> ObjectGetTimeByValue_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "object_name");
            ParamAdd(context, parameters, "value");
            ParamAdd(context, parameters, "line_id");
            await ExecCommandAsync(context, MQLCommand.ObjectGetTimeByValue_1, parameters); // MQLCommand ENUM = 176

            result["result"] = (DateTime)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> ObjectGetValueByTime<br>
        /// <b>Description:</b> The function returns the price value for the specified time value of the specified object.<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectgetvaluebytime.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart identifier.</li>
        /// <li><b>object_name</b> :  [in] Name of the object.</li>
        /// <li><b>time</b> :  [in] Time value.</li>
        /// <li><b>line_id</b> :  [in] Line identifier.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectgetvaluebytime$")]
        public IHttpContext Handle_ObjectGetValueByTime_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), ObjectGetValueByTime_1);
        }

        /// <summary>
        /// <b>Function:</b> ObjectGetValueByTime<br>
        /// <b>Description:</b> The function returns the price value for the specified time value of the specified object.<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectgetvaluebytime.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart identifier.</li>
        /// <li><b>object_name</b> :  [in] Name of the object.</li>
        /// <li><b>time</b> :  [in] Time value.</li>
        /// <li><b>line_id</b> :  [in] Line identifier.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/objectgetvaluebytime$")]
        public IHttpContext Handle_ObjectGetValueByTime_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, ObjectGetValueByTime_1);
        }

        private async Task<JObject> ObjectGetValueByTime_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "chart_id");
            ParamAdd(context, parameters, "object_name");
            ParamAdd(context, parameters, "time");
            ParamAdd(context, parameters, "line_id");
            await ExecCommandAsync(context, MQLCommand.ObjectGetValueByTime_1, parameters); // MQLCommand ENUM = 177

            result["result"] = Convert.ToDecimal(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> ObjectMove<br>
        /// <b>Description:</b> The function changes coordinates of the specified anchor point of the object at the specified chart. There are two variants of the function:<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectmove.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>object_name</b> :  [in] Name of the object.</li>
        /// <li><b>point_index</b> :  [in] Index of the anchor point. The number of anchor points depends on the .</li>
        /// <li><b>time</b> :  [in] Time coordinate of the selected anchor point.</li>
        /// <li><b>price</b> :  [in] Price coordinate of the selected anchor point.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectmove$")]
        public IHttpContext Handle_ObjectMove_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), ObjectMove_1);
        }

        /// <summary>
        /// <b>Function:</b> ObjectMove<br>
        /// <b>Description:</b> The function changes coordinates of the specified anchor point of the object at the specified chart. There are two variants of the function:<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectmove.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>object_name</b> :  [in] Name of the object.</li>
        /// <li><b>point_index</b> :  [in] Index of the anchor point. The number of anchor points depends on the .</li>
        /// <li><b>time</b> :  [in] Time coordinate of the selected anchor point.</li>
        /// <li><b>price</b> :  [in] Price coordinate of the selected anchor point.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/objectmove$")]
        public IHttpContext Handle_ObjectMove_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, ObjectMove_1);
        }

        private async Task<JObject> ObjectMove_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "object_name");
            ParamAdd(context, parameters, "point_index");
            ParamAdd(context, parameters, "time");
            ParamAdd(context, parameters, "price");
            await ExecCommandAsync(context, MQLCommand.ObjectMove_1, parameters); // MQLCommand ENUM = 178

            result["result"] = (bool)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> ObjectsTotal<br>
        /// <b>Description:</b> The function returns the number of objects of the specified type in the specified chart. There are two variants of the function:<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectstotal.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart identifier.</li>
        /// <li><b>sub_window</b> :  [in] Number of the chart subwindow. 0 means the main chart window, -1 means all the subwindows of the chart, including the main window.</li>
        /// <li><b>type</b> :  [in] Type of the object. The value can be one of the values of the enumeration. EMPTY(-1) means all types.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectstotal$")]
        public IHttpContext Handle_ObjectsTotal_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), ObjectsTotal_1);
        }

        /// <summary>
        /// <b>Function:</b> ObjectsTotal<br>
        /// <b>Description:</b> The function returns the number of objects of the specified type in the specified chart. There are two variants of the function:<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectstotal.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart identifier.</li>
        /// <li><b>sub_window</b> :  [in] Number of the chart subwindow. 0 means the main chart window, -1 means all the subwindows of the chart, including the main window.</li>
        /// <li><b>type</b> :  [in] Type of the object. The value can be one of the values of the enumeration. EMPTY(-1) means all types.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/objectstotal$")]
        public IHttpContext Handle_ObjectsTotal_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, ObjectsTotal_1);
        }

        private async Task<JObject> ObjectsTotal_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "chart_id");
            ParamAdd(context, parameters, "sub_window");
            ParamAdd(context, parameters, "type");
            await ExecCommandAsync(context, MQLCommand.ObjectsTotal_1, parameters); // MQLCommand ENUM = 179

            result["result"] = Convert.ToInt32(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> ObjectsTotal<br>
        /// <b>Description:</b> The function returns the number of objects of the specified type in the specified chart. There are two variants of the function:<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectstotal.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>type</b> :  [in] Type of the object. The value can be one of the values of the enumeration. EMPTY(-1) means all types.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectstotal$")]
        public IHttpContext Handle_ObjectsTotal_2(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), ObjectsTotal_2);
        }

        /// <summary>
        /// <b>Function:</b> ObjectsTotal<br>
        /// <b>Description:</b> The function returns the number of objects of the specified type in the specified chart. There are two variants of the function:<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectstotal.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>type</b> :  [in] Type of the object. The value can be one of the values of the enumeration. EMPTY(-1) means all types.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/objectstotal$")]
        public IHttpContext Handle_ObjectsTotal_2_Default(IHttpContext context)
        {
            return SendJsonResponse(context, ObjectsTotal_2);
        }

        private async Task<JObject> ObjectsTotal_2(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "type");
            await ExecCommandAsync(context, MQLCommand.ObjectsTotal_2, parameters); // MQLCommand ENUM = 179

            result["result"] = Convert.ToInt32(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> ObjectGetDouble<br>
        /// <b>Description:</b> The function returns the value of the corresponding object property. The object property must be of the<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectgetdouble.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart identifier. 0 means the current chart.</li>
        /// <li><b>object_name</b> :  [in] Name of the object.</li>
        /// <li><b>prop_id</b> :  [in] ID of the object property. The value can be one of the values of the enumeration.</li>
        /// <li><b>prop_modifier</b> :  [in] Modifier of the specified property. For the first variant, the default modifier value is equal to 0. Most properties do not require a modifier. It denotes the number of the level in and in the graphical object Andrew's pitchfork. The numeration of levels starts from zero.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectgetdouble$")]
        public IHttpContext Handle_ObjectGetDouble_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), ObjectGetDouble_1);
        }

        /// <summary>
        /// <b>Function:</b> ObjectGetDouble<br>
        /// <b>Description:</b> The function returns the value of the corresponding object property. The object property must be of the<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectgetdouble.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart identifier. 0 means the current chart.</li>
        /// <li><b>object_name</b> :  [in] Name of the object.</li>
        /// <li><b>prop_id</b> :  [in] ID of the object property. The value can be one of the values of the enumeration.</li>
        /// <li><b>prop_modifier</b> :  [in] Modifier of the specified property. For the first variant, the default modifier value is equal to 0. Most properties do not require a modifier. It denotes the number of the level in and in the graphical object Andrew's pitchfork. The numeration of levels starts from zero.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/objectgetdouble$")]
        public IHttpContext Handle_ObjectGetDouble_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, ObjectGetDouble_1);
        }

        private async Task<JObject> ObjectGetDouble_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "chart_id");
            ParamAdd(context, parameters, "object_name");
            ParamAdd(context, parameters, "prop_id");
            ParamAdd(context, parameters, "prop_modifier");
            await ExecCommandAsync(context, MQLCommand.ObjectGetDouble_1, parameters); // MQLCommand ENUM = 180

            result["result"] = Convert.ToDecimal(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> ObjectGetInteger<br>
        /// <b>Description:</b> The function returns the value of the corresponding object property. The object property must be of the<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectgetinteger.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart identifier. 0 means the current chart.</li>
        /// <li><b>object_name</b> :  [in] Name of the object.</li>
        /// <li><b>prop_id</b> :  [in] ID of the object property. The value can be one of the values of the enumeration.</li>
        /// <li><b>prop_modifier</b> :  [in] Modifier of the specified property. For the first variant, the default modifier value is equal to 0. Most properties do not require a modifier. It denotes the number of the level in and in the graphical object Andrew's pitchfork. The numeration of levels starts from zero.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectgetinteger$")]
        public IHttpContext Handle_ObjectGetInteger_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), ObjectGetInteger_1);
        }

        /// <summary>
        /// <b>Function:</b> ObjectGetInteger<br>
        /// <b>Description:</b> The function returns the value of the corresponding object property. The object property must be of the<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectgetinteger.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart identifier. 0 means the current chart.</li>
        /// <li><b>object_name</b> :  [in] Name of the object.</li>
        /// <li><b>prop_id</b> :  [in] ID of the object property. The value can be one of the values of the enumeration.</li>
        /// <li><b>prop_modifier</b> :  [in] Modifier of the specified property. For the first variant, the default modifier value is equal to 0. Most properties do not require a modifier. It denotes the number of the level in and in the graphical object Andrew's pitchfork. The numeration of levels starts from zero.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/objectgetinteger$")]
        public IHttpContext Handle_ObjectGetInteger_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, ObjectGetInteger_1);
        }

        private async Task<JObject> ObjectGetInteger_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "chart_id");
            ParamAdd(context, parameters, "object_name");
            ParamAdd(context, parameters, "prop_id");
            ParamAdd(context, parameters, "prop_modifier");
            await ExecCommandAsync(context, MQLCommand.ObjectGetInteger_1, parameters); // MQLCommand ENUM = 181

            result["result"] = Convert.ToInt64(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> ObjectGetString<br>
        /// <b>Description:</b> The function returns the value of the corresponding object property. The object property must be of the<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectgetstring.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart identifier. 0 means the current chart.</li>
        /// <li><b>object_name</b> :  [in] Name of the object.</li>
        /// <li><b>prop_id</b> :  [in] ID of the object property. The value can be one of the values of the enumeration.</li>
        /// <li><b>prop_modifier</b> :  [in] Modifier of the specified property. For the first variant, the default modifier value is equal to 0. Most properties do not require a modifier. It denotes the number of the level in and in the graphical object Andrew's pitchfork. The numeration of levels starts from zero.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectgetstring$")]
        public IHttpContext Handle_ObjectGetString_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), ObjectGetString_1);
        }

        /// <summary>
        /// <b>Function:</b> ObjectGetString<br>
        /// <b>Description:</b> The function returns the value of the corresponding object property. The object property must be of the<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectgetstring.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart identifier. 0 means the current chart.</li>
        /// <li><b>object_name</b> :  [in] Name of the object.</li>
        /// <li><b>prop_id</b> :  [in] ID of the object property. The value can be one of the values of the enumeration.</li>
        /// <li><b>prop_modifier</b> :  [in] Modifier of the specified property. For the first variant, the default modifier value is equal to 0. Most properties do not require a modifier. It denotes the number of the level in and in the graphical object Andrew's pitchfork. The numeration of levels starts from zero.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/objectgetstring$")]
        public IHttpContext Handle_ObjectGetString_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, ObjectGetString_1);
        }

        private async Task<JObject> ObjectGetString_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "chart_id");
            ParamAdd(context, parameters, "object_name");
            ParamAdd(context, parameters, "prop_id");
            ParamAdd(context, parameters, "prop_modifier");
            await ExecCommandAsync(context, MQLCommand.ObjectGetString_1, parameters); // MQLCommand ENUM = 182

            result["result"] = (string)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> ObjectSetDouble<br>
        /// <b>Description:</b> The function sets the value of the corresponding object property. The object property must be of the<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectsetdouble.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart identifier. 0 means the current chart.</li>
        /// <li><b>object_name</b> :  [in] Name of the object.</li>
        /// <li><b>prop_id</b> :  [in] ID of the object property. The value can be one of the values of the enumeration.</li>
        /// <li><b>prop_value</b> :  [in] The value of the property.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectsetdouble$")]
        public IHttpContext Handle_ObjectSetDouble_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), ObjectSetDouble_1);
        }

        /// <summary>
        /// <b>Function:</b> ObjectSetDouble<br>
        /// <b>Description:</b> The function sets the value of the corresponding object property. The object property must be of the<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectsetdouble.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart identifier. 0 means the current chart.</li>
        /// <li><b>object_name</b> :  [in] Name of the object.</li>
        /// <li><b>prop_id</b> :  [in] ID of the object property. The value can be one of the values of the enumeration.</li>
        /// <li><b>prop_value</b> :  [in] The value of the property.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/objectsetdouble$")]
        public IHttpContext Handle_ObjectSetDouble_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, ObjectSetDouble_1);
        }

        private async Task<JObject> ObjectSetDouble_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "chart_id");
            ParamAdd(context, parameters, "object_name");
            ParamAdd(context, parameters, "prop_id");
            ParamAdd(context, parameters, "prop_value");
            await ExecCommandAsync(context, MQLCommand.ObjectSetDouble_1, parameters); // MQLCommand ENUM = 183

            result["result"] = (bool)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> ObjectSetDouble<br>
        /// <b>Description:</b> The function sets the value of the corresponding object property. The object property must be of the<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectsetdouble.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart identifier. 0 means the current chart.</li>
        /// <li><b>object_name</b> :  [in] Name of the object.</li>
        /// <li><b>prop_id</b> :  [in] ID of the object property. The value can be one of the values of the enumeration.</li>
        /// <li><b>prop_modifier</b> :  [in] Modifier of the specified property. It denotes the number of the level in and in the graphical object Andrew's pitchfork. The numeration of levels starts from zero.</li>
        /// <li><b>prop_value</b> :  [in] The value of the property.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectsetdouble$")]
        public IHttpContext Handle_ObjectSetDouble_2(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), ObjectSetDouble_2);
        }

        /// <summary>
        /// <b>Function:</b> ObjectSetDouble<br>
        /// <b>Description:</b> The function sets the value of the corresponding object property. The object property must be of the<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectsetdouble.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart identifier. 0 means the current chart.</li>
        /// <li><b>object_name</b> :  [in] Name of the object.</li>
        /// <li><b>prop_id</b> :  [in] ID of the object property. The value can be one of the values of the enumeration.</li>
        /// <li><b>prop_modifier</b> :  [in] Modifier of the specified property. It denotes the number of the level in and in the graphical object Andrew's pitchfork. The numeration of levels starts from zero.</li>
        /// <li><b>prop_value</b> :  [in] The value of the property.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/objectsetdouble$")]
        public IHttpContext Handle_ObjectSetDouble_2_Default(IHttpContext context)
        {
            return SendJsonResponse(context, ObjectSetDouble_2);
        }

        private async Task<JObject> ObjectSetDouble_2(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "chart_id");
            ParamAdd(context, parameters, "object_name");
            ParamAdd(context, parameters, "prop_id");
            ParamAdd(context, parameters, "prop_modifier");
            ParamAdd(context, parameters, "prop_value");
            await ExecCommandAsync(context, MQLCommand.ObjectSetDouble_2, parameters); // MQLCommand ENUM = 183

            result["result"] = (bool)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> ObjectSetInteger<br>
        /// <b>Description:</b> The function sets the value of the corresponding object property. The object property must be of the<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectsetinteger.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart identifier. 0 means the current chart.</li>
        /// <li><b>object_name</b> :  [in] Name of the object.</li>
        /// <li><b>prop_id</b> :  [in] ID of the object property. The value can be one of the values of the enumeration.</li>
        /// <li><b>prop_value</b> :  [in] The value of the property.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectsetinteger$")]
        public IHttpContext Handle_ObjectSetInteger_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), ObjectSetInteger_1);
        }

        /// <summary>
        /// <b>Function:</b> ObjectSetInteger<br>
        /// <b>Description:</b> The function sets the value of the corresponding object property. The object property must be of the<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectsetinteger.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart identifier. 0 means the current chart.</li>
        /// <li><b>object_name</b> :  [in] Name of the object.</li>
        /// <li><b>prop_id</b> :  [in] ID of the object property. The value can be one of the values of the enumeration.</li>
        /// <li><b>prop_value</b> :  [in] The value of the property.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/objectsetinteger$")]
        public IHttpContext Handle_ObjectSetInteger_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, ObjectSetInteger_1);
        }

        private async Task<JObject> ObjectSetInteger_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "chart_id");
            ParamAdd(context, parameters, "object_name");
            ParamAdd(context, parameters, "prop_id");
            ParamAdd(context, parameters, "prop_value");
            await ExecCommandAsync(context, MQLCommand.ObjectSetInteger_1, parameters); // MQLCommand ENUM = 184

            result["result"] = (bool)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> ObjectSetInteger<br>
        /// <b>Description:</b> The function sets the value of the corresponding object property. The object property must be of the<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectsetinteger.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart identifier. 0 means the current chart.</li>
        /// <li><b>object_name</b> :  [in] Name of the object.</li>
        /// <li><b>prop_id</b> :  [in] ID of the object property. The value can be one of the values of the enumeration.</li>
        /// <li><b>prop_modifier</b> :  [in] Modifier of the specified property. It denotes the number of the level in and in the graphical object Andrew's pitchfork. The numeration of levels starts from zero.</li>
        /// <li><b>prop_value</b> :  [in] The value of the property.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectsetinteger$")]
        public IHttpContext Handle_ObjectSetInteger_2(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), ObjectSetInteger_2);
        }

        /// <summary>
        /// <b>Function:</b> ObjectSetInteger<br>
        /// <b>Description:</b> The function sets the value of the corresponding object property. The object property must be of the<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectsetinteger.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart identifier. 0 means the current chart.</li>
        /// <li><b>object_name</b> :  [in] Name of the object.</li>
        /// <li><b>prop_id</b> :  [in] ID of the object property. The value can be one of the values of the enumeration.</li>
        /// <li><b>prop_modifier</b> :  [in] Modifier of the specified property. It denotes the number of the level in and in the graphical object Andrew's pitchfork. The numeration of levels starts from zero.</li>
        /// <li><b>prop_value</b> :  [in] The value of the property.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/objectsetinteger$")]
        public IHttpContext Handle_ObjectSetInteger_2_Default(IHttpContext context)
        {
            return SendJsonResponse(context, ObjectSetInteger_2);
        }

        private async Task<JObject> ObjectSetInteger_2(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "chart_id");
            ParamAdd(context, parameters, "object_name");
            ParamAdd(context, parameters, "prop_id");
            ParamAdd(context, parameters, "prop_modifier");
            ParamAdd(context, parameters, "prop_value");
            await ExecCommandAsync(context, MQLCommand.ObjectSetInteger_2, parameters); // MQLCommand ENUM = 184

            result["result"] = (bool)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> ObjectSetString<br>
        /// <b>Description:</b> The function sets the value of the corresponding object property. The object property must be of the<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectsetstring.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart identifier. 0 means the current chart.</li>
        /// <li><b>object_name</b> :  [in] Name of the object.</li>
        /// <li><b>prop_id</b> :  [in] ID of the object property. The value can be one of the values of the enumeration.</li>
        /// <li><b>prop_value</b> :  [in] The value of the property.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectsetstring$")]
        public IHttpContext Handle_ObjectSetString_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), ObjectSetString_1);
        }

        /// <summary>
        /// <b>Function:</b> ObjectSetString<br>
        /// <b>Description:</b> The function sets the value of the corresponding object property. The object property must be of the<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectsetstring.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart identifier. 0 means the current chart.</li>
        /// <li><b>object_name</b> :  [in] Name of the object.</li>
        /// <li><b>prop_id</b> :  [in] ID of the object property. The value can be one of the values of the enumeration.</li>
        /// <li><b>prop_value</b> :  [in] The value of the property.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/objectsetstring$")]
        public IHttpContext Handle_ObjectSetString_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, ObjectSetString_1);
        }

        private async Task<JObject> ObjectSetString_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "chart_id");
            ParamAdd(context, parameters, "object_name");
            ParamAdd(context, parameters, "prop_id");
            ParamAdd(context, parameters, "prop_value");
            await ExecCommandAsync(context, MQLCommand.ObjectSetString_1, parameters); // MQLCommand ENUM = 185

            result["result"] = (bool)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> ObjectSetString<br>
        /// <b>Description:</b> The function sets the value of the corresponding object property. The object property must be of the<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectsetstring.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart identifier. 0 means the current chart.</li>
        /// <li><b>object_name</b> :  [in] Name of the object.</li>
        /// <li><b>prop_id</b> :  [in] ID of the object property. The value can be one of the values of the enumeration.</li>
        /// <li><b>prop_modifier</b> :  [in] Modifier of the specified property. It denotes the number of the level in and in the graphical object Andrew's pitchfork. The numeration of levels starts from zero.</li>
        /// <li><b>prop_value</b> :  [in] The value of the property.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectsetstring$")]
        public IHttpContext Handle_ObjectSetString_2(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), ObjectSetString_2);
        }

        /// <summary>
        /// <b>Function:</b> ObjectSetString<br>
        /// <b>Description:</b> The function sets the value of the corresponding object property. The object property must be of the<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectsetstring.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart identifier. 0 means the current chart.</li>
        /// <li><b>object_name</b> :  [in] Name of the object.</li>
        /// <li><b>prop_id</b> :  [in] ID of the object property. The value can be one of the values of the enumeration.</li>
        /// <li><b>prop_modifier</b> :  [in] Modifier of the specified property. It denotes the number of the level in and in the graphical object Andrew's pitchfork. The numeration of levels starts from zero.</li>
        /// <li><b>prop_value</b> :  [in] The value of the property.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/objectsetstring$")]
        public IHttpContext Handle_ObjectSetString_2_Default(IHttpContext context)
        {
            return SendJsonResponse(context, ObjectSetString_2);
        }

        private async Task<JObject> ObjectSetString_2(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "chart_id");
            ParamAdd(context, parameters, "object_name");
            ParamAdd(context, parameters, "prop_id");
            ParamAdd(context, parameters, "prop_modifier");
            ParamAdd(context, parameters, "prop_value");
            await ExecCommandAsync(context, MQLCommand.ObjectSetString_2, parameters); // MQLCommand ENUM = 185

            result["result"] = (bool)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> TextSetFont<br>
        /// <b>Description:</b> The function sets the font for displaying the text using drawing methods and returns the result of that operation. Arial font with the size -120 (12 pt) is used by default.<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/textsetfont.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>name</b> :  [in] Font name in the system or the name of the resource containing the font or the path to font file on the disk.</li>
        /// <li><b>size</b> :  [in] The font size that can be set using positive and negative values. In case of positive values, the size of a displayed text does not depend on the operating system's font size settings. In case of negative values, the value is set in tenths of a point and the text size depends on the operating system settings ("standard scale" or "large scale"). See the Note below for more information about the differences between the modes.</li>
        /// <li><b>flags</b> :  [in] Combination of describing font style.</li>
        /// <li><b>orientation</b> :  [in] Text's horizontal inclination to X axis, the unit of measurement is 0.1 degrees. It means that orientation=450 stands for inclination equal to 45 degrees.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/textsetfont$")]
        public IHttpContext Handle_TextSetFont_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), TextSetFont_1);
        }

        /// <summary>
        /// <b>Function:</b> TextSetFont<br>
        /// <b>Description:</b> The function sets the font for displaying the text using drawing methods and returns the result of that operation. Arial font with the size -120 (12 pt) is used by default.<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/textsetfont.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>name</b> :  [in] Font name in the system or the name of the resource containing the font or the path to font file on the disk.</li>
        /// <li><b>size</b> :  [in] The font size that can be set using positive and negative values. In case of positive values, the size of a displayed text does not depend on the operating system's font size settings. In case of negative values, the value is set in tenths of a point and the text size depends on the operating system settings ("standard scale" or "large scale"). See the Note below for more information about the differences between the modes.</li>
        /// <li><b>flags</b> :  [in] Combination of describing font style.</li>
        /// <li><b>orientation</b> :  [in] Text's horizontal inclination to X axis, the unit of measurement is 0.1 degrees. It means that orientation=450 stands for inclination equal to 45 degrees.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/textsetfont$")]
        public IHttpContext Handle_TextSetFont_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, TextSetFont_1);
        }

        private async Task<JObject> TextSetFont_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "name");
            ParamAdd(context, parameters, "size");
            ParamAdd(context, parameters, "flags");
            ParamAdd(context, parameters, "orientation");
            await ExecCommandAsync(context, MQLCommand.TextSetFont_1, parameters); // MQLCommand ENUM = 186

            result["result"] = (bool)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> ObjectDescription<br>
        /// <b>Description:</b> Returns the object description.<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectdescription.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>object_name</b> :  [in] Object name.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectdescription$")]
        public IHttpContext Handle_ObjectDescription_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), ObjectDescription_1);
        }

        /// <summary>
        /// <b>Function:</b> ObjectDescription<br>
        /// <b>Description:</b> Returns the object description.<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectdescription.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>object_name</b> :  [in] Object name.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/objectdescription$")]
        public IHttpContext Handle_ObjectDescription_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, ObjectDescription_1);
        }

        private async Task<JObject> ObjectDescription_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "object_name");
            await ExecCommandAsync(context, MQLCommand.ObjectDescription_1, parameters); // MQLCommand ENUM = 187

            result["result"] = (string)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> ObjectGet<br>
        /// <b>Description:</b> Returns the value of the specified object property.<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectget.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>object_name</b> :  [in] Object name.</li>
        /// <li><b>index</b> :  [in] Object property index. It can be any of the enumeration values.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectget$")]
        public IHttpContext Handle_ObjectGet_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), ObjectGet_1);
        }

        /// <summary>
        /// <b>Function:</b> ObjectGet<br>
        /// <b>Description:</b> Returns the value of the specified object property.<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectget.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>object_name</b> :  [in] Object name.</li>
        /// <li><b>index</b> :  [in] Object property index. It can be any of the enumeration values.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/objectget$")]
        public IHttpContext Handle_ObjectGet_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, ObjectGet_1);
        }

        private async Task<JObject> ObjectGet_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "object_name");
            ParamAdd(context, parameters, "index");
            await ExecCommandAsync(context, MQLCommand.ObjectGet_1, parameters); // MQLCommand ENUM = 188

            result["result"] = Convert.ToDecimal(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> ObjectGetFiboDescription<br>
        /// <b>Description:</b> Returns the level description of a Fibonacci object.<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectgetfibodescription.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>object_name</b> :  [in] Fibonacci object name.</li>
        /// <li><b>index</b> :  [in] Index of the Fibonacci level (0-31).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectgetfibodescription$")]
        public IHttpContext Handle_ObjectGetFiboDescription_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), ObjectGetFiboDescription_1);
        }

        /// <summary>
        /// <b>Function:</b> ObjectGetFiboDescription<br>
        /// <b>Description:</b> Returns the level description of a Fibonacci object.<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectgetfibodescription.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>object_name</b> :  [in] Fibonacci object name.</li>
        /// <li><b>index</b> :  [in] Index of the Fibonacci level (0-31).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/objectgetfibodescription$")]
        public IHttpContext Handle_ObjectGetFiboDescription_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, ObjectGetFiboDescription_1);
        }

        private async Task<JObject> ObjectGetFiboDescription_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "object_name");
            ParamAdd(context, parameters, "index");
            await ExecCommandAsync(context, MQLCommand.ObjectGetFiboDescription_1, parameters); // MQLCommand ENUM = 189

            result["result"] = (string)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> ObjectGetShiftByValue<br>
        /// <b>Description:</b> The function calculates and returns bar index (shift related to the current bar) for the given price.<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectgetshiftbyvalue.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>object_name</b> :  [in] Object name.</li>
        /// <li><b>value</b> :  [in] Price value.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectgetshiftbyvalue$")]
        public IHttpContext Handle_ObjectGetShiftByValue_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), ObjectGetShiftByValue_1);
        }

        /// <summary>
        /// <b>Function:</b> ObjectGetShiftByValue<br>
        /// <b>Description:</b> The function calculates and returns bar index (shift related to the current bar) for the given price.<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectgetshiftbyvalue.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>object_name</b> :  [in] Object name.</li>
        /// <li><b>value</b> :  [in] Price value.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/objectgetshiftbyvalue$")]
        public IHttpContext Handle_ObjectGetShiftByValue_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, ObjectGetShiftByValue_1);
        }

        private async Task<JObject> ObjectGetShiftByValue_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "object_name");
            ParamAdd(context, parameters, "value");
            await ExecCommandAsync(context, MQLCommand.ObjectGetShiftByValue_1, parameters); // MQLCommand ENUM = 190

            result["result"] = Convert.ToInt32(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> ObjectGetValueByShift<br>
        /// <b>Description:</b> The function calculates and returns the price value for the specified bar (shift related to the current bar).<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectgetvaluebyshift.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>object_name</b> :  [in] Object name.</li>
        /// <li><b>shift</b> :  [in] Bar index.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectgetvaluebyshift$")]
        public IHttpContext Handle_ObjectGetValueByShift_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), ObjectGetValueByShift_1);
        }

        /// <summary>
        /// <b>Function:</b> ObjectGetValueByShift<br>
        /// <b>Description:</b> The function calculates and returns the price value for the specified bar (shift related to the current bar).<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectgetvaluebyshift.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>object_name</b> :  [in] Object name.</li>
        /// <li><b>shift</b> :  [in] Bar index.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/objectgetvaluebyshift$")]
        public IHttpContext Handle_ObjectGetValueByShift_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, ObjectGetValueByShift_1);
        }

        private async Task<JObject> ObjectGetValueByShift_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "object_name");
            ParamAdd(context, parameters, "shift");
            await ExecCommandAsync(context, MQLCommand.ObjectGetValueByShift_1, parameters); // MQLCommand ENUM = 191

            result["result"] = Convert.ToDecimal(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> ObjectSet<br>
        /// <b>Description:</b> Changes the value of the specified object property.<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectset.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>object_name</b> :  [in] Object name.</li>
        /// <li><b>index</b> :  [in] Object property index. It can be any of enumeration values.</li>
        /// <li><b>value</b> :  [in] New value of the given property.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectset$")]
        public IHttpContext Handle_ObjectSet_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), ObjectSet_1);
        }

        /// <summary>
        /// <b>Function:</b> ObjectSet<br>
        /// <b>Description:</b> Changes the value of the specified object property.<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectset.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>object_name</b> :  [in] Object name.</li>
        /// <li><b>index</b> :  [in] Object property index. It can be any of enumeration values.</li>
        /// <li><b>value</b> :  [in] New value of the given property.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/objectset$")]
        public IHttpContext Handle_ObjectSet_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, ObjectSet_1);
        }

        private async Task<JObject> ObjectSet_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "object_name");
            ParamAdd(context, parameters, "index");
            ParamAdd(context, parameters, "value");
            await ExecCommandAsync(context, MQLCommand.ObjectSet_1, parameters); // MQLCommand ENUM = 192

            result["result"] = (bool)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> ObjectSetFiboDescription<br>
        /// <b>Description:</b> The function sets a new description to a level of a Fibonacci object.<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectsetfibodescription.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>object_name</b> :  [in] Object name.</li>
        /// <li><b>index</b> :  [in] Index of the Fibonacci level (0-31).</li>
        /// <li><b>text</b> :  [in] New description of the level.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectsetfibodescription$")]
        public IHttpContext Handle_ObjectSetFiboDescription_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), ObjectSetFiboDescription_1);
        }

        /// <summary>
        /// <b>Function:</b> ObjectSetFiboDescription<br>
        /// <b>Description:</b> The function sets a new description to a level of a Fibonacci object.<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectsetfibodescription.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>object_name</b> :  [in] Object name.</li>
        /// <li><b>index</b> :  [in] Index of the Fibonacci level (0-31).</li>
        /// <li><b>text</b> :  [in] New description of the level.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/objectsetfibodescription$")]
        public IHttpContext Handle_ObjectSetFiboDescription_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, ObjectSetFiboDescription_1);
        }

        private async Task<JObject> ObjectSetFiboDescription_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "object_name");
            ParamAdd(context, parameters, "index");
            ParamAdd(context, parameters, "text");
            await ExecCommandAsync(context, MQLCommand.ObjectSetFiboDescription_1, parameters); // MQLCommand ENUM = 193

            result["result"] = (bool)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> ObjectSetText<br>
        /// <b>Description:</b> The function c<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectsettext.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>object_name</b> :  [in] Object name.</li>
        /// <li><b>text</b> :  [in] A text describing the object.</li>
        /// <li><b>font_size</b> :  [in] Font size in points.</li>
        /// <li><b>font_name</b> :  [in] Font name.</li>
        /// <li><b>text_color</b> :  [in] Font color.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectsettext$")]
        public IHttpContext Handle_ObjectSetText_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), ObjectSetText_1);
        }

        /// <summary>
        /// <b>Function:</b> ObjectSetText<br>
        /// <b>Description:</b> The function c<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectsettext.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>object_name</b> :  [in] Object name.</li>
        /// <li><b>text</b> :  [in] A text describing the object.</li>
        /// <li><b>font_size</b> :  [in] Font size in points.</li>
        /// <li><b>font_name</b> :  [in] Font name.</li>
        /// <li><b>text_color</b> :  [in] Font color.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/objectsettext$")]
        public IHttpContext Handle_ObjectSetText_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, ObjectSetText_1);
        }

        private async Task<JObject> ObjectSetText_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "object_name");
            ParamAdd(context, parameters, "text");
            ParamAdd(context, parameters, "font_size");
            ParamAdd(context, parameters, "font_name");
            ParamAdd(context, parameters, "text_color");
            await ExecCommandAsync(context, MQLCommand.ObjectSetText_1, parameters); // MQLCommand ENUM = 194

            result["result"] = (bool)GetCommandResult(context);

            return result;
        }
        /// <summary>
        /// <b>Function:</b> ObjectType<br>
        /// <b>Description:</b> The function returns the object type value.<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objecttype.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>object_name</b> :  [in] Object name.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/objecttype$")]
        public IHttpContext Handle_ObjectType_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), ObjectType_1);
        }

        /// <summary>
        /// <b>Function:</b> ObjectType<br>
        /// <b>Description:</b> The function returns the object type value.<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objecttype.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>object_name</b> :  [in] Object name.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/objecttype$")]
        public IHttpContext Handle_ObjectType_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, ObjectType_1);
        }

        private async Task<JObject> ObjectType_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "object_name");
            await ExecCommandAsync(context, MQLCommand.ObjectType_1, parameters); // MQLCommand ENUM = 195

            result["result"] = Convert.ToInt32(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> iAC<br>
        /// <b>Description:</b> Calculates the Bill Williams' Accelerator/Decelerator oscillator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/iac.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/iac$")]
        public IHttpContext Handle_iAC_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), iAC_1);
        }

        /// <summary>
        /// <b>Function:</b> iAC<br>
        /// <b>Description:</b> Calculates the Bill Williams' Accelerator/Decelerator oscillator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/iac.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/iac$")]
        public IHttpContext Handle_iAC_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, iAC_1);
        }

        private async Task<JObject> iAC_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "symbol");
            ParamAdd(context, parameters, "timeframe");
            ParamAdd(context, parameters, "shift");
            await ExecCommandAsync(context, MQLCommand.iAC_1, parameters); // MQLCommand ENUM = 196

            result["result"] = Convert.ToDecimal(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> iAD<br>
        /// <b>Description:</b> Calculates the Accumulation/Distribution indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/iad.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/iad$")]
        public IHttpContext Handle_iAD_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), iAD_1);
        }

        /// <summary>
        /// <b>Function:</b> iAD<br>
        /// <b>Description:</b> Calculates the Accumulation/Distribution indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/iad.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/iad$")]
        public IHttpContext Handle_iAD_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, iAD_1);
        }

        private async Task<JObject> iAD_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "symbol");
            ParamAdd(context, parameters, "timeframe");
            ParamAdd(context, parameters, "shift");
            await ExecCommandAsync(context, MQLCommand.iAD_1, parameters); // MQLCommand ENUM = 197

            result["result"] = Convert.ToDecimal(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> iADX<br>
        /// <b>Description:</b> Calculates the Average Directional Movement Index indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/iadx.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>period</b> :  [in] Averaging period for calculation.</li>
        /// <li><b>applied_price</b> :  [in] Applied price. It can be any of enumeration values.</li>
        /// <li><b>mode</b> :  [in] Indicator line index. It can be any of the enumeration value. (0 - MODE_MAIN, 1 - MODE_PLUSDI, 2 - MODE_MINUSDI).</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/iadx$")]
        public IHttpContext Handle_iADX_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), iADX_1);
        }

        /// <summary>
        /// <b>Function:</b> iADX<br>
        /// <b>Description:</b> Calculates the Average Directional Movement Index indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/iadx.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>period</b> :  [in] Averaging period for calculation.</li>
        /// <li><b>applied_price</b> :  [in] Applied price. It can be any of enumeration values.</li>
        /// <li><b>mode</b> :  [in] Indicator line index. It can be any of the enumeration value. (0 - MODE_MAIN, 1 - MODE_PLUSDI, 2 - MODE_MINUSDI).</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/iadx$")]
        public IHttpContext Handle_iADX_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, iADX_1);
        }

        private async Task<JObject> iADX_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "symbol");
            ParamAdd(context, parameters, "timeframe");
            ParamAdd(context, parameters, "period");
            ParamAdd(context, parameters, "applied_price");
            ParamAdd(context, parameters, "mode");
            ParamAdd(context, parameters, "shift");
            await ExecCommandAsync(context, MQLCommand.iADX_1, parameters); // MQLCommand ENUM = 198

            result["result"] = Convert.ToDecimal(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> iAlligator<br>
        /// <b>Description:</b> Calculates the Alligator indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/ialligator.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>jaw_period</b> :  [in] Blue line averaging period (Alligator's Jaw).</li>
        /// <li><b>jaw_shift</b> :  [in] Blue line shift relative to the chart.</li>
        /// <li><b>teeth_period</b> :  [in] Red line averaging period (Alligator's Teeth).</li>
        /// <li><b>teeth_shift</b> :  [in] Red line shift relative to the chart.</li>
        /// <li><b>lips_period</b> :  [in] Green line averaging period (Alligator's Lips).</li>
        /// <li><b>lips_shift</b> :  [in] Green line shift relative to the chart.</li>
        /// <li><b>ma_method</b> :  [in] MA method. It can be any of Moving Average methods. It can be any of enumeration values.</li>
        /// <li><b>applied_price</b> :  [in] Applied price. It can be any of enumeration values.</li>
        /// <li><b>mode</b> :  [in] Data source, identifier of the . It can be any of the following values:</li>
        /// <li><b>shift</b> :  MODE_GATORJAW - Gator Jaw (blue) balance line,MODE_GATORTEETH - Gator Teeth (red) balance line,MODE_GATORLIPS - Gator Lips (green) balance line.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/ialligator$")]
        public IHttpContext Handle_iAlligator_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), iAlligator_1);
        }

        /// <summary>
        /// <b>Function:</b> iAlligator<br>
        /// <b>Description:</b> Calculates the Alligator indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/ialligator.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>jaw_period</b> :  [in] Blue line averaging period (Alligator's Jaw).</li>
        /// <li><b>jaw_shift</b> :  [in] Blue line shift relative to the chart.</li>
        /// <li><b>teeth_period</b> :  [in] Red line averaging period (Alligator's Teeth).</li>
        /// <li><b>teeth_shift</b> :  [in] Red line shift relative to the chart.</li>
        /// <li><b>lips_period</b> :  [in] Green line averaging period (Alligator's Lips).</li>
        /// <li><b>lips_shift</b> :  [in] Green line shift relative to the chart.</li>
        /// <li><b>ma_method</b> :  [in] MA method. It can be any of Moving Average methods. It can be any of enumeration values.</li>
        /// <li><b>applied_price</b> :  [in] Applied price. It can be any of enumeration values.</li>
        /// <li><b>mode</b> :  [in] Data source, identifier of the . It can be any of the following values:</li>
        /// <li><b>shift</b> :  MODE_GATORJAW - Gator Jaw (blue) balance line,MODE_GATORTEETH - Gator Teeth (red) balance line,MODE_GATORLIPS - Gator Lips (green) balance line.</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/ialligator$")]
        public IHttpContext Handle_iAlligator_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, iAlligator_1);
        }

        private async Task<JObject> iAlligator_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "symbol");
            ParamAdd(context, parameters, "timeframe");
            ParamAdd(context, parameters, "jaw_period");
            ParamAdd(context, parameters, "jaw_shift");
            ParamAdd(context, parameters, "teeth_period");
            ParamAdd(context, parameters, "teeth_shift");
            ParamAdd(context, parameters, "lips_period");
            ParamAdd(context, parameters, "lips_shift");
            ParamAdd(context, parameters, "ma_method");
            ParamAdd(context, parameters, "applied_price");
            ParamAdd(context, parameters, "mode");
            ParamAdd(context, parameters, "shift");
            await ExecCommandAsync(context, MQLCommand.iAlligator_1, parameters); // MQLCommand ENUM = 199

            result["result"] = Convert.ToDecimal(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> iAO<br>
        /// <b>Description:</b> Calculates the Awesome oscillator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/iao.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/iao$")]
        public IHttpContext Handle_iAO_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), iAO_1);
        }

        /// <summary>
        /// <b>Function:</b> iAO<br>
        /// <b>Description:</b> Calculates the Awesome oscillator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/iao.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/iao$")]
        public IHttpContext Handle_iAO_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, iAO_1);
        }

        private async Task<JObject> iAO_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "symbol");
            ParamAdd(context, parameters, "timeframe");
            ParamAdd(context, parameters, "shift");
            await ExecCommandAsync(context, MQLCommand.iAO_1, parameters); // MQLCommand ENUM = 200

            result["result"] = Convert.ToDecimal(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> iATR<br>
        /// <b>Description:</b> Calculates the Average True Range indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/iatr.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>period</b> :  [in] Averaging period.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/iatr$")]
        public IHttpContext Handle_iATR_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), iATR_1);
        }

        /// <summary>
        /// <b>Function:</b> iATR<br>
        /// <b>Description:</b> Calculates the Average True Range indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/iatr.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>period</b> :  [in] Averaging period.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/iatr$")]
        public IHttpContext Handle_iATR_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, iATR_1);
        }

        private async Task<JObject> iATR_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "symbol");
            ParamAdd(context, parameters, "timeframe");
            ParamAdd(context, parameters, "period");
            ParamAdd(context, parameters, "shift");
            await ExecCommandAsync(context, MQLCommand.iATR_1, parameters); // MQLCommand ENUM = 201

            result["result"] = Convert.ToDecimal(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> iBearsPower<br>
        /// <b>Description:</b> Calculates the Bears Power indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/ibearspower.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>period</b> :  [in] Averaging period.</li>
        /// <li><b>applied_price</b> :  [in] Applied price. It can be any of enumeration values.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/ibearspower$")]
        public IHttpContext Handle_iBearsPower_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), iBearsPower_1);
        }

        /// <summary>
        /// <b>Function:</b> iBearsPower<br>
        /// <b>Description:</b> Calculates the Bears Power indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/ibearspower.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>period</b> :  [in] Averaging period.</li>
        /// <li><b>applied_price</b> :  [in] Applied price. It can be any of enumeration values.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/ibearspower$")]
        public IHttpContext Handle_iBearsPower_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, iBearsPower_1);
        }

        private async Task<JObject> iBearsPower_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "symbol");
            ParamAdd(context, parameters, "timeframe");
            ParamAdd(context, parameters, "period");
            ParamAdd(context, parameters, "applied_price");
            ParamAdd(context, parameters, "shift");
            await ExecCommandAsync(context, MQLCommand.iBearsPower_1, parameters); // MQLCommand ENUM = 202

            result["result"] = Convert.ToDecimal(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> iBands<br>
        /// <b>Description:</b> Calculates the Bollinger Bands indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/ibands.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>period</b> :  [in] Averaging period to calculate the main line.</li>
        /// <li><b>deviation</b> :  [in] Number of standard deviations from the main line.</li>
        /// <li><b>bands_shift</b> :  [in] The indicator shift relative to the chart.</li>
        /// <li><b>applied_price</b> :  [in] Applied price. It can be any of enumeration values.</li>
        /// <li><b>mode</b> :  [in] Indicator line index. It can be any of the enumeration value (0 - MODE_MAIN, 1 - MODE_UPPER, 2 - MODE_LOWER).</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/ibands$")]
        public IHttpContext Handle_iBands_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), iBands_1);
        }

        /// <summary>
        /// <b>Function:</b> iBands<br>
        /// <b>Description:</b> Calculates the Bollinger Bands indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/ibands.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>period</b> :  [in] Averaging period to calculate the main line.</li>
        /// <li><b>deviation</b> :  [in] Number of standard deviations from the main line.</li>
        /// <li><b>bands_shift</b> :  [in] The indicator shift relative to the chart.</li>
        /// <li><b>applied_price</b> :  [in] Applied price. It can be any of enumeration values.</li>
        /// <li><b>mode</b> :  [in] Indicator line index. It can be any of the enumeration value (0 - MODE_MAIN, 1 - MODE_UPPER, 2 - MODE_LOWER).</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/ibands$")]
        public IHttpContext Handle_iBands_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, iBands_1);
        }

        private async Task<JObject> iBands_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "symbol");
            ParamAdd(context, parameters, "timeframe");
            ParamAdd(context, parameters, "period");
            ParamAdd(context, parameters, "deviation");
            ParamAdd(context, parameters, "bands_shift");
            ParamAdd(context, parameters, "applied_price");
            ParamAdd(context, parameters, "mode");
            ParamAdd(context, parameters, "shift");
            await ExecCommandAsync(context, MQLCommand.iBands_1, parameters); // MQLCommand ENUM = 203

            result["result"] = Convert.ToDecimal(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> iBullsPower<br>
        /// <b>Description:</b> Calculates the Bulls Power indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/ibullspower.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>period</b> :  [in] Averaging period for calculation.</li>
        /// <li><b>applied_price</b> :  [in] Applied price. It can be any of enumeration values.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/ibullspower$")]
        public IHttpContext Handle_iBullsPower_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), iBullsPower_1);
        }

        /// <summary>
        /// <b>Function:</b> iBullsPower<br>
        /// <b>Description:</b> Calculates the Bulls Power indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/ibullspower.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>period</b> :  [in] Averaging period for calculation.</li>
        /// <li><b>applied_price</b> :  [in] Applied price. It can be any of enumeration values.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/ibullspower$")]
        public IHttpContext Handle_iBullsPower_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, iBullsPower_1);
        }

        private async Task<JObject> iBullsPower_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "symbol");
            ParamAdd(context, parameters, "timeframe");
            ParamAdd(context, parameters, "period");
            ParamAdd(context, parameters, "applied_price");
            ParamAdd(context, parameters, "shift");
            await ExecCommandAsync(context, MQLCommand.iBullsPower_1, parameters); // MQLCommand ENUM = 204

            result["result"] = Convert.ToDecimal(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> iCCI<br>
        /// <b>Description:</b> Calculates the Commodity Channel Index indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/icci.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>period</b> :  [in] Averaging period for calculation.</li>
        /// <li><b>applied_price</b> :  [in] Applied price. It can be any of enumeration values.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/icci$")]
        public IHttpContext Handle_iCCI_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), iCCI_1);
        }

        /// <summary>
        /// <b>Function:</b> iCCI<br>
        /// <b>Description:</b> Calculates the Commodity Channel Index indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/icci.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>period</b> :  [in] Averaging period for calculation.</li>
        /// <li><b>applied_price</b> :  [in] Applied price. It can be any of enumeration values.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/icci$")]
        public IHttpContext Handle_iCCI_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, iCCI_1);
        }

        private async Task<JObject> iCCI_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "symbol");
            ParamAdd(context, parameters, "timeframe");
            ParamAdd(context, parameters, "period");
            ParamAdd(context, parameters, "applied_price");
            ParamAdd(context, parameters, "shift");
            await ExecCommandAsync(context, MQLCommand.iCCI_1, parameters); // MQLCommand ENUM = 205

            result["result"] = Convert.ToDecimal(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> iDeMarker<br>
        /// <b>Description:</b> Calculates the DeMarker indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/idemarker.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>period</b> :  [in] Averaging period for calculation.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/idemarker$")]
        public IHttpContext Handle_iDeMarker_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), iDeMarker_1);
        }

        /// <summary>
        /// <b>Function:</b> iDeMarker<br>
        /// <b>Description:</b> Calculates the DeMarker indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/idemarker.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>period</b> :  [in] Averaging period for calculation.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/idemarker$")]
        public IHttpContext Handle_iDeMarker_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, iDeMarker_1);
        }

        private async Task<JObject> iDeMarker_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "symbol");
            ParamAdd(context, parameters, "timeframe");
            ParamAdd(context, parameters, "period");
            ParamAdd(context, parameters, "shift");
            await ExecCommandAsync(context, MQLCommand.iDeMarker_1, parameters); // MQLCommand ENUM = 206

            result["result"] = Convert.ToDecimal(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> iEnvelopes<br>
        /// <b>Description:</b> Calculates the Envelopes indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/ienvelopes.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>ma_period</b> :  [in] Averaging period for calculation of the main line.</li>
        /// <li><b>ma_method</b> :  [in] Moving Average method. It can be any of enumeration values.</li>
        /// <li><b>ma_shift</b> :  [in] MA shift. Indicator line offset relate to the chart by timeframe.</li>
        /// <li><b>applied_price</b> :  [in] Applied price. It can be any of enumeration values.</li>
        /// <li><b>deviation</b> :  [in] Percent deviation from the main line.</li>
        /// <li><b>mode</b> :  [in] Indicator line index. It can be any of enumeration value (0 - MODE_MAIN, 1 - MODE_UPPER, 2 - MODE_LOWER).</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/ienvelopes$")]
        public IHttpContext Handle_iEnvelopes_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), iEnvelopes_1);
        }

        /// <summary>
        /// <b>Function:</b> iEnvelopes<br>
        /// <b>Description:</b> Calculates the Envelopes indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/ienvelopes.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>ma_period</b> :  [in] Averaging period for calculation of the main line.</li>
        /// <li><b>ma_method</b> :  [in] Moving Average method. It can be any of enumeration values.</li>
        /// <li><b>ma_shift</b> :  [in] MA shift. Indicator line offset relate to the chart by timeframe.</li>
        /// <li><b>applied_price</b> :  [in] Applied price. It can be any of enumeration values.</li>
        /// <li><b>deviation</b> :  [in] Percent deviation from the main line.</li>
        /// <li><b>mode</b> :  [in] Indicator line index. It can be any of enumeration value (0 - MODE_MAIN, 1 - MODE_UPPER, 2 - MODE_LOWER).</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/ienvelopes$")]
        public IHttpContext Handle_iEnvelopes_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, iEnvelopes_1);
        }

        private async Task<JObject> iEnvelopes_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "symbol");
            ParamAdd(context, parameters, "timeframe");
            ParamAdd(context, parameters, "ma_period");
            ParamAdd(context, parameters, "ma_method");
            ParamAdd(context, parameters, "ma_shift");
            ParamAdd(context, parameters, "applied_price");
            ParamAdd(context, parameters, "deviation");
            ParamAdd(context, parameters, "mode");
            ParamAdd(context, parameters, "shift");
            await ExecCommandAsync(context, MQLCommand.iEnvelopes_1, parameters); // MQLCommand ENUM = 207

            result["result"] = Convert.ToDecimal(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> iForce<br>
        /// <b>Description:</b> Calculates the Force Index indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/iforce.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>period</b> :  [in] Averaging period for calculation.</li>
        /// <li><b>ma_method</b> :  [in] Moving Average method. It can be any of enumeration values.</li>
        /// <li><b>applied_price</b> :  [in] Applied price. It can be any of enumeration values.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/iforce$")]
        public IHttpContext Handle_iForce_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), iForce_1);
        }

        /// <summary>
        /// <b>Function:</b> iForce<br>
        /// <b>Description:</b> Calculates the Force Index indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/iforce.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>period</b> :  [in] Averaging period for calculation.</li>
        /// <li><b>ma_method</b> :  [in] Moving Average method. It can be any of enumeration values.</li>
        /// <li><b>applied_price</b> :  [in] Applied price. It can be any of enumeration values.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/iforce$")]
        public IHttpContext Handle_iForce_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, iForce_1);
        }

        private async Task<JObject> iForce_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "symbol");
            ParamAdd(context, parameters, "timeframe");
            ParamAdd(context, parameters, "period");
            ParamAdd(context, parameters, "ma_method");
            ParamAdd(context, parameters, "applied_price");
            ParamAdd(context, parameters, "shift");
            await ExecCommandAsync(context, MQLCommand.iForce_1, parameters); // MQLCommand ENUM = 208

            result["result"] = Convert.ToDecimal(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> iFractals<br>
        /// <b>Description:</b> Calculates the Fractals indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/ifractals.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>mode</b> :  [in] Indicator line index. It can be any of the enumeration value.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/ifractals$")]
        public IHttpContext Handle_iFractals_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), iFractals_1);
        }

        /// <summary>
        /// <b>Function:</b> iFractals<br>
        /// <b>Description:</b> Calculates the Fractals indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/ifractals.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>mode</b> :  [in] Indicator line index. It can be any of the enumeration value.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/ifractals$")]
        public IHttpContext Handle_iFractals_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, iFractals_1);
        }

        private async Task<JObject> iFractals_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "symbol");
            ParamAdd(context, parameters, "timeframe");
            ParamAdd(context, parameters, "mode");
            ParamAdd(context, parameters, "shift");
            await ExecCommandAsync(context, MQLCommand.iFractals_1, parameters); // MQLCommand ENUM = 209

            result["result"] = Convert.ToDecimal(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> iGator<br>
        /// <b>Description:</b> Calculates the Gator oscillator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/igator.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>jaw_period</b> :  [in] Blue line averaging period (Alligator's Jaw).</li>
        /// <li><b>jaw_shift</b> :  [in] Blue line shift relative to the chart.</li>
        /// <li><b>teeth_period</b> :  [in] Red line averaging period (Alligator's Teeth).</li>
        /// <li><b>teeth_shift</b> :  [in] Red line shift relative to the chart.</li>
        /// <li><b>lips_period</b> :  [in] Green line averaging period (Alligator's Lips).</li>
        /// <li><b>lips_shift</b> :  [in] Green line shift relative to the chart.</li>
        /// <li><b>ma_method</b> :  [in] MA method. It can be any of enumeration value.</li>
        /// <li><b>applied_price</b> :  [in] Applied price. It can be any of enumeration values.</li>
        /// <li><b>mode</b> :  [in] Indicator line index. It can be any of enumeration value.</li>
        /// <li><b>shift</b> :  MODE_GATORJAW - blue line (Jaw line),MODE_GATORTEETH - red line (Teeth line),MODE_GATORLIPS - green line (Lips line).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/igator$")]
        public IHttpContext Handle_iGator_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), iGator_1);
        }

        /// <summary>
        /// <b>Function:</b> iGator<br>
        /// <b>Description:</b> Calculates the Gator oscillator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/igator.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>jaw_period</b> :  [in] Blue line averaging period (Alligator's Jaw).</li>
        /// <li><b>jaw_shift</b> :  [in] Blue line shift relative to the chart.</li>
        /// <li><b>teeth_period</b> :  [in] Red line averaging period (Alligator's Teeth).</li>
        /// <li><b>teeth_shift</b> :  [in] Red line shift relative to the chart.</li>
        /// <li><b>lips_period</b> :  [in] Green line averaging period (Alligator's Lips).</li>
        /// <li><b>lips_shift</b> :  [in] Green line shift relative to the chart.</li>
        /// <li><b>ma_method</b> :  [in] MA method. It can be any of enumeration value.</li>
        /// <li><b>applied_price</b> :  [in] Applied price. It can be any of enumeration values.</li>
        /// <li><b>mode</b> :  [in] Indicator line index. It can be any of enumeration value.</li>
        /// <li><b>shift</b> :  MODE_GATORJAW - blue line (Jaw line),MODE_GATORTEETH - red line (Teeth line),MODE_GATORLIPS - green line (Lips line).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/igator$")]
        public IHttpContext Handle_iGator_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, iGator_1);
        }

        private async Task<JObject> iGator_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "symbol");
            ParamAdd(context, parameters, "timeframe");
            ParamAdd(context, parameters, "jaw_period");
            ParamAdd(context, parameters, "jaw_shift");
            ParamAdd(context, parameters, "teeth_period");
            ParamAdd(context, parameters, "teeth_shift");
            ParamAdd(context, parameters, "lips_period");
            ParamAdd(context, parameters, "lips_shift");
            ParamAdd(context, parameters, "ma_method");
            ParamAdd(context, parameters, "applied_price");
            ParamAdd(context, parameters, "mode");
            ParamAdd(context, parameters, "shift");
            await ExecCommandAsync(context, MQLCommand.iGator_1, parameters); // MQLCommand ENUM = 210

            result["result"] = Convert.ToDecimal(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> iIchimoku<br>
        /// <b>Description:</b> Calculates the Ichimoku Kinko Hyo indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/iichimoku.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>tenkan_sen</b> :  [in] Tenkan Sen averaging period.</li>
        /// <li><b>kijun_sen</b> :  [in] Kijun Sen averaging period.</li>
        /// <li><b>senkou_span_b</b> :  [in] Senkou SpanB averaging period.</li>
        /// <li><b>mode</b> :  [in] Source of data. It can be one of the enumeration (1 - MODE_TENKANSEN, 2 - MODE_KIJUNSEN, 3 - MODE_SENKOUSPANA, 4 - MODE_SENKOUSPANB, 5 - MODE_CHIKOUSPAN).</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/iichimoku$")]
        public IHttpContext Handle_iIchimoku_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), iIchimoku_1);
        }

        /// <summary>
        /// <b>Function:</b> iIchimoku<br>
        /// <b>Description:</b> Calculates the Ichimoku Kinko Hyo indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/iichimoku.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>tenkan_sen</b> :  [in] Tenkan Sen averaging period.</li>
        /// <li><b>kijun_sen</b> :  [in] Kijun Sen averaging period.</li>
        /// <li><b>senkou_span_b</b> :  [in] Senkou SpanB averaging period.</li>
        /// <li><b>mode</b> :  [in] Source of data. It can be one of the enumeration (1 - MODE_TENKANSEN, 2 - MODE_KIJUNSEN, 3 - MODE_SENKOUSPANA, 4 - MODE_SENKOUSPANB, 5 - MODE_CHIKOUSPAN).</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/iichimoku$")]
        public IHttpContext Handle_iIchimoku_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, iIchimoku_1);
        }

        private async Task<JObject> iIchimoku_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "symbol");
            ParamAdd(context, parameters, "timeframe");
            ParamAdd(context, parameters, "tenkan_sen");
            ParamAdd(context, parameters, "kijun_sen");
            ParamAdd(context, parameters, "senkou_span_b");
            ParamAdd(context, parameters, "mode");
            ParamAdd(context, parameters, "shift");
            await ExecCommandAsync(context, MQLCommand.iIchimoku_1, parameters); // MQLCommand ENUM = 211

            result["result"] = Convert.ToDecimal(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> iBWMFI<br>
        /// <b>Description:</b> Calculates the Market Facilitation Index indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/ibwmfi.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/ibwmfi$")]
        public IHttpContext Handle_iBWMFI_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), iBWMFI_1);
        }

        /// <summary>
        /// <b>Function:</b> iBWMFI<br>
        /// <b>Description:</b> Calculates the Market Facilitation Index indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/ibwmfi.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/ibwmfi$")]
        public IHttpContext Handle_iBWMFI_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, iBWMFI_1);
        }

        private async Task<JObject> iBWMFI_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "symbol");
            ParamAdd(context, parameters, "timeframe");
            ParamAdd(context, parameters, "shift");
            await ExecCommandAsync(context, MQLCommand.iBWMFI_1, parameters); // MQLCommand ENUM = 212

            result["result"] = Convert.ToDecimal(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> iMomentum<br>
        /// <b>Description:</b> Calculates the Momentum indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/imomentum.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>period</b> :  [in] Averaging period (amount of bars) for calculation of price changes.</li>
        /// <li><b>applied_price</b> :  [in] Applied price. It can be any of enumeration values.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/imomentum$")]
        public IHttpContext Handle_iMomentum_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), iMomentum_1);
        }

        /// <summary>
        /// <b>Function:</b> iMomentum<br>
        /// <b>Description:</b> Calculates the Momentum indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/imomentum.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>period</b> :  [in] Averaging period (amount of bars) for calculation of price changes.</li>
        /// <li><b>applied_price</b> :  [in] Applied price. It can be any of enumeration values.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/imomentum$")]
        public IHttpContext Handle_iMomentum_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, iMomentum_1);
        }

        private async Task<JObject> iMomentum_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "symbol");
            ParamAdd(context, parameters, "timeframe");
            ParamAdd(context, parameters, "period");
            ParamAdd(context, parameters, "applied_price");
            ParamAdd(context, parameters, "shift");
            await ExecCommandAsync(context, MQLCommand.iMomentum_1, parameters); // MQLCommand ENUM = 213

            result["result"] = Convert.ToDecimal(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> iMFI<br>
        /// <b>Description:</b> Calculates the Money Flow Index indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/imfi.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>period</b> :  [in] Period (amount of bars) for calculation of the indicator.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/imfi$")]
        public IHttpContext Handle_iMFI_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), iMFI_1);
        }

        /// <summary>
        /// <b>Function:</b> iMFI<br>
        /// <b>Description:</b> Calculates the Money Flow Index indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/imfi.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>period</b> :  [in] Period (amount of bars) for calculation of the indicator.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/imfi$")]
        public IHttpContext Handle_iMFI_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, iMFI_1);
        }

        private async Task<JObject> iMFI_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "symbol");
            ParamAdd(context, parameters, "timeframe");
            ParamAdd(context, parameters, "period");
            ParamAdd(context, parameters, "shift");
            await ExecCommandAsync(context, MQLCommand.iMFI_1, parameters); // MQLCommand ENUM = 214

            result["result"] = Convert.ToDecimal(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> iMA<br>
        /// <b>Description:</b> Calculates the Moving Average indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/ima.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>ma_period</b> :  [in] Averaging period for calculation.</li>
        /// <li><b>ma_shift</b> :  [in] MA shift. Indicators line offset relate to the chart by timeframe.</li>
        /// <li><b>ma_method</b> :  [in] Moving Average method. It can be any of enumeration values.</li>
        /// <li><b>applied_price</b> :  [in] Applied price. It can be any of enumeration values.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/ima$")]
        public IHttpContext Handle_iMA_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), iMA_1);
        }

        /// <summary>
        /// <b>Function:</b> iMA<br>
        /// <b>Description:</b> Calculates the Moving Average indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/ima.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>ma_period</b> :  [in] Averaging period for calculation.</li>
        /// <li><b>ma_shift</b> :  [in] MA shift. Indicators line offset relate to the chart by timeframe.</li>
        /// <li><b>ma_method</b> :  [in] Moving Average method. It can be any of enumeration values.</li>
        /// <li><b>applied_price</b> :  [in] Applied price. It can be any of enumeration values.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/ima$")]
        public IHttpContext Handle_iMA_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, iMA_1);
        }

        private async Task<JObject> iMA_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "symbol");
            ParamAdd(context, parameters, "timeframe");
            ParamAdd(context, parameters, "ma_period");
            ParamAdd(context, parameters, "ma_shift");
            ParamAdd(context, parameters, "ma_method");
            ParamAdd(context, parameters, "applied_price");
            ParamAdd(context, parameters, "shift");
            await ExecCommandAsync(context, MQLCommand.iMA_1, parameters); // MQLCommand ENUM = 215

            result["result"] = Convert.ToDecimal(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> iOsMA<br>
        /// <b>Description:</b> iOsMA<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/iosma.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>fast_ema_period</b> :  [in] Fast EMA averaging period.</li>
        /// <li><b>slow_ema_period</b> :  [in] Slow EMA averaging period.</li>
        /// <li><b>signal_period</b> :  [in] Signal line averaging period.</li>
        /// <li><b>applied_price</b> :  [in] Applied price. It can be any of enumeration values.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/iosma$")]
        public IHttpContext Handle_iOsMA_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), iOsMA_1);
        }

        /// <summary>
        /// <b>Function:</b> iOsMA<br>
        /// <b>Description:</b> iOsMA<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/iosma.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>fast_ema_period</b> :  [in] Fast EMA averaging period.</li>
        /// <li><b>slow_ema_period</b> :  [in] Slow EMA averaging period.</li>
        /// <li><b>signal_period</b> :  [in] Signal line averaging period.</li>
        /// <li><b>applied_price</b> :  [in] Applied price. It can be any of enumeration values.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/iosma$")]
        public IHttpContext Handle_iOsMA_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, iOsMA_1);
        }

        private async Task<JObject> iOsMA_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "symbol");
            ParamAdd(context, parameters, "timeframe");
            ParamAdd(context, parameters, "fast_ema_period");
            ParamAdd(context, parameters, "slow_ema_period");
            ParamAdd(context, parameters, "signal_period");
            ParamAdd(context, parameters, "applied_price");
            ParamAdd(context, parameters, "shift");
            await ExecCommandAsync(context, MQLCommand.iOsMA_1, parameters); // MQLCommand ENUM = 216

            result["result"] = Convert.ToDecimal(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> iMACD<br>
        /// <b>Description:</b> Calculates the Moving Averages Convergence/Divergence indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/imacd.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>fast_ema_period</b> :  [in] Fast EMA averaging period.</li>
        /// <li><b>slow_ema_period</b> :  [in] Slow EMA averaging period.</li>
        /// <li><b>signal_period</b> :  [in] Signal line averaging period.</li>
        /// <li><b>applied_price</b> :  [in] Applied price. It can be any of enumeration values.</li>
        /// <li><b>mode</b> :  [in] Indicator line index. It can be one of the enumeration values (0-MODE_MAIN, 1-MODE_SIGNAL).</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/imacd$")]
        public IHttpContext Handle_iMACD_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), iMACD_1);
        }

        /// <summary>
        /// <b>Function:</b> iMACD<br>
        /// <b>Description:</b> Calculates the Moving Averages Convergence/Divergence indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/imacd.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>fast_ema_period</b> :  [in] Fast EMA averaging period.</li>
        /// <li><b>slow_ema_period</b> :  [in] Slow EMA averaging period.</li>
        /// <li><b>signal_period</b> :  [in] Signal line averaging period.</li>
        /// <li><b>applied_price</b> :  [in] Applied price. It can be any of enumeration values.</li>
        /// <li><b>mode</b> :  [in] Indicator line index. It can be one of the enumeration values (0-MODE_MAIN, 1-MODE_SIGNAL).</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/imacd$")]
        public IHttpContext Handle_iMACD_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, iMACD_1);
        }

        private async Task<JObject> iMACD_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "symbol");
            ParamAdd(context, parameters, "timeframe");
            ParamAdd(context, parameters, "fast_ema_period");
            ParamAdd(context, parameters, "slow_ema_period");
            ParamAdd(context, parameters, "signal_period");
            ParamAdd(context, parameters, "applied_price");
            ParamAdd(context, parameters, "mode");
            ParamAdd(context, parameters, "shift");
            await ExecCommandAsync(context, MQLCommand.iMACD_1, parameters); // MQLCommand ENUM = 217

            result["result"] = Convert.ToDecimal(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> iOBV<br>
        /// <b>Description:</b> Calculates the On Balance Volume indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/iobv.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>applied_price</b> :  [in] Applied price. It can be any of enumeration values.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/iobv$")]
        public IHttpContext Handle_iOBV_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), iOBV_1);
        }

        /// <summary>
        /// <b>Function:</b> iOBV<br>
        /// <b>Description:</b> Calculates the On Balance Volume indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/iobv.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>applied_price</b> :  [in] Applied price. It can be any of enumeration values.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/iobv$")]
        public IHttpContext Handle_iOBV_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, iOBV_1);
        }

        private async Task<JObject> iOBV_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "symbol");
            ParamAdd(context, parameters, "timeframe");
            ParamAdd(context, parameters, "applied_price");
            ParamAdd(context, parameters, "shift");
            await ExecCommandAsync(context, MQLCommand.iOBV_1, parameters); // MQLCommand ENUM = 218

            result["result"] = Convert.ToDecimal(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> iSAR<br>
        /// <b>Description:</b> Calculates the Parabolic Stop and Reverse system indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/isar.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>step</b> :  [in] The step of price increment, usually 0.02.</li>
        /// <li><b>maximum</b> :  [in] The maximum step, usually 0.2.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/isar$")]
        public IHttpContext Handle_iSAR_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), iSAR_1);
        }

        /// <summary>
        /// <b>Function:</b> iSAR<br>
        /// <b>Description:</b> Calculates the Parabolic Stop and Reverse system indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/isar.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>step</b> :  [in] The step of price increment, usually 0.02.</li>
        /// <li><b>maximum</b> :  [in] The maximum step, usually 0.2.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/isar$")]
        public IHttpContext Handle_iSAR_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, iSAR_1);
        }

        private async Task<JObject> iSAR_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "symbol");
            ParamAdd(context, parameters, "timeframe");
            ParamAdd(context, parameters, "step");
            ParamAdd(context, parameters, "maximum");
            ParamAdd(context, parameters, "shift");
            await ExecCommandAsync(context, MQLCommand.iSAR_1, parameters); // MQLCommand ENUM = 219

            result["result"] = Convert.ToDecimal(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> iRSI<br>
        /// <b>Description:</b> Calculates the Relative Strength Index indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/irsi.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>period</b> :  [in] Averaging period for calculation.</li>
        /// <li><b>applied_price</b> :  [in] Applied price. It can be any of enumeration values.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/irsi$")]
        public IHttpContext Handle_iRSI_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), iRSI_1);
        }

        /// <summary>
        /// <b>Function:</b> iRSI<br>
        /// <b>Description:</b> Calculates the Relative Strength Index indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/irsi.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>period</b> :  [in] Averaging period for calculation.</li>
        /// <li><b>applied_price</b> :  [in] Applied price. It can be any of enumeration values.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/irsi$")]
        public IHttpContext Handle_iRSI_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, iRSI_1);
        }

        private async Task<JObject> iRSI_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "symbol");
            ParamAdd(context, parameters, "timeframe");
            ParamAdd(context, parameters, "period");
            ParamAdd(context, parameters, "applied_price");
            ParamAdd(context, parameters, "shift");
            await ExecCommandAsync(context, MQLCommand.iRSI_1, parameters); // MQLCommand ENUM = 220

            result["result"] = Convert.ToDecimal(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> iRVI<br>
        /// <b>Description:</b> Calculates the Relative Vigor Index indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/irvi.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>period</b> :  [in] Averaging period for calculation.</li>
        /// <li><b>mode</b> :  [in] Indicator line index. It can be any of enumeration value.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/irvi$")]
        public IHttpContext Handle_iRVI_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), iRVI_1);
        }

        /// <summary>
        /// <b>Function:</b> iRVI<br>
        /// <b>Description:</b> Calculates the Relative Vigor Index indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/irvi.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>period</b> :  [in] Averaging period for calculation.</li>
        /// <li><b>mode</b> :  [in] Indicator line index. It can be any of enumeration value.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/irvi$")]
        public IHttpContext Handle_iRVI_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, iRVI_1);
        }

        private async Task<JObject> iRVI_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "symbol");
            ParamAdd(context, parameters, "timeframe");
            ParamAdd(context, parameters, "period");
            ParamAdd(context, parameters, "mode");
            ParamAdd(context, parameters, "shift");
            await ExecCommandAsync(context, MQLCommand.iRVI_1, parameters); // MQLCommand ENUM = 221

            result["result"] = Convert.ToDecimal(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> iStdDev<br>
        /// <b>Description:</b> Calculates the Standard Deviation indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/istddev.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>ma_period</b> :  [in] Moving Average period.</li>
        /// <li><b>ma_shift</b> :  [in] Moving Average shift.</li>
        /// <li><b>ma_method</b> :  [in] Moving Average method. It can be any of enumeration values.</li>
        /// <li><b>applied_price</b> :  [in] Applied price. It can be any of enumeration values.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/istddev$")]
        public IHttpContext Handle_iStdDev_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), iStdDev_1);
        }

        /// <summary>
        /// <b>Function:</b> iStdDev<br>
        /// <b>Description:</b> Calculates the Standard Deviation indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/istddev.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>ma_period</b> :  [in] Moving Average period.</li>
        /// <li><b>ma_shift</b> :  [in] Moving Average shift.</li>
        /// <li><b>ma_method</b> :  [in] Moving Average method. It can be any of enumeration values.</li>
        /// <li><b>applied_price</b> :  [in] Applied price. It can be any of enumeration values.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/istddev$")]
        public IHttpContext Handle_iStdDev_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, iStdDev_1);
        }

        private async Task<JObject> iStdDev_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "symbol");
            ParamAdd(context, parameters, "timeframe");
            ParamAdd(context, parameters, "ma_period");
            ParamAdd(context, parameters, "ma_shift");
            ParamAdd(context, parameters, "ma_method");
            ParamAdd(context, parameters, "applied_price");
            ParamAdd(context, parameters, "shift");
            await ExecCommandAsync(context, MQLCommand.iStdDev_1, parameters); // MQLCommand ENUM = 222

            result["result"] = Convert.ToDecimal(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> iStochastic<br>
        /// <b>Description:</b> Calculates the Stochastic Oscillator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/istochastic.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>Kperiod</b> :  [in] Period of the %K line.</li>
        /// <li><b>Dperiod</b> :  [in] Period of the %D line.</li>
        /// <li><b>slowing</b> :  [in] Slowing value.</li>
        /// <li><b>method</b> :  [in] Moving Average method. It can be any of enumeration values.</li>
        /// <li><b>price_field</b> :  [in] Price field parameter. Can be one of this values: 0 - Low/High or 1 - Close/Close.</li>
        /// <li><b>mode</b> :  [in] Indicator line index. It can be any of the enumeration value (0 - MODE_MAIN, 1 - MODE_SIGNAL).</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/istochastic$")]
        public IHttpContext Handle_iStochastic_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), iStochastic_1);
        }

        /// <summary>
        /// <b>Function:</b> iStochastic<br>
        /// <b>Description:</b> Calculates the Stochastic Oscillator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/istochastic.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>Kperiod</b> :  [in] Period of the %K line.</li>
        /// <li><b>Dperiod</b> :  [in] Period of the %D line.</li>
        /// <li><b>slowing</b> :  [in] Slowing value.</li>
        /// <li><b>method</b> :  [in] Moving Average method. It can be any of enumeration values.</li>
        /// <li><b>price_field</b> :  [in] Price field parameter. Can be one of this values: 0 - Low/High or 1 - Close/Close.</li>
        /// <li><b>mode</b> :  [in] Indicator line index. It can be any of the enumeration value (0 - MODE_MAIN, 1 - MODE_SIGNAL).</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/istochastic$")]
        public IHttpContext Handle_iStochastic_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, iStochastic_1);
        }

        private async Task<JObject> iStochastic_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "symbol");
            ParamAdd(context, parameters, "timeframe");
            ParamAdd(context, parameters, "Kperiod");
            ParamAdd(context, parameters, "Dperiod");
            ParamAdd(context, parameters, "slowing");
            ParamAdd(context, parameters, "method");
            ParamAdd(context, parameters, "price_field");
            ParamAdd(context, parameters, "mode");
            ParamAdd(context, parameters, "shift");
            await ExecCommandAsync(context, MQLCommand.iStochastic_1, parameters); // MQLCommand ENUM = 223

            result["result"] = Convert.ToDecimal(GetCommandResult(context));

            return result;
        }
        /// <summary>
        /// <b>Function:</b> iWPR<br>
        /// <b>Description:</b> Calculates the Larry Williams' Percent Range and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/iwpr.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>period</b> :  [in] Averaging period for calculation.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/[0-9]+/iwpr$")]
        public IHttpContext Handle_iWPR_1(IHttpContext context)
        {
            return SendJsonResponse(context, GetChartId(context), iWPR_1);
        }

        /// <summary>
        /// <b>Function:</b> iWPR<br>
        /// <b>Description:</b> Calculates the Larry Williams' Percent Range and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/iwpr.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>period</b> :  [in] Averaging period for calculation.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = @"^/iwpr$")]
        public IHttpContext Handle_iWPR_1_Default(IHttpContext context)
        {
            return SendJsonResponse(context, iWPR_1);
        }

        private async Task<JObject> iWPR_1(MQLRestContext context)
        {
            var payload = context.JsonPayload;
            var result = context.Result;
            if (PayloadNotValid(context))
                return context.Result;
            List<Object> parameters = new List<Object>();
            ParamAdd(context, parameters, "symbol");
            ParamAdd(context, parameters, "timeframe");
            ParamAdd(context, parameters, "period");
            ParamAdd(context, parameters, "shift");
            await ExecCommandAsync(context, MQLCommand.iWPR_1, parameters); // MQLCommand ENUM = 224

            result["result"] = Convert.ToDecimal(GetCommandResult(context));

            return result;
        }
    }
}