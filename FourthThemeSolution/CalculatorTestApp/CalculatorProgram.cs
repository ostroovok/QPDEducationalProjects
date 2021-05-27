using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CaclulatorLogic;

namespace TestApp.Theme4
{
    public static class CalculatorProgram
    {
        public static void Main(string[] args)
        {
            Start();
        }
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
            ArrayList arr = CheckInputValue();
            var result = calc.PerformOperation((string)arr[0], (double)arr[1], (double)arr[2]);
            Console.WriteLine(result);
        }
        public static ArrayList CheckInputValue()
        {
            var value = Console.ReadLine();
            var temp = value.Split();

            var op = "";
            double x = 1;
            double y = 1;

            while (temp.Length != 3 || !double.TryParse(temp[0], out x) || !double.TryParse(temp[2], out y))
            {
                Console.WriteLine("Неверный ввод");
                Console.WriteLine("Введите еще раз: ");
                value = Console.ReadLine();
                temp = value.Split();
                
            }
            op = temp[1];
            return new ArrayList() { op, x, y };
        }
    }
}
