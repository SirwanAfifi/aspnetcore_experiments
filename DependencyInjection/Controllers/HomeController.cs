using DependencyInjection.Models;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjection.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository repository;

        public HomeController(IRepository repository)
        {
            this.repository = repository;
        }
        public ViewResult Index()
        {
            ViewBag.HomeController = repository.ToString();
            return View(repository.Products);
        }
    }
}