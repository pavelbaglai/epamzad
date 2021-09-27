using Microsoft.VisualStudio.TestTools.UnitTesting;
using homework_7.Task1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_7.Tests
{
    [TestClass]
    public class CustomerTests
    {

        private bool EqCustomer(Customer c1, Customer c2)
        {
            if (c1.ContactPhone == c2.ContactPhone && c1.Name == c2.Name && c1.Revenue == c2.Revenue)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        [TestMethod()]
        public void Normal_CustomerTests()
        {
            var customer = new Customer("Andrey", 2051515416, "89111111111");

            Assert.IsTrue(EqCustomer(customer, new Customer("Andrey", 2051515416, "89111111111")));
        }

        [TestMethod()]
        public void NullNameValue_Test()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Customer("", 2051515416, "89111111111"));
        }

        [TestMethod()]
        public void NegativeRevValue_Test()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Customer("Andrey", -2, "89111111111"));
        }

        [TestMethod()]
        public void NullPhoneValue_Test()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Customer("Andrey", -2, ""));
        }

        [TestMethod()]
        public void InCorrectValueToStringMethod_Test()
        {
            var customer = new Customer("Andrey", 2051515416, "89111111111");

            Assert.ThrowsException<ArgumentException>(() => customer.ToString("Yohoho"));
        }

        [TestMethod()]
        public void CorrectValueToStringMethod_Test()
        {
            //arrange
            var customer = new Customer("Andrey", 2051515416, "89111111111");
            var expected = "Customer record: Andrey, 2,051,515,416.00";

            //act
            var result = customer.ToString("NameRev");

            //assert
            Assert.IsTrue(expected==result);
        }

    }
}