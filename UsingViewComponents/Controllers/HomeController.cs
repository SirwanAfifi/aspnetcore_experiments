using Microsoft.AspNetCore.Mvc;

namespace UsingViewComponents.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index() => View();
    }
}