namespace SharpikLogic
{
    public static class Phrases
    {
        private static string[] _helloPhrases = new string[] { "Привет", "Здравствуйте", "Доброго времени суток" };
        private static string[] _anecdotes = new string[] { "Приходит муж домой, а там жена! ха-ха", "Купил мужик шляпу, а она ему как раз!" };
        private static string[] _aphorisms = new string[] {
                        "Если тебе тяжело, значит ты поднимаешься в гору. Если тебе легко, значит ты летишь в пропасть.",
                        "Какое слово скажешь, такое в ответ и услышишь.",
                        "Шутку, как и соль, должно употреблять с умеренностью.",
                        "Не происходит изменений лишь с высшей мудростью и низшей глупостью."
                    };
        private static string[] _byePhrases = new string[] { "Пока", "До свидания", "Всего хорошего" };

        public static string[] HelloPhrases { get => _helloPhrases; }
        public static string[] Aphorisms { get => _aphorisms; }
        public static string[] ByePhrases { get => _byePhrases; }
        public static string[] Anecdotes { get => _anecdotes; }
    }
}
