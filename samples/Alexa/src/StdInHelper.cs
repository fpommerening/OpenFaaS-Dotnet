using System;
using System.Collections.Generic;
using System.Text;

namespace FP.OpenfaasDotnet.Alexa
{
    public static class StdInHelper
    {
        public static string[] GetValueAsArray()
        {
            var buffer = new List<string>();
            string s;
            while ((s = Console.ReadLine()) != null)
            {
                buffer.Add(s);
            }

            return buffer.ToArray();
        }

        public static string GetValue()
        {
            var sb = new StringBuilder();
            string s;
            while ((s = Console.ReadLine()) != null)
            {
                sb.Append(s);
            }

            return sb.ToString();
        }
    }
}
