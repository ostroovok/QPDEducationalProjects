using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SixthThemeLogic
{
    public static class FillArray
    {
        public static int[] StandartFill(int[] arr)
        {
            Random rnd = new();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(0, 101);
            }
            return arr;
        }
        public static int[] StandartFill(int[] arr, int startIndex, int finishIndex)
        {
            Random rnd = new();
            for (int i = startIndex; i < finishIndex; i++)
            {
                arr[i] = rnd.Next(0, 101);
            }
            return arr;
        }
        public static int[] ThreadFill(int[] arr)
        {
            List<int[]> outL = new();
            Task<int[]> t1 = new Task<int[]>(() =>
                  StandartFill(arr, 0, arr.Length / 2)
                );
            Task<int[]> t2 = new Task<int[]>(() =>
                  StandartFill(arr, arr.Length / 2, arr.Length)
                );
            t1.Start();
            t2.Start();
            Task.WaitAll();
            return arr;
        }
    }
}
