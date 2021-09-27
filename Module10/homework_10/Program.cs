using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using homework_10.Task1;
using homework_10.Task2;
using homework_10.Task4;
using homework_10.Task7;
using homework_10.Task8;

namespace homework_10
{
    class Program
    {
        static void Main(string[] args)
        {
            //1
            //int[] arr = {1,2,5,9,11,55,88,99,152,158,178,199};
            //int element = 152;
            //var index = BinaryGenericSearch.Exec(arr.ToList(),152);
            //System.Console.WriteLine("Элемент {0} находится после позиции {1}",element,index);
            //2
            //string fname = "10.2.SilkRoads1.txt";
            //Dictionary<string, int> result = FrequencyWords.Exec(fname);
            //foreach (var i in result) Console.WriteLine("Word: {0,-20}Freq: {1}", i.Key, i.Value);
            //3
            //int fibNumbers = 0;
            //var sum = Fibonacci.Calc(fibNumbers);
            //Console.WriteLine("Sequence of {0} Fibonacci's numbers is: ", fibNumbers);
            //foreach (var i in sum) Console.Write(i + " ");
            //Console.ReadKey();

            //4
            QueueT<int> myQueue = new QueueT<int>();
            for (int i = 1; i < 5; i++)
            {
                myQueue.Enqueue(i);
            }
            myQueue.Dequeue();
            myQueue.Enqueue(6);
            myQueue.Dequeue();

            for (int i = 0; i < 2; i++)
            {
                myQueue.Enqueue(i);
            }

            //7
            //var bst = new BST<int>();

            //bst.Add(1);
            //bst.Add(2);
            //bst.Add(3);
            //bst.Add(4);
            //bst.Add(5);
            //bst.Remove(2);
            //var result = bst.PreOrder().ToArray();
            //8

            //Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            //string rpn = "5 1 2 + 4 * + 3 - ";
            //Console.WriteLine("\n{0}", rpn);
            //decimal result1 = RPMCalc.CalculateRPN(rpn);
            //Console.WriteLine("Result is {0}", result1);
            //Console.ReadKey();
        }
    }
}
