using System;

namespace homework_6.Task2_Shape
{
    public class Triangle : Shape
    {
        protected double a;
        protected double b;
        protected double c;

        public double A
        {
            get { return a; }
            set
            {
                if (value > 0 && value < B + C) a = value;
                else throw new ArgumentOutOfRangeException();
            }
        }

        public double B
        {
            get { return b; }
            set
            {
                if (value > 0 && value < A + C) b = value;
                else throw new ArgumentOutOfRangeException();
            }
        }

        public double C
        {
            get { return c;}
            set
            {
                if (value > 0 && value < B + A) c = value;
                else throw new ArgumentOutOfRangeException();
            }
        }

        public Triangle(double aSide, double bSide, double cSide)
        {
            if (aSide > 0 && bSide > 0 && cSide > 0 && (aSide < bSide + cSide) && (bSide < aSide + cSide) && (cSide < aSide + bSide))
            {
                a = aSide;
                b = bSide;
                c = cSide;
            }
            else throw new ArgumentOutOfRangeException();
        }

        public override double Area()
        {
            var per = Perimeter() / 2.0;
            return Math.Sqrt(per * (per - A) * (per - B) * (per - C));
        }

        public override double Perimeter()
        {
            return A + B + C;
        }
    }
}