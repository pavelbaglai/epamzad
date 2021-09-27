using Microsoft.VisualStudio.TestTools.UnitTesting;
using homeWork_11;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homeWork_11.Tests
{
    [TestClass]
    public class FilterTests
    {
        [DataRow("")]
        [DataRow(null)]
        [DataTestMethod]
        public void ConstructorNull_FilterTest(string str)
        {
            Assert.ThrowsException<ArgumentNullException>(() => new Filter(str));
        }

        [TestMethod]
        public void ConstructorIncArg_FilterTest(string str)
        {
            Assert.ThrowsException<ArgumentException>(() => new Filter("-d -ff"));
        }
        [DataRow("-Ivan D -English -20150133 -20180101 -2 -8 -1")]
        [DataRow("-Ivan D -English -20150103 -20181301 -2 -8 -1")]
        [DataRow("-Ivan D -English -20150103 -20181201 -s -8 -1")]
        [DataRow("-Ivan D -English -20150103 -20181201 -2 -s -1")]
        [DataRow("-Ivan D -English -20150103 -20181201 -2 -8 -s")]
        [DataTestMethod]
        public void ConstrIncorArg_FilterTest(string str)
        {
            Assert.ThrowsException<FormatException>(() => new Filter(str));
        }

        [TestMethod]
        public void Parse_FilterTest()
        {
            //arrange
            string StudentName = "Ivan D";
            string Discipline = "English";
            DateTime StartDate = new DateTime(2015, 01, 31, 0, 0, 0);
            DateTime EndDate = new DateTime(2018, 01, 01, 0, 0,0);
            int MinMark = 2;
            int MaxMark = 8;
            int Number = 1;

            //act
            Filter filter = new Filter("-Ivan D -English -20150131 -20180101 -2 -8 -1");
            //assert
            Assert.AreEqual(StudentName,filter.StudentName);
        }
    }
}