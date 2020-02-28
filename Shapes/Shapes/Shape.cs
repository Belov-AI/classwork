using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace Shapes
{
    public class Point
    {
        public float X;
        public float Y;

        public Point(float x, float y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"({X}; {Y})";
        }
    }

    public abstract class Shape
    {
        public Color FillColor { get; set; }
        public Color OutlineColor { get; set; }

        public abstract void PrintInfo();

        public abstract float Area { get; }

    }

    public class Circle : Shape
    {
        public Point Center;

        private float raduis;
        public float Radius
        {
            get { return raduis; }

            set
            {
                if (value < 0)
                {
                    //Console.WriteLine("Радиус не может быть отрицательным");
                    throw new InvalidOperationException("Радиус не может быть отрицательным");
                }
                else
                    raduis = value;
            }
        }

        public Circle(Point c, float r)
        {
            Center = c;
            Radius = r;
        }
        

        public override void PrintInfo()
        {
            //throw new NotImplementedException();
            Console.WriteLine($"Круг радиуса {Radius} с центром в точке {Center}.");
            Console.WriteLine($"Площадь круга: {Area:F2} кв. ед.");
        }

        public override float Area
        {
            get
            {
                return (float)(Math.PI * Radius * Radius);
            }
        }


    }

    public class Rectangle : Shape
    {
        public Point A;
        public Point B;

        public Rectangle(Point a, Point b)
        {
            A = a;
            B = b;
        }

        public override float Area
        {
            get
            {
                return (float)Math.Abs((A.X-B.X)*(A.Y-B.Y));
            }
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"Прямоугольник с вершинами {A}, ({A.X}; {B.Y}), {B}, ({B.X}; {A.Y})");
            Console.WriteLine($"Площадь прямоугольника: {Area} кв. ед.");
        }
    }
}
