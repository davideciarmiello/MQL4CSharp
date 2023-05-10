using MQL4CSharp;
using MQL4CSharp.Base;
using MQL4CSharp.Base.Enums;
using MQL4CSharp.Base.MQL;
using MQL4CSharp.Base.REST;
using MQL4CSharp.UserDefined.Managers;
using MQL4CSharp.UserDefined.Strategy;
using mqlsharp.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQL4TestConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RestServerHelper.RestServerStart(0, "127.0.0.1");

            CachedDataStorageInstance.TerminalDataPath = Environment.CurrentDirectory;
            CachedDataStorageInstance.TerminalDataPath = @"C:\Users\dciar\AppData\Roaming\MetaQuotes\Terminal\F1BBCAACDA8825381C125EAF07296C41";

            var mqlBase = new MQLBaseFake(0);
            mqlBase.OnTick();

            //mqlBase.ChartExpertAdvisorEnableLastActive(133275210266993546);


            ////"closetime":"2023-05-01T23:25:31Z","closetimevalue":1682983531
            //var dt = DateUtil.FromUnixTime(1682983531);


            //var instance = OrdersLoggerStaticMethods.GetOrdersLoggerInstance(0);
            //instance.Init(123, "test.xlsx", 23, null, "AUDCAD", @"D:\temp\mql4csharp.magic-mapping.txt");
            //instance.SetCurrentInfo(DateTime.Now, 0, 1000);
            //OrdersLoggerStaticMethods.OrdersLoggerSetOrdersHistoryTotal(0, 1);
            //OrdersLoggerStaticMethods.OrdersLoggerSetOrdersHistoryDef(0, 0, "TICKET\u0002100374899\u0001POSITIONID\u0002\u0001SYMBOL\u0002AUDCAD.r\u0001TYPE\u00021\u0001VOLUME\u00020.01\u0001OPENPRICE\u00020.90188000\u0001SL\u00020.00000000\u0001TP\u00020.00000000\u0001CLOSEPRICE\u00020.90209000\u0001OPENTIME\u00021682597121\u0001CLOSETIME\u00021682597269\u0001COMMENT\u0002we!\u0001MAGIC\u00020\u0001PROFIT\u0002-0.13\u0001SWAP\u00020.00\u0001COMMISSION\u0002-0.06\r\n");

            //OrdersLoggerStaticMethods.OrdersLoggerSetOrdersTotal(0, 1);
            //OrdersLoggerStaticMethods.OrdersLoggerSetOrdersDef(0, 0, "TICKET\u0002100374891\u0001POSITIONID\u0002\u0001SYMBOL\u0002AUDCAD.r\u0001TYPE\u00021\u0001VOLUME\u00020.01\u0001OPENPRICE\u00020.90188000\u0001SL\u00020.00000000\u0001TP\u00020.00000000\u0001CLOSEPRICE\u00020.90209000\u0001OPENTIME\u00021682597121\u0001CLOSETIME\u0002\u0001COMMENT\u0002we!\u0001MAGIC\u00020\u0001PROFIT\u0002-0.13\u0001SWAP\u00020.00\u0001COMMISSION\u0002-0.06\r\n");

            //instance.SaveExcel();

            ////RestServerHelper.RestServerStart(0, "127.0.0.1:1234");
            //var gen = new IncludedFileGenerator();
            //gen.Generate();
            //var str = gen.Sb.ToString();

            Console.WriteLine("Press a key to exit");
            Console.ReadKey();
        }
    }

    public class MQLBaseFake : MQLRESTStrategy
    {
        public MQLBaseFake(long ix) : base(ix)
        {
        }
        
        protected override object ExecCommand(MQLCommand command, List<object> parameters)
        {
            switch (command)
            {
                case MQLCommand.AccountNumber_1:
                    return 0;
                case MQLCommand.TerminalInfoString_1:
                    {
                        var property_id = (TERMINAL_INFO_STRING)parameters.First();
                        if (property_id == TERMINAL_INFO_STRING.TERMINAL_DATA_PATH && !string.IsNullOrEmpty(CachedDataStorageInstance.TerminalDataPath))
                            return CachedDataStorageInstance.TerminalDataPath;
                    }
                    break;
            }
            return base.ExecCommand(command, parameters);
        }
    }

    public class IncludedFileGenerator
    {
        public StringBuilder Sb { get; } = new StringBuilder();
        public virtual void Generate()
        {
            GenerateEnums();
        }

        public virtual void GenerateEnums()
        {
            GenerateEnum(typeof(SYMBOL_INFO_DOUBLE));
            GenerateEnum(typeof(SYMBOL_INFO_INTEGER));
            GenerateEnum(typeof(SYMBOL_INFO_STRING));
        }

        public virtual void GenerateEnum(Type type)
        {
            var sb = Sb;
            sb.Append("\r\nint CONVERT_").Append(type.Name.StartsWith("ENUM_") ? "" : "ENUM_").Append(type.Name).Append("(string value)\r\n{");
            var values = Enum.GetValues(type);
            foreach (var @enum in values.Cast<Enum>())
            {
                var name = Enum.GetName(type, @enum);
                var intValue = Convert.ToInt32(@enum);
                sb.Append($"\r\n  if (value == \"{name}\" || value == \"{intValue}\") {{ return {name}; }}");
            }
            sb.Append("\r\n  return -1;\r\n}\r\n");
        }
    }
}
