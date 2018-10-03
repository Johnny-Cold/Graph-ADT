using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_ADT.map
{
    public abstract class HashMap<K,V> 
    {
        protected int capacity; // The hash map's capacity.
        protected int numEntries;
        private int primeFactor;
        private long shift, scale; // The shift and scaling factors.
        protected List<K> keySet = new List<K>();

        /// <summary>
        /// Class constructor.
        /// Initialises class member variables.
        /// </summary>
        /// <param name="capacity"> The hash map's capacity. </param>
        /// <param name="primeFactor"> the prime factor to use. </param>
        public HashMap(int capacity, int primeFactor)
        {
            Random rand = new Random();

            this.capacity = capacity;
            this.primeFactor = primeFactor;
            scale = rand.Next(primeFactor - 1) + 1;
            shift = rand.Next(primeFactor);
            createTable();
        }

        /// <summary>
        /// Class constructor.
        /// Creates a new hash map with a specified capacity and a default prime factor.
        /// </summary>
        /// <param name="capacity"> The hash map's capacity. </param>
        public HashMap(int capacity) : this(capacity, 109345121){}

        /// <summary>
        /// No-args constructor.
        /// Creates a new hash map with default capacity and prime factor.
        /// </summary>
        public HashMap() : this(17) {}
        
        /// <summary>
        /// Generates a hash value from the given key.
        /// </summary>
        /// <returns> The hash value of a given key. </returns>
        protected int hashCode(K key)
        {
            return (int)((Math.Abs(key.GetHashCode() * scale + shift) % primeFactor) % capacity);
        }

        public abstract V get(K key);

        public abstract V put(K key, V value);

        public abstract V remove(K key);
        
        public List<KeyValuePair<K,V>> entrySet()
        {
            List<KeyValuePair<K, V>> entries = new List<KeyValuePair<K, V>>();

            foreach(K key in keySet)
            {
                V value = get(key);
                KeyValuePair<K, V> entry = new KeyValuePair<K, V>(key, value);
                entries.Add(entry);
            }

            return entries;
        }

        public void resize(int newCapacity)
        {
            List<KeyValuePair<K, V>> buffer = new List<KeyValuePair<K, V>>(numEntries);
            List<KeyValuePair<K,V>> entries = entrySet();
            
            foreach (KeyValuePair<K,V> entry in entries)
            {
                buffer.Add(entry);
            }

            // Starting to build the hash map from scratch using the new capacity.
            capacity = newCapacity;
            createTable();
            numEntries = 0;
            
            foreach(KeyValuePair<K,V> entry in buffer)
            {
                put(entry.Key, entry.Value);
            }
        }

        public bool contains(K key)
        {
            return get(key) != null;
        }

        /// <summary>
        /// Clears the hash map.
        /// </summary>
        public virtual void clear()
        {
            foreach(K key in keySet)
            {
                remove(key);
            }
        }
        
        protected abstract void createTable();
    }
}
