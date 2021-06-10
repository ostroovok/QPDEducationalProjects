using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace ChatBotLibrary.Repositories
{
    class FakeAphorismsRepository : IRepository
    {
        private string[] _aphorisms;

        public string GetAnswer()
        {
            Random rnd = new();
            Load(Directory.GetCurrentDirectory() + "\\PhrasesXML.xml");
            return _aphorisms[rnd.Next(_aphorisms.Length)];
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

            var xnode = xRoot.GetElementsByTagName("aphorisms");

            foreach (XmlNode childNode in xnode[0].ChildNodes)
            {
                if (childNode.Name == "answer")
                {
                    List<string> tempList = new();
                    foreach (XmlNode str in childNode.ChildNodes)
                    {
                        tempList.Add(str.InnerText);
                    }
                    _aphorisms = tempList.ToArray();
                }
            }
        }
    }
}
