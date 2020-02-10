using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ViewModel.Models;

namespace ViewModel.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            string message = "MessageMessageMessageMessageMessageMessageMessageMessageMessageMessageMessageMessageMessageMessagessss";
            return View("Index", message);
        }

        public IActionResult Numbers()
        {
            int[] numbers = {3,56,89,30,100,29};
            return View(numbers);
        }

        public IActionResult Users()
        {
            List<User> users = new List<User>();
            User john = new User();
            john.FirstName = "John";
            john.LastName = "Wick";
            User peter = new User();
            peter.LastName = "Parker";
            peter.FirstName = "Peter";
            User bruce = new User();
            bruce.FirstName = "Bruce";
            bruce.LastName = "Wayne";
            users.Add(john);
            users.Add(peter);
            users.Add(bruce);
            return View("Users", users);
        }

        public IActionResult SomeUser()
        {
            User newUser = new User();
            newUser.FirstName = "John";
            newUser.LastName = "Wick";
            return View("SomeUser", newUser);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
