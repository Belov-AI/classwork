using System;

namespace CheckNumber
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите число");
            var number = double.Parse(Console.ReadLine());

            //if (number > 0)
            //    Console.WriteLine("Число положительное.");
            //else if (number < 0)
            //    Console.WriteLine("Число отрицательное.");
            //else
            //    Console.WriteLine("Число равно 0");

            switch (Math.Sign(number))
            {
                case 1:
                    Console.WriteLine("Число положительное.");
                    break;
                case -1:
                    Console.WriteLine("Число отрицательное.");
                    break;
                default:
                    Console.WriteLine("Число равно 0");
                    break;
            }
            
            Console.ReadKey();
        }
    }
}
