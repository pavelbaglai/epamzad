using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_4
{
    class Program
    {
        //public static Random randNum = new Random();
        static void Main(string[] args)
        {
            //1
            double d = -8.0;
            Console.WriteLine("ConvertToIEEE754 result:" + convertToIEEE754.Exec(d));

            //2

            //int[] arr = {4,8,12,16,20,24,2,6,10 };
            int[] arr = null;
            long EuclidtimeElapsed, SteintimeElapsed;

            try
            {
                int multiEuclidGCD = CalcGCD.multiEuclidGCD(out EuclidtimeElapsed, arr);
                Console.WriteLine("Euclid's algorithm result: {0}; Timer result: {1}", multiEuclidGCD, EuclidtimeElapsed);
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e);
            }

            try
            {
                int multiSteinGCD = CalcGCD.multiSteinGCD(out SteintimeElapsed, arr);
                Console.WriteLine("Stein's algorithm result: {0}; Timer result: {1}", multiSteinGCD, SteintimeElapsed);

            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e);
            }
            
            
            //3
            String name = "Andrey";
            Console.WriteLine(name.SayHello());
            Console.WriteLine(name.SayGoodbye());
            Console.ReadKey();
        }
    }
}
