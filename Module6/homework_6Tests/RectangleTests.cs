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
    public class RectangleTests
    {
        [TestMethod()]
        public void NormalUseArea_RectangleTests()
        {
            //arrange
            var Rectangle = new Rectangle(5,4);
            var expected = 20;

            //act
            var result = Math.Round(Rectangle.Area(), 1);

            //assert

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void NormalUsePerim_RectangleTests()
        {
            //arrange
            var Rectangle = new Rectangle(5,4);
            var expected = 18;

            //act
            var result = Math.Round(Rectangle.Perimeter(), 1);

            //assert

            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void NegativeVal_RectangleTests()
        {
            //arrange
            //act
            //assert

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Rectangle(-5,4));
        }

    }
}