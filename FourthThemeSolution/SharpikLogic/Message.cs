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
        /// <summary>
        /// Проверяет входящее сообщение с содержащимися в св-ве Question, в случае, если
        /// пришедшее содержится в массиве, то возвращает true, иначе false
        /// </summary>
        /// <param name="mess">Входящее сообщение</param>
        /// <returns>Результат проверки</returns>
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
