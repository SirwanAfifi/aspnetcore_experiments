using System.Collections.Generic;
using configureService.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace configureService
{
    public class HomeController : Controller
    {
        private readonly UptimeService uptime;

        public HomeController(UptimeService uptime)
        {
            this.uptime = uptime;
        }
        public IActionResult Index() =>
            View(new Dictionary<string, string>
            {
                ["Message"] = "This is the index action",
                ["UpTime"] = $"{uptime.Uptime}ms"
            });
    }
}