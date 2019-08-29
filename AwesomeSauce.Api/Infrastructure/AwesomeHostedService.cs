using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace AwesomeSauce.Api.Infrastructure
{
    public class AwesomeHostedService : BackgroundService
    {
        private readonly IHostingEnvironment env;

        public AwesomeHostedService(IHostingEnvironment env)
        {
            this.env = env;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            System.Console.WriteLine("Service Started");
            var client = new HttpClient();
            var file = $@"{env.ContentRootPath}/wwwroot/comments.json";
            while (!stoppingToken.IsCancellationRequested)
            {
                var response = await client.GetAsync("http://localhost:3000/users");
                using (var output = File.OpenWrite(file))
                using (var content = await response.Content.
                ReadAsStreamAsync())
                {
                    content.CopyTo(output);
                }
                Thread.Sleep(60000);
            }
        }
    }
}