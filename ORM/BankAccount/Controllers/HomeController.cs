using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BankAccount.Models;
using Microsoft.EntityFrameworkCore;
using BankAccount.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace BankAccount.Controllers
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
            return View();
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("register")]
        public IActionResult Register(User register)
        {
            if(ModelState.IsValid)
            {
                if(dbContext.Users.Any(u => u.Email == register.Email))
                {
                    ModelState.AddModelError("Email", "Email is already in use");
                    return View("Index");
                }
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                register.Password = Hasher.HashPassword(register, register.Password);
                dbContext.Users.Add(register);
                dbContext.SaveChanges();
                HttpContext.Session.SetInt32("UserId", register.UserId);
                return Redirect($"/account/{register.UserId}");
            }
            else
            {
                return View("Index");
            }
        }

        [HttpGet("success")]
        public IActionResult Success()
        {
            User userInDb = LoggedIn();
            if(userInDb == null)
            {
                return RedirectToAction("Logout");
            }
            return View(userInDb);
        }

        [HttpPost("signin")]
        public IActionResult SignIn(LoginUser login)
        {
            if(ModelState.IsValid)
            {
                User dbUser = dbContext.Users.FirstOrDefault(u => u.Email == login.LoginEmail);
                if(dbUser == null)
                {
                    ModelState.AddModelError("LoginEmail", "Invalid email/password");
                    return View("Login");
                }
                PasswordHasher<LoginUser> Hash = new PasswordHasher<LoginUser>();
                var result = Hash.VerifyHashedPassword(login, dbUser.Password, login.LoginPassword);
                if(result == 0)
                {
                    ModelState.AddModelError("LoginEmail", "Invalid email/password");
                    return View("Login");
                }
                HttpContext.Session.SetInt32("UserId", dbUser.UserId);
                return Redirect($"/account/{dbUser.UserId}");
            }
            else
            {
                return View("Login");
            }
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        private User LoggedIn()
        {
            return dbContext.Users.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("UserId"));
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
