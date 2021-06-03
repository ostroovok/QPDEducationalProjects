using System;

namespace SharpikLogic.Repositories
{
    class FakeByePhrasesRepository : IByePhrasesRepository
    {
        private static string[] _byePhrases = new string[] { "Пока", "До свидания", "Всего хорошего" };

        private string[] _triggerPhrases = new string[] { "пока", "до свидания" };
        public static string[] ByePhrases { get => _byePhrases; }

        public string FindAnswerForQuestion(string question)
        {
            if (!CheckInputQuestionForMatch(question))
            {
                return "";
            }
            Random rnd = new();
            return _byePhrases[rnd.Next(_byePhrases.Length)];
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
