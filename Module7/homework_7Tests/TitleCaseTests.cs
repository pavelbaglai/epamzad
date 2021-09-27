using Microsoft.VisualStudio.TestTools.UnitTesting;
using homework_7.Task3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using homework_7.Task2;

namespace homework_7Tests
{
    [TestClass()]
    public class TitleCaseTests
    {
        [TestMethod()]
        public void TestMult_TitleCaseTest()
        {
            //arrange
            var url = new URL();
            string result = TitleCase.Exec("a clash of KINGS", "a an the of");

            //act
            string expected = "A Clash of Kings";

            //assert
            Assert.IsTrue(result==expected);
        }
        [TestMethod()]
        public void NullSecondArg_TitleCaseTest()
        {
            //arrange
            var url = new URL();
            string result = TitleCase.Exec("the quick brown fox");

            //act
            string expected = "The Quick Brown Fox";

            //assert
            Assert.IsTrue(result == expected);
        }
        [DataRow("")]
        [DataRow(null)]
        [DataTestMethod]
        public void NullOrEmptyValue_TitleCaseTest(string str)
        {
            //arrange
            var url = new URL();
            //assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => TitleCase.Exec(str));
        }
    }
}