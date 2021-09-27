using System;

namespace Homework3_2
{
    public static class BubbleSortTask
    {

        public static void Display(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                Console.Write("\r\n");
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
            }
        }
    }
}