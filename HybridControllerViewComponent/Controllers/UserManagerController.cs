using System.Linq;
using HybridControllerViewComponent.Models;
using Microsoft.AspNetCore.Mvc;

namespace HybridControllerViewComponent.Controllers
{
    public class UserManagerController : Controller
    {
        private readonly UserRepository repository;

        public UserManagerController(UserRepository repository)
        {
            this.repository = repository;
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
    }
}