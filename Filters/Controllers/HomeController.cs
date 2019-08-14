using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Filters.Controllers
{
    public class HomeController : Controller
    {
        [RequireHttps]
        public IActionResult Index() => View("Message",
            "This is the Index action on the Home controller");


        [RequireHttps]
        public IActionResult SecondAction() => View("Message",
                    "This is the SecondAction action on the Home controller");
    }
}