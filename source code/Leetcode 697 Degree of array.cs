using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_697_Degree_of_array
{
    public class Solution
    {
        public int FindShortestSubArray(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return -1;

            var dict = new Dictionary<int, int[]>();

            var degree = 0;
            var minSpan = nums.Length + 1;
            var length = nums.Length;
            for (int i = 0; i < length; i++)
            {
                var current = nums[i];
                if (!dict.ContainsKey(current))
                    dict.Add(current, new int[] { 1, i, i });
                else
                {
                    dict[current][0]++;
                    dict[current][2] = i;
                }

                var currentCount = dict[current][0];
                var currentSpan = dict[current][2] - dict[current][1] + 1;
                if (currentCount > degree)
                {
                    degree = currentCount;
                    minSpan = currentSpan;
                }
                else if (currentCount == degree && currentSpan < minSpan)
                    minSpan = currentSpan;
            }

            return minSpan;
        }
    }
}
