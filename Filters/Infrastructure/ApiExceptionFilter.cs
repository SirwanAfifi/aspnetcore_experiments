using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Filters.Infrastructure
{
    public class ApiExceptionFilter : ExceptionFilterAttribute
    {
        private readonly IHostingEnvironment env;

        public ApiExceptionFilter(IHostingEnvironment env)
        {
            this.env = env;
        }
        public override void OnException(ExceptionContext context)
        {
            context.Result = new JsonResult(new { message = context.Exception.Message });
            base.OnException(context);
        }
    }
}