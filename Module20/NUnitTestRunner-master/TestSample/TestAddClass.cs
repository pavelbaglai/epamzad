using System;
using NUnit.Framework;

namespace TestSample
{
    [TestFixture]
    public class TestAddClass
    {
        [TestCaseSource(nameof(testData))]
        [TestCaseSource(nameof(testData2))]
        public void TestAdditionCases(int x1, int x2, int expectedResult)
        {
            var actualResult = x1 + x2;

            Assert.AreEqual(expectedResult, actualResult);
        }

        private static object[] testData = new object[]
        {
            new int [] { 1, 1, 2},
            new int [] { 1, 2, 3},
            new int [] { 2, 2, 5},
            new int [] { 2, 3, 5},
        };
        private static object[] testData2 = new object[]
        {
            new int [] { 1, 1, 2},
            new int [] { 1, 2, 3},
            new int [] { 2, 2, 5},
            new int [] { 2, 3, 5},
        };
    }
}
