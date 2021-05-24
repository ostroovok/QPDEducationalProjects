using System;
using TasksLogic;
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
                Console.WriteLine("Введите номер задачи (от 1 до 7, кроме 6, эта задача выполняется вместе с пятой ввода 5)\n Элементы массивов вводятся построчно!");
                Console.Write("-->\t");
                var number = NumbersUtils.CheckInputValue();
                if (number == -1)
                    break;
                switch (number)
                {

                    case 1:
                        Console.Write("Размер массива: ");
                        FirstTask(Input(NumbersUtils.CheckNegativeOrZero()));
                        break;

                    case 2:
                        Console.Write("Размер массива: ");
                        SecondTask(Input(NumbersUtils.CheckNegativeOrZero()));
                        break;

                    case 3:
                        Console.Write("Размер массива: ");
                        ThirdTask(Input(NumbersUtils.CheckNegativeOrZero()));
                        break;

                    case 4:
                        Console.Write("Размер массивов: ");
                        FourthTask(NumbersUtils.CheckNegativeOrZero());
                        break;

                    case 5:
                        FifthTask();
                        Console.WriteLine("Результат в файле test_1.txt");
                        break;

                    case 7:
                        Console.WriteLine("Введите положительное чиcло, на которое нужно сдвинуть массив: ");
                        SeventhTask(NumbersUtils.CheckNegativeOrZero());
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
            Console.WriteLine($"Результат: \nЦифра: {Arrays.CountValues(arr)[0]}; Количество его повторений: {Arrays.CountValues(arr)[1]}");
        }
        private static void SecondTask(int[] arr)
        {
            Console.WriteLine("Результат: ");
            if (Arrays.IsOrderedAscending(arr))
            {
                Console.WriteLine("Отсортирован по возрастанию");
            }
            else
            {
                Console.WriteLine("Не отсортирован по возрастанию");
            }
            if (Arrays.IsOrderedDescending(arr))
            {
                Console.WriteLine("Отсортирован по убыванию");
            }
            else
            {
                Console.WriteLine("Не отсортирован по убыванию");
            }
        }
        private static void ThirdTask(int[] arr)
        {
            
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
            WriteToFile(arr);
            PrintArray(arr);
            Arrays.BubbleSort(arr, false);
            WriteToFile(arr);
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
        
        
        private static int[] Input(int number)
        {
            Console.WriteLine("Введите массив: ");
            int[] arr = new int[number];
            for (int i = 0; i < number; i++)
            {
                arr[i] = NumbersUtils.CheckInputValue();
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
        private static void WriteToFile(int[] arr)
        { 
            try
            {
                using FileStream fstream = new FileStream($"test_1.txt", FileMode.OpenOrCreate);
                byte[] byteArr = Encoding.Default.GetBytes(string.Join(' ', Array.ConvertAll(arr, Convert.ToString)));
                fstream.Write(byteArr);
            }
            catch
            {
                throw new FileNotFoundException("Файл не был найден, проверьте указанное местоположение файла");
            }
        }
        private static int[] ReadFromFile()
        {
            string textFromFile = "";
            List<int> outList = new();
            try
            {
                using FileStream fstream = File.OpenRead($"test_1.txt");
                byte[] byteArr = new byte[fstream.Length];

                fstream.Read(byteArr, 0, byteArr.Length);

                textFromFile = Encoding.Default.GetString(byteArr);
            }
            catch
            {
                throw new FileNotFoundException("Файл не был найден, проверьте указанное местоположение файла");
            }

            try
            {
                outList = Array.ConvertAll(textFromFile.Split(), Convert.ToInt32).ToList();
            }
            catch
            {
                throw new ArgumentException("В файле указаны не числа или не только числа");
            }

            return outList.ToArray();
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
