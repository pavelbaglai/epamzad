using homework_3;
using Homework3_1;
using Homework3_2;
using System;

namespace Homework3
{
    class Program
    {
        static void Main(string[] args)
        {

            //1
            double eps = 0;
            double dx = 9;
            int x0 = 2;
            Newton newton = new Newton(eps);
            Console.WriteLine("Результат: "+newton.Exec(x0, dx));

            //Task2
            int[,] array = { { 26, 22, 14 }, { 23, 5, 13 }, { 44, 8, 11 } };
            Console.WriteLine("Input array");
            BubbleSortTask.Display(array);

            SumSort ss = new SumSort(true);
            Sorter sorter = new Sorter(ss);

            Console.WriteLine("\r\nIn order of decreasing sums of elements of rows of the matrix");
            sorter.ChangeSortType(new SumSort(false));
            array = sorter.Sort(array);
            BubbleSortTask.Display(array);

            Console.WriteLine("\r\nIn order of increasing sums of elements of rows of the matrix");
            sorter.ChangeSortType(new SumSort(true));
            array = sorter.Sort(array);
            BubbleSortTask.Display(array);

            Console.WriteLine("\r\nIn order of decreasing max element of rows of the matrix");
            sorter.ChangeSortType(new MaxSort(false));
            array = sorter.Sort(array);
            BubbleSortTask.Display(array);

            Console.WriteLine("\r\nIn order of increasing max element of rows of the matrix");
            sorter.ChangeSortType(new MaxSort(true));
            array = sorter.Sort(array);
            BubbleSortTask.Display(array);

            Console.WriteLine("\r\nIn order of decreasing min element of rows of the matrix");
            sorter.ChangeSortType(new MinSort(false));
            array = sorter.Sort(array);
            BubbleSortTask.Display(array);

            Console.WriteLine("\r\nIn order of increasing min element of rows of the matrix");
            sorter.ChangeSortType(new MinSort(true));
            array = sorter.Sort(array);
            BubbleSortTask.Display(array);
            Console.ReadKey();
        }
    }
}