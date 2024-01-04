using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Critical_Path_Project_Manager_NEA_MS_Access
{
    internal class CustomLinkedListNode<T>
    {
        private CustomLinkedListNode<T> next;
        private T item;
        public CustomLinkedListNode(T item)
        {
            this.item = item;
            next = null;
        }
        public CustomLinkedListNode<T> getNext()
        {
            return next;
        }
        public T getItem()
        {
            return item;
        }
        public void setNext(CustomLinkedListNode<T> next)
        {
            this.next = next;
        }
    }
}
