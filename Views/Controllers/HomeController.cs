using Microsoft.AspNetCore.Mvc;

namespace Views.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}