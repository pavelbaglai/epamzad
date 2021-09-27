using Microsoft.VisualStudio.TestTools.UnitTesting;
using homework_4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_9Tests
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
            int result = CalcGCD.Calc(CalcGCD.multiEuclidGCD, out EuclidtimeElapsed, arr);

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
            int result = CalcGCD.Calc(CalcGCD.multiEuclidGCD, out EuclidtimeElapsed, arr);

            // assert  
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Null_multiEuclidGCD()
        {
            // arrange  
            long EuclidtimeElapsed;
            int[] arr = null;
            // assert  
            Assert.ThrowsException<ArgumentNullException>(() => CalcGCD.Calc(CalcGCD.multiEuclidGCD, out EuclidtimeElapsed, arr));
        }

        //
        [TestMethod]
        public void Normal_multiSteinGCD()
        {
            // arrange  
            int[] arr = { 4, 8, 12, 16, 20, 24, 2, 6, 10 };
            int expected = 2;
            long SteintimeElapsed;

            // act  
            int result = CalcGCD.Calc(CalcGCD.multiSteinGCD, out SteintimeElapsed, arr);

            // assert  
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ZeroValue_multiSteinGCD()
        {
            // arrange  
            int[] arr = { 0, 8, 12, 16, 20, 24, 2, 6, 10 };
            int expected = 0;
            long SteintimeElapsed;

            // act  
            int result = CalcGCD.Calc(CalcGCD.multiSteinGCD, out SteintimeElapsed, arr);

            // assert  
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Null_multiSteinGCD()
        {
            // arrange  
            long SteintimeElapsed;
            int[] arr = null;
            // assert  
            Assert.ThrowsException<ArgumentNullException>(() => CalcGCD.Calc(CalcGCD.multiSteinGCD, out SteintimeElapsed, arr));
        }
    }
}