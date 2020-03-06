using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorAlgebra
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new Vector(1, 2);
            var b = new Vector(-2, 3);

            var c = a + b;
            Console.WriteLine($"{a} + {b} = {c}");

            var d = a - b;
            Console.WriteLine($"{a} - {b} = {d}");

            var f = 2 * a;
            Console.WriteLine($"2 * {a} = {f}");

            f = a * 3;
            Console.WriteLine($"{a} * 3 = {f}");

            var h = a * b;
            Console.WriteLine($"{a} * {b} = {h}");

            Console.ReadKey();
        }
    }
}
