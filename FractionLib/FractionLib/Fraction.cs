using System;


namespace FractionLib
{
    public struct Fraction
    {
        public int Numerator;

        private int denominator;

        public int Denominator
        {
            get { return denominator; }

            set
            {
                if (value > 0)
                    denominator = value;
                else
                    throw new InvalidOperationException();
            }

        }

        public double Value
        {
            get
            {
                return (double)Numerator / Denominator;
            }
        }

        public Fraction(int p, int q)
        {
            Numerator = p;

            if (q > 0)
                denominator = q;
            else
                throw new ArgumentException();
        }

        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }

        public override bool Equals(object obj)
        {
            var f = (Fraction)obj;

            return Numerator * f.Denominator == Denominator * f.Numerator;
        }

        public static bool operator == (Fraction a, Fraction b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Fraction a, Fraction b)
        {
            return !a.Equals(b);
        }

        public static Fraction operator + (Fraction a, Fraction b)
        {
            return new Fraction(
                a.Numerator * b.Denominator + a.Denominator * b.Numerator,
                a.Denominator * b.Denominator);
        }
    }
}
