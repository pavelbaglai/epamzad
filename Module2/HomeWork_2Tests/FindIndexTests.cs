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
    public class FindIndexTests
    {
        [TestMethod()]
        public void Normal_FindIndexTest()
        {
            // arrange  
            int[] array = { 2, 8, 7, 4, 9, 8 };
            Int16 expected = 3;

            // act  
            int result = FindIndex.Exec(array);

            // assert  
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void NegativeValue_FindIndexTest()
        {
            // arrange  
            int[] array = { -2, 8, -7, 4, 8,-9 };
            Int16 expected = 3;

            // act  
            int result = FindIndex.Exec(array);

            // assert  
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void NullDim_FindIndexTest()
        {
            // arrange  
            int[] array = {};
            int expected = -1;

            // act  
            int result = FindIndex.Exec(array);
            
            // assert  
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void Null_FindIndexTest()
        {
            // arrange  
            int[] array = null;

            // act  
            // assert  
            Assert.ThrowsException<NullReferenceException>(() => FindIndex.Exec(array));
        }

    }
}