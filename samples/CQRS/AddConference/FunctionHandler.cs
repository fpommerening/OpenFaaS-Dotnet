using System;
using System.Text;
using Data;
using Domain.Commands;
using Domain.Handlers;
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
            var addConferenceCommand = JsonConvert.DeserializeObject<AddConference>(input);
            var conferenceHandler = new ConferenceHandler();
            var events = conferenceHandler.Handle(addConferenceCommand);


            var dl = new DataLayer();
            dl.SaveEventData(events);




        }
    }
}
