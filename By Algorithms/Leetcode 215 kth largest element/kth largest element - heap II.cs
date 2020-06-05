using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _215_kth_largest_element
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// First practice: June 4, 2020
        /// </summary>
        public class MinHeap
        {
            /// <summary>
            /// use SortedDictionary to implement the minimum heap              
            /// </summary>
            public SortedDictionary<int, int> sorted = new SortedDictionary<int, int>();

            public void Add(int val)
            {
                if (sorted.ContainsKey(val))
                {
                    sorted[val]++;
                }
                else
                {
                    sorted.Add(val, 1);
                }
            }

            /// <summary>
            /// SortedDictionary<int> default is in ascending order. 
            /// 
            /// </summary>
            /// <returns></returns>
            public int PopMin()
            {
                int minKey = sorted.Keys.First();

                var count = sorted[minKey];
                if (count == 1)
                {
                    sorted.Remove(minKey);
                }
                else
                {
                    sorted[minKey]--;
                }

                return minKey;
            }
        }

        /// <summary>
        /// Find kth largest element in the array, not kth largest distinct element
        /// For example, [1, 2, 3, 4, 5], kth largest element is 4 if k = 2; how to find 4? 
        /// All elements should be searched, last one is 5, kth one should be minimum one on the top. 
        /// The tricky part is to keep minimum heap size as k
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int FindKthLargest(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0 || k < 0)
                return -1;            

            var length = nums.Length;
            var heap = new MinHeap();

            // Let us keep min heap size as k all the time
            // In other words, add one number to the heap, 
            // move the minimum one in the heap as well if heap's size is bigger than k. 
            int size = 0;

            for (int i = 0; i < length; i++)
            {
                var value = nums[i];
                size++;

                heap.Add(value);

                if (size > k)
                {
                    heap.PopMin();
                }
            }

            return heap.PopMin();
        }
    }
}
