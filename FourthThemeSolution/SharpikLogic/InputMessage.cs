using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpikLogic
{
    public class InputMessage
    {
        public event Answer.EnteredQuestion EnteredQuestion;
        public bool Enable { get => _message.Enable; set => _message.Enable = value; }
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
