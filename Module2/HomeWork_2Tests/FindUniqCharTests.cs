using Microsoft.VisualStudio.TestTools.UnitTesting;
using homework_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_2.Tests
{
    [TestClass()]
    public class FindUniqCharTests
    {
        [TestMethod()]
        public void FindUniqChar_TwoArgs_Test()
        {
            // arrange  
            string str = ("abhcir");
            string str2 = ("hi");
            
            string expected = "abchir";

            // act  
            string result = FindUniqChar.Exec(str, str2);

            // assert  
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void FindUniqChar_WitNullArg_Test()
        {
            // arrange  
            string str = "abhcir";
            string str2=null;

            string expected = "abchir";

            // act  
            string result = FindUniqChar.Exec(str, str2);

            // assert  
            Assert.AreEqual(expected, result);
        }
    }
}