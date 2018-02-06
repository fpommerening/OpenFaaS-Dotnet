using System;
using System.Text;

namespace SampleRunner
{
    class Program
    {
        private static string GetConsoleInput()
        {
            StringBuilder buffer = new StringBuilder();
            string s;
            while ((s = Console.ReadLine()) != null)
            {
                buffer.AppendLine(s);
            }
            return buffer.ToString();
        }

        static void Main(string[] args)
        {
            var buffer = GetConsoleInput();
            new Function.FunctionHandler().Handle(buffer);
        }
    }
}
