using System;

namespace Array
{
    class Program
    {
        static void Main()
        {
            int[] numbers;
            numbers = new int[4];
            numbers[0] = 1;
            numbers[1] = 2;
            numbers[2] = -3;
            numbers[3] = -4;

            for (var i = 0; i < numbers.Length; i++)
                Console.Write("{0} ", numbers[i]);

            Console.WriteLine();

            var text = new[] { "abcd", "aaaaaaaaaaaaaaaaa", "zzz" };

            foreach (var line in text)
                Console.WriteLine(line);

            Console.WriteLine("Введите число квадратов");
            
            int numberOfSquares;

            while (true)
            {
                //try
                //{
                //    numberOfSquares = int.Parse(Console.ReadLine());
                //    break;
                //}

                //catch
                //{
                //    Console.WriteLine("Надо ввести целое число");
                //}

                if (int.TryParse(Console.ReadLine(), out numberOfSquares))
                    break;
                else
                    Console.WriteLine("Надо ввести целое число");
            }

            
            

            var squares = new int[numberOfSquares];
            for (var i = 0; i < squares.Length; i++)
                squares[i] = (i + 1) * (i + 1);

            foreach (var square in squares)
                Console.WriteLine(square);

                Console.ReadKey();
        }
    }
}
