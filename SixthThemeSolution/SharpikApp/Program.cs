using SharpikLogic;
using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace SharpikTestApp
{
    class Program
    {

        private static bool isRunning = true;
        private static ConcurrentQueue<string> messagesQueue = new();
        static void Main(string[] args)
        {
            Console.WriteLine("Для начала диалога введите сообщение:");

            Task.Run(() => Start());

            while (isRunning)
            {
                var str = Console.ReadLine().Trim().ToLower();
                messagesQueue.Enqueue(str);
            }
        }

        private static void Start()
        {
            var bot = new Bot(ExitCallback);
            while (isRunning)
            {
                if (messagesQueue.TryDequeue(out var message))
                {
                    Console.WriteLine(bot.HandleMessage(message));
                }
                Thread.Sleep(10);
            }
        }

        private static void ExitCallback()
        {
            isRunning = false;
        }
    }
}
