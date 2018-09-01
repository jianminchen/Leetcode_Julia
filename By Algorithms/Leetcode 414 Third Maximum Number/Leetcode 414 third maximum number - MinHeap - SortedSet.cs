using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_414_third_maximum_number_SortedSet
{
    class Program
    {
        public class MinHeap
        {
            /// <summary>
            /// use SortedSet to implement the minimum heap 
            /// </summary>
            public SortedSet<int> Set = new SortedSet<int>();

            public void Add(int val)
            {
                if (!Set.Contains(val))
                {
                    Set.Add(val);
                }
            }

            public int PopMin()
            {
                int minKey = Set.First();

                Set.Remove(minKey);

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
            for (; index < length && heap.Set.Count < 3; index++)
            {
                var current = nums[index];

                heap.Add(current);
            }

            if (heap.Set.Count < 3)
                return heap.Set.Last();

            for (int i = index; i < length; i++)
            {
                var current = nums[i];

                if (current > heap.Set.First() && !heap.Set.Contains(current))
                {
                    heap.PopMin();
                    heap.Add(current);
                }
            }

            return heap.PopMin();
        }
    }
}
