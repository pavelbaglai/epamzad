
using Microsoft.VisualStudio.TestTools.UnitTesting;
using homework_7.Task3;
using System;
using System.Linq;
using homework_7.Task4;
using homework_7.Task5;

namespace homework_7Tests
{
    [TestClass()]
    public class UniqueInOrderReveresTests
    {
        [TestMethod()]
        public void Normal_UniqueInOrderReveresTests()
        {
            //arrange
            char[] result = UniqueInOrderReverse.Exec("AAAABBBCCDAABBB").ToArray();

            //act
            char[] expected = {'B','A','D','C','B', 'A' };

            //assert
            Assert.IsTrue(result.ToString() == expected.ToString());
        }

        [DataRow(null)]
        [DataTestMethod]
        public void NullValue_UniqueInOrderReveresTests(string str)
        {
            //assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => UniqueInOrderReverse.Exec(str).ToString());
        }
    }
}