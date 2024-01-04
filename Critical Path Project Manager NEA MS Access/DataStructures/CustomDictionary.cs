using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Critical_Path_Project_Manager_NEA_MS_Access
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
          

        public List<K> keys = new List<K>();
        public List<V> values = new List<V>();
        private List<Bucket> hashTable = new List<Bucket>(); // LinkedListNode for Separate Chaining
        private List<Bucket> newHashTable = new List<Bucket>(); // For rehashing into
        private double loadFactorThreshold = 0.7; // When load factor exceeds this, double length of hashTable and rehash
        private int size = 10; // Set to starting size of the hashTable
        private bool rehashing = false;

        
        public CustomDictionary()
        {
            for (int i = 0; i < size; i++) 
            {
                hashTable.Add(new Bucket(null, null)); // Initialise each bucket to no contents
            }
        }

        public void add(K key, V value)
        {
            if (!rehashing && contains(key))
            {
                throw new InvalidOperationException("This key already exists.");
            }
            if (((double)keys.Count + 1) / (double)size > loadFactorThreshold) // If the new item would make the load factor go above the threshold, resize and rehash before adding
            {
                rehash();
            }
            KVPair kVPair = new KVPair(key, value);
            CustomLinkedListNode<KVPair> dictionaryLinkedListNode = new CustomLinkedListNode<KVPair>(kVPair);
            int index = djb2HashFunction.djb2(key.ToString());
            index %= size;
            if (index < 0) index += size; // If the hash value and therefore modulo was negative, make it positive to be in range

            Bucket bucket;
            if (rehashing) 
            {
                bucket = newHashTable[index]; // Adding to the new hash table as we are rehashing
            }
            else
            {
                bucket = hashTable[index]; // Adding to the normal hash table
            }
            
            if (bucket.getHead() == null)
            {
                bucket.setHead(dictionaryLinkedListNode);
                bucket.setTail(dictionaryLinkedListNode);
            } else
            {
                bucket.getTail().setNext(dictionaryLinkedListNode);
                bucket.setTail(dictionaryLinkedListNode);
            }
            if (!rehashing)
            {
                keys.Add(key);
                values.Add(value);
            }

        }

        public V getValue(K key)
        {
            int index = djb2HashFunction.djb2(key.ToString());
            index %= size;
            if (index < 0) index += size; // If the hash value and therefore modulo was negative, make it positive to be in range
            Bucket bucket = hashTable[index];
            CustomLinkedListNode<KVPair> current = bucket.getHead();
            while (current != null)
            {
                KVPair currentKVPair = current.getItem();
                if (currentKVPair.getKey().Equals(key)) return currentKVPair.getValue();
                else
                {
                    current = current.getNext();
                }
            }
            throw new InvalidOperationException("This key-value pair does not exist in the Dictionary.");
        }

        public bool contains(K key)
        {
            int index = djb2HashFunction.djb2(key.ToString());
            index %= size;
            if (index < 0) index += size; // If the hash value and therefore modulo was negative, make it positive to be in range
            Bucket bucket = hashTable[index];
            CustomLinkedListNode<KVPair> current = bucket.getHead();
            while (current != null)
            {
                KVPair currentKVPair = current.getItem();
                if (currentKVPair.getKey().Equals(key)) return true;
                else
                {
                    current = current.getNext();
                }
            }
            return false;
        }

        private void rehash()
        {
            // Resize
            size *= 2;
            // Make a new empty hash table to copy into
            newHashTable = new List<Bucket>();
            for (int i = 0; i < size; i++)
            {
                newHashTable.Add(new Bucket(null, null)); // Initialise each bucket to no contents
            }

            // Rehash
            rehashing = true; // Mark that we are rehashing to not add the key or value again to the key or value lists
            // rename newHashTable to hashTable
            for (int i = 0; i < hashTable.Count; i++)
            {
                Bucket bucket = hashTable[i];
                CustomLinkedListNode<KVPair> current = bucket.getHead();
                while (current != null)
                {
                    KVPair currentKVPair = current.getItem();
                    add(currentKVPair.getKey(), currentKVPair.getValue());
                    current = current.getNext();
                }
            }
            rehashing = false;
            hashTable = newHashTable;
        }


    }
}
