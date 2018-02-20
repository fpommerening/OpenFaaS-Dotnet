using System;
using System.Text;

namespace Function
{
    public class FunctionHandler
    {
        public void Handle(string input) {
            Console.WriteLine($"Hallo OpenFAAS {DateTime.Now}");
        }
    }
}
