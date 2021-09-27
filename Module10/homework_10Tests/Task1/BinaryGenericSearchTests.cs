using Microsoft.VisualStudio.TestTools.UnitTesting;
using homework_10.Task1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_10.Tests
{
    [TestClass()]
    public class BinaryGenericSearchTests
    {
        [TestMethod()]
        public void Null_BinaryGenericSearchTest()
        {
            int[] arr = null;

            Assert.ThrowsException<ArgumentNullException>(() => BinaryGenericSearch.Exec(arr.ToList(), 1));
        }

        [TestMethod]
        public void Empty_BinaryGenericSearchTest()
        {
            var arr = new int[] { };

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => BinaryGenericSearch.Exec(arr.ToList(), 1));
        }

        [DataRow(2,0)]
        [DataRow(9,3)]
        [DataRow(1,-1)]
        [DataRow(10,-1)]
        [DataTestMethod]
        public void Boundary_BinaryGenericSearchTest(int searchItem,int expectedResult)
        {
            //arrange
            var arr = new int[] { 2, 3, 7, 9 };

            //act
            var result = BinaryGenericSearch.Exec(arr.ToList(), searchItem);

            //assert
            Assert.AreEqual(expectedResult, result);
        }


        [TestMethod]
        public void RepeatElements_BinaryGenericSearchTest()
        {
            var arr = new double[] { 10,55,88,99,99,115,158 };

            var result = BinaryGenericSearch.Exec(arr.ToList(), 99);

            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void NormUseInt_BinaryGenericSearchTest()
        {
            var arr = new int[] { 5, 8, 13, 17, 336 };

            var result = BinaryGenericSearch.Exec(arr.ToList(), 13);

            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void NormUseDouble_BinaryGenericSearchTest()
        {
            var arr = new double[] { -5,6,7,9,15 };

            var result = BinaryGenericSearch.Exec(arr.ToList(), 9);

            Assert.AreEqual(3, result);
        }

       
        [TestMethod]
        public void OnelElement_BinaryGenericSearchTest()
        {
            var arr = new double[] { 10 };

            var result = BinaryGenericSearch.Exec(arr.ToList(), 10);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void StringValue_BinaryGenericSearchTest()
        {
            //arrange
            var arr = new string[] { "cat", "dog", "bird", "seal" };

            //act
            var result = BinaryGenericSearch.Exec(arr.ToList(), "seal");

            //assert
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void NotExisting_BinaryGenericSearchTest()
        {
            var arr = new string[] { "a", "b", "c", "d" };

            var result = BinaryGenericSearch.Exec(arr.ToList(), "e");

            Assert.AreEqual(-1, result);
        }
    }
}