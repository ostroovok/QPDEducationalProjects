using System;
using System.Collections.Generic;
using System.Xml;

namespace SharpikLogicXML.Repositories
{
    class FakeAphorismsRepository : IRepository
    {
        private string[] _aphorisms = new string[] {
                        "Если тебе тяжело, значит ты поднимаешься в гору. Если тебе легко, значит ты летишь в пропасть.",
                        "Какое слово скажешь, такое в ответ и услышишь.",
                        "Шутку, как и соль, должно употреблять с умеренностью.",
                        "Не происходит изменений лишь с высшей мудростью и низшей глупостью."
                    };

        public string GetAnswer()
        {
            Random rnd = new();
            Load("C:\\Users\\e.barkalov\\source\\repos\\SimpleProjects\\FifthThemeSolution\\SharpikLogicXML\\PhrasesXML.xml");
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

            foreach (XmlNode childNode in xnode)
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
