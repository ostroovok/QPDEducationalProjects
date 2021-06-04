namespace SharpikLogic
{
    public class InputMessage
    {
        public bool Enable { get; set; } = true;

        private Answer _answer = new();

        public string InputQuestion(string q)
        {
            return _answer.GenerateAnswer(this, q);
        }
    }
}
