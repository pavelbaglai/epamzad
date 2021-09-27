using System;
using System.Collections.Generic;
using System.Linq;
using homework_10.Task7;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace homework_10Tests.Task7
{
    [TestClass]
    public class BSTTests
    {
        public class StringComparer : IComparer<String>
        {
            public int Compare(string str1, string str2)
            {
                if (str1.Length == str2.Length) return 0;
                if (str1.Length > str2.Length) return 1;
                else return -1;
            }
        }
        
        [TestMethod]
        public void TreeSearch_Test()
        {
            //arrange
            var bst = new BST<int>();

            bst.Add(1);
            bst.Add(2);
            bst.Add(3);
            Assert.IsTrue(bst.Find(1));
        }

        [TestMethod]
        public void TreeSearch_FailTest()
        {
            //arrange
            var bst = new BST<int>();
            bst.Add(1);
            bst.Add(2);
            bst.Add(3);
            Assert.IsFalse(bst.Find(5));
        }

        [TestMethod]
        public void TreePreOrderTrav()
        {
            //arrange
            var bst = new BST<int>();
            var expectedResult = new [] { 1, 2, 3 };
            bst.Add(1);
            bst.Add(2);
            bst.Add(3);

            var result = bst.PreOrder(bst.Head).ToArray();
            Assert.IsTrue((expectedResult.SequenceEqual(result)));
        }

        [TestMethod]
        public void TreePostOrderTrav()
        {
            //arrange
            var bst = new BST<int>();
            var expectedResult = new [] { 3, 2, 1 };
            bst.Add(1);
            bst.Add(2);
            bst.Add(3);

            var result = bst.PostOrder(bst.Head).ToArray();
            Assert.IsTrue((expectedResult.SequenceEqual(result)));
        }

        [TestMethod]
        public void TreeInOrderTrav()
        {
            //arrange
            var bst = new BST<int>();
            bst.Add(1);
            bst.Add(2);
            bst.Add(3);

            var expectedResult = new [] { 1, 2,3 };
            var result = bst.InOrder(bst.Head).ToArray();
            Assert.IsTrue((expectedResult.SequenceEqual(result)));
        }

        [TestMethod]
        public void TreeLengthComparer()
        {
            //arrange
            var comparer = new StringComparer();
            var bst = new BST<string>(comparer);
            bst.Add("hi");
            bst.Add("you");
            bst.Add("foo");

            Assert.IsTrue(bst.Find("foo"));
        }

        [TestMethod]
        public void TreeBookPostOrder()
        {
            //arrange
            var bst = new BST< Book>();
            var book1 = new Book("Title1", "Author1");
            var book2 = new Book("Title2", "Author2");
            var book3 = new Book("Title3", "Author3");
            bst.Add(book1);
            bst.Add(book2);
            bst.Add(book3);

            var expectedResult = new Book[] { book3, book2, book1 };
            var result = bst.PostOrder(bst.Head).ToArray();

            Assert.IsTrue((expectedResult.SequenceEqual(result)));
        }

        [TestMethod]
        public void TreePointPostOrder()
        {
            //arrange
            var bst = new BST<Point>();
            var point1 = new Point(2, 2);
            var point2 = new Point(3, 3);
            var point3 = new Point(5, 6);
            bst.Add(point1);
            bst.Add(point2);
            bst.Add(point3);

            var expectedResult = new Point[] { point3, point2, point1 };
            var result = bst.PostOrder(bst.Head).ToArray();

            Assert.IsTrue((expectedResult.SequenceEqual(result)));
        }

    }
}