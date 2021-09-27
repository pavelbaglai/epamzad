using Microsoft.VisualStudio.TestTools.UnitTesting;
using homework_6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_6Tests
{
    [TestClass]
    public class PolynomialTests
    {
        [TestMethod()]
        public void NegativeValue_PolynomialTests()
        {
            double[] array = { 10, 1, 8, -6 };

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Polynomial(array));

        }

        [TestMethod]
        public void Empty_PolynomialTests()
        {
            double[] array = { };

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Polynomial(array));
        }

        [TestMethod]
        public void Null_PolynomialTests()
        {
            double[] array = null;

            Assert.ThrowsException<ArgumentNullException>(() => new Polynomial(array));
        }

        [TestMethod]

       // [DataRow(набор_значений_2)]
       // [DataRow(набор_значений_3)]
        public void Plus_PolynomialTests()
        {
            var p1 = new Polynomial(1, 2);
            var p2 = new Polynomial(10, 20, 30, 40);
            Polynomial expected = new Polynomial(11, 22, 30, 40);

            Polynomial result = p1 + p2;
            Assert.IsTrue(expected==result);
        }
        [TestMethod]
        public void Minus_PolynomialTests()
        {
            var p1 = new Polynomial(10, 20, 30, 40); 
            var p2 = new Polynomial(1, 2);
            Polynomial expected = new Polynomial(9, 18, 30, 40);

            Polynomial result = p1 - p2;
            Assert.IsTrue(expected == result);
        }

        [TestMethod]
        public void Multy_PolynomialTests()
        {
            var p1 = new Polynomial(1, 2);
            var p2 = new Polynomial(10, 20, 30, 40);
            Polynomial expected = new Polynomial(10, 40, 70,100, 80);

            Polynomial result = p1 * p2;
            Assert.IsTrue(expected == result);
        }

    }
}