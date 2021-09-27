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
    public class SearchMaxTests
    {
        [TestMethod()]
        public void Normal_SearchMaxTest()
        {
            // arrange  
            int[] array = {5, 821, 589, 4, 1, 0};
            Int16 expected = 821;

            // act  
            int result = SearchMax.Exec(array, array.Length - 1);

            // assert  
            Assert.AreEqual(expected, result);
        }
        [TestMethod()]
        public void Negative_SearchMaxTest()
        {
            // arrange  
            int[] array = { 5, -821, 589, 4, 1, 0 };
            Int16 expected = 589;

            // act  
            int result = SearchMax.Exec(array, array.Length - 1);

            // assert  
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException),
            "A array of null was inappropriately allowed.")]
        public void Null_SearchMaxTest()
        {
            // arrange  
            int[] array = null;

            // act  
            int maxElement = SearchMax.Exec(array, array != null ? array.Length - 1 : 0);

        }
        [TestMethod()]
        public void LengtEq0_SearchMaxTest()
        {
            // arrange  
            int[] array = {};
            int expected = -1;

            // act  
            int result = SearchMax.Exec(array, array.Length - 1);

            // assert  
            Assert.AreEqual(expected, result);
        }
    }
}