using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace configureServices
{
    public class BrowserTypeMiddleware
    {
        private RequestDelegate nextDelegate;

        public BrowserTypeMiddleware(RequestDelegate next) => nextDelegate = next;

        public async Task Invoke(HttpContext httpContext)
        {
            httpContext.Items["EdgeBrowser"]
            = httpContext.Request.Headers["User-Agent"]
                .Any(h => h.ToLower().Contains("edge"));
            await nextDelegate.Invoke(httpContext);
        }
    }
}