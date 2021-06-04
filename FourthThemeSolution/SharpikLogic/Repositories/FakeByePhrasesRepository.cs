using System;

namespace SharpikLogic.Repositories
{
    class FakeByePhrasesRepository : IRepository
    {
        private static string[] _byePhrases = new string[] { "Пока", "До свидания", "Всего хорошего" };

        public string GetAnswer()
        {
            Random rnd = new();
            return _byePhrases[rnd.Next(_byePhrases.Length)];
        }
    }
}
