using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Threading.Tasks;

namespace api.cribhub.ifttt
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = CreateWebHostBuilder(args);

            builder.UseKestrel(o => o.AddServerHeader = false); // do not adverstise Kestrel

            var webHost = builder.Build();

            webHost.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
