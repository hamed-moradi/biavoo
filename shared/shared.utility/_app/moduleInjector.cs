﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace shared.utility._app {
    public class ModuleInjector {
        public static void Init(IServiceCollection services) {
            services.AddSingleton(new ServiceLocator(services));
            services.AddTransient<IRandomGenerator, RandomGenerator>();
        }
    }
}
