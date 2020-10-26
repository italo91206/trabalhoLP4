using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace trabalhoLP4.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            if (ViewBag.Logado == null)
                return View("~/Views/Login/Index.cshtml");
            else
                return View("~/Views/Default/Index.cshtml");
        }
    }
}
