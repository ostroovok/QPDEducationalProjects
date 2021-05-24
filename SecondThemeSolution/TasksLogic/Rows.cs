using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksLogic
{
    public static class Rows
    {
        public static int Count { get; private set; } = 0;
        public static int VariableSeriesSum(int max, int plus=1, bool isOdd=false, int from=0)
        {
            var sum = 0;
            Count = 0;
            for (int i = from; i <= max; i += plus)
            {
                if (i % 2 == 0 && !isOdd)
                {
                    sum += i;
                    Count++;
                }
                if (i % 2 != 0 && isOdd)
                {
                    sum += i;
                    Count++;
                }
            }
            return sum;
        }
        public static int TheSumOfTheSeries(int max, int plus = 1, int from=0)
        {
            Count = 0;
            var sum = 0;
            for (int i = from; i <= max; i += plus)
            {
                Count++;
                sum += i;
            }
            return sum;
        }
        public static int SumWithLimitedNumberOfTerms(int max, int plus = 1, int from = 0)
        {
            Count = 0;
            int sum = 0;
            for (int i = from; Count < max; i+=plus)
            {
                Count++;
                sum += i;
            }
            return sum;
        }
        public static int IncreasingSumWithLimitedNumberOfTerms(int max, int plus = 1, int from = 0)
        {
            Count = 0;
            int sum = 0;
            while (Count < max)
            {
                Count++;
                sum += plus;
                plus += plus;
            }
            return sum;
        }
        public static int LimitedSum(int max, int plus = 1, int from = 0, bool moreMax=false)
        {
            Count = 0;
            var sum = 0;
            if (!moreMax)
            {
                for (int i = from; sum < max; i+=plus)
                {
                    Count++;
                    sum += i;
                    if (sum + i > max)
                        return sum;
                }
            }
            for (int i = from; sum < max; i+=plus)
            {
                Count++;
                sum += i;
            }
            return sum;
        }
        public static int Fibonacci(int number)
        {
            if (number == 0 || number == 1)
            {
                return number;
            }
            else
            {
                return Fibonacci(number - 1) + Fibonacci(number - 2);
            }
        }
    }
}
