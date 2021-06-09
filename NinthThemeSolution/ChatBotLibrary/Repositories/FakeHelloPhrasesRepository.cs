using System;
using System.Collections.Generic;
using System.Xml;

namespace ChatBotLibrary.Repositories
{
    class FakeHelloPhrasesRepository : IRepository
    {
        private string[] _helloPhrases = new string[] { "Привет", "Здравствуйте", "Доброго времени суток" };

        public string GetAnswer()
        {
            Random rnd = new();
            Load("C:\\Users\\e.barkalov\\source\\repos\\SimpleProjects\\FifthThemeSolution\\SharpikLogicXML\\PhrasesXML.xml");
            return _helloPhrases[rnd.Next(_helloPhrases.Length)];
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
            }
        }
    }
}
