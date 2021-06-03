using SharpikLogic;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SharpikTestApp
{
    class Program
    {
        static bool _exit = false;
        static void Main(string[] args)
        {
            InputMessage mess = new();
            Console.WriteLine("Для начала диалога введите сообщение:");

            while (true)
            {
                if (!mess.Enable)
                {
                    break;
                }

                var inputStr = Console.ReadLine();

                Task.Run(() =>
                    Console.WriteLine(mess.InputQuestion(inputStr)));

            }
        }
    }
}
