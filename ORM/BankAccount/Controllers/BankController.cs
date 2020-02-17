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
    [Route("account")]
    public class BankController : Controller
    {
        private HomeContext dbContext;
        public BankController(HomeContext context)
        {
            dbContext = context;
        }

        [HttpGet("{userId}")]
        public IActionResult Index()
        {
            User dbUser = LoggedIn();
            if(dbUser == null)
            {
                return RedirectToAction("Logout", "Home");
            }
            ViewBag.User = dbUser;
            ViewBag.Balance = dbUser.MyTransactions.Sum(t => t.Ammount);
            return View();
        }


        [HttpPost("process")]
        public IActionResult Process(Transaction amount)
        {
            User dbUser = LoggedIn();
            if(dbUser == null)
            {
                return RedirectToAction("Logout", "Home");
            }
            if(ModelState.IsValid)
            {
                double balance = dbUser.MyTransactions.Sum(t => t.Ammount);
                if(balance + amount.Ammount < 0)
                {
                    ModelState.AddModelError("Amount", "You don't have the funds");
                    ViewBag.User = dbUser;
                    ViewBag.Balance = balance;
                    return Redirect($"/account/{dbUser.UserId}");
                }
                else
                {
                    dbContext.Transactions.Add(amount);
                    dbContext.SaveChanges();
                    return Redirect($"/account/{dbUser.UserId}");
                }
            }
            else
            {
                ViewBag.User = dbUser;
                ViewBag.Balance = dbUser.MyTransactions.Sum(t => t.Ammount);
                return Redirect($"/account/{dbUser.UserId}");
            }
        }
        private User LoggedIn()
        {
            return dbContext.Users.Include(u => u.MyTransactions).FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("UserId"));
        }
    }
}