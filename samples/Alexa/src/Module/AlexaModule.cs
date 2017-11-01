using System.IO;
using System.Text;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using Nancy;
using Newtonsoft.Json;

namespace FP.OpenfaasDotnet.Alexa.Module
{
    public class AlexaModule : NancyModule
    {
        public AlexaModule()
        {
            Post("/", async (args, ct) =>
            {

                SkillRequest request = null;

                using (var reader = new StreamReader(this.Request.Body, Encoding.UTF8))
                {
                    var bodyText = await reader.ReadToEndAsync();
                    request = JsonConvert.DeserializeObject<SkillRequest>(bodyText);
                }

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
                    return CreatePlaneTextResponse("Hallo und Willkommen bei der dot NET Usergroup Hamburg Ich bin Alexa und wünsche euch viel Spaß beim Vortrag dot Net in the big Box.");
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