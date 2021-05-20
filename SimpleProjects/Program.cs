using System;
using System.Collections.Generic;
using TasksLogic;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {

            //NumbersProgram.Start();

            //Figures f = new Figures(7, 5);
            //f.PrintAll();

            /*
            Console.WriteLine("\tЗадача #6");
            Console.WriteLine(Rows.TheSumOfTheSeries(50, 1, 1));
            Console.WriteLine(Rows.VariableSeriesSum(50, 2, false, 2));
            Console.WriteLine(Rows.VariableSeriesSum(50, 2, true, 1));
            Console.WriteLine("\tЗадача #7");
            Console.WriteLine(Rows.TheSumOfTheSeries(46,4,6));
            Console.WriteLine(Rows.Count);
            Console.WriteLine("\tЗадача #8");
            Console.WriteLine(Rows.SumWithLimitedNumberOfTerms(10,4,6));
            Console.WriteLine(Rows.Count);
            Console.WriteLine("\tЗадача #9");
            Console.WriteLine(Rows.SumWithLimitedNumberOfTerms(11, 2, 1));
            Console.WriteLine(Rows.Count);
            Console.WriteLine("\tЗадача #10");
            Console.WriteLine(Rows.LimitedSum(100, 4, 6));
            Console.WriteLine(Rows.Count);
            Console.WriteLine("\tЗадача #11");
            Console.WriteLine(Rows.LimitedSum(100, 4, 6, true));
            Console.WriteLine(Rows.Count);
            Console.WriteLine("\tЗадача #12");
            Console.WriteLine(Rows.Fibonacci(3));
            */

            ArrayProgram.Start();

            //SFirst();
        }
        public static void SFirst()
        {
            var hello = "Привет!";
            var name = "Меня зовут Егор";
            var age = "Мне 20 лет";

            Console.WriteLine($"{hello} {name}, {age}.");



            var strArr = new string[] { "apple", "banana", "orange", "kiwi", "mango" };
            foreach (var s in strArr)
            {
                Console.Write($"{s}, ");
            }


            Console.WriteLine();


            foreach (var s in strArr)
            {
                Console.WriteLine(s);
            }


            Console.WriteLine();


            strArr = new string[] { "привет" , "здравствуйте", "двацдать" , "двенадцать", 
                "синус" , "синусоида", "14", "81"};
            for (int i = 0; i < strArr.Length; i+=2)
            {
                Console.WriteLine(strArr[i + 1].Equals(strArr[i]));
            }

            Console.WriteLine();

            List<int> indexes = new();
            indexes.Add(FindFirst(" Хорошо в лесу...", 'о'));
            indexes.Add(FindFirst(" Эх, дороги, пыль да туман", 'о'));
            indexes.Add(FindFirst(" Семнадцать вариантов решения", 'о'));
            Console.WriteLine("индекс О: ");
            foreach (var i in indexes)
            {
                Console.Write($"{i}, ");
            }

            Console.WriteLine();


            indexes.Clear();
            indexes.Add(FindFirst("Где такое интересное место?", 'у'));
            indexes.Add(FindFirst("У меня дома есть ноутбук.", 'у'));
            indexes.Add(FindFirst("Винтажный стул", 'у'));
            Console.WriteLine("\nиндекс У: ");
            foreach (var i in indexes)
            {
                Console.Write($"{i}, ");
            }

            Console.WriteLine();


            var str = "Какой ... день!";
            var insertStr = "замечательный";
            Console.WriteLine("\n" + String.Join(insertStr, str.Split("...")));

            Console.WriteLine();


            str = "Привет, я иду в магазин.";
            strArr = str.Split();
            for (int i = 0; i < strArr.Length; i++)
            {
                if (strArr[i].ToLower() == "магазин")
                    strArr[i] = "парк";
            }
            Console.WriteLine(str);


            Console.WriteLine();


            str = "Сегодня в зоопраке я видел большого жирафа";
            str = str.Replace("большого", "");
            Console.WriteLine(str);


            Console.WriteLine();


            str = "ПрыгаЮщие БуквЫ";
            Console.WriteLine(str.ToLower());
            Console.WriteLine(str.ToUpper() + "\n");


            Console.WriteLine();


            str = "Первый рабочий день прошел на ура";
            foreach (var s in str.Split())
            {
                Console.Write($"{s} : ");
            }
        }
        
        private static int FindFirst(string str, char symbol)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (str.ToCharArray()[i] == symbol)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
