using System;
using SharpikLogic;

namespace SharpikTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            InputMessage mess = new InputMessage();
            Console.WriteLine("Для начала диалога введите сообщение:");
            while (true)
            {

                var temp = mess.InputQuestion(Console.ReadLine());

                Console.WriteLine(temp);

                if (!mess.Enable)
                {
                    break;
                }
            }
        }
    }
}
