using Forum.Web.Data;
using Forum.Web.Models.ViewModels;
using Forum.Web.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Forum.Web.Controllers
{
    public class ThreadController : Controller
    {
        private readonly ForumDbContext forumDbContext;

        public ThreadController(ForumDbContext forumDbContext) 
        {
            this.forumDbContext = forumDbContext;
        }

        public IActionResult Index(int topicId)
        {
            var threads = forumDbContext.Threads.Where(t => t.TopicId == topicId).ToList();
            return View(threads);
        }

        public IActionResult Thread(int threadId)
        {
            var thread = forumDbContext.Threads.Include(t => t.Replies).FirstOrDefault(t => t.Id == threadId);
            var replies = thread.Replies.ToList();
            var viewModel = new ThreadViewModel
            {
                Thread = thread,
                Replies = replies
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddReply(CreateReplyViewModel model)
        {
            if (ModelState.IsValid)
            {
                var reply = new ReplyModel
                {
                    Title = model.Title,
                    Text = model.Text,
                    Created = DateTime.Now,
                    ThreadId = model.ThreadId
                };

                forumDbContext.Replies.Add(reply);
                forumDbContext.SaveChanges();

                return RedirectToAction("Thread", new { threadId = model.ThreadId });
            }

            return View(model);
            // Handle validation errors
        }

        public IActionResult AddThread()
        {

            
            // Hämtar alla ämnen från databasen
            var topics = forumDbContext.Topics.ToList();

            // Skapa en lista av SelectListItems för dropdown-listan
            var topicList = topics.Select(t => new SelectListItem
            {
                Value = t.Id.ToString(),
                Text = t.Title 
            });

            // Skicka dropdown-listan till vyn
            ViewBag.TopicList = topicList;

            return View();
            
        }

        [HttpPost]
        [ActionName("AddThread")]
        public IActionResult AddThread(CreateThreadViewModel createThread)
        {
            if (ModelState.IsValid)
            {
                var thread = new ThreadModel
                {
                    Title = createThread.Title,
                    Text = createThread.Text,
                    Created = DateTime.Now,
                    TopicId = createThread.SelectedTopicId
                };

                forumDbContext.Threads.Add(thread);
                forumDbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("AddThread");
        }




    }
}
