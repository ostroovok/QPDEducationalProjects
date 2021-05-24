using System;
using System.Collections.Generic;
using TasksLogic;
using TestApp.Theme2;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {     
            Console.Clear();
            Console.WriteLine("Выберите номер задачи:\nБЛОК 1 \n\t1. Числа \n\t2. Фигуры \n\t3. Ряды \n\t4.Массивы\n\t5. Строки" +
                "\nБЛОК 2\n\n");
            int num = CheckInputValue();
            switch (num)
            {
                case 1:
                    NumbersProgram.Start();
                    break;
                case 2:
                    FiguresProgram.Start();
                    break;
                case 3:
                    RowsMethod();
                    break;
                case 4:
                    ArrayProgram.Start();
                    break;
                case 5:
                    StringProgram.Start();
                    break;
                default:
                    Console.WriteLine("Введенного значение нет в списке");
                    break;
            }
        }
        public static void RowsMethod()
        {
            Console.Clear();
            Console.WriteLine("\tЗадача #6");
            Console.WriteLine(Rows.TheSumOfTheSeries(50, 1, 1));
            Console.WriteLine(Rows.VariableSeriesSum(50, 2, false, 2));
            Console.WriteLine(Rows.VariableSeriesSum(50, 2, true, 1));
            Console.WriteLine("\tЗадача #7");
            Console.WriteLine(Rows.TheSumOfTheSeries(46, 4, 6));
            Console.WriteLine(Rows.Count);
            Console.WriteLine("\tЗадача #8");
            Console.WriteLine(Rows.SumWithLimitedNumberOfTerms(10, 4, 6));
            Console.WriteLine(Rows.Count);
            Console.WriteLine("\tЗадача #9");
            Console.WriteLine(Rows.SumWithLimitedNumberOfTerms(11, 2, 1));
            Console.WriteLine(Rows.Count);
            Console.WriteLine("\tЗадача #10");
            Console.WriteLine(Rows.LimitedSum(100, 4, 6));
            Console.WriteLine(Rows.Count);
            Console.WriteLine("\tЗадача #11");
            Console.WriteLine(Rows.LimitedSum(100, 4, 6, true));
            Console.WriteLine(Rows.Count);
            Console.WriteLine("\tЗадача #12");
            Console.WriteLine(Rows.Fibonacci(3));
        }
        public static int CheckInputValue()
        {
            var value = Console.ReadLine();
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
    }
}
