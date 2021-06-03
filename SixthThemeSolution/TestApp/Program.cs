using SixthThemeLogic;
using System;
using System.Diagnostics;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //FirstTask.Start();

            FillArrayExperiment();

            //BubbleSortExperiment();

            QuickSortExperiment();
        }
        /// <summary>
        /// Метод, сравнивающий обычное заполнение массива и параллельное заполнение
        /// </summary>
        static void FillArrayExperiment()
        {
            int[] arr = new int[100000000];
            Console.WriteLine($"Размер массива: {arr.Length}\n\n");
            Stopwatch sw = new();
            sw.Start();
            arr = FillArray.StandartFill(arr);
            sw.Stop();

            Console.WriteLine("\nПримитивное заполнение массива рандомными элементами: " + sw.ElapsedMilliseconds + " мс.\n\n\n");

            sw.Reset();

            arr = new int[100000000];

            sw.Start();
            arr = FillArray.ThreadFill(arr);
            sw.Stop();
            Console.WriteLine("\nЗаполнение массива рандомными элементами с помощью класса задач: " + sw.ElapsedMilliseconds + " мс.\n\n\n");
        }
        /// <summary>
        /// Метод, сравнивающий обычную и параллельную сортировку массива пузырьком
        /// </summary>
        static void BubbleSortExperiment()
        {
            int[] arr = new int[100000];
            Console.WriteLine($"Размер массива: {arr.Length}\n\n");
            Stopwatch sw = new();

            arr = FillArray.ThreadFill(arr);
            sw.Start();
            arr = SortArray.StandartBubbleSort(arr);
            sw.Stop();

            Console.WriteLine("\nОбычная сортировка пузырьком: " + sw.ElapsedMilliseconds + " мс.\n\n\n");
            sw.Reset();

            arr = new int[100000];

            arr = FillArray.StandartFill(arr);
            sw.Start();
            arr = SortArray.ThreadBubbleSort(arr);
            sw.Stop();

            Console.WriteLine("\nСортировка пузырьком с использованием класса задач: " + sw.ElapsedMilliseconds + " мс.\n\n\n");

        }
        /// <summary>
        /// Метод, сравнивающий обычную и параллельную быструю сортировку
        /// </summary>
        static void QuickSortExperiment()
        {
            int[] arr = new int[1000000];
            Console.WriteLine($"Размер массива: {arr.Length}\n\n");
            Stopwatch sw = new();

            arr = FillArray.StandartFill(arr);
            sw.Start();
            arr = SortArray.StandartQuickSort(arr);
            sw.Stop();

            Console.WriteLine("\nОбычная быстрая сортировка: " + sw.ElapsedMilliseconds + " мс.\n\n\n");
            sw.Reset();

            arr = new int[1000000];

            arr = FillArray.StandartFill(arr);
            sw.Start();
            arr = SortArray.ThreadQuickSort(arr);
            sw.Stop();

            Console.WriteLine("\nБыстрая сортировка с использованием параллельности: " + sw.ElapsedMilliseconds + " мс.\n\n\n");

        }
    }
}
