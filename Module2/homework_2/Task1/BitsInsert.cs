using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_2
{
    public class BitsInsert
    {
        public static int Exec(int a, int b, int posi, int posj)
        {
            if (posi<0||posj<0||posi>posj) throw new ArgumentOutOfRangeException();

            int[] result = new int[1];

            result[0] = a;
            BitArray a_ByteArr = new BitArray(result);
            result[0] = b;
            BitArray b_ByteArr = new BitArray(result);
            //int index = 0;
            while (posi <= posj)
            {
                a_ByteArr[posi] = b_ByteArr[posi];
                posi++;
                //index++;
            }

            a_ByteArr.CopyTo(result, 0);

            return result[0];
        }
    }
}
