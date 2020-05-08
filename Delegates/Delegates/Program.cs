using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    delegate double UnaryOperation(double x);
    class Program
    {
        static void Main(string[] args)
        {
            //UnaryOperation f = Math.Sin;
            //Console.WriteLine(f(1.5));
            //f = Square;
            //Console.WriteLine(Square(1.5));

            var table = new Table() { RowNumber = 10, Start = 0, Step = 0.25 };

            table.Print("sin(x)", Math.Sin);
            table.Print("x^2", Square);

            var calc = new Calculator();
            table.Print("x^3", calc.Cube);

            var first = new[] { 1, 2, 3, 4, 5 };
            var second = new[] { 6, 7, 8, 9 };

            PrintIntArray(Zip(first, second, 
                delegate(int x, int y) { return x + y; }
                ));

            PrintIntArray(Zip(first, second, (x, y) => x * y));

            Console.ReadKey();
        }

        static double Square(double x)
        {
            return x * x;
        }

        static int[] Zip(int[] a, int[] b, Func<int, int, int> f)
        {
            var result = new int[Math.Min(a.Length, b.Length)];

            for (var i = 0; i < result.Length; i++)
                result[i] = f(a[i], b[i]);

            return result;
        }

        static void PrintIntArray(int[] array)
        {
            foreach (var elem in array)
                Console.Write($"{elem} ");

            Console.WriteLine("\n");
        }
    }
}
