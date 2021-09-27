using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using homework_10.Task2;
using System.IO;

namespace homework_10Tests.Task2
{
    [TestClass()]
    public class FrequencyWordsTest
    {
        [TestMethod()]
        public void Null_FrequencyWordsTest()
        {
            string fname = null;

            Assert.ThrowsException<FileNotFoundException>(() => FrequencyWords.Exec(fname));
        }

        [TestMethod]
        public void FileNotFound_FrequencyWordsTest()
        {
            //arrange
            string fname = "10.2.SilkRoads1.txt";

            //assert
            Assert.ThrowsException<FileNotFoundException>(() => FrequencyWords.Exec(fname));
        }
        
    }
}