using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_10
{
    public class Fibonacci
    {
        public static IEnumerable<int> Calc(int x)
        {
            if (x<=0) throw new ArgumentOutOfRangeException();
            int prev = -1;
            int next = 1;
            for (int i = 0; i < x; i++)
            {
                int sum = prev + next;
                prev = next;
                next = sum;
                yield return sum;
            }
        }
    }
}
