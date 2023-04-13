using Grapevine.Server;
using log4net;
using MQL4CSharp.Base.MQL;
using MQL4CSharp.Base.REST;
using MQL4CSharp.UserDefined.Managers;
using RGiesecke.DllExport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MQL4CSharp.UserDefined.Strategy
{
    public class FileOrderPlacer : MQLRESTStrategy
    {
        private static readonly ILog LOG = LogManager.GetLogger(typeof(FileOrderPlacer));

        public FileOrderPlacer(long ix) : base(ix)
        {
        }


        [DllExport("FileOrderPlacerConfig", CallingConvention = CallingConvention.StdCall)]
        public static bool FileOrderPlacerConfig(Int64 ix, int magicnumber,
            [MarshalAs(UnmanagedType.LPWStr)] string fileName,
            [MarshalAs(UnmanagedType.LPWStr)] string customSymbolMappings,
            [MarshalAs(UnmanagedType.LPWStr)] string customLotMultipliers,
            [MarshalAs(UnmanagedType.LPWStr)] string permittedSymbols,
            double useFixedLotSize,
            double limitOrderExpirationMinutes,
            bool mirrorSLandTPChanges
        )
        {
            try
            {
                var instance = (FileOrderPlacer)DLLObjectWrapper.getInstance().getMQLExpert(ix);
                instance.InitConfigs(magicnumber, fileName, customSymbolMappings, customLotMultipliers, permittedSymbols, useFixedLotSize, limitOrderExpirationMinutes, mirrorSLandTPChanges);
                LOG.Info($"FileOrderPlacerConfig started {fileName}");
                return true;
            }
            catch (Exception e)
            {
                LOG.Error(e);
                return false;
            }
        }

        public virtual void InitConfigs(int magicnumber, string fileName, string customSymbolMappings, string customLotMultipliers, string permittedSymbols, double useFixedLotSize, double limitOrderExpirationMinutes, bool mirrorSLandTPChanges)
        {
            var manager = new FileOrderPlacerManager(this);
            manager.InitConfigs(magicnumber, fileName, customSymbolMappings, customLotMultipliers, permittedSymbols, useFixedLotSize, limitOrderExpirationMinutes, mirrorSLandTPChanges);
            fileManager = manager;
            manager.MonitorFile();
            manager.Execute();
        }

        private FileOrderPlacerManager fileManager;

        public override void OnDeinit()
        {
            LOG.Info("OnDeinit");
            base.OnDeinit();
            fileManager?.Dispose();
            fileManager = null;
        }

        public override void OnTick()
        {
            base.OnTick();
            fileManager?.Execute();
        }

        public override void OnTimer()
        {
            base.OnTimer();
            fileManager?.Execute();
        }
    }
}
