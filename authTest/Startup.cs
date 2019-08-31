using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                var auth = context.Request.Headers["Authorization"].ToString();
                if (!string.IsNullOrEmpty(auth))
                {
                    var tmp = auth.Split(' ');
                    byte[] data = Convert.FromBase64String(tmp[0]);
                    string decodedString = Encoding.UTF8.GetString(data);

                    var creds = decodedString.Split(':');
                    var username = creds[0];
                    var password = creds[1];

                    if ((username == "sirwan") && (password == "afifi"))
                    {

                        context.Response.StatusCode = 200;
                        await context.Response.WriteAsync("<html><body>Congratulations you just Sirwan!</body></html>");
                    }
                    else
                    {
                        context.Response.StatusCode = 401;
                        context.Response.Headers.Add("WWW-Authenticate", "Basic realm='Secure Area'");
                        await context.Response.WriteAsync("<html><body>You shall not pass</body></html>");
                    }
                }
                else
                {
                    context.Response.StatusCode = 401;
                    context.Response.Headers.Add("WWW-Authenticate", "Basic realm='Secure Area'");
                    await context.Response.WriteAsync("<html><body>Need some creds son</body></html>");
                }
            });
        }
    }
}
