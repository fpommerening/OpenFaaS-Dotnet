namespace FP.OpenfaasDotnet.Alexa.Model
{
    public class Request
    {
        public Request()
        {
            Intent = new Intent();
        }

        public string Type { get; set; }

        public string RequestId { get; set; }

        public string Locale { get; set; }

        public Intent Intent { get; set; }
    }
}
