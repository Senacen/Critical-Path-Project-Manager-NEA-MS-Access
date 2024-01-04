using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Critical_Path_Project_Manager_NEA_MS_Access.DataStructures
{
    internal class CustomDictionary<K, V>
    {
        private struct KVPair
        {
            private K key;
            private V value;
            public KVPair(K key, V value)
            {
                this.key = key;
                this.value = value;
            }
            public K getKey()
            {
                return key;
            }
            public V getValue()
            {
                return value;
            }
        }
        private class Bucket // Class as it has to be mutable, and passed by reference
        {
            private CustomLinkedListNode<KVPair> head;
            private CustomLinkedListNode<KVPair> tail;

            public Bucket(CustomLinkedListNode<KVPair> head, CustomLinkedListNode<KVPair> tail)
            {
                this.head = head;
                this.tail = tail;
            }

            public CustomLinkedListNode<KVPair> getHead()
            {
                return head;
            }
            public CustomLinkedListNode<KVPair> getTail()
            {
                return tail;
            }
            public void setHead(CustomLinkedListNode<KVPair> head)
            {
                this.head = head;
            }
            public void setTail(CustomLinkedListNode<KVPair> tail)
            {
                this.tail = tail;
            }
        }
          

        private List<string> keys = new List<string>();
        private List<Bucket> hashTable = new List<Bucket>(); // LinkedListNode for Separate Chaining
        private double loadFactorThreshold = 0.7; // When load factor exceeds this, double length of hashTable and rehash
        private int size = 10; // Set to starting size of the hashTable

        
        public CustomDictionary()
        {
            for (int i = 0; i < size; i++) 
            {
                hashTable.Add(new Bucket(null, null)); // Initialise each bucket to no contents
            }
        }

        public void add(K key, V value)
        {
            if ((double)keys.Count + 1 / (double)size > 0.7) // If the new item would make the load factor go above the threshold, resize and rehash before adding
            {
                rehash();
            }
            KVPair kVPair = new KVPair(key, value);
            CustomLinkedListNode<KVPair> dictionaryLinkedListNode = new CustomLinkedListNode<KVPair>(kVPair);
            int index = djb2HashFunction.djb2(key.ToString());
            index %= size;
            Bucket bucket = hashTable[index];
            if (bucket.getHead() == null)
            {
                bucket.setHead(dictionaryLinkedListNode);
                bucket.setTail(dictionaryLinkedListNode);
            } else
            {
                bucket.getTail().setNext(dictionaryLinkedListNode);
                bucket.setTail(dictionaryLinkedListNode);
            }

        }

        private void rehash()
        {
            // Resize
            size *= 2;
            List<Bucket> newHashTable = new List<Bucket>();
            for (int i = 0; i < size; i++)
            {
                newHashTable.Add(new Bucket(null, null)); // Initialise each bucket to no contents
            }

            // Rehash
            for (int i = 0; i < hashTable.Count; i++)
            {
                Bucket bucket = hashTable[i];
                CustomLinkedListNode<KVPair> current = bucket.getHead();
                while (current != null)
                {
                    KVPair currentKVPair = current.getItem();
                    add(currentKVPair.getKey(), currentKVPair.getValue());
                }
            }

            // Rename
            hashTable = newHashTable;

        }


    }
}
