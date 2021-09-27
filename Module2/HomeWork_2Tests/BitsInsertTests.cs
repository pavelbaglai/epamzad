using homework_2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace HomeWork_2.Tests
{
    [TestClass()]
    public class BitsInsertTests
    {
        [TestMethod]
        public void NormalUse_firstBitZero_BytePasteTest()
        {

            // arrange  
            int first = 63;
            int second = 8;
            int startBit = 0;
            int endBit = 3;
            int expected = 56;

            // act  
            int result = BitsInsert.Exec(first, second, startBit, endBit);

            // assert  
            Assert.AreEqual(expected, result);

        }

        public void NormalUse_firstBitNotZero_BytePasteTest()
        {

            // arrange  
            int first = 63;
            int second = 8;
            int startBit = 2;
            int endBit = 4;
            int expected = 43;

            // act  
            int result = BitsInsert.Exec(first, second, startBit, endBit);

            // assert  
            Assert.AreEqual(expected, result);

        }

        //DONT WORK
        //[DataTestMethod]
        //[DataRow(-1)]
        //[DataRow(0)]
        //[DataRow(1)]
        //
        [TestMethod]
        public void firstNegativeValue_BytePasteTest()
        {

            // arrange  
            int first = -63;
            int second = 8;
            int startBit = 0;
            int endBit = 3;
            int expected = -56;

            // act  
            int result = BitsInsert.Exec(first, second, startBit, endBit);

            // assert  
            Assert.AreEqual(expected, result);

        }

        public void secondNegativeValue_BytePasteTest()
        {

            // arrange  
            int first = 63;
            int second = -8;
            int startBit = 0;
            int endBit = 3;
            int expected = 56;

            // act  
            int result = BitsInsert.Exec(first, second, startBit, endBit);

            // assert  
            Assert.AreEqual(expected, result);

        }

        public void bothNegativeValue_BytePasteTest()
        {

            // arrange  
            int first = -63;
            int second = -8;
            int startBit = 0;
            int endBit = 3;
            int expected = 56;

            // act  
            int result = BitsInsert.Exec(first, second, startBit, endBit);

            // assert  
            Assert.AreEqual(expected, result);

        }

        [TestMethod()]
        public void ZeroValues_BytePasteTest()
        {
            // arrange  
            int first = 0;
            int second = 0;
            int startBit = 0;
            int endBit = 0;
            int expected = 0;

            // act  
            int result = BitsInsert.Exec(first, second, startBit, endBit);

            // assert  
            Assert.AreEqual(expected, result);

        }
        [DataTestMethod]
        [DataRow(-1,10)]
        [DataRow(2,-2)]
        [DataRow(2, 0)]
        public void NegativeValueStBit_BytePasteTest(int stbit, int endbit)
        {
            // arrange  
            int first = 63;
            int second = 8;
            int startBit = stbit;
            int endBit = endbit;

            // act  
            // assert  
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => BitsInsert.Exec(first, second, startBit, endBit)); 
        }
    }
}