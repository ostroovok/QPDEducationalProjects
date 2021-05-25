using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpikLogic
{
    public class InputMessage
    {
        public event Logic.EnteredQuestion EnteredQuestion;
        public bool Enable { get => _message.Enable; set => _message.Enable = value; }
        public string ActiveQuestion { get; set; }


        private Logic _message = new();

        public InputMessage()
        {
            EnteredQuestion += _message.GetAnswer;
        }

        public string InputQuestion(string q)
        {
            ActiveQuestion = q;
            EnteredQuestion?.Invoke(this);
            return _message.ActualAnswer;
        }
    }
}
