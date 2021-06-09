using ChatBotLibrary.Repositories;
using System;
using System.Linq;

namespace ChatBotLibrary
{
    public class Bot
    {
        private readonly Action exitCallback;

        private readonly string[] helloPhrases = new string[] { "привет", "здравствуй", "здравствуйте", "добрый день", "добрый вечер", "доброе утро", "доброй ночи" };
        private readonly string[] byePhrases = new string[] { "пока", "до свидания" };

        private readonly IRepository anecdotesRep;
        private readonly IRepository aphorismsRep;
        private readonly IRepository byePhrasesRep;
        private readonly IRepository helloPhrasesRep;

        public Bot(Action exitCallback)
        {
            this.exitCallback = exitCallback;

            anecdotesRep = new FakeAnecdotesRepository();
            aphorismsRep = new FakeAphorismsRepository();
            byePhrasesRep = new FakeByePhrasesRepository();
            helloPhrasesRep = new FakeHelloPhrasesRepository();
        }

        public string HandleMessage(string message)
        {
            var messageType = GetMessageType(message);

            switch (messageType)
            {
                case MessageType.Hello:
                    return helloPhrasesRep.GetAnswer();
                case MessageType.Bye:
                    exitCallback();
                    return byePhrasesRep.GetAnswer();
                case MessageType.Anecdote:
                    return anecdotesRep.GetAnswer();
                case MessageType.Unknown:
                    return aphorismsRep.GetAnswer();
                case MessageType.Time:
                    return DateTime.Now.ToString("HH:MM");
                case MessageType.Name:
                    return "Шарпик";
                default:
                    throw new Exception("Unknown message type");
            }
        }

        private MessageType GetMessageType(string message)
        {
            if (helloPhrases.Contains(message))
            {
                return MessageType.Hello;
            }
            if (byePhrases.Contains(message))
            {
                return MessageType.Bye;
            }
            if (message.Contains("анекдот"))
            {
                return MessageType.Anecdote;
            }
            if (message == "который час?" || message == "сколько времени?")
            {
                return MessageType.Time;
            }
            if (message == "как тебя зовут?")
            {
                return MessageType.Name;
            }
            return MessageType.Unknown;
        }
    }
}
