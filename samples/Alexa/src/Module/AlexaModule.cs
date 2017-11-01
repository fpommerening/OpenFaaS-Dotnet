using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using Nancy;
using Nancy.ModelBinding;

namespace FP.OpenfaasDotnet.Alexa.Module
{
    public class AlexaModule : NancyModule
    {
        public AlexaModule()
        {
            Post("/", async (args, ct) =>
            {
                var request = this.Bind<SkillRequest>();
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
                return Response.AsJson(response);
            });
        }

        private SkillResponse ExecuteIntent(SkillRequest skillRequest)
        {
            var intentRequest = skillRequest.Request as IntentRequest;

            if (intentRequest == null)
            {
                return CreateUnkownIntentResponse(string.Empty);
            }
            switch (intentRequest.Intent.Name.ToLowerInvariant())
            {
                case "greeting":
                    return CreatePlaneTextResponse("Hallo und Willkommen zum zehnten Developer Open Space in Leipzig. Ich bin Alexa und wünsche euch viel Spaß beim Workshop dot Net in the big Box.");
                case "sendoff":
                    return CreatePlaneTextResponse("Vielen Dank für eure Teilnahme und bis zum nächsten mal.");
                case "amazon.helpintent":
                    return CreatePlaneTextResponse("Wenn du Hilfe brauchst rufe Torsten oder Greogor.");
                case "amazon.stopintent":
                    return CreatePlaneTextResponse("Meetup aus - OK");
                default:
                    return CreateUnkownIntentResponse(intentRequest.Intent.Name);
            }
        }

     

        private SkillResponse CreateUnkownIntentResponse(string name)
        {
            return CreatePlaneTextResponse($"Dein Befehl {name} wurde nicht gefunden.");
        }

        private SkillResponse CreatePlaneTextResponse(string content)
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

            return reponse;
        }
    }
}