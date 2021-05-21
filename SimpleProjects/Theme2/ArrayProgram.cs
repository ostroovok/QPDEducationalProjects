using System;
using TasksLogic.Theme2;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TestApp
{
    public static class ArrayProgram
    {
        public static void Start()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Введите номер задачи (от 1 до 7, кроме 6, эта задача выполняется вместе с пятой ввода 5)\n stop - Выход \t Элементы массивов вводятся построчно!");
                Console.Write("-->\t");
                var number = CheckInputValue();
                int temp;
                if (number == -1)
                    break;
                switch (number)
                {

                    case 1:
                        Console.Write("Размер массива: ");
                        FirstTask(Input(CheckNegative()));
                        break;

                    case 2:
                        Console.Write("Размер массива: ");
                        SecondTask(Input(CheckNegative()));
                        break;

                    case 3:
                        Console.Write("Размер массива: ");
                        ThirdTask(CheckNegative());
                        break;

                    case 4:
                        Console.Write("Размер массивов: ");
                        FourthTask(CheckNegative());
                        break;

                    case 5:
                        FifthTask();
                        Console.WriteLine("Результат в файле out_test.txt");
                        break;

                    case 7:
                        Console.WriteLine("Введите положительное чиcло, на которое нужно сдвинуть массив: ");
                        SeventhTask(CheckNegative());
                        break;

                    default:
                        Console.WriteLine("Такого варианта нет в списке \n Нажмите любую клавишу для продолжения");
                        break;

                }
                Console.ReadLine();
            }
        }

        
        #region Problem Solving Methods
        private static void FirstTask(int[] arr)
        {
            Console.WriteLine($"Результат: \nЧисло: {Arrays.CountValues(arr)[0]}; Количество его повторений: {Arrays.CountValues(arr)[1]}");
        }
        private static void SecondTask(int[] arr)
        {
            Console.WriteLine("Результат: ");
            Console.WriteLine(Arrays.IsOrderedAscending(arr) + " По возрастанию");
            Console.WriteLine(Arrays.IsOrderedDescending(arr) + " По убыванию");
        }
        private static void ThirdTask(int number)
        {
            var arr = Arrays.RandomArray(number);
            
            Console.WriteLine($"Максимальный элемент в массиве: {Arrays.FindMaxValue(arr)}; Минимальный  элемент в массиве: {Arrays.FindMinValue(arr)} ");
            Console.WriteLine($"Минимальный нечетный элемент в массиве: {Arrays.FindWithСonditions(arr, false, true)}; " +
                $"Минимальный четный элемент в массиве: {Arrays.FindWithСonditions(arr, false, false)}");
            Console.WriteLine("Массив до смены мест максимального и минимального эл-ов:");
            PrintArray(arr);
            Arrays.SwapMinValueToMaxValue(arr);
            Console.WriteLine("Массив после смены мест максимального и минимального эл-ов:");
            PrintArray(arr);
        }
        private static void FourthTask(int number)
        {
            Console.WriteLine("Массивы должны быть упорядоченными по возрастанию");

            bool check = false;
            int[] first = OrderedInput(number, check);
            int[] second = OrderedInput(number, check);
            int[] newArr = Arrays.OrderedConcat(first, second);
            PrintArray(newArr);
        }
        private static void FifthTask()
        {
            var arr = ReadFromFile();

            Arrays.BubbleSort(arr, true);
            WriteInFile(arr);
            PrintArray(arr);
            Arrays.BubbleSort(arr, false);
            WriteInFile(arr);
            PrintArray(arr);
        }
        private static void SeventhTask(int number)
        {
            var arr = Arrays.RandomArray(10);

            PrintArray(arr);
            Arrays.Shift(arr, number);
            PrintArray(arr);
        }
        #endregion
        #region Utils Methods
        private static int CheckNegative()
        {
            var temp = CheckInputValue();
            while (temp < 0)
            {
                Console.WriteLine("Не может быть отрицательным!");
                Console.Write("Введите еще раз: ");
                temp = CheckInputValue();
            }
            return temp;
        }
        private static int CheckInputValue()
        {
            var value = Console.ReadLine();
            if (value.ToLower() == "stop")
                Start();
            int number;
            bool success = int.TryParse(value, out number);
            while (!success)
            {
                Console.WriteLine("Не число!");
                value = Console.ReadLine();
                if (value.ToLower() == "stop")
                    Start();
                success = int.TryParse(value, out number);
            }
            return number;
        }
        private static int[] Input(int number)
        {
            Console.WriteLine("Введите массив: ");
            int[] arr = new int[number];
            for (int i = 0; i < number; i++)
            {
                arr[i] = CheckInputValue();
            }
            return arr;
        }
        private static int[] OrderedInput(int number, bool isMin)
        {
            int[] arr = Input(number);
            if (!isMin)
            {
                while (!Arrays.IsOrderedAscending(arr))
                {
                    Console.WriteLine("Введите еще раз, массив не соответсвует условиям");
                    arr = Input(number);
                }    
            }
            else
            {
                while (!Arrays.IsOrderedDescending(arr))
                {
                    Console.WriteLine("Введите еще раз, массив не соответсвует условиям");
                    arr = Input(number);
                }     
            }
            return arr;
        }
        private static void WriteInFile(int[] arr)
        { 
            using FileStream fstream = new FileStream($"out_test.txt", FileMode.OpenOrCreate);
            byte[] byteArr = Encoding.Default.GetBytes(String.Join(' ', Array.ConvertAll(arr, Convert.ToString)));
            fstream.Write(byteArr);
        }
        private static int[] ReadFromFile()
        {
            using FileStream fstream = File.OpenRead($"test_1.txt");

            byte[] byteArr = new byte[fstream.Length];

            fstream.Read(byteArr, 0, byteArr.Length);

            string textFromFile = Encoding.Default.GetString(byteArr);
            return Array.ConvertAll(textFromFile.Split(), Convert.ToInt32);
        }
        private static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                Console.Write($"{arr[i]}, ");
            }
            Console.Write(arr.Last() + ".\n");
        }
        #endregion
    }
}
