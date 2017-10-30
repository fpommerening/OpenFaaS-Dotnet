namespace FP.OpenfaasDotnet.Alexa.Model
{
    public class Response
    {
        public OutputSpeech OutputSpeech { get; set; }

        public bool ShouldEndSession { get; set; } = true;
    }
}
