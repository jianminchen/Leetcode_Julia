using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _930_Binary_subarrays_with_sum
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// the code was written in the weekly contest 108. I did submit five time until the code 
        /// passed online judge. 
        /// Here is my discuss link:
        /// https://leetcode.com/problems/binary-subarrays-with-sum/discuss/186713/C-it-took-me-five-submissions-in-the-contest-one-hour
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int NumSubarraysWithSum(int[] numbers, int target)
        {
            if (numbers == null || target < 0)
                return 0;

            var sum = numbers.Sum();
            if (target > sum)
                return 0;

            int length = numbers.Length;
            var onePositions = new int[sum];
            if (sum == 0)
            {
                return length * (length + 1) / 2;
            }

            int index = 0;

            var diff = 0;
            for (int i = 0; i < length; i++)
            {
                if (numbers[i] == 1)
                {
                    onePositions[index] = i;

                    if (index == 0)
                    {
                        diff += i * (i + 1) / 2;
                    }
                    else
                    {
                        int no = (i - onePositions[index - 1] - 1);
                        diff += no * (no + 1) / 2;
                    }

                    index++;
                }
            }

            int no2 = length - onePositions[sum - 1] - 1;
            diff += no2 * (no2 + 1) / 2;

            if (target == 0)
            {
                return diff;
            }

            int totalCount = 0;
            // need to work on the counting
            for (int start = 0; start >= 0 && (start + target - 1) < sum; start++)
            {
                int end = start + target - 1;

                var startIndex = onePositions[start]; // index out of range
                var endIndex = onePositions[end];

                int variation1 = 0;
                if (start == 0)
                {
                    variation1 = startIndex + 1;
                }
                else
                {
                    variation1 = startIndex - onePositions[start - 1];
                }

                int variation2 = 0;
                if (end == sum - 1)
                {
                    variation2 = length - endIndex;
                }
                else
                {
                    variation2 = onePositions[end + 1] - endIndex;
                }

                totalCount += variation1 * variation2;
            }

            return totalCount;
        }
    }
}
