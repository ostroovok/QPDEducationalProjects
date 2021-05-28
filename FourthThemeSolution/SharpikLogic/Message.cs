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
            for (int i = 0; i < Question.Length; i++)
            {
                mess = mess.ToLower();
                if (mess.Contains(Question[i]))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
