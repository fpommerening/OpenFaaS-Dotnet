using System;
using System.Net.Http;
using Data;
using Newtonsoft.Json;
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
            if (Context.HttpMethod == HttpMethod.Get)
            {
                var dl = new ReadDataLayer();
                var conferenceList = dl.GetConferenceList();
                Context.WriteContent(JsonConvert.SerializeObject(conferenceList));
            }
            else
            {
                throw new NotSupportedException();
            }
        }
    }
}
