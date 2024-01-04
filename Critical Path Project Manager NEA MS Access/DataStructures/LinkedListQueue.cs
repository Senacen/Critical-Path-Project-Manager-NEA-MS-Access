using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Critical_Path_Project_Manager_NEA_MS_Access.Objects
{
    internal class LinkedListQueue<T>
    {
        private CustomLinkedListNode<T> front, back;

        public LinkedListQueue()
        {
            front = null;
            back = null;
        }

        // Enqueue an item to the back of the queue
        public void enqueue(T item)
        {
            CustomLinkedListNode<T> newNode = new CustomLinkedListNode<T>(item);

            if (back == null)
            {
                // The queue is empty, so set both front and back to the new node
                front = newNode;
                back = newNode;
            }
            else
            {
                // Add the new node to the back of the queue and update back
                back.setNext(newNode);
                back = newNode;
            }
        }

        // Dequeue an item from the front of the queue
        public T dequeue()
        {
            if (this.isEmpty())
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            T value = front.getItem();
            front = front.getNext();

            // If front becomes null, the queue is now empty, so also update back
            if (front == null)
            {
                back = null;
            }

            return value;
        }

        // Check if the queue is empty
        public bool isEmpty()
        {
            return front == null;
        }
    }
}
