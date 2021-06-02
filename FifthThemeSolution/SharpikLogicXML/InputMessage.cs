namespace SharpikLogic
{
    public class InputMessage
    {
        public event Answer.EnteredQuestion EnteredQuestion;
        public bool Enable { get; set; } = true;
        public string ActiveQuestion { get; set; }


        private Answer _message = new();

        public InputMessage()
        {
            EnteredQuestion += _message.GenerateAnswer;
        }

        public string InputQuestion(string q)
        {
            EnteredQuestion?.Invoke(this, q);
            return _message.ActualAnswer;
        }
    }
}
