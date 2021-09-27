using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using homework_6.Task2_Shape;

namespace homework_6
{
    public static class Program
    {
        private static void Main()
        {
            var p1 = new Polynomial(1, 2,3,4);
            //Polynomial p1 = null;
            var p2 = new Polynomial(10, 20, 30, 40);
            Console.WriteLine(p1 + p2);
            Console.WriteLine(p2 - p1);
            Console.WriteLine(p1 * p2);
            Console.WriteLine(p1 == p2);
            Console.WriteLine((p1 * p2).Calculate(1.2d));
            Console.ReadKey();

            Triangle triangle = new Triangle(5, 8, 5);
            var expected = 15;

            //act
            var result = Math.Round(triangle.Area(), 1);
        }
    }
    
}
