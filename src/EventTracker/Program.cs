﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.SignalR;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using System.Reflection;

namespace EventTracker {
    public class Program {
        public static void Main(string[] args) {

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
                .MinimumLevel.Override("System", LogEventLevel.Error)
                .WriteTo.Console()
                .CreateLogger();

            var names = Assembly.GetExecutingAssembly().GetManifestResourceNames();
            foreach (var item in names) {
                Log.Logger.Information(">> {0}", item);
            }

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureLogging(config => {
                    config.ClearProviders();
                })
                // .UseUrls("https://*:5678")
                .UseUrls("http://*:7777")
                .UseStartup<Startup>();
    }
}
