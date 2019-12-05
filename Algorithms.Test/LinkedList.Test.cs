using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Test
{
    [TestFixture]
    [Category("LinkedList Tests")]
    public class TestLinkedList
    {
        LinkedList list;
        [SetUp]
        public void MySetUp()
        {
            // Create the list here which will be used further in the tests
            list = new LinkedList(2);
            list.AddToBack(8);
            list.AddToBack(3);
            list.AddToBack(5);           
        }
        [Test]       
        public void AddToFront()
        {
            // we had a list 2 8 3 5 . After adding an element 7 the list should read 7 2 8 3 5
            list.AddToFront(7);
            Assert.That(0, Is.EqualTo(list.GetIndex(7)));

        }
        [Test]
        public void AddToBack()
        {
            // we had a list 2 8 3 5 . After adding an element 7 the list should read  2 8 3 5 7
            list.AddToBack(7);
            Assert.That(4, Is.EqualTo(list.GetIndex(7)));

        }
        [Test]
        public void TestInsertion()
        {
            list.Insert(19, 8);
            Assert.That(-1, Is.EqualTo(list.GetIndex(19)));
        }
        [Test]
        public void TestInsertionAtStart()
        {
            list.Insert(19, 0);
            Assert.That(1, Is.EqualTo(list.GetIndex(19)));
        }
        [Test]
        public void TestInsertionAtMid()
        {
            list.Insert(19, 2);
            Assert.That(2, Is.EqualTo(list.GetIndex(19)));
        }
        [Test]
        public void TestInsertionAtEnd()
        {
            list.Insert(19, 3);
            Assert.That(3, Is.EqualTo(list.GetIndex(19)));
            Assert.That(5, Is.EqualTo(list.length));
        }
        [Test]
        public void DeleteElement()
        {
            list.Delete(3);
            Assert.That("285", Is.EqualTo(list.ToString()));
        }
        [Test]
        public void TestGetHead()
        {
            Assert.That(2, Is.EqualTo(list.GetHead()));
        }
    }
}
