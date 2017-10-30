using System;
using System.Collections.Generic;

namespace FP.OpenfaasDotnet.ConsoleArgs
{
    class Program
    {
            private static string[] GetConsoleInput() {
            var buffer = new  List<string>();
            string s;
            while ((s = Console.ReadLine()) != null)
            {
                buffer.Add(s);
            }
            return buffer.ToArray();
        }

        static void Main(string[] args)
        {
              var buffer = GetConsoleInput();
            Console.WriteLine(string.Join(Environment.NewLine, buffer));
        }
    }
}
