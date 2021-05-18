using System;
using TasksLogic;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    public static class ArrayProgram
    {
        public static void Start()
        {
            while (true)
            {
                var number = NumbersProgram.CheckInput();
                if (number == -1)
                    break;
                switch (number)
                {
                    case 1:
                        First(Input(number));
                        break;
                    case 2:
                        Second(Input(number));
                        break;
                    case 3:
                        Third(number);
                        break;
                    case 4:
                        //Fourth();
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
        private static void First(int[] arr)
        {
            Console.WriteLine(Arrays.CountValues(arr)[0] + " : " + Arrays.CountValues(arr)[1]);
        }
        private static void Second(int[] arr)
        {
            Console.WriteLine(Arrays.IsOrderedMinToMax(arr));
            Console.WriteLine(Arrays.IsOrderedMaxToMin(arr));
        }
        private static void Third(int number)
        {
            var arr = Arrays.RandomArray(number);
            Console.WriteLine($"Max: {Arrays.FindMax(arr)} Min: {Arrays.FindMin(arr)}");
            Console.WriteLine($"Min Odd: {Arrays.FindEvenOddMinMax(arr, false, true)}");

        }
    }
}
