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
    public class CsvReaderTests
    {
        [DataRow("")]
        [DataRow(null)]
        [DataTestMethod]
        public void ExecTest(string str)
        {
            Assert.ThrowsException<ArgumentNullException>(() => CsvReader.Exec(str));
        }
        [TestMethod]
        public void ExecTest()
        {
            Assert.ThrowsException<FileNotFoundException>(() => CsvReader.Exec("test.csv" ));
        }
    }
}