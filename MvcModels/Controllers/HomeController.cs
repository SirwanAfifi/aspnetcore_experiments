using Microsoft.AspNetCore.Mvc;
using MvcModels.Models;

namespace MvcModels.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository repo;

        public HomeController(IRepository repo)
        {
            this.repo = repo;
        }

        public ViewResult Index(int id) => View(repo[id]);
    }
}