using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpikLogic
{
    public class Logic
    {
        public delegate void EnteredQuestion(InputMessage q);

        public bool Enable { get; set; } = true;
        public List<Message> AllMessages { get; private set; }

        public string ActualAnswer { get; private set; }

        public Logic()
        {
            AllMessages = new List<Message>
            {
                new(new string[] { "привет", "здравствуй", "здравствуйте", "добрый день", "добрый вечер", "доброе утро", "доброй ночи" }, 
                    new string[] { "Привет", "Здравствуйте", "Доброго времени суток" } ),
                new(new string[] { "как тебя зовут?" }, new string[] { "Шарпик", "Меня зовут Шарпик" } ),
                new(new string[] { "анекдот" }, new string[] { "Приходит муж домой, а там жена! ха-ха", "Купил мужик шляпу, а она ему как раз!" } ),
                new(new string[] { "сколько времени?", "который час?" }, new string[] { $"Сейчас {DateTime.Now}" } ),
                new(new string[] { "пока", "до свидания" }, new string[] { "Пока", "До свидания", "Всего хорошего" } ),
                new(new string[] {}, 
                    new string[] {
                        "Если тебе тяжело, значит ты поднимаешься в гору. Если тебе легко, значит ты летишь в пропасть.",
                        "Какое слово скажешь, такое в ответ и услышишь.",
                        "Шутку, как и соль, должно употреблять с умеренностью.",
                        "Не происходит изменений лишь с высшей мудростью и низшей глупостью."
                    }),
            };
        }

        public void GetAnswer(InputMessage q)
        {
            if (!Enable)
            {
                return;
            }
            Random rnd = new();
            for (int i = 0; i < AllMessages.Count; i++)
            {
                if (AllMessages[i].ContainsQuestion(q.ActiveQuestion))
                {
                    ActualAnswer = AllMessages[i].Answer[rnd.Next(AllMessages[i].Answer.Length)];
                    if (i == 4)
                    {
                        Enable = false;
                    }
                    return;
                }
            }
            ActualAnswer = AllMessages.Last().Answer[rnd.Next(AllMessages.Last().Answer.Length)];
        }
    }
}
