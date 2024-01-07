using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Critical_Path_Project_Manager_NEA_MS_Access
{
    internal class LinkedListNode<T>
    {
        private LinkedListNode<T> next;
        private T item;
        public LinkedListNode(T item)
        {
            this.item = item;
            next = null;
        }
        public LinkedListNode<T> getNext()
        {
            return next;
        }
        public T getItem()
        {
            return item;
        }
        public void setNext(LinkedListNode<T> next)
        {
            this.next = next;
        }
    }
}
