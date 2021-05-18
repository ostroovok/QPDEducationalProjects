using System;
using TasksLogic;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {

            NumbersProgram.Start();

            //Figures f = new Figures(7, 5);
            //f.PrintAll();

            /*
            Console.WriteLine("\t#6");
            Console.WriteLine(Rows.SimpleSumRow(50, 1, 1));
            Console.WriteLine(Rows.SumRow(50, 2, false, 2));
            Console.WriteLine(Rows.SumRow(50, 2, true, 1));
            Console.WriteLine("\t#7");
            Console.WriteLine(Rows.SimpleSumRow(46,4,6));
            Console.WriteLine(Rows.Count);
            Console.WriteLine("\t#8");
            Console.WriteLine(Rows.SumForMaxTerms(10,4,6));
            Console.WriteLine(Rows.Count);
            Console.WriteLine("\t#9");
            Console.WriteLine(Rows.SumForMaxTerms(11, 2, 1));
            Console.WriteLine(Rows.Count);
            Console.WriteLine("\t#10");
            Console.WriteLine(Rows.SumForMaxSum(100, 4, 6));
            Console.WriteLine(Rows.Count);
            Console.WriteLine("\t#11");
            Console.WriteLine(Rows.SumForMaxSum(100, 4, 6, true));
            Console.WriteLine(Rows.Count);
            Console.WriteLine("\t#12");
            Console.WriteLine(Rows.Fibonacci(3));
            */
            ArrayProgram.Start();
        }
    }
}
