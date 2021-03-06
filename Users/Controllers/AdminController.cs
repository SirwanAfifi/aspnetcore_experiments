using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Users.Models;

namespace Users.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<AppUser> usrMgr;

        public AdminController(UserManager<AppUser> usrMgr)
        {
            this.usrMgr = usrMgr;
        }

        public ViewResult Index() => View(usrMgr.Users);

        public ViewResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    UserName = model.Name,
                    Email = model.Email
                };
                IdentityResult result
                    = await usrMgr.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }
    }
}