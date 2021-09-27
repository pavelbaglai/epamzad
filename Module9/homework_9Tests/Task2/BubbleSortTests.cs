using System;
using homework_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace homework_9Tests
{
    [TestClass()]
    public class BubbleSortTests
    {
        private bool AreEqualse(int[,] arr1, int[,] arr2)
        {
            if ((arr1.GetLength(0) != arr2.GetLength(0)) || (arr1.GetLength(1) != arr2.GetLength(1))) return false;
            for (int i = 0; i < arr1.GetLength(0); i++)
            {
                for (int j = 0; j < arr1.GetLength(1); j++)
                {
                    if (arr1[i, j] != arr2[i, j]) return false;
                }
            }
            return true;
        }
        [TestMethod()]
        public void BubbleSort_DescSum_Test()
        {
            // arrange  
            int[,] expectedarray = { { 7, 8, 9 }, { 4, 5, 6 }, { 1, 2, 3 } };
            int[,] result = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

            // act  
            SumSort ss = new SumSort(true);
            Sorter sorter = new Sorter(ss);
            sorter.ChangeSortType(new MinSort(false));
            result = sorter.Sort(result);

            // assert  

            Assert.IsTrue(AreEqualse(expectedarray,result));
        }
        
        [TestMethod()]
        public void BubbleSort_AscSum_Test()
        {
            // arrange  
            int[,] expectedarray = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            int[,] result = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

            // act  
            SumSort ss = new SumSort(true);
            Sorter sorter = new Sorter(ss);
            sorter.ChangeSortType(new MinSort(true));
            result = sorter.Sort(result);

            // assert  
            Assert.IsTrue(AreEqualse(expectedarray, result));
        }
        [TestMethod()]
        public void BubbleSort_DescMax_Test()
        {
            // arrange  
            int[,] result = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            int[,] expectedarray = { { 7, 8, 9 }, { 4, 5, 6 }, { 1, 2, 3 } };

            // act  
            SumSort ss = new SumSort(true);
            Sorter sorter = new Sorter(ss);
            sorter.ChangeSortType(new MaxSort(false));
            result = sorter.Sort(result);

            // assert  

            Assert.IsTrue(AreEqualse(expectedarray, result));
        }
        [TestMethod()]
        public void BubbleSort_AscMax_Test()
        {
            // arrange  
            int[,] result = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            int[,] expectedarray = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            // act  
            SumSort ss = new SumSort(true);
            Sorter sorter = new Sorter(ss);
            sorter.ChangeSortType(new MaxSort(true));
            result = sorter.Sort(result);

            // assert  

            Assert.IsTrue(AreEqualse(expectedarray, result));
        }
        [TestMethod]
        public void BubbleSort_DescMin_Test()
        {
            // arrange  
            int[,] result = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            int[,] expectedarray = { { 7, 8, 9 }, { 4, 5, 6 }, { 1, 2, 3 } };

            // act  
            SumSort ss = new SumSort(true);
            Sorter sorter = new Sorter(ss);
            sorter.ChangeSortType(new MinSort(false));
            result = sorter.Sort(result);

            // assert  

            Assert.IsTrue(AreEqualse(expectedarray, result));
        }
        [TestMethod]
        public void BubbleSort_AscMin_Test()
        {
            // arrange  
            int[,] result = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            int[,] expectedarray = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            // act  
            SumSort ss = new SumSort(true);
            Sorter sorter = new Sorter(ss);
            sorter.ChangeSortType(new MinSort(true));
            result = sorter.Sort(result);

            // assert  

            Assert.IsTrue(AreEqualse(expectedarray, result));
        }

        [TestMethod]
        public void BubbleSort_EmptyArr_Test()
        {
            // arrange  
            int[,] result = { };
            // act  
            SumSort ss = new SumSort(true);
            Sorter sorter = new Sorter(ss);
            sorter.ChangeSortType(new MaxSort(true));

            // assert  
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => sorter.Sort(result));
        }

        public void BubbleSort_NullArr_Test()
        {
            // arrange  
            int[,] result = null;
            // act  
            SumSort ss = new SumSort(true);
            Sorter sorter = new Sorter(ss);
            sorter.ChangeSortType(new MaxSort(true));
            result = sorter.Sort(result);

            // assert  
            Assert.ThrowsException<NullReferenceException>(() => sorter.Sort(result));
        }
        
    }
}
