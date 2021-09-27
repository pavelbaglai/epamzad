using Microsoft.VisualStudio.TestTools.UnitTesting;
using homework_4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_4Tests
{
    [TestClass]
    public class CalcGCDTests
    {
        [TestMethod]
        public void Normal_multiEuclidGCD()
        {
            // arrange  
            int[] arr = { 4, 8, 12, 16, 20, 24, 2, 6, 10 };
            int expected = 2;
            long EuclidtimeElapsed;

            // act  
            int result = CalcGCD.multiEuclidGCD(out EuclidtimeElapsed, arr);

            // assert  
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Negative_multiEuclidGCD()
        {
            // arrange  
            int[] arr = { -4, -8, 12, 16, 20, 24, 2, 6, 10 };
            int expected = 2;
            long EuclidtimeElapsed;

            // act  
            int result = CalcGCD.multiEuclidGCD(out EuclidtimeElapsed, arr);

            // assert  
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException),
            "A array of null was inappropriately allowed.")]
        public void Null_multiEuclidGCD()
        {
            // arrange  
            int[] arr =null ;
            long EuclidtimeElapsed;

            // act  
            int result = CalcGCD.multiEuclidGCD(out EuclidtimeElapsed, arr);

            // assert  
            //Assert.IsTrue(expected, result);
        }


        [TestMethod]
        public void Normal_multiSteinGCD()
        {
            // arrange  
            int[] arr = { 4, 8, 12, 16, 20, 24, 2, 6, 10 };
            int expected = 2;
            long SteintimeElapsed;

            // act  
            int result = CalcGCD.multiSteinGCD(out SteintimeElapsed, arr);

            // assert  
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void Negative_multiSteinGCD()
        {
            // arrange  
            int[] arr = { -4, 8, -12, 16, 20, 24, 2, 6, 10 };
            int expected = 2;
            long SteintimeElapsed;

            // act  
            int result = CalcGCD.multiEuclidGCD(out SteintimeElapsed, arr);

            // assert  
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException),
            "A array of null was inappropriately allowed.")]
        public void Null_multiSteinGCD()
        {
            // arrange  
            int[] arr = null;
            long SteintimeElapsed;

            // act  
            int result = CalcGCD.multiSteinGCD(out SteintimeElapsed, arr);

            // assert  
            //Assert.IsTrue(expected, result);
        }
    }
}