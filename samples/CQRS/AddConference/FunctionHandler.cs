using System;
using System.Text;
using OpenFaaS.Dotnet;

namespace Function
{
    public class FunctionHandler : BaseFunction
    {

         public FunctionHandler(IFunctionContext functionContext)
            : base(functionContext)
        {
        }

        public override void Handle(string input)
        {
            Context.WriteContent($"Hi there - your input was: {input}");
                // try Mongo-Client
            var client = new MongoDB.Driver.MongoClient("mongodb://localhost:27017");
        }
    }
}
