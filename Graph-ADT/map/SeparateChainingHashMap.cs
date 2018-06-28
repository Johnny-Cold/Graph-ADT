using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Graph_ADT.map
{
    /// <summary>
    /// Implementation of a hash map that implements separate chaining.
    /// </summary>
    public class SeparateChainingHashMap<K, V> : HashMap<K, V>
    {
        private List<KeyValuePair<K, V>>[] table;
        private float loadFactor = 10.0f;
        private int minimumSize = 1024;
        private int initialListSize = 10;

        public SeparateChainingHashMap() : base()
        {
            initialiseMap(minimumSize);
        }

        public SeparateChainingHashMap(int capacity) : base(capacity)
        {
            initialiseMap(capacity);
        }

        public SeparateChainingHashMap(int capacity, int primeFactor) : base(capacity, primeFactor)
        {
            initialiseMap(capacity);
        }

        protected override void createTable()
        {
            table = new List<KeyValuePair<K,V>>[capacity];
        }

        private void initialiseMap(int length)
        {
            table = new List<KeyValuePair<K, V>>[length];

            for(int k = 0; k < table.Length; k++)
            {
                table[k] = new List<KeyValuePair<K, V>>(initialListSize);
            }
                
            numEntries = 0;
        }

        public int indexOf(int hash)
        {
            return hash & (table.Length - 1);
        }

        public override V get(K key)
        {
            V value = default(V);
            int hash = hashCode(key);
            List<KeyValuePair<K, V>> bucket = table[hash];
         
            foreach(KeyValuePair<K,V> entry in bucket)
            {
                if(entry.Key.Equals(key))
                {
                    value = entry.Value;
                }
            }

            return value;
        }

        public override V put(K key, V value)
        {
            return put(new KeyValuePair<K, V>(key, value));
        }

        private V put(KeyValuePair<K, V> pair)
        {
            int hash = hashCode(pair.Key);
            bool alreadyExist = false; // Determines whther or not the given key-value pair already is in the table.
            V value = pair.Value;
            List<KeyValuePair<K, V>> bucket = table[hash];
            
            foreach(KeyValuePair<K,V> entry in bucket)
            {
                // Ensures no duplicates are created.
                // Enters new value to existing key if the provided key-value key already exists.
                if(entry.Key.Equals(pair.Key))
                {
                    value = entry.Value;
                    bucket.Remove(entry);
                    bucket.Add(new KeyValuePair<K, V>(pair.Key, pair.Value));
                    alreadyExist = true;
                    break;
                }
            }

            if(!alreadyExist)
            {
                bucket.Add(pair);
                numEntries++;
            }

           
            int maxSize = (int)(loadFactor * table.Length);

            // If the number of entires is greater than the threshold, we increase the hash map's capacity.
            if (numEntries >= maxSize)
            {
                increaseCapacity();
            }
            
            return value;
        }

        public override V remove(K key)
        {
            V removedValue = default(V);
            int hash = hashCode(key);
            List<KeyValuePair<K, V>> bucket = table[hash];

            foreach(KeyValuePair<K,V> entry in bucket)
            {
                if(entry.Key.Equals(key))
                {
                    removedValue = entry.Value;
                    bucket.Remove(entry);
                    numEntries--;

                    int hereLoadFactored = (int)(numEntries / loadFactor);
                    int smallerSize = getSmallerSize(table.Length);

                    if((hereLoadFactored < smallerSize) && (smallerSize > minimumSize))
                    {
                        reduceCapacity();
                    }
                }
            }
            
            return removedValue;
        }

        /// <returns> The input multiplied by ten. </returns>
        private int getLargerSize(int input)
        {
            return input * 10;
        }

        /// <returns> A quarter of the input. </returns>
        private int getSmallerSize(int input)
        {
            return input / 4;
        }

        private void increaseCapacity()
        {
            List<KeyValuePair<K, V>>[] temp = table;

            // Calculate the new size and assign it.
            int size = getLargerSize(table.Length);
            initialiseMap(size);

            // Re-hash old data.
            foreach(List<KeyValuePair<K,V>> list in temp)
            {
                foreach(KeyValuePair<K,V> entry in list)
                {
                    put(entry);
                }
            }
        }
        
        private void reduceCapacity()
        {
            List<KeyValuePair<K, V>>[] temp = table;

            // Calculate the new size and check minimum.
            int length = getSmallerSize(table.Length);
            initialiseMap(length);

            foreach(List<KeyValuePair<K,V>> list in temp)
            {
                foreach(KeyValuePair<K,V> entry in list)
                {
                    put(entry);
                }
            }
        }
        
        public override void clear()
        {
            for(int k = 0; k < table.Length; k++)
            {
                table[k].Clear();
                numEntries--;
            }
        }
    }
}
