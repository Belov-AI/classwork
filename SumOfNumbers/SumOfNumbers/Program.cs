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

            while (sum < upperBorder)
            {
                Console.Write("Введите целое число: ");
                var number = int.Parse(Console.ReadLine());
                count++;
                sum += number;
            }

            Console.WriteLine("Введено {0} чисел. Сумма равна {1}", count, sum);
            Console.ReadKey();
        }
    }
}
