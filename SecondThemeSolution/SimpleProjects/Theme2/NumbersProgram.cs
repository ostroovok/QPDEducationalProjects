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
                Console.WriteLine("Введите номер задачи (от 1 до 4)");
                Console.Write("-->\t");
                var number = NumbersUtils.CheckInputValue();
                if (number == -1)
                    break;
                switch (number)
                {
                    case 1:
                        Console.WriteLine("Введите трехзначное число для подсчета суммы цифр:  ");
                        FirstTask(NumbersUtils.CheckInputValue());
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
        

        #region Private Methods
        private static void FourthTask()
        {
            var count = 0;
            var oddCount = 0;
            var first = 0;
            var second = 0;
            var third = 0;
            Console.Write("Количество чисел: \n");
            var n = NumbersUtils.CheckNegativeOrZero();
            Console.WriteLine("Отлично! Теперь введите числа: \n");
            while (count < n)
            {
                var t = NumbersUtils.CheckInputValue();
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
            Console.Write("Количество чисел: \n");
            var n = NumbersUtils.CheckNegativeOrZero();
            Console.WriteLine("Отлично! Теперь введите числа: \n");

            while (count < n)
            {
                var t = NumbersUtils.CheckInputValue();
                if (t % 2 != 0 && oddCount < 3)
                {
                    sum += t;
                    oddCount++;
                }
                count++;
            }
            Console.WriteLine($"Сумма первых 3-х нечетных: {sum}");
        }

        private static void SecondTask() // ---- 
        {
            Console.WriteLine(" 0 - Выход");
            var result = 0;
            var maxValue = int.MinValue;
            var number = -1;
            while (number != 0)
            {
                number = NumbersUtils.CheckInputValue();

                var temp = Numbers.TheSumOfTheDigits(number);
                if (temp > maxValue)
                {
                    result = number;
                    maxValue = temp;
                }
            }
            Console.WriteLine($"Число с максимальной суммой цифр в нем: {result}");
        }
        private static void FirstTask(int number)
        {
            while (Math.Abs(number) < 100 || Math.Abs(number) > 999)
            {
                Console.WriteLine("Введенное число не соответствует условиям задачи");
                number = NumbersUtils.CheckInputValue();
            }
            Console.WriteLine($"Вывод: {Numbers.TheSumOfTheDigits(number)}");
        }
        #endregion  
    }
}
