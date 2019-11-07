using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _239_sliding_window_max
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = MaxSlidingWindow(new int[] { 1, 3, -1, -3, 5, 3, 6, 7 }, 3);
        }

        /// <summary>
        /// code review on Nov. 6, 2019
        /// Time complexity: O(N), N is is the length of the array
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int[] MaxSlidingWindow(int[] numbers, int k)
        {
            if (k == 0)
            {
                return numbers;
            }

            var length = numbers.Length;
            var windowCount = length - k + 1;

            var answer = new int[windowCount];

            var queue = new LinkedList<int>();

            // Queue stores indices of array, and 
            // values are in decreasing order.
            // So, the first node in queue is the max in window
            for (int i = 0; i < length; i++)
            {
                // 1. remove element from head until first number within window
                if (queue.Count > 0 && queue.First.Value + k <= i)
                {
                    queue.RemoveFirst();                    
                }

                // 2. before inserting i into queue, remove from the tail of the
                // queue indices with smaller values - why?
                // those elements in the array cannot be maximum one. 
                while (queue.Count > 0 && numbers[queue.Last.Value] <= numbers[i])
                {
                    queue.RemoveLast();
                }

                queue.AddLast(i);

                // 3. set the max value in the window (always the top number in
                // queue)
                int index = i + 1 - k;
                if (index >= 0)
                {
                    answer[index] = numbers[queue.First.Value];
                }
            }

            return answer;
        }
    }
}
