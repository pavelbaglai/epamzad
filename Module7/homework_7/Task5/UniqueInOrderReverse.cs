using System;
using System.Collections.Generic;
using System.Linq;

namespace homework_7.Task5
{
    public static class UniqueInOrderReverse
    {
        public static IEnumerable<T> Exec<T>(IEnumerable<T> str)
        {
            if (str == null) throw new ArgumentOutOfRangeException(nameof(str));

            List<T> result = new List<T>();
            var strList = str.ToList();
            var lastElem = strList[0];
            result.Add(strList[0]);
            for (int i = 0; i < strList.Count; i++)
            {
                if (!lastElem.Equals(strList[i]))
                {
                    lastElem = strList[i];
                    result.Add(strList[i]);
                }

            }

            result.Reverse();
            return result;
        }
    }
}