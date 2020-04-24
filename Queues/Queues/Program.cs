using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queues
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Ведите количество знаков числа");
            var k = int.Parse(Console.ReadLine());
            var minNumber = (int)Math.Pow(10, k - 1);
            var maxNumber = (int)Math.Pow(10, k);

            Console.WriteLine("Введимте количество чисел");
            var n = int.Parse(Console.ReadLine());

            Console.WriteLine();

            var numbers = new Queue<int>[10];

            for (var i = 0; i < numbers.Length; i++)
                numbers[i] = new Queue<int>();

            var rnd = new Random();

            for(var i = 0; i < n; i++)
            {
                int m = rnd.Next(minNumber, maxNumber);
                Console.Write($"{m} ");
                numbers[m % 10].Enqueue(m);
            }

            Console.WriteLine("\n");

            for(var i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine($"Числа, оканчивающиеся на {i}");

                while (numbers[i].Count > 0)
                    Console.Write($"{numbers[i].Dequeue()} ");

                Console.WriteLine("\n");
            }


            Console.ReadKey();
        }
    }
}
