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
                Console.WriteLine("1 : 2 : 3 : 4 : 5 : 7");
                Console.Write("--> ");
                var number = NumbersProgram.CheckInput();
                if (number == -1)
                    break;
                switch (number)
                {
                    case 1:
                        Console.WriteLine("Введите массив: ");
                        Console.Write("Size: ");
                        First(Input(NumbersProgram.CheckInput()));
                        break;
                    case 2:
                        Console.WriteLine("Введите массив: ");
                        Console.Write("Size: ");
                        Second(Input(NumbersProgram.CheckInput()));
                        break;
                    case 3:
                        Console.Write("Size: ");
                        Third(NumbersProgram.CheckInput());
                        break;
                    case 4:
                        Console.Write("Size: ");
                        Fourth(NumbersProgram.CheckInput());
                        break;
                    case 5:
                        Fifth();
                        break;
                    case 7:
                        Seventh(NumbersProgram.CheckInput()); ;
                        break;
                    default:
                        Console.WriteLine("Такого варианта нет в списке \n Нажмите любую клавишу");
                        break;
                }
                Console.ReadLine();
            }
        }
        private static int[] Input(int number)
        {
            int[] arr = new int[number];
            for (int i = 0; i < number; i++)
            {
                arr[i] = NumbersProgram.CheckInput();
            }
            return arr;
        }
        private static int[] OrderedInput(int number, bool isMin)
        {
            Console.WriteLine("Введите упорядоченный массив ");
            int[] arr = Input(number);
            if (!isMin)
            {
                while (!Arrays.IsOrderedMinToMax(arr))
                    arr = Input(number);
            }
            else
            {
                while (!Arrays.IsOrderedMaxToMin(arr))
                    arr = Input(number);
            }
            return arr;
        }
        private static void First(int[] arr)
        {
            Console.WriteLine("Out: " + Arrays.CountValues(arr)[0] + " : " + Arrays.CountValues(arr)[1]);
        }
        private static void Second(int[] arr)
        {
            Console.WriteLine(Arrays.IsOrderedMinToMax(arr));
            Console.WriteLine(Arrays.IsOrderedMaxToMin(arr));
        }
        private static void Third(int number)
        {
            var arr = Arrays.RandomArray(number);
            
            Console.WriteLine($"Max: {Arrays.FindMax(arr)} Min: {Arrays.FindMin(arr)} ");
            Console.WriteLine($"Min Odd: {Arrays.FindEvenOddMinMax(arr, false, true)}");
            PrintArray(arr);
            Arrays.SwapMinToMax(arr);
            PrintArray(arr);
        }
        private static void Fourth(int number)
        {
            int[] first = OrderedInput(number, false);
            int[] second = OrderedInput(number, false);
            int[] newArr = Arrays.OrderedConcat(first, second);
            PrintArray(newArr);
        }
        private static void Write(int[] arr)
        { 
            var path = "C:\\Users\\e.barkalov\\source\\repos\\SimpleProjects\\SimpleProjects";
            using FileStream fstream = new FileStream($"{path}\\out_test.txt", FileMode.OpenOrCreate);
            byte[] byteArr = Encoding.Default.GetBytes(String.Join(' ', Array.ConvertAll(arr, Convert.ToString)));
            fstream.Write(byteArr);
        }
        private static int[] Read()
        {
            var path = "C:\\Users\\e.barkalov\\source\\repos\\SimpleProjects\\SimpleProjects";
            using FileStream fstream = File.OpenRead($"{path}\\test_1.txt");

            byte[] byteArr = new byte[fstream.Length];

            fstream.Read(byteArr, 0, byteArr.Length);

            string textFromFile = Encoding.Default.GetString(byteArr);
            return Array.ConvertAll(textFromFile.Split(), Convert.ToInt32);
        }
        private static void Fifth()
        {
            var arr = Read();

            Arrays.BubbleSort(arr, true);
            Write(arr);
            PrintArray(arr); 
            Arrays.BubbleSort(arr, false);
            Write(arr);
            PrintArray(arr);
        }
        private static void Seventh(int number)
        {
            var arr = Arrays.RandomArray(10);
  
            PrintArray(arr);
            Arrays.Shift(arr, number);
            //Console.Write("\t");
            PrintArray(arr);
        }
        private static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                Console.Write($"{arr[i]}, ");
            }
            Console.Write(arr.Last() + ".\n");
        }
    }
}
