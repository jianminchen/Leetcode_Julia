using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_198_House_robber
{
    /// <summary>
    /// Leetcode 198 house robber
    /// 7/21/2018
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

            var length = nums.Length;
            if(length == 1)
                return nums[0];
            if(length == 2)
                return Math.Max(nums[0], nums[1]);

            var maximum = new int[length];
            maximum[0] = nums[0];
            maximum[1] = Math.Max(nums[0], nums[1]);

            for(int i = 2; i < length; i++)
            {   //              rob ith house              not ith house
                maximum[i] = Math.Max(maximum[i - 2] + nums[i], maximum[i - 1]);
            }

            return maximum.Max();
        }
    }
}
