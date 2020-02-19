using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheWall.Models;
using Microsoft.EntityFrameworkCore;
using TheWall.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace TheWall.Controllers
{
    [Route("wall")]
    public class WallController : Controller
    {
        private HomeContext dbContext;
        public WallController(HomeContext context)
        {
            dbContext = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            User dbUser = LoggedIn();
            if(dbUser == null)
            {
                return RedirectToAction("Logout", "Home");
            }
            ViewBag.User = dbUser;
            ViewBag.AllMessages = dbContext.Messages.Include(m => m.Creator).Include(m => m.Comments).ThenInclude(c => c.Creator).OrderByDescending(m => m.CreatedAt);
            return View();
        }

        [HttpPost("postmessage")]
        public IActionResult PostMessage(Message newMessage)
        {
            User dbUser = LoggedIn();
            if(dbUser == null)
            {
                return RedirectToAction("Logout", "Home");
            }
            dbContext.Messages.Add(newMessage);
            dbUser.Messages.Add(newMessage);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost("/{messageId}/postcomment")]
        public IActionResult PostComment(string Content, int messageId)
        {
            User dbUser = LoggedIn();
            if(dbUser == null)
            {
                return RedirectToAction("Logout", "Home");
            }
            Comment newComment = new Comment();
            newComment.Content = Content;
            newComment.MessageId = messageId;
            newComment.UserId = dbUser.UserId;
            dbContext.Comments.Add(newComment);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        private User LoggedIn()
        {
            return dbContext.Users.Include(u => u.Messages).Include(u => u.Comments).FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("UserId"));
        }
    }
}