using MQL4CSharp;
using MQL4CSharp.Base.Enums;
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
            //RestServerHelper.RestServerStart(0, "127.0.0.1:1234");
            var gen = new IncludedFileGenerator();
            gen.Generate();
            var str = gen.Sb.ToString();

            Console.WriteLine("Press a key to exit");
            Console.ReadKey();
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
