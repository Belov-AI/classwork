using System;

namespace SqEquation
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите коэффициенты уравнения ax^2 + bx + c = 0");
            Console.Write("a = ");
            var a = double.Parse(Console.ReadLine());
            Console.Write("b = ");
            var b = double.Parse(Console.ReadLine());
            Console.Write("c = ");
            var c = double.Parse(Console.ReadLine());

            if (a == 0)
            {
                Console.WriteLine("Это не квадратное уравнение (a = 0)");
                Console.ReadKey();
                return;
            }
            else
                Console.WriteLine("Решаем уравнение ({0})x^2 + ({1})x + ({2}) = 0", a, b, c);

            double x1, x2;

            var d = b * b - 4 * a * c;

            if (d > 0)
            {
                var sqrd = Math.Sqrt(d);
                x1 = (-b - sqrd) / (2 * a);
                x2 = (-b + sqrd) / (2 * a);
                Console.WriteLine("Два корня x1 = {0} и x2 = {1}", x1, x2);
            }
            else if (d == 0)
            {
                x1 = -b / (2 * a);
                Console.WriteLine("Один корень x = {0}", x1);
            }
            else
                Console.WriteLine("Корней нет");
            

            Console.ReadKey();
        }
    }
}
