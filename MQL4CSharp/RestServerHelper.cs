using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Grapevine.Server;
using Grapevine.Shared;
using log4net;
using mql4csharp;
using MQL4CSharp.Base;
using MQL4CSharp.Base.REST;
using RGiesecke.DllExport;

namespace MQL4CSharp
{
    public class RestServerHelper
    {
        private static readonly ILog LOG = LogManager.GetLogger(typeof(RestServerHelper));

        internal static ConcurrentDictionary<long, RestServer> instances = new ConcurrentDictionary<long, RestServer>();
         
        [DllExport("RestServerStart", CallingConvention = CallingConvention.StdCall)]
        public static bool RestServerStart(Int64 ix, [MarshalAs(UnmanagedType.LPWStr)] string listenAddress)
        {
            try
            {
                //https://scottoffen.github.io/grapevine-legacy/en/
                RestServer restServer;
                instances.TryGetValue(ix, out restServer);
                if (restServer?.IsListening == true)
                    return true;

                restServer = new RestServer();
                var hostAndPort = (listenAddress ?? "").Split(':');
                if (!string.IsNullOrEmpty(hostAndPort.First()))
                    restServer.Host = hostAndPort.First().Trim();
                if (hostAndPort.Length == 2 && !string.IsNullOrEmpty(hostAndPort.Last()))
                    restServer.Port = hostAndPort.Last().Trim();
                restServer.Router.ScanAssemblies();

                var registerdTypes = restServer.Router.RoutingTable.Select(x => x.Name)
                    .Where(x => x?.Contains(".") == true)
                    .Select(x => string.Join(".", x.Split('.').Reverse().Skip(1).Reverse()))
                    .Distinct()
                    .Select(x =>
                    {
                        try
                        {
                            return Type.GetType(x);
                        }
                        catch
                        {
                            return null;
                        }
                    })
                    .Where(x => x != null && x.IsClass)
                    .ToList();

                foreach (var registerdType in registerdTypes.Union(new[] { typeof(MQLRESTResource) }))
                {
                    var instance = Activator.CreateInstance(registerdType) as MQLRESTBase;
                    instance?.OnServerInit(restServer);
                }

                restServer.Start();
                instances.AddOrUpdate(ix, restServer, (l, server) => restServer);
                LOG.Info($"RestServer started {listenAddress}");
                return true;
            }
            catch (Exception e)
            {
                LOG.Error(e);
                return false;
            }
        }

        [DllExport("RestServerStop", CallingConvention = CallingConvention.StdCall)]
        public static void RestServerStop(Int64 ix)
        {
            try
            {
                RestServer restServer;
                instances.TryGetValue(ix, out restServer);
                if (restServer == null)
                    return;
                if (restServer.IsListening == true)
                    restServer.Stop();
                restServer.Dispose();
                instances.TryRemove(ix, out restServer);
                LOG.Info($"RestServer stopped");
            }
            catch (Exception e)
            {
                LOG.Error(e);
            }
        }
    }
}
