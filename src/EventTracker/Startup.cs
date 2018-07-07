using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventTracker.Hubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.FileProviders;
using System.IO;
using System.Reflection;

namespace EventTracker {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services) {
            services
                .AddCors()
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSignalR();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILogger<Startup> logger) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            } else {
                // app.UseHsts();
            }

            // app.UseHttpsRedirection();

            var asm = Assembly.GetEntryAssembly();
            var asmName = asm.GetName().Name;

            var defaultOptions = new DefaultFilesOptions();
            defaultOptions.DefaultFileNames.Clear();
            defaultOptions.DefaultFileNames.Add("index.html");
            defaultOptions.FileProvider = new EmbeddedFileProvider(asm, $"{asmName}.wwwroot");


            app
                .UseDefaultFiles(defaultOptions)
                .UseStaticFiles(new StaticFileOptions {
                    FileProvider =
                        new EmbeddedFileProvider(asm, $"{asmName}.wwwroot")
                })
                .UseSignalR(routes => {
                    routes.MapHub<TrackingHub>("/trackingHub");
                })
                .UseCors(builder => {
                    builder.AllowAnyHeader();
                    builder.AllowAnyMethod();
                    builder.AllowAnyOrigin();
                    builder.AllowCredentials();
                })
                .UseMvc();
        }
    }
}