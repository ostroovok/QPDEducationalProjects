using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TasksLogic.Theme4;

namespace TestApp.Theme4
{
    public static class CalculatorProgram
    {
        public static void Start()
        {
            Calculator calc = new();
            Console.WriteLine("Список доступных операций: ");

            var declaredOp = calc.DeclaredOperations;

            for (int i = 0; i < declaredOp.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {declaredOp[i]}");
            }

            Console.Write("Ввод осуществляется через проблем. Пример: y * x\n\n--> ");

            var value = Console.ReadLine();
            var temp = value.Split();

            if (temp.Length != 3)
                throw new ArgumentException("Неверный ввод");

            var op = temp[1];

            try
            {
                var x = int.Parse(temp[0]);
                var y = int.Parse(temp.Last());
                Console.WriteLine(calc.PerformOperation(op, x, y));
            }
            catch
            {
                throw new ArgumentException("Неверный ввод");
            }
            
        }
    }
}
