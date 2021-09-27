using Microsoft.VisualStudio.TestTools.UnitTesting;
using homework_4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_4Tests
{
    [TestClass()]
    public class convertToIEEE754Tests
    {
        [TestMethod()]
        public void Normal_convertToIEEE754Test()
        {
            // arrange  
            String expected = "0100000000100000000000000000000000000000000000000000000000000000";
            // act  		

            double d = 8.0;
            String result = convertToIEEE754.Exec(d);

            // assert  
            Assert.AreEqual(expected, result);
        }
        [TestMethod()]
        public void NullValue_convertToIEEE754Test()
        {
            // arrange  
            String expected = "0000000000000000000000000000000000000000000000000000000000000000";
            // act  		

            double d=0;
            String result = convertToIEEE754.Exec(d);

            // assert  
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void NegativeValue_convertToIEEE754Test()
        {
            // arrange  
            String expected = "1100000000100000000000000000000000000000000000000000000000000000";
            // act  		

            double d = -8.0;
            String result = convertToIEEE754.Exec(d);

            // assert  
            Assert.AreEqual(expected, result);
        }
    }
}