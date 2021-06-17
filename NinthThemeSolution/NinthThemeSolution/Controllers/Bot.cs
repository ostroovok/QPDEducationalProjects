using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NinthThemeSolution.Data;
using NinthThemeSolution.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NinthThemeSolution.Controllers
{
    [NonController]
    public class Bot
    {
        private readonly BotRepositoryContext _context;

        //public bool Enable = true;

        public Bot(BotRepositoryContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Выборка по типу сообщения
        /// Тип сообщения содержится в базе данных вместе с вопросами и ответами, по нему сопоставляем 
        /// В случае, если ответа такого типа в базе нет и длина массива равна 0, то ответ, скорее всего,
        /// должен составляться в реальном времени
        /// </summary>
        /// <param name="request">Входящее сообщение</param>
        /// <returns>Ответ в формате Json</returns>

        public async Task<Answer> HandleMessage(Question request)
        {
            Random rnd = new();

            var questionType = await _context.Questions.Where(m => request.Message.ToLower().Contains(m.Message.ToLower())).FirstOrDefaultAsync();

            if (questionType != null)
            {

                var question = await _context.Questions.Where(
                    m => m.MessageType.ToLower() == questionType.MessageType.ToLower()).FirstOrDefaultAsync();

                if (question != null)
                {

                    var answer = await _context.Answers.Where(m => m.MessageType.ToLower() == question.MessageType.ToLower()).ToArrayAsync();

                    if (answer.Length != 0)
                    {
                        var response = answer[rnd.Next(answer.Length + 1)];

                        return response;
                    }
                    else
                    {
                        var response = new Answer { Message = DateTime.Now.ToString("HH:mm") };

                        return response;
                    }
                }
            }

            var aphorism = await _context.Answers.Where(m => m.MessageType.ToLower() == "aphorism").ToArrayAsync();

            var result = aphorism[rnd.Next(aphorism.Length + 1)];

            return result;
        }
    }
}
