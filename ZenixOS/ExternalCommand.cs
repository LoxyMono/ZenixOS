using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenixOS
{
    class ExternalCommand
    {
        public static void OK(string OKMessage)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("OK");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("]: ");
            Console.ResetColor();
            Console.Write(OKMessage);
        }
        public static void ERR(string ERRMessage)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("ERR");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("]: ");
            Console.ResetColor();
            Console.Write(ERRMessage);
        }
        public static void WRN(string WRNMessage)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("WRN");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("]: ");
            Console.ResetColor();
            Console.Write(WRNMessage);
        }
    }
}
