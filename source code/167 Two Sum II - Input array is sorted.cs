using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Two_sum_II___Input_array_is_sorted
{
    public class Solution
    {
        public int[] TwoSum(int[] numbers, int target)
        {
            if (numbers == null || numbers.Length == 0)
                return new int[0];

            var length = numbers.Length;

            var start = 0;
            var end = length - 1;
            while (start < end)
            {
                var left = numbers[start];
                var right = numbers[end];
                var sum = left + right;

                if (sum == target)
                {
                    return new int[] { start + 1, end + 1 };
                }
                else if (sum < target)
                {
                    start++;
                }
                else
                    end--;
            }

            return new int[0];
        }
    }
}
