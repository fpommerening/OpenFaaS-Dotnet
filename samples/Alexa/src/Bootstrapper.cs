using Nancy;
using Nancy.TinyIoc;
using Newtonsoft.Json;

namespace FP.OpenfaasDotnet.Alexa
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);

            container.Register<JsonSerializer, CustomJsonSerializer>();
        }
    }
}
