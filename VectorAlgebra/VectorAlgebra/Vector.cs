using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorAlgebra
{
    class Vector
    {
        public double X;
        public double Y;

        public Vector(double x, double y)
        {
            X = x;
            Y = y;
        }

        //public Vector Add(Vector v)
        //{
        //    return new Vector(X + v.X, Y + v.Y);
        //}

        public override string ToString()
        {
            return $"({X}; {Y})";
        }

        public static Vector operator + (Vector u, Vector v)
        {
            return new Vector(u.X + v.X, u.Y + v.Y);
        }

        public static Vector operator - (Vector u, Vector v)
        {
            return new Vector(u.X - v.X, u.Y - v.Y);
        }

        public static Vector operator * (double lambda, Vector v)
        {
            return new Vector(lambda * v.X, lambda * v.Y);
        }

        public static Vector operator * (Vector v, double lambda)
        {
            return new Vector(lambda * v.X, lambda * v.Y);
        }

        public static double operator * (Vector u, Vector v)
        {
            return u.X * v.X + u.Y * v.Y;
        }

    }
}
