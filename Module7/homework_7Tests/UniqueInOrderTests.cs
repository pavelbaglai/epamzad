
using Microsoft.VisualStudio.TestTools.UnitTesting;
using homework_7.Task3;
using System;
using System.Linq;
using homework_7.Task4;

namespace homework_7Tests
{
    [TestClass()]
    public class UniqueInOrderTests
    {
        [TestMethod()]
        public void Normal_UniqueInOrderTests()
        {
            //arrange
            char[] result = UniqueInOrder.Exec("AAAABBBCCDAABBB").ToArray();

            //act
            char[] expected = {'A','B','C','D','A','B'};

            //assert
            Assert.IsTrue(result.ToString() == expected.ToString());
        }

        [DataRow(null)]
        [DataTestMethod]
        public void NullValue_UniqueInOrderTests(string str)
        {
            //assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => UniqueInOrder.Exec(str).ToString());
        }
    }
}