using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Critical_Path_Project_Manager_NEA_MS_Access.DataStructures
{
    internal class CustomDictionary<K, V>
    {
        private List<string> keys = new List<string>();
        private List<KeyValuePair<K, LinkedListNode<V>>> hashTable = new List<KeyValuePair<K, LinkedListNode<V>>>(); // LinkedListNode for Separate Chaining
        private double loadFactorThreshold = 0.7; // When load factor exceeds this, double length of hashTable and rehash
        private int size = 0;

        private struct bucket
        {
            public K key;
            public LinkedListNode<V> head;
            public LinkedListNode<V> tail;

            public bucket(K key, LinkedListNode<V> head, LinkedListNode)
        }
        public CustomDictionary()
        {
            
        }

        public 


    }
}
