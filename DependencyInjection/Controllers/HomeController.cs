using DependencyInjection.Models;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjection.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index([FromServices]IRepository repository)
        {
            ViewBag.HomeController = repository.ToString();
            return View(repository.Products);
        }
    }
}