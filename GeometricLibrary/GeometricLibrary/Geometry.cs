﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricLibrary
{
    public class Point
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
            return $"({X:F3}; {Y:F3})";
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

    }

    public class Segment
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
    }

    public class Triangle
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

            if (a.IsInsideSegment(result.BC) ||
                b.IsInsideSegment(result.AC) ||
                c.IsInsideSegment(result.AB))
                throw new ArgumentException();
            else
                return result;
        }
    }
}
