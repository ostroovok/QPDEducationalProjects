using CaclulatorLogic;
using System;

namespace TestApp.Theme4
{
    public static class CalculatorProgram
    {
        private static bool _exit = true;
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

            double leftOperand;
            double rightOperand;
            string operation;

            Console.WriteLine("Для выхода введите 0 и найжмите Enter");
            Console.Write("Ввод осуществляется через проблем. Пример: y * x. Дробная часть отделяется запятой: 3,14");
            while (_exit)
            {
                Console.Write("\n\n>>> ");
                GetExpressionFromConsole(out leftOperand, out rightOperand, out operation);

                var result = calc.PerformOperation(operation, leftOperand, rightOperand);

                Console.WriteLine(result);
            }

        }
        public static void GetExpressionFromConsole(out double leftOperand, out double rightOperand, out string operation)
        {
            var value = Console.ReadLine();
            if (value == "0")
            {
                _exit = false;
                leftOperand = 0;
                rightOperand = 0;
                operation = "-";
                return;
            }
            var temp = value.Split();
            while (temp.Length != 3 || !double.TryParse(temp[0], out leftOperand) || !double.TryParse(temp[2], out rightOperand))
            {
                Console.WriteLine("Неверный ввод");
                Console.Write("Введите еще раз: \n\n>>> ");
                value = Console.ReadLine();
                temp = value.Split();
            }
            operation = temp[1];
        }
    }
}
