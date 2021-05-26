using System;
using System.Collections.Generic;
using TasksLogic;
using TestApp;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {     
            Console.Clear();
            Console.WriteLine("Выберите номер задачи:\nБЛОК 1 \n\t1. Числа \n\t2. Фигуры \n\t3. Ряды \n\t4. Массивы\n\t5. Строки" +
                "\n\n");
            int num = NumbersUtils.CheckInputValue();
            switch (num)
            {
                case 1:
                    NumbersProgram.Start();
                    break;
                case 2:
                    FiguresProgram.Start();
                    break;
                case 3:
                    RowsProgram.Start();
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
       
    }
}
