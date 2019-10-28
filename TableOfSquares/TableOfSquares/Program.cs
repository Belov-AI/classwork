using System;

namespace TableOfSquares
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите натуральное число от 1 до 99");
            var number = int.Parse(Console.ReadLine());
            if (number > 99 || number < 1)
            {
                Console.WriteLine("Нужно ввести число от 1 до 99");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("\nТаблица квадратов чисел от 1 до {0}\n", number);

            PrintHorizontalLine(13);
            Console.WriteLine("|  x |  x^2 |");
            PrintHorizontalLine(13);

            for (int i = 1; i <= number; i++)
                Console.WriteLine("| {0,2} | {1,4} |",i, i * i);

            PrintHorizontalLine(13);

                Console.ReadKey();
        }

        static void PrintHorizontalLine(int count)
        {
            for (int i = 0; i < count; i++)
                Console.Write("-");

            Console.WriteLine();
        }      
    }
}
