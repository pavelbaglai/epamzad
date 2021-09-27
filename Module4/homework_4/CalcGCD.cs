using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_4
{
    public static class CalcGCD
    {
        public static int multiEuclidGCD(out long timeElapsed, params int[] arr)
        {
            if (arr==null)
                throw new ArgumentNullException(nameof(arr));

            Stopwatch stopWatch = new Stopwatch();

            if (arr.Length < 2)
            {
                timeElapsed = 0;
                return 0;
            }

            stopWatch.Start();
            int b,a = arr[0];
            for (int i = 0; i < arr.Length - 1; i++)
            {
                b = arr[i];
                while (b != 0)
                {
                    int temp = b;
                    b = a % b;
                    a = temp;
                }
            }
                //gcd = classicEuclidGCD(gcd, arr[i + 1]);

            stopWatch.Stop();
            timeElapsed = stopWatch.ElapsedTicks;

            return a;
        }

        public static int multiSteinGCD(out long timeElapsed, params int[] arr)
        {
            if (arr == null)
                throw new ArgumentNullException(nameof(arr));

            Stopwatch stopWatch = new Stopwatch();

            if (arr.Length < 2)
            {
                timeElapsed = 0;
                return 0;
            }

            stopWatch.Start();
            int b, a = arr[0];
            for (int i = 0; i < arr.Length - 1; i++)
            {
                b = arr[i];
                int shift;

                if (a == 0) continue;
                if (b == 0) continue;

                for (shift = 0; ((a | b) & 1) == 0; ++shift)
                {
                    a >>= 1;
                    b >>= 1;
                }

                while ((a & 1) == 0)
                    a >>= 1;

                do
                {
                    while ((b & 1) == 0)
                        b >>= 1;

                    if (a > b)
                    {
                        var t = b;
                        b = a;
                        a = t;
                    }
                    b = b - a;
                } while (b != 0);

                a <<= shift;
            }

            stopWatch.Stop();
            timeElapsed = stopWatch.ElapsedTicks;

            return a;
        }
    }
}
