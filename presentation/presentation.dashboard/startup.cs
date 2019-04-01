using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using domain.repository._app;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using presentation.dashboard.helpers;
using presentation.dashboard.middlewares;

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
            shared.utility._app.ModuleInjector.Init(services);
            domain.office._app.ModuleInjector.Init(services);
            services.AddSingleton(new MapperConfig().Init().CreateMapper());
            services.Configure<CookiePolicyOptions>(options => {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            if(env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            else {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            //app.UseMvc(routes => {
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Home}/{action=Index}/{id?}");
            //});
            app.UseMvcWithDefaultRoute();
        }
    }
}