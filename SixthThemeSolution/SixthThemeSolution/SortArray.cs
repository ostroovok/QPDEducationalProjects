using System.Threading.Tasks;

namespace SixthThemeLogic
{
    public static class SortArray
    {
        #region Bubble Sort
        public static int[] StandartBubbleSort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] >= arr[j])
                    {
                        var t = arr[i];
                        arr[i] = arr[j];
                        arr[j] = t;
                    }
                }
            }

            return arr;
        }

        public static int[] ThreadBubbleSort(int[] arr)
        {

            Task<int[]> t1 = Task.Run(() =>
                ThreadBubbleSortLine(arr, 0, arr.Length / 4)
            );
            Task<int[]> t2 = Task.Run(() =>
                            ThreadBubbleSortLine(arr, arr.Length / 4, arr.Length / 2)
                        );
            Task<int[]> t3 = Task.Run(() =>
                ThreadBubbleSortLine(arr, arr.Length / 4 + arr.Length / 2, arr.Length)
            );

            t1.Wait();
            t2.Wait();
            t3.Wait();

            Task<int[]> t4 = Task.Run(() =>
                ThreadBubbleSortLine(arr, 0, arr.Length)
            );

            t4.Wait();
            return arr;
        }
        private static int[] ThreadBubbleSortLine(int[] arr, int from, int max)
        {
            for (int i = from; i < max; i++)
            {
                for (int j = i + 1; j < max; j++)
                {
                    if (arr[i] >= arr[j])
                    {
                        var t = arr[i];
                        arr[i] = arr[j];
                        arr[j] = t;
                    }
                }
            }

            return arr;
        }
        #endregion

        #region Quick Sort
        public static int[] ThreadQuickSort(int[] arr)
        {
            return ThreadQuickSortStep(arr, 0, arr.Length - 1); ;
        }

        public static int[] StandartQuickSort(int[] arr)
        {
            return StandartQuickSortStep(arr, 0, arr.Length - 1);
        }

        #region Private Methods
        private static void Swap(ref int x, ref int y)
        {
            var t = x;
            x = y;
            y = t;
        }

        private static int Partition(int[] array, int minIndex, int maxIndex)
        {
            var pivot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
                if (array[i] < array[maxIndex])
                {
                    pivot++;
                    Swap(ref array[pivot], ref array[i]);
                }
            }

            pivot++;
            Swap(ref array[pivot], ref array[maxIndex]);
            return pivot;
        }
        private static int[] ThreadQuickSortStep(int[] arr, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return arr;
            }
            int sequentialThreshold = arr.Length / 10;
            if (maxIndex > minIndex)
            {
                var pivotIndex = Partition(arr, minIndex, maxIndex);

                if (maxIndex - minIndex < sequentialThreshold)
                {
                    StandartQuickSortStep(arr, minIndex, maxIndex);
                }
                else
                {
                    Parallel.Invoke(
                        () => ThreadQuickSortStep(arr, minIndex, pivotIndex - 1),
                        () => ThreadQuickSortStep(arr, pivotIndex + 1, maxIndex));
                }
            }

            return arr;
        }
        private static int[] StandartQuickSortStep(int[] arr, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return arr;
            }

            var pivotIndex = Partition(arr, minIndex, maxIndex);
            StandartQuickSortStep(arr, minIndex, pivotIndex - 1);
            StandartQuickSortStep(arr, pivotIndex + 1, maxIndex);

            return arr;
        }
        #endregion

        #endregion
    }
}
