using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace homework_7.Task6
{
    public class SumBigNumbers
    {
        static int carry = 0;

        public static string Add1(string a, string b)
        {
            List<string> res = new List<string>();
            StringBuilder myString = new StringBuilder();
            int i = a.Length - 1;
            int j = b.Length - 1;
            int i1, i2;
            while (true)
            {
                if (!int.TryParse(a.Substring(i, 1), out i1)) i1 = 0;
                if (!int.TryParse(b.Substring(j, 1), out i2)) i2 = 0;
                int i3 = i1 + i2 + carry;
                if (i3 > 9)
                {
                    carry = 1;
                    i3 = i3 - 10;
                }
                else carry = 0;
                res.Add(i3.ToString());
                i--; j--;
                if (j < 0&&j<0) break;
                if (i < 0) i = 0;
                if (j < 0) j = 0;
                //if (i < 0)
                //{
                //    res.Add(carry.ToString());
                //    break;
                //}
            }
            res.Reverse();
            foreach (var s in res)
            {
                myString.Append(s.ToString());
            }
            return myString.ToString();

        }

        public static string Add(string a, string b)
        {
            BigInteger number1=0, number2=0;
            bool succeeded1 = BigInteger.TryParse(a, out number1);
            bool succeeded2 = BigInteger.TryParse(b, out number2);
            if (!succeeded1) throw new ArgumentOutOfRangeException(nameof(a));
            if (!succeeded2) throw new ArgumentOutOfRangeException(nameof(b));
            return (number1 + number2).ToString();
        }
    }
}