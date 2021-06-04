using System;
using System.Collections.Generic;
using System.Xml;

namespace SharpikLogicXML.Repositories
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

            var xnode = xRoot.GetElementsByTagName("byePhrases");

            foreach (XmlNode childNode in xnode)
            {
                if (childNode.Name == "answer")
                {
                    List<string> tempList = new();
                    foreach (XmlNode str in childNode.ChildNodes)
                    {
                        tempList.Add(str.InnerText);
                    }
                    _byePhrases = tempList.ToArray();
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
