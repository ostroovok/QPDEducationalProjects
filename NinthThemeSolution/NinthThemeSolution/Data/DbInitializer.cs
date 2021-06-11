using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NinthThemeSolution.Models;
using System;
using System.Linq;

namespace NinthThemeSolution.Data
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BotRepositoryContext(
                serviceProvider.GetRequiredService<DbContextOptions<BotRepositoryContext>>()))
            {

                if (context.Answers.Any())
                {
                    return;
                }

                var answers = new Answer[]
                {
                    new Answer{ Message = "Привет", MessageType = "HelloType"},
                    new Answer{ Message = "Здравствуйте", MessageType = "HelloType"},
                    new Answer{ Message = "Пока", MessageType = "ByeType"},
                    new Answer{ Message = "До свидания", MessageType = "ByeType"},
                    new Answer{ Message = "Шарпик", MessageType = "NameType"},
                    new Answer{ Message = "Приходит муж домой, а там жена!", MessageType = "Anecdote"},
                    new Answer{ Message = "Купил мужик шляпу, а она ему как раз", MessageType = "Anecdote"},
                    new Answer{ Message = "Если тебе тяжело, значит ты поднимаешься в гору. Если тебе легко, значит ты летишь в пропасть.", 
                        MessageType = "Aphorism"},
                    new Answer{ Message = "Шутку, как и соль, должно употреблять с умеренностью.", MessageType = "Aphorism"},
                    new Answer{ Message = "Не происходит изменений лишь с высшей мудростью и низшей глупостью.", MessageType = "Aphorism"},
                };

                context.Answers.AddRange(answers);
                context.SaveChanges();


                var questions = new Question[]
                {
                    new Question{ Message = "привет", MessageType = "HelloType"},
                    new Question{ Message = "здравствуй", MessageType = "HelloType"},
                    new Question{ Message = "добрый день", MessageType = "HelloType"},
                    new Question{ Message = "добрый вечер", MessageType = "HelloType"},
                    new Question{ Message = "доброе утро", MessageType = "HelloType"},
                    new Question{ Message = "анекдот", MessageType = "Anecdote"},
                    new Question{ Message = "как тебя зовут", MessageType = "NameType"},
                    new Question{ Message = "пока", MessageType = "ByeType"},
                    new Question{ Message = "до свидания", MessageType = "ByeType"},
                };

                context.Questions.AddRange(questions);
                context.SaveChanges();
            }
        }
    }
}
