using System;

namespace homework_6.Task2_Shape
{
    public class Rectangle : Shape
    {
        protected double width;
        protected double height;

        public double Height
        {
            get { return height; }
            set
            {
                if (value > 0) height = value;
                else throw new ArgumentOutOfRangeException();
            }
        }

        public double Width
        {
            get { return width; }
            set
            {
                if (value > 0) width = value;
                else throw new ArgumentOutOfRangeException();
            }
        }

        public Rectangle(double height, double width)
        {
            if (height > 0 && width > 0)
            {
                this.height = height;
                this.width = width;
            }
            else throw new ArgumentOutOfRangeException();

        }
        public override double Area()
        {
            return Height * Width;
        }

        public override double Perimeter()
        {
            return 2 * (Height + Width);
        }
    }
}