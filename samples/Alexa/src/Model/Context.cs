namespace FP.OpenfaasDotnet.Alexa.Model
{
    public class Context
    {
        public Context()
        {
            AudioPlayer = new AudioPlayer();
            System = new System();
            Device = new Device();
        }

        public AudioPlayer AudioPlayer { get; set; }

        public System System { get; set; }

        public Device Device { get; set; }
    }
}
