using System;
using System.Collections.Generic;

namespace TasksLogic
{
    public static class Numbers
    {
        public static int TheSumOfTheDigits(int number)
        {
            var sum = 0;
            while (number != 0)
            {
                sum += int.Parse((number % 10).ToString().Trim('-'));
                number /= 10;
            }
            return sum;
        }
        public static int[] TheArrayOfTheDigits(int number)
        {
            List<int> outArr = new();
            for(int i = 0; number != 0; i++)
            {
                outArr.Add(int.Parse((number % 10).ToString().Trim('-')));
                number /= 10;
            }
            return outArr.ToArray();
        }
    }
}
