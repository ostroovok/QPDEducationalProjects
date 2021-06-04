using System;
using System.Collections.Generic;
using System.Xml;

namespace SharpikLogicXML.Repositories
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

            var xnode = xRoot.GetElementsByTagName("helloPhrases");

            foreach (XmlNode childNode in xnode)
            {
                if (childNode.Name == "answer")
                {
                    List<string> tempList = new();
                    foreach (XmlNode str in childNode.ChildNodes)
                    {
                        tempList.Add(str.InnerText);
                    }
                    _helloPhrases = tempList.ToArray();
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
