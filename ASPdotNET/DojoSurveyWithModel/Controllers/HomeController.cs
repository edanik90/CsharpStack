using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DojoSurveyWithModel.Models;

namespace DojoSurveyWithModel.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("process")]
        public IActionResult Success(Dojo newDojo)
        {
            ViewBag.Name = newDojo.Name;
            ViewBag.Location = newDojo.Location;
            ViewBag.Language = newDojo.Language;
            ViewBag.Comment = newDojo.Comment;
            return View("Success");
        }
    }
}
