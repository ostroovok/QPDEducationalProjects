using System.Threading;

namespace SharpikLogic
{
    public class InputMessage
    {
        public event Answer.EnteredQuestion EnteredQuestion;
        public bool Enable { get; set; } = true;


        private Answer _message = new();

        public InputMessage()
        {
            EnteredQuestion += _message.GenerateAnswer;
        }

        public string InputQuestion(string q)
        {
            EnteredQuestion?.Invoke(this, q);
            Thread.Sleep(1000);
            return _message.ActualAnswer;
        }
    }
}
