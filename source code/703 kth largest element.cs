using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _703_kth_largest_element
{
    /// <summary>
    /// use minimum heap size k
    /// Use SortedDictionary<int, int> 
    /// </summary>
    public class KthLargest
    {
        private SortedDictionary<int, int> minimumHeap;
        private int size;
        private int actualSize; 

        static void Main(string[] args)
        {
            //RunTestcase();
            RunTestcase2(); 
        }

        public static void RunTestcase()
        {
            var test = new KthLargest(3, new int[] { 4, 5, 8, 2 });

            var shouldReturn4 = test.Add(3);
            var shouldReturn5 = test.Add(5); 
        }

        public static void RunTestcase2()
        {
            var test = new KthLargest(3, new int[] { 4, 5, 8, 2 });

            var shouldReturn4 = test.Add(3);
            var shouldReturn5 = test.Add(5);
            var shouldReturn5B = test.Add(10);
            var shouldReturn8 = test.Add(9);
            var shouldReturn8B = test.Add(4);
        }

        public KthLargest(int k, int[] nums)
        {
            if (k <= 0)
            {
                return;
            }

            minimumHeap = new SortedDictionary<int, int>();
            size = k; 

            var length = nums.Length;
            var heapSize = Math.Min(k, length);

            for (int i = 0; i < Math.Min(k, length); i++)
            {
                var current = nums[i];

                if (minimumHeap.ContainsKey(current))
                {
                    minimumHeap[current]++;
                }
                else
                {
                    minimumHeap.Add(current, 1);
                }
            }

            for (int i = heapSize; i < length; i++)
            {
                var current = nums[i];
                int minimum = minimumHeap.First().Key;

                if (current > minimum)
                {
                    addNumberToHeap(minimumHeap, current);
                    // remove minimum element
                    removeMinimum(minimumHeap); 
                }                
            }

            actualSize = heapSize;
        }

        public int Add(int value)
        {
            if (minimumHeap.Count == 0)
            {
                addNumberToHeap(minimumHeap, value);
                actualSize++;
                return value; 
            }

            var minimum = minimumHeap.First().Key;
            if (value > minimum || actualSize < size)  // catched by online judge - test case [[2,[0]],[-1],[1],[-2],[-4],[3]]
            {
                addNumberToHeap( minimumHeap, value);
                actualSize++;

                // remove minimum element
                if (actualSize > size) // not minimumHeap.Count - catched by online judge
                {
                    removeMinimum(minimumHeap);
                    actualSize--;
                }
            }

            return minimumHeap.First().Key;
        }

        private void addNumberToHeap(SortedDictionary<int, int> minimumHeap, int value)
        {
            if (minimumHeap.ContainsKey(value))
            {
                minimumHeap[value]++;
            }
            else
            {
                minimumHeap.Add(value, 1);
            }
        }

        private void removeMinimum(SortedDictionary<int, int> minimumHeap)
        {
            var minimum = minimumHeap.First().Key;

            if (minimumHeap[minimum] == 1)
            {
                minimumHeap.Remove(minimum);
            }
            else
            {
                minimumHeap[minimum]--;
            }
        }
    }

    /**
        * Your KthLargest object will be instantiated and called as such:
        * KthLargest obj = new KthLargest(k, nums);
        * int param_1 = obj.Add(val);
        */    
}
