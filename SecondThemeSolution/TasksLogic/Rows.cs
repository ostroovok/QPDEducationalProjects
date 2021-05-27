using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksLogic
{
    public static class Rows
    {
        public static int SeriesModifiedSum(int max, int from, int plus)
        {
            var sum = 0;
            for (int i = from; i <= max; i += plus)
            {
                sum += i;
            }
            return sum;
        }
        public static int[] SeriesSumTerms(int max, int from, int plus)
        {
            var count = 0;
            var sum = 0;
            for (int i = from; i <= max; i += plus)
            {
                sum += i;
                count++;
            }
            return new int[] { sum, count };
        }
        public static int[] SumWithLimitedNumberOfTerms(int max, int plus = 1, int from = 0)
        {
            var count = 0;
            int sum = 0;
            for (int i = from; count < max; i+=plus)
            {
                count++;
                sum += i;
            }
            return new int[] { sum, count };
        }
        public static int[] IncreasingSumWithLimitedNumberOfTerms(int max, int plus = 1, int from = 0)
        {
            var count = 0;
            int sum = 0;
            while (count < max)
            {
                count++;
                sum += plus;
                plus += plus;
            }
            return new int[] { sum, count };
        }
        public static int[] LimitedSum(int max, int plus = 1, int from = 0, bool moreMax=false)
        {
            var count = 0;
            var sum = 0;
            if (!moreMax)
            {
                for (int i = from; sum < max; i+=plus)
                {
                    count++;
                    sum += i;
                    if (sum + i > max)
                        return new int[] { sum, count };
                }
            }
            for (int i = from; sum < max; i+=plus)
            {
                count++;
                sum += i;
            }
            return new int[] { sum, count };
        }

        public static int Fibonacci(int number)
        {
            var sum = 0;
            for (int i = 1; i <= number; i++)
            {
                sum += FibStep(i);
            }
            return sum;
        }
        private static int FibStep(int number)
        {
            int res;
            if (number == 1 || number == 2)
            {
                return 1;
            }
            else
            {
                 res = FibStep(number - 1) + FibStep(number - 2);
            }
            return res;
        }
    }
}
