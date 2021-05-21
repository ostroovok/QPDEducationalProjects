using System;

namespace TasksLogic.Theme2
{
    public static class Numbers
    {
        public static int TheSumOfTheDigits(int number)
        {
            var sum = 0;
            while (number != 0)
            {
                sum += Math.Abs(number % 10);
                number /= 10;
            }
            return sum;
        }
    }
}
