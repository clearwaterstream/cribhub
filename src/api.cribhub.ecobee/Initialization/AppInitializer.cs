﻿using Autofac;
using clearwaterstream.IoC;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.cribhub.ecobee.Initialization
{
    public static class AppInitializer
    {
        public static void Initialize(IConfiguration configuration)
        {
            ServiceRegistrar.SetConfigutation(configuration);

            ServiceRegistrar.Bootstrap(PerformRegistrations);
        }

        static void PerformRegistrations(ContainerBuilder builder)
        {
            // MediatR
            builder.Register<ServiceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });

            builder.RegisterModule(new AppModule());
        }
    }
}
