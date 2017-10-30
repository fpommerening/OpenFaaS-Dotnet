namespace FP.OpenfaasDotnet.Alexa.Model
{
    public class AlexaResponse
    {
        public AlexaResponse()
        {
            Response = new Response();
            SessionAttributes = new SessionAttributes();
        }

        public string Version { get; set; } = "1.0";

        public Response Response { get; set; }

        public SessionAttributes SessionAttributes { get; set; }
    }
}
