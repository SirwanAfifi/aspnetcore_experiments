using System.Linq;
using HybridControllerViewComponent.Models;
using Microsoft.AspNetCore.Mvc;

namespace HybridControllerViewComponent.Controllers
{
    public class UserManagerController : Controller
    {
        public ViewResult Edit(int id)
        {
            var user = UserDataSource.GetUsers().FirstOrDefault(u => u.Id == id);
            return View(user);
        }
    }
}