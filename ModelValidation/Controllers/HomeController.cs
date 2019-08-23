using System;
using Microsoft.AspNetCore.Mvc;
using ModelValidation.Models;

namespace ModelValidations.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index() =>
            View("MakeBooking", new Appointment { Date = DateTime.Now });

        [HttpPost]
        public ViewResult MakeBooking(Appointment appt) =>
            View("Completed", appt);
    }
}