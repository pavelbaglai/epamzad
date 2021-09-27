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
    public class TriangleTests
    {
        [TestMethod()]
        public void NormalUseArea_TriangleTests()
        {
            //arrange
            var Triangle = new Triangle(5,8,5);
            var expected = 12;

            //act
            var result = Math.Round(Triangle.Area(), 1);

            //assert

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void NormalUsePerim_TriangleTests()
        {
            //arrange
            var Triangle = new Triangle(5,3,5);
            var expected = 13.0;

            //act
            var result = Math.Round(Triangle.Perimeter(), 1);

            //assert

            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void NegativeVal_TriangleTests()
        {
            //arrange
            //act
            //assert

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Triangle(-5,3,4));
        }

    }
}

   
