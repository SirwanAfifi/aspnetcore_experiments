using System.Linq;
using HybridControllerViewComponent.Models;
using Microsoft.AspNetCore.Mvc;

namespace HybridControllerViewComponent.ViewComponents
{
    public class UserListViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(int numberToTake)
        {
            var users = UserDataSource.GetUsers().Take(10).ToList();
            return View(model: users);
        }
    }
}