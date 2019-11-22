using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _239_sliding_window_maximumII
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// 239 sliding window maximum
        /// Nov. 22, 2019
        /// Practice on mock interview 
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] MaxSlidingWindow(int[] numbers, int k)
        {
            if (numbers == null || numbers.Length == 0)
            {
                return new int[0];
            }

            var deque = new LinkedList<int>();

            var length = numbers.Length;
            var limit = Math.Min(length, k);

            for (int i = 0; i < limit; i++)
            {
                var current = numbers[i];
                if (deque.Count == 0 || numbers[deque.Last.Value] > current)
                {
                    deque.AddLast(i);
                    continue;
                }

                while (deque.Count > 0 && numbers[deque.Last.Value] < current)
                {
                    deque.RemoveLast();
                }

                deque.AddLast(i);
            }

            var max = new int[length - k + 1];
            max[0] = numbers[deque.First.Value];
            if (deque.First.Value == 0)
            {
                deque.RemoveFirst();
            }

            for (int i = limit; i < length; i++)
            {
                var current = numbers[i];
                if (deque.Count == 0 || numbers[deque.Last.Value] > current)
                {
                    deque.AddLast(i);
                }
                else
                {
                    while (deque.Count > 0 && numbers[deque.Last.Value] < current)
                    {
                        deque.RemoveLast();
                    }

                    deque.AddLast(i);
                }

                var maximumIndex = deque.First.Value;
                max[i - limit + 1] = numbers[maximumIndex];
                if (maximumIndex == i - k + 1)
                {
                    deque.RemoveFirst();
                }
            }

            return max;
        }
    }
}
