using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Serilog;

namespace Presentation.WebApi {
    public class Program {
        public static void Main(string[] args) {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                //.UseKestrel()
                //.UseUrls("http://*.80")
                .UseStartup<Startup>()
                .UseSerilog((ctx, config) => {
                    config.ReadFrom.Configuration(ctx.Configuration);
                    //Serilog.Debugging.SelfLog.Enable(Console.Error);
                })
                .Build();
    }
}
