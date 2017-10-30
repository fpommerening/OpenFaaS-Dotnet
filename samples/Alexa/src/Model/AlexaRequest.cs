using System;

namespace FP.OpenfaasDotnet.Alexa.Model
{
    [Serializable]
    public class AlexaRequest
    {
        public AlexaRequest()
        {
            Session = new Session();
            Request = new Request();
            Context = new Context();
        }

        public string Version { get; set; }

        public Session Session { get; set; }
        
        public Request Request { get; set; }

        public Context Context { get; set; }
    }
}
