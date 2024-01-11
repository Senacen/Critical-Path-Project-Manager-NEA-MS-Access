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
        // Top pointer to know which linked list node is the top of the stack
        private LinkedListNode<T> top;

        public LinkedListStack() 
        {
            top = null;
        }

        public void push (T item)
        {
            // Create a new node with the item stored
            LinkedListNode<T> newNode = new LinkedListNode<T>(item);

            // Connect the new node to the current top
            newNode.setNext(top);

            // Set the top pointer to point to the new node
            top = newNode;
        }

        public T pop()
        {
            // Check if there is anything to pop
            if (isEmpty())
            {
                // If not, error
                throw new InvalidOperationException("Stack is empty.");
            }

            // Get the item of the top node
            T result = top.getItem();

            // Move the top pointer to the next node down the stack
            top = top.getNext();

            // The previous top node will be destroyed by C# garbage collection to avoid memory leakage
            // Return the item
            return result;
        }

        public bool isEmpty()
        {
            // If top is null, there are no LinkedListNodes in the stack
            return top == null;
        }
    }
}
