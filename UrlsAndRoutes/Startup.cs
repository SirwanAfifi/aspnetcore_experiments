using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace UrlsAndRoutes
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            // app.UseMvc(routes =>
            // {
            //     routes.MapRoute(name: "MapRoute",
            //         template: "{controller=Home}/{action=Index}/{id:int?}");
            // });
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "MyRoute",
                template: "{controller}/{action}/{id?}",
                defaults: new { controller = "Home", action = "Index" }, constraints: new { id = new IntRouteConstraint() });
            });
        }
    }
}
