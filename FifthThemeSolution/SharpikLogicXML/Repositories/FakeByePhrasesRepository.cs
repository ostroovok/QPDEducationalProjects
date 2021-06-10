using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace SharpikLogicXML.Repositories
{
    class FakeByePhrasesRepository : IRepository
    {
        private static string[] _byePhrases;

        public string GetAnswer()
        {
            Random rnd = new();
            Load(Directory.GetCurrentDirectory() + "\\PhrasesXML.xml");
            //Load("C:\\Users\\e.barkalov\\source\\repos\\SimpleProjects\\FifthThemeSolution\\SharpikLogicXML\\PhrasesXML.xml");
            return _byePhrases[rnd.Next(_byePhrases.Length)];
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

            foreach (XmlNode childNode in xnode[0].ChildNodes)
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
            }
        }
    }
}
