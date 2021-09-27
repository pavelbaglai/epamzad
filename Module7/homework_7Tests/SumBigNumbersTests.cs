
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using homework_7.Task6;

namespace homework_7Tests
{
    [TestClass()]
    public class SumBigNumbersTests
    {
        [TestMethod()]
        public void Normal_SumBigNumbersTests()
        {
            //arrange
            string result = SumBigNumbers.Add("100000000000000000000000000000000000000000000000000000000000000000000000011", "100000000000000000000000000000000000000000000000000000000000000000000000011");

            //act
            string expected = "200000000000000000000000000000000000000000000000000000000000000000000000022";

            //assert
            Assert.IsTrue(result == expected);
        }

        [DataRow(null,"2432567")]
        [DataRow("2432567", null)]
        [DataRow(null, null)]
        [DataTestMethod]
        public void NullValue_SumBigNumbersTests(string a,string b)
        {
            //assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => SumBigNumbers.Add(a,b));
        }
    }
}