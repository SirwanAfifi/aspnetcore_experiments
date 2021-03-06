﻿using System.Text;
using AwesomeSauce.Api.Infrastructure;
using AwesomeSauce.Api.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Logging;
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
            services.AddMemoryCache();
            services.AddMvc();
            IdentityModelEventSource.ShowPII = true;
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
            // services.AddSingleton<IPersonRepository, PersonRepository>();
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMiddleware<AwesomeGraphQLMiddleware>();
            app.UseAuthentication();

            app.UseMiddleware<AwesomeRateLimiterMiddleware>();

            app.UseMvc();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
