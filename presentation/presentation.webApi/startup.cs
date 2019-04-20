﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using domain.application.services;
using domain.repository._app;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using presentation.webApi.helpers;
using presentation.webApi.middlewares;
using shared.resource;
using shared.utility._app;
using Swashbuckle.AspNetCore.Swagger;

namespace Presentation.WebApi {
    public class Startup {
        #region Constructor
        private static readonly string apiVersion = Assembly.GetEntryAssembly().GetName().Version.ToString();
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }
        #endregion

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services) {
            services.AddLocalization(options => options.ResourcesPath = "SharedResource");
            services.AddMvc()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization(options => {
                    options.DataAnnotationLocalizerProvider = (type, factory) => factory.Create(typeof(SharedResource));
                });
            services.AddSingleton(new MongoDBContext());
            shared.utility._app.ModuleInjector.Init(services);
            domain.application._app.ModuleInjector.Init(services);
            services.AddSingleton(new MapperConfig());
            services.AddSwaggerGen(c => {
                c.SwaggerDoc(apiVersion, new Info { Title = AppSettings.MyTitle, Version = apiVersion });
            });
            services.Configure<RequestLocalizationOptions>(options => {
                options.DefaultRequestCulture = new RequestCulture("en-US");
                options.SupportedCultures = SupportedCultures.List;
                options.SupportedUICultures = SupportedCultures.List;
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            app.UseGateway();
            app.UseSwagger();
            if(env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                //app.UseBrowserLink();
                app.UseSwaggerUI(c => {
                    c.SwaggerEndpoint($"swagger/{apiVersion}/swagger.json", $"biavoo {apiVersion}");
                    c.RoutePrefix = string.Empty;
                });
            }
            app.UseRequestLocalization(new RequestLocalizationOptions {
                DefaultRequestCulture = new RequestCulture("en-US"),
                // Formatting numbers, dates, etc.
                SupportedCultures = SupportedCultures.List,
                // UI strings that we have localized.
                SupportedUICultures = SupportedCultures.List
            });
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRequestLocalization();
            app.UseMvcWithDefaultRoute();
        }
    }
}