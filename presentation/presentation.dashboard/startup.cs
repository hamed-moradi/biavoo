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
using presentation.dashboard.helpers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using shared.resource;

namespace Presentation.WebApi {
    public class Startup {
        #region Constructor
        private static readonly string apiVersion = Assembly.GetEntryAssembly().GetName().Version.ToString();
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }
        #endregion

        public void ConfigureServices(IServiceCollection services) {
            services.AddLocalization(options => options.ResourcesPath = "SharedResource");
            services.Configure<CookiePolicyOptions>(options => {
                //This lambda determines whether user consent for non - essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddMvc()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization(options => {
                    options.DataAnnotationLocalizerProvider = (type, factory) => factory.Create(typeof(SharedResource));
                })
                .AddRazorPagesOptions(options => {
                    options.Conventions.AuthorizePage("/Home/Contact");
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options => {
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.LoginPath = "/Account/SignIn";
                options.LogoutPath = "/Account/SignOut";
                options.ReturnUrlParameter = "returnUrl";
                options.EventsType = typeof(AccountCookieAuthenticationEvents);
            });
            services.AddScoped<AccountCookieAuthenticationEvents>();
            shared.utility._app.ModuleInjector.Init(services);
            domain.office._app.ModuleInjector.Init(services);
            services.AddSingleton(new MapperConfig().Init().CreateMapper());
            services.Configure<RequestLocalizationOptions>(options => {
                options.DefaultRequestCulture = new RequestCulture("en-US");
                options.SupportedCultures = SupportedCultures.List;
                options.SupportedUICultures = SupportedCultures.List;
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            if(env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink(); //TODO: what is this?
            }
            else {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts(); //TODO: what is this?
            }
            app.UseRequestLocalization(new RequestLocalizationOptions {
                DefaultRequestCulture = new RequestCulture("en-US"),
                // Formatting numbers, dates, etc.
                SupportedCultures = SupportedCultures.List,
                // UI strings that we have localized.
                SupportedUICultures = SupportedCultures.List
            });
            // To configure external authentication, see: http://go.microsoft.com/fwlink/?LinkID=532715
            app.UseAuthentication(); //TODO: what is this?
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRequestLocalization();
            app.UseCookiePolicy(new CookiePolicyOptions {
                MinimumSameSitePolicy = SameSiteMode.Strict,
                Secure = CookieSecurePolicy.SameAsRequest
            });
            //app.UseMvc(routes => {
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Home}/{action=Index}/{id?}");
            //});
            app.UseMvcWithDefaultRoute();
        }
    }
}