using Algorithms;
using System;
using System.Collections.Generic;
using System.IO;

class Solution
{
    class DoublyLinkedListNode
    {
        public int data;
        public DoublyLinkedListNode next;
        public DoublyLinkedListNode prev;

        public DoublyLinkedListNode(int nodeData)
        {
            this.data = nodeData;
            this.next = null;
            this.prev = null;
        }
    }

    class DoublyLinkedList
    {
        public DoublyLinkedListNode head;
        public DoublyLinkedListNode tail;

        public DoublyLinkedList()
        {
            this.head = null;
            this.tail = null;
        }

        public void InsertNode(int nodeData)
        {
            DoublyLinkedListNode node = new DoublyLinkedListNode(nodeData);

            if (this.head == null)
            {
                this.head = node;
            }
            else
            {
                this.tail.next = node;
                node.prev = this.tail;
            }

            this.tail = node;
        }
    }

    static void PrintDoublyLinkedList(DoublyLinkedListNode node, string sep, TextWriter textWriter)
    {
        while (node != null)
        {
            textWriter.Write(node.data);

            node = node.next;

            if (node != null)
            {
                textWriter.Write(sep);
            }
        }
    }

    class SinglyLinkedListNode
    {
        public int data;
        public SinglyLinkedListNode next;

        public SinglyLinkedListNode(int nodeData)
        {
            this.data = nodeData;
            this.next = null;
        }
    }

    class SinglyLinkedList
    {
        public SinglyLinkedListNode head;
        public SinglyLinkedListNode tail;

        public SinglyLinkedList()
        {
            this.head = null;
            this.tail = null;
        }

        public void InsertNode(int nodeData)
        {
            SinglyLinkedListNode node = new SinglyLinkedListNode(nodeData);

            if (this.head == null)
            {
                this.head = node;
            }
            else
            {
                this.tail.next = node;
            }

            this.tail = node;
        }
    }

    static void PrintSinglyLinkedList(SinglyLinkedListNode node, string sep)
    {
        while (node != null)
        {
            Console.Write(node.data);

            node = node.next;

            if (node != null)
            {
                Console.Write(sep);
            }
        }
    }

    // Complete the reversePrint function below.

    /*
     * For your reference:
     *
     * SinglyLinkedListNode {
     *     int data;
     *     SinglyLinkedListNode next;
     * }
     *
     */
    static void reversePrint(SinglyLinkedListNode head)
    {
        /*SinglyLinkedListNode current = head;
        SinglyLinkedListNode temp = null;
        head = null;
        while (current != null)
        {
            temp = current;
            current = current.next;
            temp.next = head;
            head = temp;
        }*/
        SinglyLinkedListNode prev = null, current = head, next = null;
        while (current != null)
        {
            next = current.next;
            current.next = prev;
            prev = current;
            current = next;
        }
        head = prev;
    }
    static bool CompareLists(SinglyLinkedListNode head1, SinglyLinkedListNode head2)
    {
        bool result = true;
        while (true)
        {
            if (head1 == null && head2 == null)
                break;
            if ((head1 == null && head2 != null) || (head1 != null && head2 == null))
            {
                result = false;break;
            }
            if (head1.data != head2.data)
            {
                result = false;break;
            }
            head1 = head1.next;head2 = head2.next;                
        }
        return result;
    }
    static SinglyLinkedListNode mergeLists(SinglyLinkedListNode head1, SinglyLinkedListNode head2)
    {
        if (head1 != null && head2 == null) return head1;
        if (head2!=null && head1==null) return head2;

        SinglyLinkedListNode prev = null;
        SinglyLinkedListNode curr1 = head1;
        SinglyLinkedListNode curr2 = head2;
        SinglyLinkedListNode temp = null;

        // Since we are adding everything to the first list check for first element in both the lists
        if (curr1.data > curr2.data)
        {
            temp = curr2;
            curr2 = curr2.next;
            prev = temp;
            prev.next = head1;
            head1 = prev;
        }
        while (curr1 != null && curr2 != null)
        {
            if (curr1.data <= curr2.data)
            {
                prev = curr1;
                curr1 = curr1.next;
            }
            else
            {
                temp = curr2;
                curr2 = curr2.next;
                temp.next = prev.next;
                prev.next = temp;
                prev = temp;
            }
        }
        if (curr1 != null)
            prev.next = curr1;
        else
            prev.next = curr2;
        return head1;
    }
    static bool hasCycle(SinglyLinkedListNode head)
    {
        bool hasCycle = false;
        SinglyLinkedListNode current = head;
        SinglyLinkedListNode ahead = head.next;
        while (current != null && ahead != null)
        {
            if (current.data == ahead.data)
            {
                hasCycle = true; break;
            }
            else
            {
                current = current.next;
                ahead = ahead.next;
            }
            if (ahead != null)
                ahead = ahead.next;
        }
        return hasCycle;
    }
    static int findMergeNode(SinglyLinkedListNode head1, SinglyLinkedListNode head2)
    {
        int head1Count = 0;
        int head2Count = 0;
        SinglyLinkedListNode current1 = head1;
        SinglyLinkedListNode current2 = head2;
        while (current1 != null)
        { current1 = current1.next;head1Count++; }
        while (current2 != null)
        { current2 = current2.next;head2Count++; }

        current1 = head1;current2 = head2;
        if (head1Count > head2Count)
        {
            while ((head1Count > head2Count))
            { current1 = current1.next; head1Count--; }
        }
        else
        {
            while ((head2Count > head1Count))
            { current2 = current2.next; head2Count--; }
        }
        while (current1 != null)
        {
            if (current1 == current2)
                break;
            else
            {
                current1 = current1.next;
                current2 = current2.next;
            }
        }
        return current1.data;
    }

