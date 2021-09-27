using homework_2.Task5;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace homework_2
{
    class Program
    {
        static Random random = new Random();

        static int[] CreateRandomArray(int numberElements=100, int range=5000)
        {
            int[] array= new int[numberElements];

            for (int i = 0; i < numberElements; i++)
            {
                array[i] = random.Next(1, range);
            }
            return array;
        }

        static void Main(string[] args)
        {
            //1
            int first = 63;
            int second = 8;
            int startBit = 2;
            int endBit = 4;
            int result = BitsInsert.Exec(first, second, startBit, endBit);
            Console.WriteLine("First: {0}\nSecond: {1}\nChange from bit {2} to bit {3}\nResult: {4}\n",first,second, startBit, endBit, result);
            //2

            int[] array = null;

            int maxElement = SearchMax.Exec(array, array!=null?array.Length-1:0);
            Console.WriteLine("Max number: " + maxElement);

            //3
            //test 
            int[] array2 = {2,8,7,4,9,8};
            //int[] array2 = CreateRandomArray(4, 4);
            int indexValue = FindIndex.Exec(array2);
            Console.WriteLine("\nNumber index: " + indexValue);

            //4
            string str = ("edbca");
            string str2 = ("abcde");
            string concat = FindUniqChar.Exec(str, str2);
            Console.Write("\nFirst string: {0}\nSecond string: {1}\nResult: ",str,str2);
            Console.WriteLine(concat);

            //5
            //test 
            int[] array3 = CreateRandomArray(20, 100);
            List<int> luckyNumbers = FilterLucky.Exec(array3).Distinct().ToList();
            if (luckyNumbers.Count == 0)
            {
                Console.WriteLine("\ndigit 7 not found");
            }
            else
            {
                Console.WriteLine("\ndigit 7 found in next numbers:");
                luckyNumbers.ForEach(Console.WriteLine);
            }
            Console.ReadKey();
        }
    }
}
