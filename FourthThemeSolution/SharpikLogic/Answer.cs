using System;
using System.Collections.Generic;
using System.Linq;

namespace SharpikLogic
{
    public class Answer
    {
        public delegate void EnteredQuestion(InputMessage q, string questionMessage);

        public List<Message> AllMessages { get; private set; }

        public string ActualAnswer { get; private set; }

        public Answer()
        {
            AllMessages = new List<Message>
            {
                new(new string[] { "привет", "здравствуй", "здравствуйте", "добрый день", "добрый вечер", "доброе утро", "доброй ночи" },
                    Phrases.HelloPhrases ),

                new(new string[] { "как тебя зовут?" }, new string[] { "Шарпик" } ),

                new(new string[] { "анекдот" }, Phrases.Anecdotes ),

                new(new string[] { "сколько времени?", "который час?" }, new string[] { "Сейчас " + DateTime.Now.ToString("HH:mm") } ),

                new(new string[] { "пока", "до свидания" }, Phrases.ByePhrases ),

                new(new string[] {}, Phrases.Aphorisms),
            };
        }
        /// <summary>
        /// Метод, генерирующий ответ
        /// Первым делом проверяет, доступен ли класс InputMessage (св-во Enable переходит в false после сообщения от пользователя "Пока")
        /// Если нет, выходит из метода, в противном случае начинает генерировать ответ
        /// Порядок генерации(выборки):
        ///     1. В цикле проверяется корректность сообщения
        ///     2. В случае соответствия одному из содержащийся в списке ответов устанавливает его в св-во ActualAnswer
        ///     3. При совпадении на 5 итерации цикла "выключает" класс сообщения, тк это означает, что было введено "Пока"
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
            for (int i = 0; i < AllMessages.Count; i++)
            {
                if (AllMessages[i].ContainsQuestion(qMess))
                {
                    ActualAnswer = AllMessages[i].Answer[rnd.Next(AllMessages[i].Answer.Length)];
                    if (i == 4)
                    {
                        q.Enable = false;
                    }
                    return;
                }
            }
            ActualAnswer = AllMessages.Last().Answer[rnd.Next(AllMessages.Last().Answer.Length)];
        }
    }
}
