using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _377_Combination_Sum___dp
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static int[] dp; 
        /// <summary>
        /// 377 dynamic programming solution - top down
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int CombinationSum4(int[] nums, int target)
        {
            var dp = new int[target + 1];

            for (int i = 0; i < target + 1; i++)
                dp[i] = -1; 

            dp[0] = 1;
            return helper(nums, target);
        }

        /// <summary>
        /// top down
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        private int helper(int[] nums, int target)
        {
            if (dp[target] != -1)
            {
                return dp[target];
            }

            int res = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (target >= nums[i])
                {
                    res += helper(nums, target - nums[i]);
                }
            }

            dp[target] = res;
            return res;
        }
    }
}
