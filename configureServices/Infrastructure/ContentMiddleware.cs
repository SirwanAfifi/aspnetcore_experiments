using System.Text;
using System.Threading.Tasks;
using configureService.Infrastructure;
using Microsoft.AspNetCore.Http;

namespace configureServices
{
    public class ContentMiddleware
    {
        private RequestDelegate nextDelegate;
        private readonly UptimeService up;

        public ContentMiddleware(RequestDelegate next, UptimeService up)
        {
            nextDelegate = next;
            this.up = up;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Path.ToString() == "/middleware")
            {
                await httpContext.Response.WriteAsync("This is from the content middleware " +
                        $"(uptime: {up.Uptime}ms)", Encoding.UTF8);
            }
            else
            {
                await nextDelegate.Invoke(httpContext);
            }
        }
    }
}