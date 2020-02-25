using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RawApi.Middlewares;

namespace RawApi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.Use(async (context, next) =>
            //{
            //    Trace.WriteLine($"{context.Request.Method} {context.Request.Path}");
            //    await next.Invoke();
            //    Trace.WriteLine($"{context.Response.StatusCode}");
            //});


            // app.UseMiddleware<LoggerMiddleware>();

            app.UseLogger();

            app.Use(async (context, next) =>
            {
                if (context.Request.Headers.ContainsKey("Authorization"))
                {
                    await next.Invoke();
                }
                else
                {
                    context.Response.StatusCode = 403;
                    await context.Response.WriteAsync("Brak autoryzacji");
                }

                
            });

            app.Run(context => context.Response.WriteAsync("Hello World!"));
        }
    }
}
