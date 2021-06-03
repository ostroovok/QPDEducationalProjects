namespace SharpikLogic
{
    public class Message
    {
        public string[] Question { get; set; }
        public string[] Answer { get; set; }

        public Message(string[] question, string[] answer)
        {
            Question = question;
            Answer = answer;
        }

        public Message()
        {
        }

        public bool ContainsQuestion(string mess)
        {
            for (int i = 0; i < Question.Length; i++)
            {
                mess = mess.ToLower();
                if (mess.Contains(Question[i].ToLower()))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
