using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksLogic
{
    public static class Arrays
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
            int[] outArr = new int[Math.Max(arr.Length + 1,FindMax(arr) + 1)];
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
            var minIndex = 1;
            var maxIndex = 1;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                    maxIndex = i;
                }
                    
            }
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < min)
                {
                    min = arr[i];
                    minIndex = i;
                }
                    
            }
            var t = arr[minIndex];
            arr[minIndex] = arr[maxIndex];
            arr[maxIndex] = t;
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
        
        public static int[] OrderedConcat(int[] first, int[] second)
        {
            var maxLen = first.Length + second.Length;
            var outArr = new int[maxLen];
            for (int i = 0, f = 0, s = 0; i < maxLen; i++)
            {
                if(f < first.Length && first[f] < second[s])
                {
                    outArr[i] = first[f];
                    f++;
                }
                else if(s < second.Length)
                {
                    outArr[i] = second[s];
                    s++;
                }
            }
            return outArr;
        }
        
        public static int[] Shift(int[] arr, int k)
        {

            for (int j = 0; j < arr.Length - 1; j++)
            {
                var temp = 0;
                if (j == arr.Length - 1 || j + k >= arr.Length)
                {
                    temp = arr[j];
                    arr[j] = arr[arr.Length - k];
                    arr[arr.Length - k] = temp;
                }
                else
                {
                    temp = arr[j];
                    arr[j] = arr[j + k];
                    arr[j + k] = temp;
                }

            }
            return arr;
        }
        
        public static int[] BubbleSort(int[] arr, bool isMin)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {

                for (int j = 0; j < arr.Length - 1; j++)
                {

                    if (isMin)
                    {
                        if (arr[j] <= arr[j + 1])
                        {
                            var t = arr[j];
                            arr[j] = arr[j + 1];
                            arr[j + 1] = t;
                        }
                    }
                    else
                    {
                        if (arr[j] >= arr[j + 1])
                        {
                            var t = arr[j];
                            arr[j] = arr[j + 1];
                            arr[j + 1] = t;
                        }
                    }
                }

            }
            return arr;
        }
        
        #region Private Methods
        private static void ShiftStep(int[] arr)
        {
            for (int j = 0; j < arr.Length; j++)
            {
                var temp = 0;
                if (j + 1 == arr.Length)
                {
                    temp = arr[j];
                    arr[j] = arr[0];
                    arr[0] = temp;
                }
                else
                {
                    temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }

            }
        }
        private static int[] Swap(int[] arr, int a, int b)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == a)
                    a = i;
                else if (arr[i] == b)
                    b = i;
            }
            var t = arr[a];
            arr[a] = arr[b];
            arr[b] = t;
            return arr;
        }
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
