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
            Console.Clear();
            var hello = "Привет!";
            var name = "Меня зовут Егор";
            var age = "Мне 20 лет";

            Console.WriteLine($"{hello} {name}, {age}.");
            Console.WriteLine($"{0} {1}, {2}.", hello, name, age);
            Console.WriteLine($"{hello}" + $"{name}" + $"{age}.");
            Console.WriteLine(string.Join(hello, name, age));



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

            string s1 = " Хорошо в лесу...";
            string s2 = " Эх, дороги, пыль да туман";
            string s3 = " Семнадцать вариантов решения";
            indexes.Add(s1.IndexOf('о'));
            indexes.Add(s2.IndexOf('о'));
            indexes.Add(s3.IndexOf('о'));

            Console.WriteLine("индекс О: ");
            foreach (var i in indexes)
            {
                Console.Write($"{i}, ");
            }

            Console.WriteLine();


            indexes.Clear();
            s1 = "Где такое интересное место?";
            s2 = "У меня дома есть ноутбук.";
            s3 = "Винтажный стул";
            indexes.Add(s1.LastIndexOf('у'));
            indexes.Add(s2.LastIndexOf('у'));
            indexes.Add(s3.LastIndexOf('у'));
            Console.WriteLine("\nиндекс У: ");
            foreach (var i in indexes)
            {
                if(i == -1)
                    Console.Write("указанного символа нет в строке, ");
                else
                    Console.Write($"{i}, ");
            }

            Console.WriteLine();


            var str = "Какой ... день!";
            var insertStr = "замечательный";
            Console.WriteLine("\n" + String.Join(insertStr, str.Split("...")));

            Console.WriteLine();


            str = "Привет, я иду в магазин";
            str = str.Replace("магазин", "парк");
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
    }
}
