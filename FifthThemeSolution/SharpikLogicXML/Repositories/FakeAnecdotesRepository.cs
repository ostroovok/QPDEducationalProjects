using System;
using System.Collections.Generic;
using System.Xml;

namespace SharpikLogicXML.Repositories
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

        public void Load(string fileName)
        {
            XmlDocument xDoc = new();

            try
            {
                xDoc.Load(fileName);
            }
            catch (Exception ex)
            {
                throw new Exception($"Загрузочный файл не найден, текст ошибки: {ex.Message}");
            }

            XmlElement xRoot = xDoc.DocumentElement;

            var xnode = xRoot.GetElementsByTagName("anecdotes");

            foreach (XmlNode childNode in xnode)
            {
                if (childNode.Name == "answer")
                {
                    List<string> tempList = new();
                    foreach (XmlNode str in childNode.ChildNodes)
                    {
                        tempList.Add(str.InnerText);
                    }
                    _anecdotes = tempList.ToArray();
                }
                if (childNode.Name == "question")
                {
                    List<string> tempList = new();
                    foreach (XmlNode str in childNode.ChildNodes)
                    {
                        tempList.Add(str.InnerText);
                    }
                    _triggerPhrases = tempList.ToArray();
                }
            }
        }
    }
}
