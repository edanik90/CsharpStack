using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dojodachi.Models;
using Microsoft.AspNetCore.Http;

namespace Dojodachi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if(HttpContext.Session.GetInt32("Fullness") == null && 
                HttpContext.Session.GetInt32("Happiness") == null &&
                HttpContext.Session.GetInt32("Meals") == null &&
                HttpContext.Session.GetInt32("Energy") == null)
                {
                    HttpContext.Session.SetInt32("Fullness", 20);
                    HttpContext.Session.SetInt32("Happiness", 20);
                    HttpContext.Session.SetInt32("Meals", 3);
                    HttpContext.Session.SetInt32("Energy", 50);
                }
            if(HttpContext.Session.GetInt32("Fullness") >= 100 &&
                HttpContext.Session.GetInt32("Energy") >= 100 &&
                HttpContext.Session.GetInt32("Happiness") >=100)
                {
                    return RedirectToAction("Win");
                }
            if(HttpContext.Session.GetInt32("Fullness") <= 0 ||
                HttpContext.Session.GetInt32("Happiness") <= 0)
                {
                    return RedirectToAction("Lose");
                }
            ViewBag.Fullness = HttpContext.Session.GetInt32("Fullness");
            ViewBag.Happiness = HttpContext.Session.GetInt32("Happiness");
            ViewBag.Meals = HttpContext.Session.GetInt32("Meals");
            ViewBag.Energy = HttpContext.Session.GetInt32("Energy");
            if(TempData["redMessage"] != null)
            {
                ViewBag.redMessage = TempData["redMessage"];
            }
            else
            {
                ViewBag.Message = TempData["Message"];
            }
            return View();
        }

        [HttpGet("feed")]
        public IActionResult Feed()
        {
            int? meals = HttpContext.Session.GetInt32("Meals");
            int? fullness = HttpContext.Session.GetInt32("Fullness");
            Random rand = new Random();
            if(meals == 0)
            {
                TempData["redMessage"] = "Oops! Cannot feed Dojodachi; you ran out of meals!";
            }
            else if(rand.Next(5) == 2)
            {
                meals -= 1;
                HttpContext.Session.SetInt32("Meals", (int)meals);
                TempData["redMessage"] = "Om nom...ewww!!! This meal was bad! Meals -1";
            }
            else
            {
                int num = rand.Next(5,11);
                fullness += num;
                meals -= 1;
                HttpContext.Session.SetInt32("Meals", (int)meals);
                HttpContext.Session.SetInt32("Fullness", (int)fullness);
                TempData["Message"] = $"Om nom nom! It was delicious! Fullness +{num}, Meals -1";
            }
            return RedirectToAction("Index");
        }

        [HttpGet("play")]
        public IActionResult Play()
        {
            int? energy = HttpContext.Session.GetInt32("Energy");
            int? happiness = HttpContext.Session.GetInt32("Happiness");
            Random rand = new Random();
            if(rand.Next(5) == 2)
            {
                energy -= 5;
                HttpContext.Session.SetInt32("Energy", (int)energy);
                TempData["redMessage"] = "I don't like this game! Energy -5";
            }
            else
            {
                int num = rand.Next(5,11);
                happiness += num;
                energy -= 5;
                HttpContext.Session.SetInt32("Energy", (int)energy);
                HttpContext.Session.SetInt32("Happiness", (int)happiness);
                TempData["Message"] = $"Ggwp! Happiness +{num}, Energy -5";
            }
            return RedirectToAction("Index");
        }

        [HttpGet("work")]
        public IActionResult Work()
        {
            int? energy = HttpContext.Session.GetInt32("Energy");
            int? meals = HttpContext.Session.GetInt32("Meals"); 
            Random rand = new Random();
            int num = rand.Next(1,4);
            energy -= 5;
            meals += num;
            HttpContext.Session.SetInt32("Energy", (int)energy);
            HttpContext.Session.SetInt32("Meals", (int)meals);
            TempData["Message"] = $"Going to work... ehh... just gotta earn those meals... Meals +{num}, Energy -5";
            return RedirectToAction("Index");
        }

        [HttpGet("sleep")]
        public IActionResult Sleep()
        {
            int? energy = HttpContext.Session.GetInt32("Energy");
            int? happiness = HttpContext.Session.GetInt32("Happiness");
            int? fullness = HttpContext.Session.GetInt32("Fullness");
            energy += 15;
            fullness -= 5;
            happiness -= 5;
            HttpContext.Session.SetInt32("Energy", (int)energy);
            HttpContext.Session.SetInt32("Happiness", (int)happiness);
            HttpContext.Session.SetInt32("Fullness", (int)fullness);
            TempData["Message"] = "Zzzz.... Energy +15, Fullness -5, Happiness -5";
            return RedirectToAction("Index");
        }

        [HttpGet("/win")]
        public IActionResult Win()
        {
            ViewBag.Fullness = HttpContext.Session.GetInt32("Fullness");
            ViewBag.Happiness = HttpContext.Session.GetInt32("Happiness");
            ViewBag.Meals = HttpContext.Session.GetInt32("Meals");
            ViewBag.Energy = HttpContext.Session.GetInt32("Energy");
            return View();
        }

        [HttpGet("/lose")]
        public IActionResult Lose()
        {
            ViewBag.Fullness = HttpContext.Session.GetInt32("Fullness");
            ViewBag.Happiness = HttpContext.Session.GetInt32("Happiness");
            ViewBag.Meals = HttpContext.Session.GetInt32("Meals");
            ViewBag.Energy = HttpContext.Session.GetInt32("Energy");
            return View();
        }

        [HttpGet("/restart")]
        public IActionResult Restart()
        {
            HttpContext.Session.Clear();
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
