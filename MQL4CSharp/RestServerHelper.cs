using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Grapevine.Server;
using log4net;
using mql4csharp;
using RGiesecke.DllExport;

namespace MQL4CSharp
{
    public class RestServerHelper
    {
        private static readonly ILog LOG = LogManager.GetLogger(typeof(RestServerHelper));

        private static RESTServer _restServer;
        private static Int64 _restServerOwner;

        [DllExport("RestServerStart", CallingConvention = CallingConvention.StdCall)]
        public static void RestServerStart(Int64 ix, [MarshalAs(UnmanagedType.LPWStr)] string listenAddress)
        {
            try
            {
                if (_restServer?.IsListening == true)
                    return;
                _restServer = new RESTServer();
                var hostAndPort = (listenAddress ?? "").Split(':');
                if (!string.IsNullOrEmpty(hostAndPort.First()))
                    _restServer.Host = hostAndPort.First().Trim();
                if (hostAndPort.Length == 2 && !string.IsNullOrEmpty(hostAndPort.Last()))
                    _restServer.Port = hostAndPort.Last().Trim();
                _restServer.Start();
                _restServerOwner = ix;
                LOG.Info($"RestServer started {listenAddress}");
            }
            catch (Exception e)
            {
                LOG.Error(e);
            }
        }

        [DllExport("RestServerStop", CallingConvention = CallingConvention.StdCall)]
        public static void RestServerStop(Int64 ix)
        {
            try
            {
                if (ix != _restServerOwner)
                    return;
                if (_restServer?.IsListening == true)
                    _restServer?.Stop();
                _restServer?.Dispose();
                _restServer = null;
                LOG.Info($"RestServer stopped");
            }
            catch (Exception e)
            {
                LOG.Error(e);
            }
        }
    }
}
