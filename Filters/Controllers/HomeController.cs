using Filters.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Filters.Controllers
{
    [Profile]
    public class HomeController : Controller
    {
        public IActionResult Index() => View("Message",
            "This is the Index action on the Home controller");

        public IActionResult SecondAction() => View("Message",
                    "This is the SecondAction action on the Home controller");
    }
}