using System;

namespace SharpikLogic.Repositories
{
    class FakeHelloPhrasesRepository : IHelloPhrasesRepository
    {
        private string[] _helloPhrases = new string[] { "Привет", "Здравствуйте", "Доброго времени суток" };

        private string[] _triggerPhrases = new string[] { "привет", "здравствуй", "здравствуйте", "добрый день", "добрый вечер", "доброе утро", "доброй ночи" };
        public string[] HelloPhrases { get => _helloPhrases; }

        public string FindAnswerForQuestion(string question)
        {
            if (!CheckInputQuestionForMatch(question))
            {
                return "";
            }
            Random rnd = new();
            return _helloPhrases[rnd.Next(_helloPhrases.Length)];
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
