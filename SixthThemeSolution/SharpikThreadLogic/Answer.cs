using SharpikLogic.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Xml;

namespace SharpikLogic
{
    public class Answer
    {
        public string ActualAnswer { get; private set; }

        private FakeAnecdotesRepository _anecdotes;
        private FakeAphorismsRepository _aphorims;
        private FakeByePhrasesRepository _byePhrases;
        private FakeHelloPhrasesRepository _helloPhrases;

        public Answer()
        {
            ActualAnswer = "";
            _anecdotes = new();
            _aphorims = new();
            _byePhrases = new();
            _helloPhrases = new();
        }

        public string GenerateAnswer(InputMessage q, string qMess)
        {
            Thread.Sleep(1000);
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
                return "Сейчас " + DateTime.Now.ToString("HH:MM");
            }
            if (qMess.ToLower().Contains("как тебя зовут"))
            {
                return "Шарпик";
            }
            return _aphorims.FindAnswerForQuestion();
        }
    }
}