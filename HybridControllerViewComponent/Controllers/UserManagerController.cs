using System.Collections.Generic;
using System.Linq;
using HybridControllerViewComponent.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace HybridControllerViewComponent.Controllers
{
    [ViewComponent(Name = "UserList")]
    public class UserManagerController : Controller
    {
        private readonly UserRepository repository;

        public UserManagerController(UserRepository repository)
        {
            this.repository = repository;
        }

        public ViewResult Index()
        {
            var users = repository.GetUsers().ToList();
            return View(users);
        }

        public ViewResult Edit(int id)
        {
            var user = repository.GetUsers().FirstOrDefault(u => u.Id == id);
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(User user)
        {
            repository.Edit(user);
            return RedirectToAction("Index", "Home");
        }

        public IViewComponentResult Invoke()
        {
            var users = repository.GetUsers().Take(10).ToList();
            return new ViewViewComponentResult
            {
                ViewData = new ViewDataDictionary<IList<User>>(ViewData, users)
            };
        }
    }
}