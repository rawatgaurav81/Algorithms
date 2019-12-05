using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class Stack
    {
        public Stack()
        {
            
        }
        private LinkedList list;
        public int Count = 0;
        public void Push(int element)
        {
            if (Count == 0)
            {
                list = new LinkedList(element);                
            }
            else
            {
                list.AddToFront(element);
            }
            
            Count = list.length;
        }
        public int Pop()
        {
            if (list==null)
                throw new ArgumentException();
            else
            {
                int result = list.GetHead();
                list.RemoveHead();
                return result;
            }
        }
        public int Top()
        {
            return -1000;
        }
        public bool Contains(int element)
        {
            bool isPresent = false;
            return isPresent;
        }             
    }
}
