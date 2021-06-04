using SharpikLogic;
using System;

namespace SharpikTestApp
{
    class Program
    {
        private static bool isRunning = true;
        static void Main(string[] args)
        {
            var bot = new Bot(ExitCallback);

            Console.WriteLine("Для начала диалога введите сообщение:");

            while (isRunning)
            {
                var message = Console.ReadLine().Trim().ToLower();
                Console.WriteLine(bot.HandleMessage(message));
            }
        }

        private static void ExitCallback()
        {
            isRunning = false;
        }
    }
}
