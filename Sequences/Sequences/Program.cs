using System;


namespace Sequences
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите натуральное число");
            int n = int.Parse(Console.ReadLine());

            var counter = 0;
            var s = new Sequence();

            Console.WriteLine();

            foreach(var elem in s.Fibonacci())
            {
                Console.Write($"{elem} ");
                if (++counter >= n)
                    break;
            }

            Console.ReadKey();
        }
    }
}
