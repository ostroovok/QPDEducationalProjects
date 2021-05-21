using System;
using TasksLogic.Theme2;

namespace TestApp
{
    public static class NumbersProgram
    {
        public static void Start()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Введите номер задачи (от 1 до 4) \t stop - Выход");
                Console.Write("-->\t");
                var number = CheckInputValue();
                if (number == -1)
                    break;
                switch (number)
                {
                    case 1:
                        Console.WriteLine("Введите трехзначное число для подсчета суммы цифр:  ");
                        FirstTask(CheckInputValue());
                        break;
                    case 2:
                        SecondTask();
                        break;
                    case 3:
                        ThirdTask();
                        break;
                    case 4:
                        FourthTask();
                        break;
                    default:
                        Console.WriteLine("Такого варианта нет в списке \nНажмите любую клавишу для продолжения");
                        break;
                }
                Console.ReadLine();
            }
        }
        public static int CheckInputValue()
        {
            var value = Console.ReadLine();
            if (value.ToLower() == "stop")
                Start();
            int number;
            bool success = int.TryParse(value, out number);
            while (!success)
            {
                Console.WriteLine("Не число!");
                value = Console.ReadLine();
                if (value.ToLower() == "stop")
                    Start();
                success = int.TryParse(value, out number);
            }
            return number;
        }

        #region Private Methods
        private static void FourthTask()
        {
            var count = 0;
            var oddCount = 0;
            var first = 0;
            var second = 0;
            var third = 0;
            Console.Write("Количество чисел: ");
            var n = CheckInputValue();
            Console.WriteLine("Введите числа: ");
            
            while (count < n)
            {
                var t = CheckInputValue();
                if (t % 2 != 0)
                {
                    switch (oddCount % 3)
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
                    oddCount++;
                }
                count++;
            }
            Console.WriteLine($"Сумма последних 3-х нечетных: {first + second + third}");
        }

        private static void ThirdTask()
        {
            var count = 0;
            var oddCount = 0;
            var sum = 0;
            Console.Write("Количество чисел: ");
            var n = CheckInputValue();
            while (n < 0)
            {
                Console.WriteLine("Количество не может быть отрицательным!");
                Console.Write("Введите еще раз: ");
                n = CheckInputValue();
            }
            Console.WriteLine("Введите числа: ");
            while (count < n)
            {
                var t = CheckInputValue();
                if (t % 2 != 0 && oddCount < 3)
                {
                    sum += t;
                    oddCount++;
                }
                count++;
            }
            Console.WriteLine($"Сумма первых 3-х нечетных: {sum}");
        }

        private static void SecondTask()
        {
            Console.WriteLine(" 0 - Выход");
            Console.Write("Введите число: ");
            var result = 0;
            var maxValue = int.MinValue;
            var number = CheckInputValue();
            while (number < 0)
            {
                Console.WriteLine("Количество не может быть отрицательным!");
                Console.Write("Введите еще раз: ");
                number = CheckInputValue();
            }
            number = Numbers.TheSumOfTheDigits(number);
            while (number != 0)
            {
                Console.Write("Введите число: ");
                var toMethod = CheckInputValue();
                number = Numbers.TheSumOfTheDigits(toMethod);
                if (number > maxValue)
                {
                    maxValue = number;
                    result = toMethod;
                }
            }
            Console.WriteLine($"Число с максимальной суммой цифр в нем: {result}");
        }
        private static void FirstTask(int number)
        {
            if (Math.Abs(number) < 100 || Math.Abs(number) > 999)
                Console.WriteLine("Введенное число не соответствует условиям задачи");
            else
                Console.WriteLine($"Вывод: {Numbers.TheSumOfTheDigits(number)}");
        }
        #endregion  
    }
}
