using System;

namespace SharpikLogic.Repositories
{
    class FakeAphorismsRepository : IRepository
    {
        private string[] _aphorisms = new string[] {
                        "Если тебе тяжело, значит ты поднимаешься в гору. Если тебе легко, значит ты летишь в пропасть.",
                        "Какое слово скажешь, такое в ответ и услышишь.",
                        "Шутку, как и соль, должно употреблять с умеренностью.",
                        "Не происходит изменений лишь с высшей мудростью и низшей глупостью."
                    };

        public string GetAnswer()
        {
            Random rnd = new();
            return _aphorisms[rnd.Next(_aphorisms.Length)];
        }
    }
}
