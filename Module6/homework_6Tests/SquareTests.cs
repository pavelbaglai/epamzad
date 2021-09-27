using Microsoft.VisualStudio.TestTools.UnitTesting;
using homework_6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using homework_6.Task2_Shape;

namespace homework_6Tests
{
    [TestClass]
    public class SquareTests
    {
        [TestMethod()]
        public void NormalUseArea_SquareTests()
        {
            //arrange
            var Square = new Square(5);
            var expected = 25;

            //act
            var result = Math.Round(Square.Area(), 1);

            //assert

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void NormalUsePerim_SquareTests()
        {
            //arrange
            var Square = new Square(4);
            var expected = 16;

            //act
            var result = Math.Round(Square.Perimeter(), 1);

            //assert

            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void NegativeVal_SquareTests()
        {
            //arrange
            //act
            //assert

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Square(-5));
        }

    }
}