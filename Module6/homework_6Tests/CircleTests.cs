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
    public class CircleTests
    {
        [TestMethod()]
        public void NormalUseArea_CircleTests()
        {
            //arrange
            var circle = new Circle(5);
            var expected = 78.5;

            //act
            var result = Math.Round(circle.Area(),1);

            //assert

            Assert.AreEqual(expected,result);
        }

        [TestMethod]
        public void NormalUsePerim_CircleTests()
        {
            //arrange
            var circle = new Circle(5);
            var expected = 31.4;

            //act
            var result = Math.Round(circle.Perimeter(),1);

            //assert

            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void NegativeVal_CircleTests()
        {
            //arrange
            //act
            //assert

            Assert.ThrowsException<ArgumentOutOfRangeException>(()=>new Circle(-5));
        }

    }
}