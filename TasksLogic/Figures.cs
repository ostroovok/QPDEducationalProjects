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
        public Size SizeOfFigure { get; set; }
        public int Width { get => SizeOfFigure.Width; }
        public int Height { get => SizeOfFigure.Height; }

        public Figures(Size figureSize)
        {
            SizeOfFigure = figureSize;
        }

        public Figures(int h, int w)
        {
            SizeOfFigure = new Size(h, w);
        }

        public void PrintAll()
        {
            PrintSquare();
                Console.WriteLine();
            PrintLeftUpTriangle();
                Console.WriteLine();
            PrintLeftDownTriangle();
                Console.WriteLine();
            PrintRightUpTriangle();
                Console.WriteLine();
            PrintRightDownTriangle();
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
        public void PrintRightDownTriangle()
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
        public void PrintRightUpTriangle()
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
        public void PrintLeftDownTriangle()
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
        public void PrintLeftUpTriangle()
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
