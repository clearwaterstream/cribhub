using api.cribhub.ecobee.Application.Persistence;
using api.cribhub.ecobee.Application.RequestHandlers;
using api.cribhub.ecobee.Application.Security;
using api.cribhub.ecobee.Application.Validators;
using api.cribhub.ecobee.domain.Model;
using api.cribhub.ecobee.domain.Requests;
using Autofac;
using clearwaterstream.AWS.Security;
using clearwaterstream.Configuration;
using clearwaterstream.Security;
using FluentValidation;
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

            builder.Register(x => new EcobeeUserDb()).AsImplementedInterfaces().SingleInstance();

            builder.Register(x => new StateInfoValidator()).AsValidator();
            builder.Register(x => new RegisterUserRequestValidator()).AsValidator();

            builder.Register(x => new RegisterUserRequestHandler()).AsImplementedInterfaces().SingleInstance();
        }
    }
}
