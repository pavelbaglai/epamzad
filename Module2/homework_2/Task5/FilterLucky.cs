using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_2.Task5
{
    class FilterLucky
    {
        public static List<int> Exec(int[] array)
        {
            if (array == null)
                throw new NullReferenceException();

            List<int> res = new List<int>();
            if (array != null)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i].ToString().Contains("7"))
                    {
                        res.Add(array[i]);
                    }
                }
            }
            return res;
        }

    }
}
