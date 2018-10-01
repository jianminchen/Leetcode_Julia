using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _706.Design_HashMap
{
    public class MyHashMap
    {
        public const int SIZE = 1000001;
        public int[] keyValues { get; set; }
        /** Initialize your data structure here. */
        public MyHashMap()
        {
            keyValues = new int[SIZE];
            for (int i = 0; i < SIZE; i++)
            {
                keyValues[i] = -1;
            }
        }

        /** value will always be non-negative. */
        public void Put(int key, int value)
        {
            if (value < 0 || value > 1000000 || key < 0 || key > 1000000)
            {
                return;
            }

            keyValues[key] = value;
        }

        /** Returns the value to which the specified key is mapped, or -1 if this map contains no mapping for the key */
        public int Get(int key)
        {
            if (key < 0 || key > SIZE)
                return -1;

            return keyValues[key];
        }

        /** Removes the mapping of the specified value key if this map contains a mapping for the key */
        public void Remove(int key)
        {
            if (key < 0 || key > SIZE)
                return;
            keyValues[key] = -1;
        }
    }

    /**
     * Your MyHashMap object will be instantiated and called as such:
     * MyHashMap obj = new MyHashMap();
     * obj.Put(key,value);
     * int param_2 = obj.Get(key);
     * obj.Remove(key);
     */
}
