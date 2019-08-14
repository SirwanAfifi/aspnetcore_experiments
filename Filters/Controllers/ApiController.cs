using System;
using Filters.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Filters.Controllers
{
    [ServiceFilter(typeof(ApiExceptionFilter))]
    public class ApiController : Controller
    {
        public JsonResult GetData()
        {
            throw new Exception("Something bad happened");
            return Json("Hello");
        }
    }
}