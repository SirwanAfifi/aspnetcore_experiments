using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace authTest
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.Use(async (context, next) =>
            {
                var user = context.Request.Query["username"];
                var password = context.Request.Query["password"];
                if (user == "sirwan" && password == "afifi")
                {
                    var personList = new List<string> {
                    "Sirwan",
                    "Kaywan"
                };
                    await context.Response.WriteAsync(personList.Aggregate((val1, val2) => val1 + "\n" + val2));
                }
                else
                {
                    context.Response.Headers.Add("WWW-Authenticate", "Basic");
                    context.Response.StatusCode = 401;
                }
            });
        }
    }
}
