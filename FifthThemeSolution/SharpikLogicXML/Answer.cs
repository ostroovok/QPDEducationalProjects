using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace SharpikLogic
{
    public class Answer
    {
        public delegate void EnteredQuestion(InputMessage q, string questionMessage);

        public bool Enable { get; set; } = true;
        public List<Message> AllMessages { get => _messages; private set => _messages = value;  }
        private List<Message> _messages;

        public string ActualAnswer { get; private set; }

        public Answer()
        {
            _messages = new List<Message>();
            AllMessages.Add(new Message(new string[] { "сколько времени", "Который час" }, new string[] { }));
            CreateAnswers();
        }

        public void GenerateAnswer(InputMessage q, string qMess)
        {
            if (!q.Enable)
            {
                return;
            }

            Random rnd = new();

            AllMessages.First().Answer = new string[] { "Сейчас " + DateTime.Now.ToString("HH:mm") };

            for (int i = 0; i < _messages.Count; i++)
            {
                if (_messages[i].ContainsQuestion(qMess))
                {
                    ActualAnswer = _messages[i].Answer[rnd.Next(_messages[i].Answer.Length)];
                    if (i == 2)
                    {
                        q.Enable = false;
                    }
                    return;
                }
            }
            ActualAnswer = _messages.Last().Answer[rnd.Next(_messages.Last().Answer.Length)];
        }

        private void CreateAnswers()
        {
            
            var fileName = "C:\\Users\\e.barkalov\\source\\repos\\SimpleProjects\\FifthThemeSolution\\SharpikLogicXML\\PhrasesXML.xml";

            XmlDocument xDoc = new();

            try
            {
                xDoc.Load(fileName);
            }
            catch(Exception ex)
            {
                throw new Exception($"Загрузочный файл не найден, текст ошибки: {ex.Message}");
            }

            XmlElement xRoot = xDoc.DocumentElement;

            foreach (XmlNode xnode in xRoot)
            {
                Message mess = new();

                foreach (XmlNode childNode in xnode.ChildNodes)
                {
                    if (childNode.Name == "answer")
                    {
                        List<string> tempList = new();
                        foreach (XmlNode str in childNode.ChildNodes)
                        {
                            tempList.Add(str.InnerText);
                        }
                        mess.Answer = tempList.ToArray();
                    }
                    if (childNode.Name == "question")
                    {
                        List<string> tempList = new();
                        foreach (XmlNode str in childNode.ChildNodes)
                        {
                            tempList.Add(str.InnerText);
                        }
                        mess.Question = tempList.ToArray();
                    }
                }
                AllMessages.Add(mess);
            }
        }
    }
}