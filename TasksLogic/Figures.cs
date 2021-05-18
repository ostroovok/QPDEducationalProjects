using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksLogic
{
    public class Figures
    {
        public struct Size
        {
            public int Height { get; }
            public int Width { get; }

            public Size(int height, int width)
            {
                Height = height;
                Width = width;
            }
            public static bool operator == (Size s1, Size s2)
            {
                return s1.Width == s2.Width && s1.Height == s2.Height;
            }
            public static bool operator !=(Size s1, Size s2)
            {
                return s1.Width != s2.Width && s1.Height != s2.Height;
            }
        }
        public Size FigureSize { get; set; }
        public int Width { get => FigureSize.Width; }
        public int Height { get => FigureSize.Height; }

        public Figures(Size figureSize)
        {
            FigureSize = figureSize;
        }

        public Figures(int h, int w)
        {
            FigureSize = new Size(h, w);
        }

        public void PrintAll()
        {
            PrintSquare();
                Console.WriteLine();
            PrintTriangle_LD();
                Console.WriteLine();
            PrintTriangle_LU();
                Console.WriteLine();
            PrintTriangle_RU();
                Console.WriteLine();
            PrintTriangle_RD();
                Console.WriteLine();
            PrintRhombus();
        }

        public void PrintSquare()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
        public void PrintTriangle_RD()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = Height - i - 1; j < Height; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
        public void PrintTriangle_RU()
        {
            for (int i = Height; i > 0; i--)
            {
                for (int j = Height - i; j < Height; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
        public void PrintTriangle_LD()
        {
            for (int i = Height; i > 0; i--)
            {
                for (int j = 0; j < Height; j++)
                {
                    if(j >= i - 1)
                        Console.Write("*");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
        public void PrintTriangle_LU()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    if (j >= i)
                        Console.Write("*");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
        public void PrintRhombus()
        {
            for (int i = Width; i > 0; i--)
            {
                for (int j = 0, h = Width*2; j < Width; j++, h--)
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
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0, h = Width * 2; j < Width; j++, h--)
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
