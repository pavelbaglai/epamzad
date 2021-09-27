using System;
using System.Collections.Generic;

namespace homework_10.Task1
{
    public static class BinaryGenericSearch
    {
        public static int Exec<T>(List<T> list, T item)
        {
            if (list==null) throw new ArgumentNullException();
            if (list.Count == 0) throw new ArgumentOutOfRangeException();

            int min = 0, max = list.Count - 1, midpoint;

            while (min <= max)
            {
                midpoint = min + (max - min) / 2;
                T midValue = list[midpoint];
                
                if (((IComparable)(midValue)).CompareTo(item)==0)
                {
                    return midpoint;
                }
                else if (((IComparable)(midValue)).CompareTo(item)>0)
                    max = midpoint - 1;
                else
                    min = midpoint + 1;
            }

            return -1;

        }
    }
}