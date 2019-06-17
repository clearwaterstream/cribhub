using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Amazon.Lambda.RuntimeSupport;
using Amazon.Lambda.Serialization.Json;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Threading.Tasks;

namespace api.cribhub.ifttt
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable("AWS_LAMBDA_FUNCTION_NAME")))
            {
                RunLocally(args);
            }
            else
            {
                await RunLambda();
            }
        }

        static async Task RunLambda()
        {
            var lambdaEntry = new LambdaEntryPoint();

            using (var handlerWrapper = HandlerWrapper.GetHandlerWrapper<APIGatewayProxyRequest, APIGatewayProxyResponse>(lambdaEntry.FunctionHandlerAsync, new JsonSerializer()))
            {
                using (var bootstrap = new LambdaBootstrap(handlerWrapper))
                {
                    await bootstrap.RunAsync();
                }
            }
        }

        static void RunLocally(string[] args)
        {
            var builder = CreateWebHostBuilder(args);

            builder.ConfigureKestrel(o => o.AddServerHeader = false); // do not adverstise Kestrel

            var webHost = builder.Build();

            webHost.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
