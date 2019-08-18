using System.Linq;
using HybridControllerViewComponent.Models;
using Microsoft.AspNetCore.Mvc;

namespace HybridControllerViewComponent.ViewComponents
{
    public class UserListViewComponent : ViewComponent
    {
        private readonly UserRepository repository;

        public UserListViewComponent(UserRepository repository)
        {
            this.repository = repository;
        }
        public IViewComponentResult Invoke(int numberToTake)
        {
            var users = repository.GetUsers().Take(10).ToList();
            return View(model: users);
        }
    }
}