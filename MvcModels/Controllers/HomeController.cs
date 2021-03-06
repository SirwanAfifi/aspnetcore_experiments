using System.Collections.Generic;
using System.Linq;
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

        public IActionResult Index(int? id)
        {
            Person person;
            if (id.HasValue && (person = repo[id.Value]) != null)
            {
                return View(person);
            }
            else
            {
                return NotFound();
            }
        }

        public ViewResult Create() => View(new Person());

        [HttpPost]
        public ViewResult Create(Person model) => View("Index", model);

        [HttpPost]
        public ViewResult DisplaySummary(
            [Bind(Prefix = nameof(Person.HomeAddress))]AddressSummary summary) => View(summary);

        public ViewResult Names(string[] names) => View(names ?? new string[0]);

        public ViewResult Address(IList<AddressSummary> addresses) =>
            View(addresses ?? new List<AddressSummary>());
    }
}