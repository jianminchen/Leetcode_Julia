using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_414_third_maximum_number___minimum_heap
{
    class Program
    {
        public class MinHeap
        {
            /// <summary>
            /// use SortedDictionary to implement the minimum heap 
            /// </summary>
            public SortedDictionary<int, int> Map = new SortedDictionary<int, int>();

            public void Add(int val, int node)
            {
                if (!Map.ContainsKey(val))
                {
                    Map.Add(val, node);
                }                
            }

            public int PopMin()
            {
                int minKey = Map.First().Key;                
                
                Map.Remove(minKey);                

                return minKey;
            }            
        }

        static void Main(string[] args)
        {
            var result = ThirdMax(new int[] { 2, 2, 3, 1 });
        }

        /// <summary>
        /// try to use MinHeap - August 15, 2018
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int ThirdMax(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return -1;

            var length = nums.Length;
            var heap = new MinHeap(); 

            // duplicate value makes this checking wrong
            //var lastOne = Math.Min(3, length);
            int index = 0;
            for (; index < length && heap.Map.Count < 3; index++)
            {
                var current = nums[index];

                heap.Add(current, current);
            }

            if (heap.Map.Count < 3)
                return heap.Map.Last().Key;

            for (int i = index; i < length; i++)
            {
                var current = nums[i];

                if (current > heap.Map.First().Key && !heap.Map.Keys.Contains(current))
                {
                    heap.PopMin();
                    heap.Add(current, current);
                }
            }

            return heap.PopMin();
        }
    }
}
