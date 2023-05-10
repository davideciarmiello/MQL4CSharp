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

using System;
using RGiesecke.DllExport;
using System.Runtime.InteropServices;
using log4net;
using System.Reflection;
using System.IO;
using System.Threading;
using MQL4CSharp;
using MQL4CSharp.Base.MQL;
using MQL4CSharp.UserDefined.Managers;

namespace mql4csharp
{
    public class Initializer
    {

        [DllExport("ExecOnDeinitCompleted", CallingConvention = CallingConvention.StdCall)]
        public static void ExecOnDeinitCompleted(Int64 ix, int reason)
        {
            OrdersLoggerStaticMethods.OrdersLoggerDeInit(ix);
            //try
            //{
            //    RestServerHelper.RestServerStop(ix);
            //}
            //catch { /**/ }
            //try
            //{
            //    DLLObjectWrapper.getInstance().getMQLThreadPool(ix)?.Dispose();
            //}
            //catch { /**/ }
            //try
            //{
            //    GC.Collect();
            //    GC.WaitForPendingFinalizers();

            //    //var otherAssemblyDomain = AppDomain.CurrentDomain;
            //    //try
            //    //{
            //    //    AppDomain.Unload(otherAssemblyDomain);
            //    //}
            //    //catch (Exception)
            //    //{
            //    //    GC.Collect();
            //    //    GC.WaitForPendingFinalizers();
            //    //    var i = 0;
            //    //    while (i < 3)   // quit after three tries
            //    //    {
            //    //        Thread.Sleep(500);     // wait a few secs before trying again...
            //    //        try
            //    //        {
            //    //            AppDomain.Unload(otherAssemblyDomain);
            //    //        }
            //    //        catch (Exception)
            //    //        {
            //    //            // log exception
            //    //            i++;
            //    //            continue;
            //    //        }
            //    //        break;
            //    //    }
            //    //}
            //}
            //catch (Exception e)
            //{
            //    //LOG.Error(e);
            //}
        }
    }
}