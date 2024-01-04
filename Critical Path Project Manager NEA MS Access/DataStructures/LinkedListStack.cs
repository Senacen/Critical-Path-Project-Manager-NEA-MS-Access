using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace Critical_Path_Project_Manager_NEA_MS_Access.Objects
{
    internal class LinkedListStack<T>
    {
        private CustomLinkedListNode<T> top;

        public LinkedListStack() 
        {
            top = null;
        }

        public void push (T item)
        {
            CustomLinkedListNode<T> newNode = new CustomLinkedListNode<T>(item);
            newNode.setNext(top);
            top = newNode;
        }

        public T pop()
        {
            if (top == null)
            {
                throw new InvalidOperationException("Stack is empty.");
            }
            T result = top.getItem();
            top = top.getNext();
            return result;
        }

        public bool isEmpty()
        {
            return top == null;
        }
    }
}
