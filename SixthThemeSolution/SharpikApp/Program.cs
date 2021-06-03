using SharpikLogic;
using System;
using System.Threading;
using System.Threading.Tasks;

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
                var inputStr = Console.ReadLine();
                Console.WriteLine(Task.Run(() => mess.InputQuestion(inputStr)).Result);

                if (!mess.Enable)
                {
                    break;
                }
            }
        }
    }
}
