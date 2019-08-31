using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace AwesomeSauce.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddHostedService<AwesomeHostedService>();
            services.AddMvc();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        var serverSecret = new SymmetricSecurityKey(Encoding.UTF8.
                GetBytes(Configuration["JWT:ServerSecret"]));
                        options.TokenValidationParameters = new
                        TokenValidationParameters
                        {
                            IssuerSigningKey = serverSecret,
                            ValidIssuer = Configuration["JWT:Issuer"],
                            ValidAudience = Configuration["JWT:Audience"]
                        };
                    });
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseAuthentication();

            app.UseMvcWithDefaultRoute();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
