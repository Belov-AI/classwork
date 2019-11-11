using System;


namespace SumOfNumbers
{
    class Program
    {
        static void Main()
        {
            var sum = 0;
            var count = 0;

            Console.WriteLine("Введите максимальное значение суммы");
            var upperBorder = int.Parse(Console.ReadLine());

            do
            {
                Console.Write("Введите целое число: ");
                var number = int.Parse(Console.ReadLine());
                count++;
                sum += number;
            } while (sum < upperBorder);

            Console.WriteLine("Введено {0} {2}. Сумма равна {1}", 
                count, sum, GetWord(count));
            Console.ReadKey();
        }

        static string GetWord(int n)
        {
            var r = n % 10;
            if (n % 100 == 11 || r > 4)
                return "чисел";
            else if (r == 1)
                return "число";
            else
                return "числа";
        }
    }
}
