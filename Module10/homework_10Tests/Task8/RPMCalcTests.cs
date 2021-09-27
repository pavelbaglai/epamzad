using homework_10.Task8;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace homework_10Tests.Task8
{
    [TestClass]
    public class RPMCalcTests
    {
        [DataRow(null)]
        [DataRow("")]
        [DataTestMethod]
        public void NullArg_RPMCalcTest(string rpn)
        {
            Assert.ThrowsException<ArgumentNullException>(() => RPMCalc.CalculateRPN(rpn));
        }

        [DataRow("5 1 2 + 4 * + 3 - ",14)]
        [DataRow("5 3 +",8)]
        [DataRow("5 3 ^", 125)]
        [DataRow("2 2 pow", 4)]
        [DataRow("2,7183 ln", 1)]
        [DataRow("4 sqrt", 2)]
        [DataRow("4 sqrt", 2)]
        [DataRow("4 4 /", 1)]
        [DataTestMethod]
        public void Norm_RPMCalcTest(string rpn,int expected)
        {
            Assert.AreEqual(expected, Math.Round(RPMCalc.CalculateRPN(rpn)));
        }

    }
}