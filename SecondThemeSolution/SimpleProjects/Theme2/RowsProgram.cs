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
                switch (number)
                {

                    case "1":
                        Console.WriteLine("Введите верхнюю границу для третьего ряда: ");
                        var num = NumbersUtils.CheckNegativeOrZero();
                        Console.WriteLine(Rows.SeriesModifiedSum(50, 1, 1));
                        Console.WriteLine(Rows.SeriesModifiedSum(50, 2, 2));
                        Console.WriteLine(Rows.SeriesModifiedSum(num, 1, 2));
                        break;

                    case "2":
                        Console.WriteLine("Посчитать сумму ряда. Сколько слагаемых?");
                        var temp = Rows.SeriesSumTerms(46, 6, 4);
                        Console.WriteLine("Сумма: " + temp[0]);
                        Console.WriteLine("Кол-во слагаемых: " + temp[1]);
                        break;

                    case "3":
                        Console.WriteLine("Посчитать сумму ряда, всего 10 слагаемых");
                        temp = Rows.SumWithLimitedNumberOfTerms(10, 4, 6);
                        Console.WriteLine("Сумма: " + temp[0]);
                        Console.WriteLine("Кол-во слагаемых: " + temp[1]);
                        break;

                    case "4":
                        Console.WriteLine("Посчитать сумму ряда, всего 11 слагаемых");
                        temp = Rows.IncreasingSumWithLimitedNumberOfTerms(11, 1, 1);
                        Console.WriteLine("Сумма: " + temp[0]);
                        Console.WriteLine("Кол-во слагаемых: " + temp[1]);
                        break;

                    case "5":
                        Console.WriteLine("Посчитать сумму ряда. Остановиться, когда сумма превысит 100. Сколько слагаемых?");
                        temp = Rows.LimitedSum(100, 4, 6, true);
                        Console.WriteLine("Сумма: " + temp[0]);
                        Console.WriteLine("Кол-во слагаемых: " + temp[1]);
                        break;

                    case "6":
                        Console.WriteLine("Посчитать сумму ряда. последнюю, которая еще не превышает 100. Сколько слагаемых?");
                        temp = Rows.LimitedSum(100, 4, 6, false);
                        Console.WriteLine("Сумма: " + temp[0]);
                        Console.WriteLine("Кол-во слагаемых: " + temp[1]);
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
