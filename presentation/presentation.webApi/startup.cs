using System;
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
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using presentation.webApi.helpers;
using presentation.webApi.middlewares;
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
            services.AddSingleton(new MongoDBContext());
            shared.utility._app.ModuleInjector.Init(services);
            domain.application._app.ModuleInjector.Init(services);
            services.AddSingleton(new MapperConfig().Init().CreateMapper());
            services.AddMvc();
            services.AddSwaggerGen(c => {
                c.SwaggerDoc(apiVersion, new Info { Title = AppSettings.MyTitle, Version = apiVersion });
            });
            //services.Configure<ForwardedHeadersOptions>(options => {
            //    options.KnownProxies.Add(IPAddress.Parse(AppSettings.MyIp));
            //});
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            app.UseGateway();
            app.UseSwagger();
            if(env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                //app.UseBrowserLink();
                app.UseSwaggerUI(c => {
                    c.SwaggerEndpoint($"swagger/{apiVersion}/swagger.json", $"biavoo {apiVersion}");
                    c.RoutePrefix = string.Empty;
                });
            }
            //app.UseForwardedHeaders(new ForwardedHeadersOptions {
            //    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            //});
            //app.UseAuthentication();
            //app.UseMvc();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}