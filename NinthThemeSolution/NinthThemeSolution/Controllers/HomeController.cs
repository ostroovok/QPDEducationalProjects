﻿using Microsoft.AspNetCore.Mvc;
using NinthThemeSolution.Data;
using NinthThemeSolution.Models;
using System.Threading.Tasks;

namespace NinthThemeSolution.Controllers
{
    public class HomeController : Controller
    {
        private readonly Bot bot;
        public HomeController(BotRepositoryContext context)
        {
            bot = new(context);
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("api/Chat")]
        public async Task<JsonResult> ChatBot(Question request)
        {

            /*HttpContext.
            if (!bot.Enable)
            {
                return Json("Шарпик ушел...");
            }*/

            Answer result = await bot.HandleMessage(request);

            return Json(result);
        }
    }
}
