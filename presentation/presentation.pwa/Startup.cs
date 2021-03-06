﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace presentation.pwa {
    public class Startup {
        #region Constructor
        private static readonly string apiVersion = Assembly.GetEntryAssembly().GetName().Version.ToString();
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }
        #endregion

        public void ConfigureServices(IServiceCollection services) {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            //if(env.IsDevelopment()) {
            //    app.UseDeveloperExceptionPage();
            //}

            app.UseHttpsRedirection();
            //app.UseDefaultFiles();
            app.UseStaticFiles();

            //app.UseMvcWithDefaultRoute();
            //app.UseMvc(routes => {
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller}/{action=Index}/{id?}");
            //});
        }
    }
}
