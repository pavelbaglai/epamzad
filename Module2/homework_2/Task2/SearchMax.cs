using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_2
{
    public class SearchMax
    {
        public static int Exec(int[] array, int counter)
        {
            if (array==null) throw new ArgumentNullException();
            if (array.Length >0)
            {
                if (counter > 0)
                {
                    return Math.Max(array[counter], Exec(array, counter - 1));
                }
                else
                {
                    return array[0];
                }
            }
            else
            {
                return -1;
            }
        }
    }
}
