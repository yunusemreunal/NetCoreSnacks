using System.Buffers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace NetCoreSnackApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore(options =>
                {
                    options.RespectBrowserAcceptHeader = true;
                    var jsonOutputFormatter = new JsonOutputFormatter(new JsonSerializerSettings(),
                        ArrayPool<char>.Shared);
                    options.OutputFormatters.Insert(0, jsonOutputFormatter);
                })
                .AddJsonFormatters(options => {
                    options.ContractResolver = new DefaultContractResolver();
                });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(routes =>
            {
                //New Route
                routes.MapRoute(
                   name: "BsonData",
                   template: "BsonData",
                   defaults: new { controller = "Home", action = "BsonData" }
                );

                routes.MapRoute(
                    name: "default",
                    template: "api/{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
