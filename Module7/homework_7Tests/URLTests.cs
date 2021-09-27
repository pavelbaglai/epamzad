using Microsoft.VisualStudio.TestTools.UnitTesting;
using homework_7.Task3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_7Tests
{
    [TestClass()]
    public class URLTests
    {
        [TestMethod()]
        public void Add3Url_AddOrChangeUrlParameterTest()
        {
            //arrange
            var url = new URL();
            string result = url.AddOrChangeUrlParameter("www.example.com?key=oldValue&key2=Value", "key3=newValue3");

            //act
            string expected = "www.example.com?key=oldValue&key2=Value&key3=newValue3";

            //assert
            Assert.IsTrue(result==expected);
        }

        [TestMethod()]
        public void AddUrl_AddOrChangeUrlParameterTest()
        {
            //arrange
            var url = new URL();
            string result = url.AddOrChangeUrlParameter("www.example.com", "key=value");

            //act
            string expected = "www.example.com?key=value";

            //assert
            Assert.IsTrue(result == expected);
        }

        [TestMethod()]
        public void Add2Url_AddOrChangeUrlParameterTest()
        {
            //arrange
            var url = new URL();
            string result = url.AddOrChangeUrlParameter("www.example.com?key=value", "key2=value2");

            //act
            string expected = "www.example.com?key=value&key2=value2";

            //assert
            Assert.IsTrue(result == expected);
        }

        [TestMethod()]
        public void UpdateUrl_AddOrChangeUrlParameterTest()
        {
            //arrange
            var url = new URL();
            string result = url.AddOrChangeUrlParameter("www.example.com?key=oldValue", "key=newValue");

            //act
            string expected = "www.example.com?key=newValue";

            //assert
            Assert.IsTrue(result == expected);
        }


        [DataRow("www.example.com?key=oldValue","")]
        [DataRow("www.example.com?key=oldValue",null)]
        [DataRow("", "key=newValue")]
        [DataRow(null, "key=newValue")]
        [DataTestMethod]
        public void NullOrEmptyValue_AddOrChangeUrlParameterTest(string urlStr, string str)
        {
            //arrange
            var url = new URL();
            //assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => url.AddOrChangeUrlParameter(urlStr, str));
        }
    }
}