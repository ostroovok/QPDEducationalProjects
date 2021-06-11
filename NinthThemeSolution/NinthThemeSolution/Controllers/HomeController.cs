using ChatBotLibrary;
using Microsoft.AspNetCore.Mvc;

namespace NinthThemeSolution.Controllers
{
    public class HomeController : Controller
    {
        private bool exit;
        private Bot bot;

        public HomeController()
        {
            bot = new(() => exit = true);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
