using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_3
{
    public delegate int DelegateSort (int comp1, int comp2);

    public class Sorter
    {
        ISortTypes sorter;
        public DelegateSort Delsorter;

        public Sorter()
        {
        }

        public Sorter(ISortTypes sorter)
        {
            this.sorter = sorter;
            Delsorter = sorter.Compare;
        }

        public void ChangeSortType(ISortTypes sorter)
        {
            this.sorter = sorter;
            Delsorter = sorter.Compare;
        }

        public int[,] Sort(int[,] arr)
        {
            if (arr == null) throw new NullReferenceException();
            if (arr.Length == 0) throw new ArgumentOutOfRangeException();

            for (int k = 0; k < arr.GetLength(0); k++)
            {
                int prev = arr[0, 0], curr;
                for (int j = 1; j < arr.GetLength(1); j++)
                {
                    prev = Delsorter(arr[0, j], prev);
                }

                for (int i = 1; i < arr.GetLength(0) - k; i++)
                {
                    curr = arr[i, 0];
                    for (int j = 1; j < arr.GetLength(1); j++)
                    {
                        curr = Delsorter(arr[0, j], curr);
                    }

                    if (sorter.AscFlag)
                    {
                        if (curr < prev)
                        {
                            for (int j = 0; j < arr.GetLength(1); j++)
                            {
                                int tmp = arr[i, j];
                                arr[i, j] = arr[i - 1, j];
                                arr[i - 1, j] = tmp;
                            }
                        }
                        else prev = curr;
                    }
                    else
                    {
                        if (curr > prev)
                        {
                            for (int j = 0; j < arr.GetLength(1); j++)
                            {
                                int tmp = arr[i, j];
                                arr[i, j] = arr[i - 1, j];
                                arr[i - 1, j] = tmp;
                            }
                        }
                        else prev = curr;
                    }
                }
            }
            return arr;
        }

    }
}
