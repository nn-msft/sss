using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NewRelicDemo_NN_01.Models;

namespace NewRelicDemo_NN_01
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddLogging();
            services.AddControllersWithViews();
            services.AddSingleton<IEntrylRepository, EntryRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World Agsain!");
                });
                endpoints.MapControllerRoute(

                    name: "default",
                    pattern: "{controller=Entries}/{Action=Index}"

                    );
                endpoints.MapControllerRoute(
                    
                    name:"Entry",
                    pattern:"Entries/High",
                    defaults: new { controller="Entries",action="High"}
                    
                    );
                
            });
        }
    }
}
