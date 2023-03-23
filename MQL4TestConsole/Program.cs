using MQL4CSharp;
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
            RestServerHelper.RestServerStart(0, "127.0.0.1:1234");
            
            Console.WriteLine("Press a key to exit");
            Console.ReadKey();
        }
    }
}
