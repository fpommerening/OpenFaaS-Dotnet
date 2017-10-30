namespace FP.OpenfaasDotnet.Alexa.Model
{
    public class Intent
    {
        public Intent()
        {
            Slots = new Slots();
        }

        public string Name { get; set; }

        public Slots Slots { get; set; }
    }
}
