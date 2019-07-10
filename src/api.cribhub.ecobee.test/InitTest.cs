using clearwaterstream.IoC;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace api.cribhub.ecobee.test
{
    [Collection("init collection")]
    public class InitTest
    {
        [Fact]
        public void CheckServiceRegistrar()
        {
            var serviceResistrar = ServiceRegistrar.Current;

            Assert.NotNull(serviceResistrar);
        }

        [Fact]
        public void CheckMediator()
        {
            var mediator = ServiceRegistrar.Current.GetMediator();

            Assert.NotNull(mediator);
        }
    }
}
