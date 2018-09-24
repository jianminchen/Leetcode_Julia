using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_213_House_robber_II
{
    /// <summary>
    /// Leetcode 213 house robber 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
        }

        public int Rob(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;

            if (nums.Length == 1)
                return nums[0];
            if (nums.Length == 2)
                return Math.Max(nums[0], nums[1]);

            var length = nums.Length;
            return Math.Max(getMaximum(nums, 0, length - 2), getMaximum(nums, 1, length - 1 ));
        }

        private static int getMaximum(int[] nums, int start, int end)
        {
            var length = nums.Length;
            var maximum = new int[length];

            maximum[start] = nums[start];
            for(int i = start + 1; i <= end; i++)
            {
                if(i == start + 1)
                {
                    maximum[i] = Math.Max(nums[i - 1], nums[i]);
                }
                else
                {
                    maximum[i] = Math.Max(nums[i] + maximum[i - 2], maximum[i - 1]);
                }
            }

            return maximum[end];
        }
    }
}
