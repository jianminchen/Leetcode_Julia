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

        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            if (k == 0)
            {
                return nums; // julia: base case is added to pass online judge. 
            }

            int length = nums.Length;
            int numberOfSlidingWindow = length - k + 1;

            var maximums = new int[numberOfSlidingWindow];

            var linkedList = new LinkedList<int>();  // LinkedList acts like deque

            for (int index = 0; index < length; index++)
            {
                var current = nums[index];

                // Remove the first number in the queue if it falls out of the sliding window
                if (linkedList.Count > 0 && linkedList.First.Value + k <= index)
                {
                    linkedList.RemoveFirst();
                }

                // Visit the current number, remove from the tail of the
                // queue indices if the value is smaller than the current number.
                while (linkedList.Count > 0 && nums[linkedList.Last.Value] <= current)
                {
                    linkedList.RemoveLast();
                }

                linkedList.AddLast(index);

                // Set the max value in the window (always the top number in the queue)                
                int maximumsIndex = index + 1 - k;
                if (maximumsIndex >= 0)
                {
                    maximums[maximumsIndex] = nums[linkedList.First.Value];
                }
            }

            return maximums;
        }
    }
}
