using Microsoft.Extensions.DependencyInjection;
using asset.utility.infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace asset.utility._app {
    public class ModuleInjector {
        public static void Init(IServiceCollection services) {
            services.AddSingleton<IParameterHandler, ParameterHandler>();
            services.AddSingleton(typeof(IParameterHandler<>), typeof(ParameterHandler<>));
            services.AddTransient<IRandomGenerator, RandomGenerator>();
            services.AddTransient<ISMSService, Candoo>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddSingleton(new ServiceLocator(services));
        }
    }
}
