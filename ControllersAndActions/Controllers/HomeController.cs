using ControllersAndActions.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Text;
namespace ControllersAndActions.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult ReceiveForm(string name, string city)
            => new CustomHtmlResult
            {
                Content = $"{name} lives in {city}"
            };
    }
}