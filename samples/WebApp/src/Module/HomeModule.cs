using System;
using System.IO;

namespace FP.OpenfaasDotnet.BuildInside.Module
{
    public class HomeModule : Nancy.NancyModule
    {
        public HomeModule()
        {
            Post("/", async (args, ct) =>
            {
                string content;
                using (Stream responseStream = this.Request.Body)
                using (StreamReader sr = new StreamReader(responseStream))
                {
                    content = await sr.ReadToEndAsync();
                }
                return $"content received {DateTime.Now}:{System.Environment.NewLine}{content}";
            });
        }
    }
}