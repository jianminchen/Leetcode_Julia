using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_724_Find_pivot_index
{
    class Program
    {
        static void Main(string[] args)
        {
            var index = PivotIndex(new int[] { 1, 7, 3, 6, 5, 6 });
        }

        /// <summary>
        /// The optimal time complexity should be O(N), N is the size of the array. 
        /// I like to preprocess the array to get prefix sum and suffix sum first, using two extra arrays
        /// to store those results. 
        /// Iterate the array from left to right, and then check prefix sum and suffix sum and then find the
        /// smallest pivot index. 
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int PivotIndex(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return -1; 

            var prefixSum = calculatePrefixSum(nums);
            var suffixSum = calculateSuffixSum(nums);

            var length = nums.Length;

            for (int i = 0; i < length; i++)
            {
                var left  = i == 0 ? 0 : prefixSum[i - 1];
                var right = i == length - 1 ? 0 : suffixSum[i + 1];

                if (left == right)
                {
                    return i;
                }
            }

            return -1; 
        }

        private static int[] calculatePrefixSum(int[] nums)
        {
            var prefix = new int[nums.Length];

            int sum = 0; 
            for (int i = 0; i < nums.Length; i++)
            {                
                sum += nums[i];
                prefix[i] = sum; 
            }

            return prefix;
        }

        private static int[] calculateSuffixSum(int[] nums)
        {
            var suffix = new int[nums.Length];

            int sum = 0;
            var length = nums.Length;

            for (int i = 0; i < length; i++)
            {
                var index = length - i - 1;
                sum += nums[index];
                suffix[index] = sum;
            }

            return suffix;
        }
    }
}
