using System;
using TasksLogic;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Theme2
{
    public class FiguresProgram
    {
        public static void Start()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("-help для вывода возможных команд");
                string value = Console.ReadLine();
                int m, n;
                switch (value)
                {
                    case "-help":
                        PrintCommands();
                        break;
                    case "printall":
                        Console.WriteLine("Введите m: ");
                        m = CheckInputValue();
                        Console.Write("Введите n: ");
                        n = CheckInputValue();
                        Figures.PrintAll(m, n);
                        break;
                    case "printsq":
                        Console.WriteLine("Введите m: ");
                        m = CheckInputValue();
                        Console.Write("Введите n: ");
                        n = CheckInputValue();
                        Figures.PrintSquare(m, n);
                        break;
                    case "printtrianglerd":
                        Console.Write("Введите n: ");
                        n = CheckInputValue();
                        Figures.PrintRightDownTriangle(n);
                        break;
                    case "printtriangleru":
                        Console.Write("Введите n: ");
                        n = CheckInputValue();
                        Figures.PrintRightUpTriangle(n);
                        break;
                    case "printtriangleld":
                        Console.Write("Введите n: ");
                        n = CheckInputValue();
                        Figures.PrintLeftDownTriangle(n);
                        break;
                    case "printtrianglelu":
                        Console.Write("Введите n: ");
                        n = CheckInputValue();
                        Figures.PrintLeftUpTriangle(n);
                        break;
                    default:
                        Console.WriteLine("Такой команды не существует, либо вы не можете ее вызвать, пока не закончите предыдущее действие");
                        break;
                }
            }
        }
        public static void PrintCommands()
        {
            Console.WriteLine(
                $"m и n - целые неотрицательные числа\n" +
                $"printall - нарисовать все\n" +
                $"printsq - нарисовать прямоугольник со сторонами n и m\n" +
                $"printtrianglerd - треугольник с катетом m, гипотенузой вправо, основанием вниз\n" +
                $"printtriangleru - треугольник с катетом m, гипотенузой вправо, основанием вверх\n" +
                $"printtriangleld - треугольник с катетом m, гипотенузой влево, основанием вниз\n" +
                $"printtrianglelu - треугольник с катетом m, гипотенузой влево, основанием вверх\n" +
                $"printrh - нарисовать ромб с стороной n\n"
                );
        }
        public static int CheckInputValue()
        {
            var value = Console.ReadLine();
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
    }
}
