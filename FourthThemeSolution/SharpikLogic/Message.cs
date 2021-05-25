using System;
using System.Collections.Generic;
using System.Linq;

namespace SharpikLogic
{
    public class Message
    {
        public string[] Question { get; }
        public string[] Answer { get; }

        public Message(string[] question, string[] answer)
        {
            Question = question;
            Answer = answer;
        }
        public bool ContainsQuestion(string mess)
        {
            return Question.Contains(mess.ToLower());
        }
    }
}
