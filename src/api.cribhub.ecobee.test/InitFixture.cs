using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace api.cribhub.ecobee.test
{
    public class InitFixture
    {
        readonly IWebHost Host;

        public InitFixture()
        {
            Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Development");

            var builder = WebHost.CreateDefaultBuilder().UseStartup<Startup>();

            Host = builder.Build();
        }
    }

    [CollectionDefinition("init collection")]
    public class InitCollection : ICollectionFixture<InitFixture>
    {
    }
}
