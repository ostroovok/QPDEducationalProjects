using Microsoft.AspNetCore.Mvc;
using NinthThemeSolution.Data;
using NinthThemeSolution.Models;
using System;
using System.Collections.Generic;
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
        public IActionResult Start()
        {
            return View();
        }

        [HttpPost("api/Chat")]
        public async Task<JsonResult> ChatBot(Question request, string token)
        {
            if (HttpContext.Request.Cookies.Keys.Contains(token))
            {
                Answer result = await bot.HandleMessage(request);

                if(result.MessageType == "ByeType")
                {
                    HttpContext.Response.Cookies.Delete(token);
                }

                return Json(result);
            }

            return Json(new Answer { Message = "Шарпик ушел..." });
        }

        [HttpGet("api/Token")]
        public JsonResult GetToken()
        {
            var token = Guid.NewGuid().ToString();
            HttpContext.Response.Cookies.Append(token, string.Empty);
            return Json(token);
        }
    }
}
