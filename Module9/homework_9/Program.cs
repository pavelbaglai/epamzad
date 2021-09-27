using homework_3;
using homework_4;
using homework_9.Task2;
using Homework3_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_9
{
    class Program
    {
        static void Main(string[] args)
        {
            //1
            /*
            int[] arr = {4,8,12,16,20,24,2,6,10 };
            //int[] arr = null;
            long EuclidtimeElapsed=0, SteintimeElapsed=0;

            try
            {
                int multiEuclidGCD = CalcGCD.Calc(CalcGCD.multiEuclidGCD, out EuclidtimeElapsed, arr);
                Console.WriteLine("Euclid's algorithm result: {0}; Timer result: {1}", multiEuclidGCD, EuclidtimeElapsed);
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e);
            }

            try
            {
                int multiSteinGCD = CalcGCD.Calc(CalcGCD.multiSteinGCD,out SteintimeElapsed, arr);
                Console.WriteLine("Stein's algorithm result: {0}; Timer result: {1}", multiSteinGCD, SteintimeElapsed);

            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e);
            }
            */
            //Task2
            /*
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
            */
            //3

            var msgManager = new Countdown();

            var listener = new Listener();
            listener.Register(msgManager);
            msgManager.SendNewMsg("Hi",3000);
            listener.Unregister(msgManager);

            Console.WriteLine();

            var listener2 = new Listener2();
            listener2.Register(msgManager);
            msgManager.SendNewMsg("Hi there",2000);
            listener2.Unregister(msgManager);

            Console.ReadLine();
        }
    }
}
