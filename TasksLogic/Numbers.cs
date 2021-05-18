using System;

namespace TasksLogic
{
    public static class Numbers
    {
        public static int SumRank(int number)
        {
            var sum = 0;
            sum += number / 100;
            sum += number % 10;
            sum += number / 10 % 10;
            return sum;
        }
    }
}
