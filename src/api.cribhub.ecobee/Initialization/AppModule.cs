using api.cribhub.ecobee.Application.RequestHandlers;
using api.cribhub.ecobee.Application.Security;
using Autofac;
using clearwaterstream.AWS.Security;
using clearwaterstream.Configuration;
using clearwaterstream.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.cribhub.ecobee.Initialization
{
    public class AppModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            if (AppEnvironment.IsDevelopment())
            {
                builder.Register(x => new InMemSecretsContainer()).As<ISecretsContainer>().SingleInstance();
            }
            else
            {
                builder.Register(x => new SecureParameterStoreSecretsContainer()).As<ISecretsContainer>().SingleInstance();
            }

            builder.Register(x => new RegisterUserRequestHandler()).AsImplementedInterfaces().SingleInstance();
        }
    }
}
