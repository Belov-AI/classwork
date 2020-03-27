using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricLibrary
{
    public class Point : ICloneable
    {
        public double X;
        public double Y;

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public bool IsInsideSegment(Segment s)
        {
            return (X - s.A.X) * (s.B.Y - Y) - (Y - s.A.Y) * (s.B.X - X) == 0 &&
                (X - s.A.X) * (s.B.X - X) + (Y - s.A.Y) * (s.B.Y - Y) >= 0;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Точка {this}");
        }

        public override string ToString()
        {
            return $"({X}; {Y})";
        }

        public void Rotate(Point center, double angleInDegrees)
        {
            var angleInRadians = angleInDegrees * Math.PI / 180;

            var xNew = (X - center.X) * Math.Cos(angleInRadians) -
                (Y - center.Y) * Math.Sin(angleInRadians) + center.X;

            var yNew = (X - center.X) * Math.Sin(angleInRadians) +
                (Y - center.Y) * Math.Cos(angleInRadians) + center.X;

            X = xNew;
            Y = yNew;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    public class Segment : ICloneable, IEnumerable 
    {
        public Point A;
        public Point B;

        public double Length
        {
            get
            {
                return Math.Sqrt((B.X - A.X) * (B.X - A.X) +
                    (B.Y - A.Y) * (B.Y - A.Y));
            }
        }

        public Segment(Point a, Point b)
        {
            A = a;
            B = b;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Отрезок с концами в точках {A}, {B}");
        }

        public bool IsContainsPoint(Point p)
        {
            return p.IsInsideSegment(this);
        }

        public void Rotate(Point center, double angleInDegrees)
        {
            A.Rotate(center, angleInDegrees);
            B.Rotate(center, angleInDegrees);
        }

        public object Clone()
        {
            return new Segment(A.Clone() as Point, B.Clone() as Point);
        }

        public IEnumerator GetEnumerator()
        {
            return new SegmentEnumerator(this);
        }
    }

    class SegmentEnumerator : IEnumerator
    {
        private Point current;
        private Segment segment;
        public object Current
        {
            get
            {
                return current;
            }
        }

        public SegmentEnumerator(Segment s)
        {
            segment = s;
            current = null;
        }

        public bool MoveNext()
        {
            var result = true;

            if (current == segment.B)
                result = false;
            else if (current == null)
                current = segment.A;
            else
                current = segment.B;

            return result;
        }

        public void Reset()
        {
            current = null;
        }
    }

    public class Triangle : ICloneable, IEnumerable
    {
        public Point A;
        public Point B;
        public Point C;

        public Segment AB
        {
            get { return new Segment(A, B); }
        }

        public Segment AC
        {
            get { return new Segment(A, C); }
        }

        public Segment BC
        {
            get { return new Segment(B, C); }
        }

        public double Area
        {
            get
            {
                var a = AB.Length;
                var b = BC.Length;
                var c = AC.Length;

                var p = (a + b + c) / 2;
                return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            }
        }

        public Triangle(Point a, Point b, Point c)
        {
            A = a;
            B = b;
            C = c;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Треугольник с вершинами в точках {A}, {B} и {C}");
        }

        public void Rotate(Point center, double angleInDegrees)
        {
            A.Rotate(center, angleInDegrees);
            B.Rotate(center, angleInDegrees);
            C.Rotate(center, angleInDegrees);
        }

        public object Clone()
        {
            return new Triangle(A.Clone() as Point, B.Clone() as Point,
                C.Clone() as Point);
        }

        public IEnumerator GetEnumerator()
        {
            yield return this.A;
            yield return this.B;
            yield return this.C;
        }
    }

    public static class Geometry
    {
        public static Segment CreateSegment(Point a, Point b)
        {
            return new Segment(a, b);
        }

        public static bool IsPointInSegment(Point p, Segment s)
        {
            return p.IsInsideSegment(s);
        }

        public static Triangle CreateTriangle(Point a, Point b, Point c)
        {
            var result = new Triangle(a, b, c);

            if (result.AB.Length >= result.BC.Length + result.AC.Length ||
                result.BC.Length >= result.AB.Length + result.AC.Length ||
                result.AC.Length >= result.AB.Length + result.BC.Length) 
                throw new ArgumentException();
            else
                return result;
        }
    }
}
