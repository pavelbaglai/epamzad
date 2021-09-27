using System;

namespace homework_6.Task2_Shape
{
    public class Circle : Shape
    {
        protected double radius;

        public double Radius
        {
            get { return radius; }
            set
            {
                if (value > 0) radius = value;
                else throw new ArgumentOutOfRangeException();
            }
        }

        public Circle(double radius)
        {
            if (radius > 0) this.radius = radius;
            else throw new ArgumentOutOfRangeException();
        }

        public override double Area()
        {
            return Math.PI * Math.Pow(Radius, 2.0);
        }

        public override double Perimeter()
        {
            return 2 * Math.PI * Radius;
        }
    }
}