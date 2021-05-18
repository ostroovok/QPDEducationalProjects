using System;
using TasksLogic;

namespace TestApp
{
    public static class NumbersProgram
    {
        public static void Start()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1 : 2 : 3 : 4");
                Console.Write("-->\t");
                var number = CheckInput();
                if (number == -1)
                    break;
                switch (number)
                {
                    case 1:
                        First(CheckInput());
                        break;
                    case 2:
                        Second(CheckInput());
                        break;
                    case 3:
                        Third();
                        break;
                    case 4:
                        Fourth();
                        break;
                    default:
                        Console.WriteLine("Такого варианта нет в списке \n Нажмите любую клавишу");
                        break;
                }
                Console.ReadLine();
            }
        }
        public static int CheckInput()
        {
            var value = Console.ReadLine();
            if (value.ToLower() == "stop")
                return -1;
            int number;
            bool success = int.TryParse(value, out number);
            while (!success)
            {
                Console.WriteLine("Не число!");
                value = Console.ReadLine();
                success = int.TryParse(value, out number);
            }
            return number;
        }

        #region Private Methods
        private static void Fourth()
        {
            var count = 0;
            var oddCount = 0;
            var first = 0;
            var second = 0;
            var third = 0;
            Console.Write("n: ");
            var n = CheckInput();
            while (count < n)
            {
                var t = CheckInput();
                if (t % 2 != 0)
                {
                    switch(oddCount % 3)
                    {
                        case 0:
                            third = t;
                            break;
                        case 2:
                            second = t;
                            break;
                        case 1:
                            first = t;
                            break;
                    }
                    oddCount ++;
                }
                count++;
            }
            Console.WriteLine($"Sum: {first + second + third}");
        }

        private static void Third()
        {
            var count = 0;
            var oddCount = 0;
            var sum = 0;
            Console.Write("n: ");
            var n = CheckInput();
            while (count < n)
            {
                var t = CheckInput();
                if (t % 2 != 0 && oddCount < 3)
                {
                    sum += t;
                    oddCount++;
                }
                count++;
            }
            Console.WriteLine($"Sum: {sum}");
        }

        private static void Second(int number)
        {
            var result = 0;
            var maxValue = int.MinValue;
            var temp = Numbers.SumRank(number);
            while (temp != 0)
            {
                var toMethod = CheckInput();
                temp = Numbers.SumRank(toMethod);
                if (temp > maxValue)
                {
                    maxValue = temp;
                    result = toMethod;
                }
            }
            Console.WriteLine($"----------{result}----------");
        }
        private static void First(int number)
        {
            if (number < 100 && number > 999)
                Console.WriteLine("Введенное число не соответствует условиям задачи");
            else
                Console.WriteLine($"First: {TasksLogic.Numbers.SumRank(number)}");
        }
        #endregion  
    }
}
