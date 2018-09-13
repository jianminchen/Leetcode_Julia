using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _239_sliding_window_maximum___August_2017
{
    class Program
    {
        static void Main(string[] args)
        {
        }
        /// <summary>
        /// optimal time complexity O(N), N is the length of the array. 
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            if (k == 0)
            {
                return nums;  
            }

            int length = nums.Length;
            int numberOfSlidingWindow = length - k + 1;

            var maximums = new int[numberOfSlidingWindow];

            var dequeue = new LinkedList<int>();  

            for (int index = 0; index < length; index++)
            {
                var current = nums[index];

                // Remove the first number in the queue if it falls out of the sliding window
                if (dequeue.Count > 0 && dequeue.First.Value + k <= index)
                {
                    dequeue.RemoveFirst();
                }

                // Visit the current number, remove from the tail of the
                // queue indices if the value is smaller than the current number.
                while (dequeue.Count > 0 && nums[dequeue.Last.Value] <= current)
                {
                    dequeue.RemoveLast();
                }

                dequeue.AddLast(index);

                // Set the max value in the window (always the top number in the queue)                
                int maximumsIndex = index + 1 - k;
                if (maximumsIndex >= 0)
                {
                    maximums[maximumsIndex] = nums[dequeue.First.Value];
                }
            }

            return maximums;
        }
    }
}
