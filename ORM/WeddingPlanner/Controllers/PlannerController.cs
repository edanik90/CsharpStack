using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;
using Microsoft.EntityFrameworkCore;
using WeddingPlanner.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace WeddingPlanner.Controllers
{
    [Route("weddingplanner")]
    public class PlannerController : Controller
    {
        private HomeContext dbContext;
        public PlannerController(HomeContext context)
        {
            dbContext = context;
        }

        [HttpGet("dashboard")]
        public IActionResult Index()
        {
            User dbUser = LoggedIn();
            if(dbUser == null)
            {
                return RedirectToAction("Logout", "Home");
            }
            ViewBag.User = dbUser;
            List<Wedding> AllWeddings = dbContext.Weddings.Include(w => w.Guests).ThenInclude(a => a.Guest).Include(w => w.Creator).ToList();
            return View(AllWeddings);
        }

        [HttpGet("wedding/new")]
        public IActionResult NewWedding()
        {
            return View();
        }

        [HttpPost("wedding/new/create")]
        public IActionResult Create(Wedding newWedding)
        {
            User dbUser = LoggedIn();
            if(dbUser == null)
            {
                return RedirectToAction("Logout", "Home");
            }
            if(ModelState.IsValid)
            {
                User current = dbContext.Users.Include(u => u.PlannedWeddings).FirstOrDefault(u => u.UserId == dbUser.UserId);
                current.PlannedWeddings.Add(newWedding);
                dbContext.Weddings.Add(newWedding);
                dbContext.SaveChanges();
                return Redirect($"/weddingplanner/wedding/{newWedding.WeddingId}");
            }
            else
            {
                return View("NewWedding");
            }
        }

        [HttpGet("wedding/{weddingId}")]
        public IActionResult WeddingInfo(int weddingId)
        {
            Wedding dbWedding = dbContext.Weddings.Include(w => w.Guests).ThenInclude(a => a.Guest).FirstOrDefault(w => w.WeddingId == weddingId);
            ViewBag.Guests = dbWedding.Guests.ToList();
            ViewBag.Wedding = dbWedding;
            return View();
        }

        [HttpGet("wedding/{weddingId}/rsvp")]
        public IActionResult RSVP(int weddingId)
        {
            User dbUser = LoggedIn();
            if(dbUser == null)
            {
                return RedirectToAction("Logout", "Home");
            }
            Association newAssoc = new Association();
            newAssoc.Guest = dbUser;
            newAssoc.Wedding = dbContext.Weddings.FirstOrDefault(w => w.WeddingId == weddingId);
            dbContext.Associations.Add(newAssoc);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet("wedding/{weddingId}/unrsvp")]
        public IActionResult UNRSVP(int weddingId)
        {
            User dbUser = LoggedIn();
            if(dbUser == null)
            {
                return RedirectToAction("Logout", "Home");
            }
            Association dbAssoc = dbContext.Associations.FirstOrDefault(a => a.WeddingId == weddingId);
            dbContext.Associations.Remove(dbAssoc);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet("wedding/{weddingId}/delete")]
        public IActionResult Delete(int weddingId)
        {
            Wedding dbWedding = dbContext.Weddings.SingleOrDefault(w => w.WeddingId == weddingId);
            List<Association> associations = dbContext.Associations.Where(a => a.WeddingId == weddingId).ToList();
            foreach(var item in associations)
            {
                dbContext.Associations.Remove(item);
            }
            dbContext.Weddings.Remove(dbWedding);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        private User LoggedIn()
        {
            return dbContext.Users.Include(u => u.Weddings).ThenInclude(a => a.Wedding).FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("UserId"));
        }
    }


}