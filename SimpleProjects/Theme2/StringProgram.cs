using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    public static class StringProgram
    {
        public static void Start()
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
            for (int i = 0; i < strArr.Length; i += 2)
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
            indexes.Add(FindLast("Где такое интересное место?", 'у'));
            indexes.Add(FindLast("У меня дома есть ноутбук.", 'у'));
            indexes.Add(FindLast("Винтажный стул", 'у'));
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
            str = str.Replace("большого ", "");
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
        private static int FindLast(string str, char symbol)
        {
            var result = -1;
            for (int i = 0; i < str.Length; i++)
            {
                if (str.ToCharArray()[i] == symbol)
                {
                    result = i;
                }
            }
            return result;
        }
    }
}
