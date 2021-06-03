using System;

namespace SharpikLogic.Repositories
{
    class FakeAnecdotesRepository : IAnecdotesRepository
    {
        private static string[] _anecdotes = new string[] { "Приходит муж домой, а там жена! ха-ха", "Купил мужик шляпу, а она ему как раз!" };

        private string[] _triggerPhrases = new string[] { "анекдот" };
        public static string[] Anecdotes { get => _anecdotes; }

        public string FindAnswerForQuestion(string question)
        {
            if (!CheckInputQuestionForMatch(question))
            {
                return "";
            }
            Random rnd = new();
            return _anecdotes[rnd.Next(_anecdotes.Length)];
        }

        public bool CheckInputQuestionForMatch(string question)
        {
            for (int i = 0; i < _triggerPhrases.Length; i++)
            {
                question = question.ToLower();
                if (question.Contains(_triggerPhrases[i]))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
