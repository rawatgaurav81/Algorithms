using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Test
{
    [TestFixture]
    [Category("Stack Tests")]
    public class StackTest
    {
        Stack myStack;
        [SetUp]
        public void MySetUp()
        {
            // Create the list here which will be used further in the tests
            myStack = new Stack();          
        }
        [Test]
        public void TestPush()
        {
            // Push 1 item in the stack
            myStack.Push(2);           
            int expected = myStack.Pop();
            Assert.That(2, Is.EqualTo(expected));          
        }
        [Test]
        public void TestForEmptyStack()
        {
            Assert.That(() => myStack.Pop(), Throws.TypeOf<ArgumentException>());
        }
        [Test]
        public void TestStackCount()
        {
            // Push 3 item in the stack
            myStack.Push(2);
            myStack.Push(3);
            myStack.Push(4);
            Assert.That(3, Is.EqualTo(myStack.Count));
        }
        [Test]
        public void TestPop()
        {
            // Push 3 item in the stack
            myStack.Push(2);
            myStack.Push(3);
            myStack.Push(4);           
            Assert.That(4, Is.EqualTo(myStack.Pop()));         
            Assert.That(3, Is.EqualTo(myStack.Pop()));         
            Assert.That(2, Is.EqualTo(myStack.Pop()));
        }
    }
}
