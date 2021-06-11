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

                if (context.HelloPhrases.Any())
                {
                    return;
                }

                var helloPhrases = new HelloPhrase[]
                {
                new HelloPhrase{ Message = "Привет" },
                new HelloPhrase{ Message = "Здравствуйте" },
                new HelloPhrase{ Message = "Добрый день" },
                };

                var helloPhrasesRequests = new HelloPhraseRequest[]
                {
                new HelloPhraseRequest{ Message = "привет", Responses = helloPhrases.ToList() },
                new HelloPhraseRequest{ Message = "здравствуй", Responses = helloPhrases.ToList() },
                new HelloPhraseRequest{ Message = "здравствуйте", Responses = helloPhrases.ToList() },
                new HelloPhraseRequest{ Message = "добрый день", Responses = helloPhrases.ToList() },
                new HelloPhraseRequest{ Message = "добрый вечер", Responses = helloPhrases.ToList() },
                new HelloPhraseRequest{ Message = "доброе утро", Responses = helloPhrases.ToList() },
                new HelloPhraseRequest{ Message = "доброй ночи", Responses = helloPhrases.ToList() },
                };
                context.HelloPhrases.AddRange(helloPhrases);
                context.HelloPhrasesRequests.AddRange(helloPhrasesRequests);
                context.SaveChanges();



                var byePhrases = new ByePhrase[]
                {
                new ByePhrase{ Message = "Пока" },
                new ByePhrase{ Message = "До свидания" },
                };

                var byePhrasesRequests = new ByePhraseRequest[]
                {
                new ByePhraseRequest{ Message = "Пока", Responses = byePhrases.ToList() },
                new ByePhraseRequest{ Message = "До свидания", Responses = byePhrases.ToList() },
                };
                context.ByePhrases.AddRange(byePhrases);
                context.ByePhrasesRequests.AddRange(byePhrasesRequests);
                context.SaveChanges();



                var anecdotes = new Anecdote[]
                {
                new Anecdote{ Message = "Приходит муж домой, а там жена!" },
                new Anecdote{ Message = "Купил мужик шляпу, а она ему как раз!" },
                };

                var anecdotesRequests = new AnecdoteRequest[]
                {
                new AnecdoteRequest{ Message = "анекдот", Responses = anecdotes.ToList() },
                };
                context.Anecdotes.AddRange(anecdotes);
                context.AnecdotesRequests.AddRange(anecdotesRequests);
                context.SaveChanges();



                var aphorisms = new Aphorism[]
                {
                new Aphorism{ Message = "Если тебе тяжело, значит ты поднимаешься в гору. Если тебе легко, значит ты летишь в пропасть." },
                new Aphorism{ Message = "Какое слово скажешь, такое в ответ и услышишь." },
                new Aphorism{ Message = "Шутку, как и соль, должно употреблять с умеренностью." },
                new Aphorism{ Message = "Не происходит изменений лишь с высшей мудростью и низшей глупостью." },
                };
                context.Aphorisms.AddRange(aphorisms);
                context.SaveChanges();

            }
        }
    }
}
