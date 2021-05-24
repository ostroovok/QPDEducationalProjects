using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public double PerformOperation(string op, double x, double y)
        {
            if (!_operations.ContainsKey(op))
                throw new ArgumentException($"Недоступная операция: {op}");
            return _operations[op](x,y);
        }
        public void AddOperation(string op, Func<double, double, double> newOp)
        {
            if (!_operations.ContainsKey(op))
                throw new ArgumentException($"Операция уже существует: {op}");
            _operations.Add(op, newOp);
        }
    }
}
