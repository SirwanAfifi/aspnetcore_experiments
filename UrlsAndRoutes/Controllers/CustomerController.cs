using Microsoft.AspNetCore.Mvc;
using UrlsAndRoutes.Models;

namespace UrlsAndRoutes.Controllers
{
    public class CustomerController : Controller
    {

        public ViewResult Index() => View("Result",
                    new Result
                    {
                        Controller = nameof(HomeController),
                        Action = nameof(Index)
                    });
        public ViewResult List() => View("Result",
            new Result
            {
                Controller = nameof(HomeController),
                Action = nameof(List)
            });
    }
}