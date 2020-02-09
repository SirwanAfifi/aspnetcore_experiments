using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace ConsoleWebApp
{
    class Program
    {
        private static readonly JsonSerializerOptions _options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };


        static async Task Main(string[] args)
        {
            var app = WebApplication.Create(args);
            app.MapGet("/api/todos", async context =>
            {
                await JsonSerializer.SerializeAsync(context.Response.Body, new { name = "Sirwan" }, _options);
            });
            await app.RunAsync();
        }
    }
}
