using Microsoft.AspNetCore.Mvc;

namespace HybridControllerViewComponent.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index() => View();
    }
}