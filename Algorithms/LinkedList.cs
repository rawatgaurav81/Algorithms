using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class LinkedList
    {
        private Node Head;
        public int length;     
        public LinkedList(int n)
        {
            Head = new Node(n);
            length++;
        }
        public void AddToFront(int data)
        {
            Node newNode = new Node(data);
            newNode.Next = Head;
            Head = newNode;
            length++;
        }
        public void AddToBack(int data)
        {
            Node backNode = new Node(data);
            Node current = Head;
            while (current.Next != null)
            {
                current = current.Next;     
            }
            current.Next = backNode;
            length++;
        }
        public int Insert(int element, int index)
        {
            if (length == 0 || index>length)
                return -1;
            int counter = 1;
            Node current = Head;
            while (current.Next != null && counter<index)
            {
                counter++; current = current.Next;
            }

            Node insertedNode = new Node(element);
            insertedNode.Next = current.Next;
            current.Next = insertedNode;
            length++;
            return index;
        }
        public int GetIndex(int element)
        {
            Node current = Head;
            int counter = 0;
            bool found = false;
            while (counter < length)
            {
                if (current.Data == element)
                {
                    found = true;
                    break;
                }
                else
                {
                    counter++;
                    current = current.Next;
                }
            }
            if (!found) return -1;
            else return counter;
        }
        public int Delete(int data)
        {
            if (length == 0) return -1;
            if (length == 1 && data == Head.Data)
            {
                Head = null; length--;return 0;
            }
            Node current = Head;Node previous = Head;
            while (current != null)
            {
                if (current.Data == data)
                { previous.Next = current.Next; return 0; }
                else
                {
                    previous = current;
                    current = current.Next;
                }
            }
            return -1;
        }
        public int GetHead()
        {
            if (Head != null)
                return Head.Data;
            else
                throw new ArgumentException();
        }
        public void RemoveHead()
        {
            if (Head != null)
            { Head = Head.Next; length--; }
        }
        public override string ToString()
        {
            string listString = "";
            while (Head!= null)
            { listString += Head.Data; Head = Head.Next; }
            return listString;
        }
    }
    public class Node
    {
        public int Data;
        public Node Next;
        public Node(int n)
        {
            Data = n;
            Next = null;
        }
    }   
}
