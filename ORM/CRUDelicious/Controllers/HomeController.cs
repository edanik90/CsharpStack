using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;

namespace CRUDelicious.Controllers
{
    public class HomeController : Controller
    {
        private HomeContext dbContext;
        public HomeController(HomeContext context)
        {
            dbContext = context;
        }
        public IActionResult Index()
        {
            List<Dish> RecentDishes = dbContext.Dishes.OrderByDescending(d => d.CreatedAt).ToList();
            ViewBag.RecentDishes = RecentDishes;
            return View();
        }

        [HttpGet("new")]
        public IActionResult AddDish()
        {
            return View();
        }

        [HttpPost("create")]
        public IActionResult Create(Dish newDish)
        {
            if(ModelState.IsValid)
            {
                dbContext.Dishes.Add(newDish);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("AddDish");
            }
        }

        [HttpGet("dish/{dishId}")]
        public IActionResult DishInfo(int dishId)
        {
            Dish dbDish = dbContext.Dishes.FirstOrDefault(d => d.DishId == dishId);
            return View(dbDish);
        }


        [HttpGet("edit/{dishId}")]
        public IActionResult Edit(int dishId)
        {
            Dish dbDish = dbContext.Dishes.FirstOrDefault(d => d.DishId == dishId);
            return View(dbDish);
        }

        [HttpPost("update/{dishId}")]
        public IActionResult Update(Dish dish, int dishId)
        {
            Dish dbDish = dbContext.Dishes.FirstOrDefault(d => d.DishId == dishId);
            if(ModelState.IsValid)
            {
                dbDish.Name = dish.Name;
                dbDish.Chef = dish.Chef;
                dbDish.Calories = dish.Calories;
                dbDish.Tastiness = dish.Tastiness;
                dbDish.Description = dish.Description;
                dbDish.UpdatedAt = DateTime.Now;
                dbContext.SaveChanges();
                return RedirectToAction("DishInfo", new { dishId = dish.DishId});
            }
            else
            {
                return View("Edit", dbDish);
            }
        }

        [HttpGet("/delete/{dishId}")]
        public IActionResult Delete(int dishId)
        {
            Dish dbDish = dbContext.Dishes.SingleOrDefault(d => d.DishId == dishId);
            dbContext.Dishes.Remove(dbDish);
            dbContext.SaveChanges();
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
