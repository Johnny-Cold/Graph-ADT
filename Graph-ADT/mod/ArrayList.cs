using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_ADT
{
    public class ArrayList<T> : List<T> 
    {
        private const int CAPACITY = 10;
        private T[] array;
        private int size = 0;

        /// <summary>
        /// Class constructor.
        /// Constructs an array with the default capacity 10.
        /// </summary>
        public ArrayList()
        {
            array = new T[CAPACITY];
        }

        /// <summary>
        /// Class constructor.
        /// Constructs an array with a given capacity.
        /// </summary>
        /// <param name="capacity"> The capacity of the array. </param>
        public ArrayList(int capacity)
        {
            array = new T[capacity];
        }

        public bool isEmpty()
        {
            return size == 0;
        }

        public int getSize()
        {
            return size;
        }

        /// <summary>
        /// Checks that the given index is in the range [0; n-1]
        /// </summary>
        /// <param name="index"> The index to check. </param>
        /// <param name="n"> The plain maximum range (array's size - 1). </param>
        private void checkIndex(int index, int n)
        {
            if (index < 0 || index >= n)
            {
                throw new IndexOutOfRangeException("The provided index is out of bounds.");
            }
        }

        public T get(int index)
        {
            checkIndex(index, size);
            return array[index];
        }

        public object get(object entry)
        {
            return array.Where(e => e.Equals(entry)).SingleOrDefault();
        }

        /// <summary>
        /// Places an entry at a particular place in the array.
        /// </summary>
        /// <param name="index"> The index of the array slot in which to enter the entry. </param>
        /// <param name="entry"> A new addition to the array list. </param>
        public void set(int index, T entry)
        {
            checkIndex(index, size);
            array[index] = entry;
        }

        public void remove(int index)
        {
            checkIndex(index, size);

            // Shifting to fill hole.
            for (int k = index; k < size - 1; k++)
            {
                array[k] = array[k + 1];
                size--;
            }
        }
    }
}
