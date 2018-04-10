using System;
using System.Text;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;


namespace Function
{
    public class FunctionHandler
    {
        public void Handle(string input) {
               var request = JsonConvert.DeserializeObject<SkillRequest>(input);

            SkillResponse response;

            switch (request.Request.Type)
            {
                case "IntentRequest":
                    response = ExecuteIntent(request);
                    break;
                case "SessionEndedRequest":
                    response = CreatePlaneTextResponse("Meetup zu Ende - Auf Wiedersehen beim nächsten Mal.");
                    break;
                default:
                    response = CreatePlaneTextResponse("Willkommen zum Meetup. Was darf ich für dich tun?");
                    break;
            }

            var responseAsJson = JsonConvert.SerializeObject(response, Formatting.Indented,
                new JsonSerializerSettings {ContractResolver = new CamelCasePropertyNamesContractResolver()});

            Console.WriteLine(responseAsJson);
        }

        private static SkillResponse ExecuteIntent(SkillRequest skillRequest)
        {
            var intentRequest = skillRequest.Request as IntentRequest;

            if (intentRequest == null)
            {
                return CreateUnkownIntentResponse(string.Empty);
            }
            switch (intentRequest.Intent.Name.ToLowerInvariant())
            {
                case "greeting":
                    return CreatePlaneTextResponse("Hallo und Willkommen bei den Magdeburger Developer Days 2018. Ich bin Alexa und wünsche euch viel Spaß beim Vortrag Deep Dive: Serverless Computing mit Docker.");
                case "sendoff":
                    return CreatePlaneTextResponse("Vielen Dank für eure Teilnahme und bis zum nächsten mal.");
                case "breaknow":
                    return CreatePlaneTextResponse("Pause");
                case "amazon.helpintent":
                    return CreatePlaneTextResponse("Wenn du Hilfe brauchst fragt den lieben Gott");
                case "amazon.stopintent":
                    return CreatePlaneTextResponse("Meetup aus - OK");
                default:
                    return CreateUnkownIntentResponse(intentRequest.Intent.Name);
            }
        }



        private static SkillResponse CreateUnkownIntentResponse(string name)
        {
            return CreatePlaneTextResponse($"Dein Befehl {name} wurde nicht gefunden.");
        }

        private static SkillResponse CreatePlaneTextResponse(string content)
        {
            var reponse = new SkillResponse
            {
                Version = "1.0",

            };

            reponse.Response = new ResponseBody
            {
                OutputSpeech = new PlainTextOutputSpeech
                {
                    Text = content
                }
            };

            reponse.Response.ShouldEndSession = true;

            return reponse;
        }
    }
}
