using System;

namespace StringInFrame
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Введите строку (Enter - завершение работы)");
                var str = Console.ReadLine();

                if (str == "")
                    break;

                var number = str.Length + 2;

                Console.WriteLine();
                PrintHorizontalBorder(number);
                Console.WriteLine("| {0} |", str);
                PrintHorizontalBorder(number);
                Console.WriteLine();
            }
            
            //Console.ReadKey();
        }

        static void PrintHorizontalBorder(int numberOfStrokes)
        {
            Console.Write("+");

            for (var i = 0; i < numberOfStrokes; i++)
                Console.Write("-");

            Console.WriteLine("+");
        }
    }
}
