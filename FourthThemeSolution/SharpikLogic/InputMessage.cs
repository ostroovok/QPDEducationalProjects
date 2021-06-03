namespace SharpikLogic
{
    public class InputMessage
    {
        public bool Enable { get; set; } = true;

        private Answer _message = new();

        public string InputQuestion(string q)
        {
            return _message.GenerateAnswer(this, q);
        }
    }
}
