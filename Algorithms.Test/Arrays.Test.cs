using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Test
{
    [TestFixture]
    [Category("Array Tests")]
    public class TestArrays
    {
        ArrayOperations operations;
        [SetUp]
        public void MySetUp()
        {
            // Initialize the array heree
            operations = new ArrayOperations();           
        }
        [Test]
        public void TestEmptyArrays()
        {
            int[] A = new int[0];
            int[] B = new int[0];

            int[] C = operations.Intersect(A, B);
            Assert.AreEqual(0, C.Length);
        }
        [Test]
        public void TestDifferentArrays()
        {
            int[] A = new int[] { 2, 4, 6 };
            int[] B = new int[] { 1, 3, 5 };
            int[] C = operations.Intersect(A, B);
            Assert.AreEqual(0, C.Length);
        }
        [Test]
        public void TestIntersection1()
        {
            int[] A = new int[] { 2, 4, 6 };
            int[] B = new int[] { 2, 4, 5 };
            int[] C = operations.Intersect(A, B);
            Assert.AreEqual(2, C.Length);
        }
        [Test]
        public void TestIntersection2()
        {
            int[] A = new int[] { 1,1,1,1,1};
            int[] B = new int[] { 1,1,1,1};
            int[] C = operations.Intersect(A, B);
            Assert.AreEqual(1, C.Length);
        }
        [Test]
        public void TestIntersection3()
        {
            int[] A = new int[] { 1,2,3,4,5 };
            int[] B = new int[] { 12, 4, 5 };
            int[] C = operations.Intersect(A, B);
            Assert.AreEqual(2, C.Length);
        }
        [Test]
        public void TestIntersection4()
        {
            int[] A = new int[] { 3,5,7,9,10 };
            int[] B = new int[] { 1,2,3,7,7,9,9,14};
            int[] C = operations.Intersect(A, B);
            Assert.AreEqual(3, C.Length);
        }
        [Test]
        public void TestIntersection5()
        {
            int[] A = new int[] { 1, 2, 3, 4, 5 };
            int[] B = new int[] { 12, 4, 5 };
            int[] C = operations.Intersect(A, B);
            Assert.AreEqual(2, C.Length);
        }
        [Test]
        public void TestLonelyNumber1()
        {
            int[] A = new int[] { 1,1,1,1,1,1 };           
            int result = operations.FindUniqueLonelyNumber(A);
            Assert.AreEqual(0,result);
        }
        [Test]
        public void TestLonelyNumber2()
        {
            int[] A = new int[] { 44,44,44,5 };
            int result = operations.FindUniqueLonelyNumber(A);
            Assert.AreEqual(5, result);
        }
        [Test]
        public void TestLonelyNumber3()
        {
            int[] A = new int[] { -1,-3,0,1,2,2,-1,-3,1 };
            int result = operations.FindUniqueLonelyNumber(A);
            Assert.AreEqual(0, result);        }
       
    }
}
