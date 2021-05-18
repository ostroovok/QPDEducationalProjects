using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksLogic
{
    public class Arrays
    {
        public static int[] RandomArray(int maxLen, int min = -100, int max = 100)
        {
            Random rnd = new Random();
            var arr = new int[maxLen];
            for (int i = 0; i < maxLen; i++)
            {
                arr[i] = rnd.Next(min, max);
            }
            return arr;
        }
        public static bool IsOrderedMinToMax(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] > arr[i + 1])
                    return false;
            }
            return true;
        }
        public static bool IsOrderedMaxToMin(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] < arr[i + 1])
                    return false;
            }
            return true;
        }
        public static int[] CountValues(int[] arr)
        {
            int[] outArr = new int[Math.Max(arr.Length,FindMax(arr))];
            for (int i = 0; i < arr.Length; i++)
            {
                outArr[arr[i]] += 1;
            }

            int result = FindMax(outArr);
            if (outArr.Contains(result))
            {
                for (int i = outArr.Length - 1; i >= 0 ; i--)
                {
                    if (outArr[i] == result)
                        return new int[] { i, outArr[i] };
                }
            }
            return new int[] { result, outArr[result] };
        }
        public static void SwapMinToMax(int[] arr)
        {
            var max = int.MinValue;
            var min = int.MaxValue;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > max)
                    max = i;
            }
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < min)
                    min = i;
            }
            var t = arr[min];
            arr[min] = arr[max];
            arr[max] = t;
        }
        public static int FindMax(int[] arr)
        {
            var max = int.MinValue;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > max)
                    max = arr[i];
            }
            return max;
        }
        public static int FindMin(int[] arr)
        {
            var min = int.MaxValue;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < min)
                    min = arr[i];
            }
            return min;
        }
        public static int FindEvenOddMinMax(int[] arr, bool max, bool odd)
        {
            if (max)
            {
                var maxValue = int.MinValue;
                for (int i = 0; i < arr.Length; i++)
                {
                    if (odd)
                    {
                        if (arr[i] > maxValue && arr[i] % 2 != 0)
                            maxValue = arr[i];
                    }
                    else
                    {
                        if (arr[i] > maxValue && arr[i] % 2 == 0)
                            maxValue = arr[i];
                    }
                }
                return maxValue;
            }
            else
            {
                var minValue = int.MaxValue;
                for (int i = 0; i < arr.Length; i++)
                {
                    if (odd)
                    {
                        if (arr[i] < minValue && arr[i] % 2 != 0)
                            minValue = arr[i];
                    }
                    else
                    {
                        if (arr[i] < minValue && arr[i] % 2 == 0)
                            minValue = arr[i];
                    }
                }
                return minValue;
            }
        }
        #region Private Methods
        private static int[] ExpandArray(int[] arr)
        {
            int[] outArr = new int[arr.Length * 2];
            Array.Copy(arr, outArr, arr.Length);
            return outArr;
        }
        private static int[] FindSimilar(int[] arr, int value)
        {
            int[] similarValues = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == value)
                    similarValues[i] = arr[i];
            }
            return similarValues;
        }
        #endregion
    }
}
