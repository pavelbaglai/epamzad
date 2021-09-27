using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_4
{
    public static class convertToIEEE754
    {
        public static String Exec(double number)
        {
            return Convert.ToString(BitConverter.DoubleToInt64Bits(number), 2).PadLeft(64, '0');
        }

    }
}
