using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RandomPasscode.Models;
using Microsoft.AspNetCore.Http;

namespace RandomPasscode.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if(HttpContext.Session.GetInt32("Count")==null)
            {
                HttpContext.Session.SetInt32("Count", 0);
            }
            Random rand = new Random();
            string chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string passcode = new string("");
            for(int i = 0; i < 14; i++)
            {
                passcode += chars[rand.Next(chars.Length)];
            }
            ViewBag.Passcode = passcode;
            ViewBag.Count = HttpContext.Session.GetInt32("Count");
            return View();
        }

        [HttpPost("generate")]
        public IActionResult Generate()
        {
            int? count = HttpContext.Session.GetInt32("Count");
            count++;
            HttpContext.Session.SetInt32("Count", (int)count);
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
