using System;
using System.Collections.Generic;
using System.Linq;

namespace CaclulatorLogic
{
    public class Calculator
    {
        private Dictionary<string, Func<double, double, double>> _operations;
        public string[] DeclaredOperations { get => _operations.Keys.ToArray(); }
        public Calculator()
        {
            _operations = new Dictionary<string, Func<double, double, double>>
            {
                { "+", (x, y) => x + y },
                { "-", (x, y) => x - y },
                { "/", (x, y) => x / y },
                { "*", (x, y) => x * y },
            };
        }
        public double? PerformOperation(string op, double x, double y)
        {
            if (!_operations.ContainsKey(op))
            {
                Console.WriteLine($"Недоступная операция: {op}. В качестве результата было возвращено значение:");
                return -1;
            }
            return _operations[op](x, y);
        }
        public void AddOperation(string op, Func<double, double, double> newOp)
        {
            if (!_operations.ContainsKey(op))
            {
                Console.WriteLine($"Операция уже существует: {op}");
                return;
            }

            _operations.Add(op, newOp);
        }
    }
}
