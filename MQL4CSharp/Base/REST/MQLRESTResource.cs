using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Grapevine.Interfaces.Server;
using Grapevine.Server;
using log4net;
using Grapevine.Server.Attributes;
using Grapevine.Shared;
using MQL4CSharp.Util;

namespace MQL4CSharp.Base.REST
{
    [RestResource]
    public sealed class MQLRESTResource : MQLRESTBase
    {

        private static readonly ILog LOG = LogManager.GetLogger(typeof(MQLRESTResource));

        //da lasciare per abilitare la scansione di questa classe
        [RestRoute(PathInfo = @"^/([0-9]+/)?(?i)helloworld$")]
        public IHttpContext HelloWorld(IHttpContext context)
        {
            context.Response.SendResponse("Hello, world.");
            return context;
        }

        protected override void SetResultFromMethod(MQLRestContext context, object target, MethodInfoExtended method)
        {
            if (method.Method.Name == nameof(MQLBase.ChartApplyTemplate))
                SetFileNameInfoAsInput(context, "templates", "tpl");
            else if (method.Method.Name == nameof(MQLBase.ChartSaveTemplate))
                SetFileNameInfoAsOutput(context, "templates", "tpl");
            else if (method.Method.Name == nameof(MQLBase.ChartScreenShot))
                SetFileNameInfoAsOutput(context, "MQL4\\Files", "png,gif,bmp");
            base.SetResultFromMethod(context, target, method);
        }

        public override void OnServerInit(RestServer server)
        {
            base.OnServerInit(server);
            //add routes to call directly methods of MQLBase
            var routeAdded = new HashSet<string>(server.Router.RoutingTable.Select(x => x.PathInfo));
            foreach (var methodInfo in typeof(MQLBase).GetMethods().Where(x => x.DeclaringType == typeof(MQLBase)))
            {
                var methodName = methodInfo.Name;
                if (methodName.StartsWith("get_") || methodName.StartsWith("set_"))
                    continue;
                var pathInfo = $@"^/([0-9]+/)?(?i){methodInfo.Name.ToLowerInvariant()}$";
                if (!routeAdded.Add(pathInfo))
                    continue;
                var route = new Route(context =>
                {
                    return SendJsonResponse(context, GetChartId(context), restContext =>
                    {
                        SetResultFromMethodName(restContext, restContext.Strategy, methodName);
                        return restContext.Result;
                    });
                }, HttpMethod.POST, pathInfo);
                server.Router.Register(route);
            }
        }
    }
}