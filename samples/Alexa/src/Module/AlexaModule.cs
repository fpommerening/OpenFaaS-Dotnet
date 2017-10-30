using FP.OpenfaasDotnet.Alexa.Model;
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
                var request = this.Bind<AlexaRequest>();
                AlexaResponse response;

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

        private AlexaResponse ExecuteIntent(AlexaRequest request)
        {
            var indent = request.Request?.Intent;

            if (indent == null)
            {
                return CreateUnkownIntentResponse(string.Empty);
            }
            switch (indent.Name.ToLowerInvariant())
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
                    return CreateUnkownIntentResponse(indent.Name);
            }
        }

     

        private AlexaResponse CreateUnkownIntentResponse(string name)
        {
            return CreatePlaneTextResponse($"Dein Befehl {name} wurde nicht gefunden.");
        }

        private AlexaResponse CreatePlaneTextResponse(string content)
        {
            var reponse = new AlexaResponse();
            reponse.Response.OutputSpeech = new OutputSpeech
            {
                Type = "PlainText",
                Text = content
            };

            return reponse;
        }
    }
}