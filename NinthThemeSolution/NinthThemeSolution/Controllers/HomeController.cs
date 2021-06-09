using ChatBotLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace NinthThemeSolution.Controllers
{
    public class HomeController : Controller
    {
        private bool exit;
        private Bot bot;

        public HomeController(ILogger<HomeController> logger)
        {
            bot = new(ExitCallback);
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string message)
        {
            ViewBag.Message = bot.HandleMessage(message);
            return ViewBag;
        }
        
        private void ExitCallback()
        {
            exit = false;
        }
    }
}
