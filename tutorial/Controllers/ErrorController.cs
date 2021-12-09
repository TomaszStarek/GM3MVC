using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tutorial.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View("ErrorDefault");
        }
        public ActionResult Unauthorize()
        {
            return View();
        }
        public IActionResult NotFounded()
        {
            return View();
        }
    }
}