    static SinglyLinkedListNode removeDuplicates(SinglyLinkedListNode head)
    {
        SinglyLinkedListNode current = head;
        SinglyLinkedListNode ahead = head.next;
        while (ahead != null)
        {
            if (current.data != ahead.data)
            {
                current = current.next;
                ahead = ahead.next;
            }
            else
            {
                current.next = ahead.next;                
                ahead = ahead.next;
            }
        }
        return head;
    }
    static int getNode(SinglyLinkedListNode head, int positionFromTail)
    {
        // Need to find node from the tail given its position from the tail
        SinglyLinkedListNode current = head;SinglyLinkedListNode returned = head;
        for (int i = 0; i < positionFromTail; i++)
            current = current.next;
        while (current.next != null)
        {
            current = current.next;
            returned = returned.next;
        }
        return returned.data;
    }
    static DoublyLinkedListNode sortedInsert(DoublyLinkedListNode head, int data)
    {
        DoublyLinkedListNode newNode = new DoublyLinkedListNode(data);
        DoublyLinkedListNode current = head;
        bool isInserted = false;
        if (current == null)
            return newNode;
        else
        {            
            while (current.next != null)
            {
                if (current.data > data)
                {
                    newNode.next = current;
                    newNode.prev = current.prev;
                    if (current.prev != null)
                    {
                        current.prev.next = newNode;
                    }
                    current.prev = newNode;
                    current = newNode;
                    isInserted = true;
                    break;
                }
                else
                    current = current.next;
            }
            // check for first or last value
            if  (!isInserted)
            { if (current.data > data)
                {
                    newNode.next = current;
                    newNode.prev = current.prev;
                    if (current.prev != null)
                    {
                        current.prev.next = newNode;
                    }
                    current.prev = newNode;
                }
                else
                {
                    // The inserted value is more than the highest entry in the list
                    current.next = newNode;
                    newNode.prev = current;
                }
            }
        }
        if (current.prev == null) head = current;
        return head;
    }
    static DoublyLinkedListNode reverse(DoublyLinkedListNode head)
    {
        DoublyLinkedListNode current = head;
        DoublyLinkedListNode temp;
        while (current != null)
        {
            temp = current.next;
            current.next = current.prev;
            current.prev = temp;
            current = temp;
            if (current != null) head = current;
        }
        return head;
    }
    static void PrintSinglyLinkedList(SinglyLinkedListNode node, string sep, TextWriter textWriter)
    {
        while (node != null)
        {
            textWriter.Write(node.data);

            node = node.next;

            if (node != null)
            {
                textWriter.Write(sep);
            }
        }
    }

    #region Arrays
    // Complete the reverseArray function below.
    static int[] reverseArray(int[] a)
    {
        int start = 0;
        int end = a.Length-1;
        while ((end - start) > 0)
        {
            int temp = a[start];
            a[start] = a[end];
            a[end] = temp;
            start++;
            end--;
        }
        return a;
    }
    #endregion
    static void Main(string[] args)
    {

        Console.WriteLine(new ArrayOperations().getFirstUniqueCharacter("stress"));
        Console.WriteLine(new ArrayOperations().getFirstUniqueCharacter("twitter"));
        Console.WriteLine(new ArrayOperations().getFirstUniqueCharacter("aabccbdeef"));

        Console.ReadLine();
    }
}

