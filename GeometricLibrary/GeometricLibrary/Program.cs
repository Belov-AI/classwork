using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new Point(1, 1);
            var b = new Point(4, 5);

            var segment = new Segment(a, b);
            segment.PrintInfo();
            Console.WriteLine($"Длина отрезка: {segment.Length}");

            var c = new Point(0, 0);
            var d = new Point(-1, 2);
            var segment2 = Geometry.CreateSegment(c, d);
            segment2.PrintInfo();
            Console.WriteLine($"Длина отрезка: {segment2.Length}");

            a.X = 2;
            a.PrintInfo();
            b.Y = 2;
            b.PrintInfo();
            d = new Point(3, 1.5);
            c.PrintInfo();
            d.PrintInfo();
            segment.PrintInfo();
            segment2.PrintInfo();

            var e = new Point(2, 2);
            Console.WriteLine();
            Console.WriteLine(c.IsInsideSegment(segment));
            Console.WriteLine(d.IsInsideSegment(segment));
            Console.WriteLine(e.IsInsideSegment(segment));
            Console.WriteLine();
            Console.WriteLine(segment.IsContainsPoint(c));
            Console.WriteLine(segment.IsContainsPoint(d));
            Console.WriteLine(segment.IsContainsPoint(e));
            Console.WriteLine();
            Console.WriteLine(Geometry.IsPointInSegment(c, segment));
            Console.WriteLine(Geometry.IsPointInSegment(d, segment));
            Console.WriteLine(Geometry.IsPointInSegment(e, segment));

            var tr = new Triangle(a, b, e);
            tr.PrintInfo();
            Console.WriteLine($"Длина стороны AC = {tr.AC.Length}");
            Console.WriteLine($"Длина стороны BC = {tr.BC.Length}");
            Console.WriteLine($"Длина стороны AB = {tr.AB.Length:F3}");
            Console.WriteLine($"Площадь треугольника = {tr.Area}");

            var p = new Point(3, 2);
            p.PrintInfo();
            p.Rotate(new Point(1, 1), 30);
            Console.WriteLine("После поворота на 30°:");
            p.PrintInfo();

            Console.ReadKey();
        }
    }
}
