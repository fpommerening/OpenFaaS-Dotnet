using System;
using System.Net.Http;
using Data;
using Microsoft.Extensions.Primitives;
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
                StringValues id;
                if (Context.QueryParameters.TryGetValue("id", out id))
                {
                    var conferenceId = Guid.Parse(id[0]);
                    var conference = dl.GetConferenceDetail(conferenceId);
                    Context.WriteContent(JsonConvert.SerializeObject(conference));
                }
                throw new ArgumentNullException("id");
            }
            throw new NotSupportedException();
        }
    }
}
