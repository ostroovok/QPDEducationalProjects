using System;
using TasksLogic;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    public static class RowsProgram
    {
        private static bool _exit = true;
        public static void Start()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Введите номер задачи (от 1 до 7)");
                Console.Write("-->\t");
                var number = Console.ReadLine();
                int temp;
                switch (number)
                {

                    case "1":
                        Console.WriteLine("Введите верхнюю границу для третьего ряда: ");
                        var num = NumbersUtils.CheckNegativeOrZero();
                        Console.WriteLine(Rows.TheSumOfTheSeries(50, 1, 1));
                        Console.WriteLine(Rows.VariableSeriesSum(50, 2, false, 2));
                        Console.WriteLine(Rows.VariableSeriesSum(num, 2, true, 1));
                        break;

                    case "2":
                        Console.WriteLine("Посчитать сумму ряда. Сколько слагаемых?");
                        Console.WriteLine(Rows.TheSumOfTheSeries(46, 4, 6));
                        Console.WriteLine(Rows.Count);
                        break;

                    case "3":
                        Console.WriteLine("Посчитать сумму ряда, всего 10 слагаемых");
                        Console.WriteLine(Rows.SumWithLimitedNumberOfTerms(10, 4, 6));
                        Console.WriteLine(Rows.Count);
                        break;

                    case "4":
                        Console.WriteLine("Посчитать сумму ряда, всего 11 слагаемых");
                        Console.WriteLine(Rows.IncreasingSumWithLimitedNumberOfTerms(11, 1, 1));
                        Console.WriteLine(Rows.Count);
                        break;

                    case "5":
                        Console.WriteLine("Посчитать сумму ряда. Остановиться, когда сумма превысит 100. Сколько слагаемых?");
                        Console.WriteLine(Rows.LimitedSum(100, 4, 6, true));
                        Console.WriteLine(Rows.Count);
                        break;

                    case "6":
                        Console.WriteLine("Посчитать сумму ряда. последнюю, которая еще не превышает 100. Сколько слагаемых?");
                        Console.WriteLine(Rows.LimitedSum(100, 4, 6, false));
                        Console.WriteLine(Rows.Count);
                        break;

                    case "7":
                        Console.WriteLine("Фибоначчи. Подсчет вплоть до: ");
                        num = NumbersUtils.CheckNegativeOrZero();
                        Console.WriteLine(Rows.Fibonacci(num));
                        break;
                    default:
                        Console.WriteLine("Такого варианта нет в списке \n Нажмите любую клавишу для продолжения");
                        break;

                }
                Console.ReadLine();
            }
        }
    }
}
