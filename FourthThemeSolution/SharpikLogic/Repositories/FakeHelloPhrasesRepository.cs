using System;

namespace SharpikLogic.Repositories
{
    class FakeHelloPhrasesRepository : IRepository
    {
        private string[] _helloPhrases = new string[] { "Привет", "Здравствуйте", "Доброго времени суток" };

        public string GetAnswer()
        {
            Random rnd = new();
            return _helloPhrases[rnd.Next(_helloPhrases.Length)];
        }

    }
}
