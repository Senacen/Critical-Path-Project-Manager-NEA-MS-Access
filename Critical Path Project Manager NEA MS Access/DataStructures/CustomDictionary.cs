using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Critical_Path_Project_Manager_NEA_MS_Access
{
    internal class CustomDictionary<K, V>
    {
        // Key-Value Pair struct
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

        // Bucket class for each index in the hash table
        private class Bucket // Class as it has to be mutable, and passed by reference
        {
            // Head and Tail of the linked list stored in the bucket
            private LinkedListNode<KVPair> head;
            private LinkedListNode<KVPair> tail;

            public Bucket(LinkedListNode<KVPair> head, LinkedListNode<KVPair> tail)
            {
                this.head = head;
                this.tail = tail;
            }

            public LinkedListNode<KVPair> getHead()
            {
                return head;
            }
            public LinkedListNode<KVPair> getTail()
            {
                return tail;
            }
            public void setHead(LinkedListNode<KVPair> head)
            {
                this.head = head;
            }
            public void setTail(LinkedListNode<KVPair> tail)
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
            // If not currently in the process of rehashing, and the dictionary already contains the key
            if (!rehashing && contains(key))
            {
                // Reject adding the key-value pair
                throw new InvalidOperationException("This key already exists.");
            }
            if (((double)keys.Count + 1) / (double)size > loadFactorThreshold) // If the new item would make the load factor go above the threshold, resize and rehash before adding
            {
                rehash();
            }

            // Create a new KVPair struct to associate the key and the value together
            KVPair kVPair = new KVPair(key, value);

            // Store it in a linked list node
            LinkedListNode<KVPair> dictionaryLinkedListNode = new LinkedListNode<KVPair>(kVPair);

            // Hash the kety
            int index = djb2HashFunction.djb2(key.ToString());
            index %= size;
            if (index < 0) index += size; // If the hash value and therefore modulo was negative, make it positive to be in range

            // Choose the correct bucket 
            Bucket bucket;
            if (rehashing) 
            {
                bucket = newHashTable[index]; // Adding to the new hash table as we are rehashing
            }
            else
            {
                bucket = hashTable[index]; // Adding to the normal hash table
            }
            
            // Add the linked list node to the linked list stored in the bucket
            if (bucket.getHead() == null)
            {
                bucket.setHead(dictionaryLinkedListNode);
                bucket.setTail(dictionaryLinkedListNode);
            } else
            {
                bucket.getTail().setNext(dictionaryLinkedListNode);
                bucket.setTail(dictionaryLinkedListNode);
            }

            // If not currently rehashing
            if (!rehashing)
            {

                // Add the key and the value to their respective lists
                keys.Add(key);
                values.Add(value);
            }

        }

        private V search(K key, LinkedListNode<KVPair> current)
        {
            if (current == null) throw new InvalidOperationException(); // End of linked list reached
            KVPair currentKVPair = current.getItem();
            
            // If the current linked list node stores the key we are looking for, return the value
            if (currentKVPair.getKey().Equals(key)) return currentKVPair.getValue();
            else
            {
                return search(key, current.getNext()); // Keep traversing
            }
            
        }

        public V getValue(K key)
        {
            // Hash the key
            int index = djb2HashFunction.djb2(key.ToString());
            index %= size;
            if (index < 0) index += size; // If the hash value and therefore modulo was negative, make it positive to be in range


            // Identify the correct bucket and linked list the key-value pair should be in
            Bucket bucket = hashTable[index];
            LinkedListNode<KVPair> current = bucket.getHead();
            try
            {
                // Search for the key-value pair in the linked list
                return search(key, current);
            } 
            catch
            {
                // The search function raised an exception, meaning that the key-value pair does not exist in the linked list
                throw new InvalidOperationException("This key-value pair does not exist in the Dictionary.");
            }
            
        }

        public bool contains(K key)
        {
            try
            {
                getValue(key); // If cannot find it, exception gets caught and returns false

                // No exception raised, so the key exists and returns true that the dictionary contains the key
                return true;
            }
            catch
            {
                return false;
            }
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

            // For each bucket in the dictionary
            for (int i = 0; i < hashTable.Count; i++)
            {
                Bucket bucket = hashTable[i];
                LinkedListNode<KVPair> current = bucket.getHead();

                // Traverse the linked list
                while (current != null)
                {
                    KVPair currentKVPair = current.getItem();

                    // Add each key-value pair to the new hash table
                    add(currentKVPair.getKey(), currentKVPair.getValue());
                    current = current.getNext();
                }
            }
            rehashing = false;

            // Update hashTable to the new, resized newHashTable
            hashTable = newHashTable;
        }


    }
}
