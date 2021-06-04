using SharpikLogicXML.Repositories;
using System;

namespace SharpikLogic
{
    public class Answer
    {
        public string ActualAnswer { get; private set; }

        private FakeAnecdotesRepository _anecdotes = new();
        private FakeAphorismsRepository _aphorims = new();
        private FakeByePhrasesRepository _byePhrases = new();
        private FakeHelloPhrasesRepository _helloPhrases = new();

        public Answer()
        {
            var filePath = "C:\\Users\\e.barkalov\\source\\repos\\SimpleProjects\\FifthThemeSolution\\SharpikLogicXML\\PhrasesXML.xml";
            ActualAnswer = "";
            _anecdotes.Load(filePath);
            _aphorims.Load(filePath);
            _byePhrases.Load(filePath);
            _helloPhrases.Load(filePath);
        }

        public string GenerateAnswer(InputMessage q, string qMess)
        {
            if (_anecdotes.CheckInputQuestionForMatch(qMess))
            {
                return _anecdotes.FindAnswerForQuestion(qMess);
            }
            if (_byePhrases.CheckInputQuestionForMatch(qMess))
            {
                q.Enable = false;
                return _byePhrases.FindAnswerForQuestion(qMess);
            }
            if (_helloPhrases.CheckInputQuestionForMatch(qMess))
            {
                return _helloPhrases.FindAnswerForQuestion(qMess);
            }
            if (qMess.ToLower().Contains("который час") || qMess.ToLower().Contains("сколько времени"))
            {
                return DateTime.Now.ToString("HH:MM");
            }
            if (qMess.ToLower().Contains("как тебя зовут"))
            {
                return "Шарпик";
            }
            return _aphorims.FindAnswerForQuestion();
        }
    }
}