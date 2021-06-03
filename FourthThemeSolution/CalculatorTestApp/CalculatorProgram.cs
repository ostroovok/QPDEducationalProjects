using CaclulatorLogic;
using System;
using System.Text.RegularExpressions;

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

            calc.AddOperation("*", (x, y) => x * y);

            Console.WriteLine("Список доступных операций: ");

            var declaredOp = calc.DeclaredOperations;

            for (int i = 0; i < declaredOp.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {declaredOp[i]}");
            }

            Console.WriteLine("Для выхода введите 0 и нажмите Enter");
            Console.Write("Пример: 5 * 7. Дробная часть отделяется запятой: 3,14");

            while (TryGetExpressionFromConsole(out var leftOperand, out var rightOperand, out var operation))
            {
                Console.WriteLine(calc.PerformOperation(operation, leftOperand, rightOperand));
            }

        }
        public static bool TryGetExpressionFromConsole(out double leftOperand, out double rightOperand, out string operation)
        {
            while (true)
            {
                Console.Write("\n\n>>> ");

                var value = Console.ReadLine().Trim();
                if (value == "0")
                {
                    leftOperand = 0;
                    rightOperand = 0;
                    operation = "";
                    return false;
                }

                var regex = new Regex(@"\s+");
                var result = regex.Replace(value, " ").Split();

                if (result.Length != 3 || !double.TryParse(result[0], out leftOperand) || !double.TryParse(result[2], out rightOperand))
                {
                    Console.WriteLine("Неверный ввод");
                    Console.Write("Введите еще раз: ");
                    continue;
                }

                operation = result[1];
                return true;
            }

        }
    }
}
