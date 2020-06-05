using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    class Program
    {
        delegate T UnaryOperation<T>(T x);
        static void Main(string[] args)
        {
            var user1 = new User<int>() { Login = "Nick", UserID = 12345 };
            var user2 = new User<string>() { Login = "Sam", UserID = "qwerty" };

            var strings = new[] { "aab", "cba", "bac", "aaaaaaaaaaaa" };

            Console.WriteLine(Max<int>(new int[0]));
            Console.WriteLine(Max(new[] { 1.5 }));
            Console.WriteLine(Max(new[] { 3, 2, 0, -5, 6, 4 }));
            Console.WriteLine(Max(strings));

            var a = new[] { 1, 2, 3, 4, 5 };
            Map(a, x => x * x);
            PrintArray(a);

            Map(a, x => x + 10);
            PrintArray(a);

            Map(strings, s => s.Replace("a", "x"));
            PrintArray(strings);
            

            Console.ReadKey();
        }

        static T Max<T>(T[] source) where T : IComparable
        {
            if (source.Length == 0)
                return default(T);

            var max = source[0];

            for (var i = 1; i < source.Length; i++)
            {
                if (source[i].CompareTo(max) > 0)
                    max = source[i];
            }

            return max;
        }

        static void Map<T>(T[] array, UnaryOperation<T> f)
        {
            for (var i = 0; i < array.Length; i++)
                array[i] = f(array[i]);
        }

        static void PrintArray<T>(T[] array)
        {
            for (var i = 0; i < array.Length; i++)
                Console.Write($"{array[i]} ");

            Console.WriteLine();
        }
    }
}
