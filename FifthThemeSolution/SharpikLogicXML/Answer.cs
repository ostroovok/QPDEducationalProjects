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
        public string ActualAnswer { get; private set; }
        public List<Message> AllMessages { get => _messages; private set => _messages = value;  }

        private List<Message> _messages;
        private int _byePhIndex = 0;

        public Answer()
        {
            _messages = new List<Message>();
            AllMessages.Add(new Message(new string[] { "сколько времени", "Который час" }, new string[] { }));
            LoadAnswersFromFile();
        }

        /// <summary>
        /// Метод, генерирующий ответ
        /// Первым делом проверяет, доступен ли класс InputMessage (св-во Enable переходит в false после сообщения от пользователя "Пока")
        /// Так как ответы в наборах явл. строками, мы не можем добавить туда время изначально, поэтому после проверки,
        ///     ответу на вопрос "Который час?" мы присваиваем значение прямо в этом методе
        /// Если нет, выходит из метода, в противном случае начинает генерировать ответ
        /// Порядок генерации(выборки):
        ///     1. В цикле проверяется корректность сообщения
        ///     2. В случае соответствия одному из содержащийся в списке ответов устанавливает его в св-во ActualAnswer
        ///     3. При совпадении на итерации цикла по номеру равной значению переменной _byePhIndex, метод "выключает" класс сообщения, тк это означает, что было введено "Пока"
        ///                 и возвращает ответ
        ///     4. Если ни один ответ не подходит, отвечает одним из афоризмов, которые лежат в последнем массиве списка всех ответов 
        /// </summary>
        /// <param name="q">Объект класса входящего сообщения</param>
        /// <param name="qMess">Входящее сообщение</param>
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
                    if (i == _byePhIndex)
                    {
                        q.Enable = false;
                    }
                    return;
                }
            }
            ActualAnswer = _messages.Last().Answer[rnd.Next(_messages.Last().Answer.Length)];
        }

        /// <summary>
        /// Метод загрузки вопросов-ответов из XML-файла
        /// В блоке try-catch загружается файл
        /// После запускается цикл, в котором мы пробегаемся по дочерним эл-там корневого эл-та файла
        /// Создаем объект класса Message
        /// Для каждого узла так же запускается цикл, просматривающий его эл-ты, для каждого из которых запускается еще один цикл, достающий значения и добавляющий их в список
        /// На каждой итерации проверяем, есть ли эл-т с атрибутом name="ByePhrases", если да, то записываем его порядоковый номер в переменную _byePhIndex
        /// Перед запуском цикла, достающего значения крайних эл-тов проходит проверка, если имя эл-та "answer". то записываем их как ответы, если "question", то как вопросы
        /// Конвертируем список в массив и присваиваем его значение св-ву Question или Answer класса Message, которые тоже явл. массивами
        /// </summary>
        private void LoadAnswersFromFile()
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

            for (int i = 0; i < xRoot.ChildNodes.Count; i++)
            {
                
                if(xRoot.ChildNodes[i].Attributes.Count > 0)
                {
                    XmlAttribute checkAtr = xRoot.ChildNodes[i].Attributes[0];
                    if (checkAtr.Value.ToLower() == "byephrases")
                    {
                        _byePhIndex = i + 1;
                    }
                }

                Message mess = new();

                foreach (XmlNode childNode in xRoot.ChildNodes[i].ChildNodes)
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