using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksLogic
{
    public static class Figures
    {

        public static void PrintAll(int m, int n)
        {
            PrintSquare(m, n);
                Console.WriteLine();
            PrintLeftUpTriangle(m);
                Console.WriteLine();
            PrintLeftDownTriangle(m);
                Console.WriteLine();
            PrintRightUpTriangle(m);
                Console.WriteLine();
            PrintRightDownTriangle(m);
                Console.WriteLine();
            PrintRhombus(n);
        }

        public static void PrintSquare(int m, int n)
        {
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
        public static void PrintRightDownTriangle(int m)
        {
            for (int i = 0; i < m; i++)
            {
                for (int j = m - i - 1; j < m; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
        public static void PrintRightUpTriangle(int m)
        {
            for (int i = m; i > 0; i--)
            {
                for (int j = m - i; j < m; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
        public static void PrintLeftDownTriangle(int m)
        {
            for (int i = m; i > 0; i--)
            {
                for (int j = 0; j < m; j++)
                {
                    if (j >= i - 1)
                        Console.Write("*");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
        public static void PrintLeftUpTriangle(int m)
        {
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (j >= i)
                        Console.Write("*");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
        public static void PrintRhombus(int n)
        {
            for (int i = n; i > 0; i--)
            {
                for (int j = 0, h = n * 2; j < n; j++, h--)
                {
                    if (j >= i - 1)
                        Console.Write("*");
                    if (h <= i - 1)
                        Console.Write("*");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0, h = n * 2; j < n; j++, h--)
                {
                    if (j - 1 > i - 1)
                        Console.Write("*");
                    if (h - 1 < i - 1)
                        Console.Write("*");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }
}
