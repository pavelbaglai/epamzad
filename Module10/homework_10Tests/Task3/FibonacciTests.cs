using homework_10;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace homework_10Tests.Task3
{
    [TestClass()]
    public class FibonacciTests
    {
        [DataRow(0)]
        [DataRow(-1)]
        [DataTestMethod]
        public void Null_FibonacciTest(int fibNumbers)
        { 
            //act
            IEnumerable<int> result = Fibonacci.Calc(fibNumbers);
            //assert
            Assert.ThrowsException<ArgumentOutOfRangeException>( () => result.Sum());
        }

        [DataRow(1, 0)]
        [DataRow(2, 1)]
        [DataRow(10, 88)]
        [DataTestMethod]
        public void Norm_FibonacciTest(int fibNumbers, int expected)
        {
            //arrange
            //act
            IEnumerable<int> result = Fibonacci.Calc(fibNumbers);
            //assert
            Assert.AreEqual(result.Sum(x => x), expected);
        }
    }
}