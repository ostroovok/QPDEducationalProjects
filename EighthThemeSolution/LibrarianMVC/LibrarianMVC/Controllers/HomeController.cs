using LibrarianMVC.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LibrarianMVC.Controllers
{
    public class HomeController : Controller
    {
        LibrarianContext db;
        public HomeController(LibrarianContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View(db.Magazines.ToList());
        }
    }
}
