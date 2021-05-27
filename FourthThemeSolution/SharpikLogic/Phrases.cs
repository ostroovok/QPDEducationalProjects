using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpikLogic
{
    public static class Phrases
    {
        public static string[] HelloPhrases { get => new string[] { "Привет", "Здравствуйте", "Доброго времени суток" }; }
        public static string[] Aphorisms { get => new string[] {
                        "Если тебе тяжело, значит ты поднимаешься в гору. Если тебе легко, значит ты летишь в пропасть.",
                        "Какое слово скажешь, такое в ответ и услышишь.",
                        "Шутку, как и соль, должно употреблять с умеренностью.",
                        "Не происходит изменений лишь с высшей мудростью и низшей глупостью."
                    }; }
        public static string[] ByePhrases { get => new string[] { "Пока", "До свидания", "Всего хорошего" }; } 
        public static string[] Anecdotes { get => new string[] { "Приходит муж домой, а там жена! ха-ха", "Купил мужик шляпу, а она ему как раз!" }; } 

        public static void Generate()
        {
            
        }
    }
}
