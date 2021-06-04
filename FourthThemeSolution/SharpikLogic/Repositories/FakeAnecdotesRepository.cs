using System;

namespace SharpikLogic.Repositories
{
    class FakeAnecdotesRepository : IRepository
    {
        private static string[] _anecdotes = new string[] { "Приходит муж домой, а там жена! ха-ха", "Купил мужик шляпу, а она ему как раз!" };

        public string GetAnswer()
        {
            Random rnd = new();
            return _anecdotes[rnd.Next(_anecdotes.Length)];
        }
    }
}
