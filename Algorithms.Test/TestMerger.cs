using NUnit.Framework;
using System;


namespace Algorithms.Test
{
    [TestFixture]
    public class TestMerger
    {
        [Test]
        [Category("Basic Test")]
        public void MergeArraysWithOneElement()
        {
            int[] A = new int[1] { 2};
            int[] B = new int[1] { 5 };
            int[] C = Merger.Merge(A, B);
            Assert.That(C.Length, Is.EqualTo(2));

            int expected = 2;
            Assert.That(C[0],Is.EqualTo(expected));
            expected = 5;
            Assert.That(C[1], Is.EqualTo(expected));
        }
        [Test]
        public void MergeArraysWithAnEmptyArray()
        {
            int[] A = new int[3] { 2 ,5,6};
            int[] B = new int[] {  };
            int[] C = Merger.Merge(A, B);
            Assert.That(C.Length, Is.EqualTo(3));

            int expected = 2;
            Assert.That(C[0], Is.EqualTo(expected));
            expected = 6;
            Assert.That(C[2], Is.EqualTo(expected));
        }
        [Test]
        public void TestNegativeSorting()
        {
            int[] A = new int[3] { 2,6,8 };
            int[] B = new int[4] { -5,0,3,9 };
            int[] C = Merger.Merge(A, B);
            Assert.That(C.Length, Is.EqualTo(7));

            int expected = 2;
            Assert.That(C[2], Is.EqualTo(expected));
            expected = 9;
            Assert.That(C[C.Length-1], Is.EqualTo(expected));
            expected = 8;
            Assert.That(C[5],Is.EqualTo(expected));
        }
        [Test]
        public void TestNormalArraysMerging()
        {
            int[] A = new int[4] { 2, 6, 8, 67 };
            int[] B = new int[4] { -5, 0, 3, 9 };
            int[] C = Merger.Merge(A, B);

            int expected = -5;
            Assert.That(C[0], Is.EqualTo(expected));
            expected = 67;
            Assert.That(C[C.Length - 1], Is.EqualTo(expected));
            expected = 8;
            Assert.That(C[5], Is.EqualTo(expected));
        }
        [Test]
        public void TestDuplicateArrays()
        {
            int[] A = new int[4] { 2,3,3,4};
            int[] B = new int[4] {1,1,1,1};
            int[] C = Merger.Merge(A, B);

            int expected = 1;
            Assert.That(C[0], Is.EqualTo(expected));
            expected = 4;
            Assert.That(C[C.Length - 1], Is.EqualTo(expected));
            expected = 2;
            Assert.That(C[4], Is.EqualTo(expected));
        }
    }
}
