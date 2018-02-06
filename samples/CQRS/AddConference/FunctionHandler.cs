using System;
using System.Text;

namespace Function
{
    public class FunctionHandler
    {
        public void Handle(string input)
        {
            Console.WriteLine("Hi there - your input was: "+ input);

            var dl = new Data.DataLayer();
            dl.SaveEventData(input);
        }
    }
}
