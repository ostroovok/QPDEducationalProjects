using System;
using System.Threading;

namespace SixthThemeLogic
{
    public class FirstTask
    {
        private static int _number;
        private static object _locker = new object();
        public static void Start()
        {
            for (int i = 0; i < 5; i++)
            {
                Thread tthread = new Thread(Count);
                tthread.Name = $"thread #{i}";
                tthread.Start();
            }
            Console.ReadLine();
        }
        private static void Count()
        {
            lock (_locker)
            {
                _number = 1;
                for (int i = 0; i < 9; i++)
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name} - {_number}");
                    _number++;
                    Thread.Sleep(100);
                }
            }
        }
    }
}
