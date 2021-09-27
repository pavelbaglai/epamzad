using System;
using System.Collections.Generic;
using System.Linq;
using homework_10.Task4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace homework_10Tests.Task4
{
    [TestClass]
    public class QueueTests
    {
        [TestMethod]
        public void QueueTIntTests()
        {
            //arrange
            var myqueue = new QueueT<int>();

            //act
            myqueue.Enqueue(0);
            myqueue.Enqueue(1);
            myqueue.Enqueue(2);

            //assert
            Assert.AreEqual(0, myqueue.Dequeue());
            Assert.AreEqual(1, myqueue.Dequeue());
            Assert.AreEqual(2, myqueue.Dequeue());
            Assert.AreEqual(0, myqueue.Count());
        }

        [TestMethod]
        public void QueueTStrTests()
        {
            //arrange
            var myqueue = new QueueT<string>();

            //act
            myqueue.Enqueue("0");
            myqueue.Enqueue("1");
            myqueue.Enqueue("2");

            //assert
            Assert.AreEqual("0", myqueue.Dequeue());
            Assert.AreEqual("1", myqueue.Dequeue());
            Assert.AreEqual("2", myqueue.Dequeue());
            Assert.AreEqual(0, myqueue.Count());
        }


        [TestMethod]
        public void QueueTNegative()
        {
            //arrange
            var myqueue = new QueueT<int>();
            
            //act+assert
            Assert.ThrowsException<InvalidOperationException>(() => myqueue.Dequeue());
        }
        [TestMethod]
        public void EnumeratorTest()
        {
            //arrange
            var enumTest = new QueueT<string>();

            //act
            enumTest.Enqueue("First");
            enumTest.Enqueue("Second");
            enumTest.Enqueue("Third");

            //assert
            Assert.AreEqual("First", enumTest.Dequeue());
            Assert.AreEqual("Second", enumTest.Dequeue());
            
        }
    }
}
