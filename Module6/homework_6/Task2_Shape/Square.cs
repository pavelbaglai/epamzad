using System;

namespace homework_6.Task2_Shape
{
    public class Square : Rectangle
    {
        public new double Width
        {
            get { return width; }
            set
            {
                if (value > 0)
                {
                    height = value;
                    width = value;
                }
                else throw new ArgumentOutOfRangeException();
            }

        }

        public new double Height
        {
            get { return height; }
            set
            {
                if (value > 0)
                {
                    height = value;
                    width = value;
                }
                else throw new ArgumentOutOfRangeException();
            }
        }

        public Square(double side) : base(side, side) { }

        public override double Area()
        {
            return Width * Width;
        }

        public override double Perimeter()
        {
            return 4 * Width;
        }
    }
}