using Microsoft.AspNetCore.Mvc;

namespace Forum.Web.Controllers
{
    public class ThreadController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
