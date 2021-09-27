using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_2
{
    public class FindIndex
    {
        public static int Exec(int[] array2)
        {
            if (array2==null)
                throw new NullReferenceException();

            int LeftSum = 0;
            int RightSum = 0;
            if (array2 != null)
            {
                for (int i = 1; i < array2.Length; i++)
                {
                    if (i == 1)
                    {
                        LeftSum = array2[i - 1];
                        for (int k = i + 1; k < array2.Length; k++)
                        {
                            RightSum += array2[k];
                        }
                    }
                    else
                    {
                        LeftSum += array2[i - 1];
                        RightSum -= array2[i];
                    }

                    if (LeftSum == RightSum)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

    }
}
