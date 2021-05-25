using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksLogic
{
    public static class NumbersUtils
    {
        public static int CheckInputValue()
        {
            Console.Write("Введите число: ");
            var value = Console.ReadLine();
            int number;
            bool success = int.TryParse(value, out number);
            while (!success)
            {
                Console.WriteLine("Не число!");
                Console.Write("Введите число: ");
                value = Console.ReadLine();
                success = int.TryParse(value, out number);
            }
            return number;
        }
        public static int CheckLimitedInputValue(int max)
        {
            Console.Write("Введите число: ");
            var value = Console.ReadLine();
            int number;
            bool success = int.TryParse(value, out number);
            while (!success || int.Parse(number.ToString().Trim('-')) > max)
            {
                Console.WriteLine("Вы ввели не число, либо число вышло за рамки диапазона [-100, 100]");
                Console.Write("Введите число: ");
                value = Console.ReadLine();
                success = int.TryParse(value, out number);
            }
            return number;
        }
        public static int CheckNegative()
        {
            var temp = CheckInputValue();
            while (temp < 0)
            {
                Console.WriteLine("Не может быть отрицательным!");
                temp = CheckInputValue();
            }
            return temp;
        }
        public static int CheckNegativeOrZero()
        {
            var temp = CheckInputValue();
            while (temp <= 0)
            {
                Console.WriteLine("Не может быть отрицательным или 0!");
                temp = CheckInputValue();
            }
            return temp;
        }
    }
}
