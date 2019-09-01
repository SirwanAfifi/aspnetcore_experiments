using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeSauce.Api.Controllers
{
    [Route("/api/secret")]
    [Authorize]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Content("This is a secret page");
        }
    }
}