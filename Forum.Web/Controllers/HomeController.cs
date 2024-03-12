using Forum.Web.Data;
using Forum.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Forum.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ForumDbContext forumDbContext;

        public HomeController(ForumDbContext forumDbContext)
        {
            this.forumDbContext = forumDbContext;
        }

        public IActionResult Index()
        {
            var topics = this.forumDbContext.Topics.Include(t => t.Threads).ToList();
            return View(topics);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}