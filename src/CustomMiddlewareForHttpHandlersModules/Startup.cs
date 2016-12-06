using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CustomMiddlewareForHttpHandlersModules
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //For Session
            app.UseSession();
            app.UseSessionMiddleware();

            app.Use(async (context, next) => {
                context.Session.SetString("mySessionValue", "test");
                await context.Response.WriteAsync("Custom call!!!!! <br/>");
                await next.Invoke();
            });

            // For Module
            app.UseCustomModuleMiddleware();

            // For Handler
            app.MapWhen(context => context.Request.Path.ToString().EndsWith(".report"),
                appBuilder => {
                    appBuilder.UseCustomHanlderMiddleware();
                });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
