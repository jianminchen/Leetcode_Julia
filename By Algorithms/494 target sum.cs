using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _494_target_sum___optimal
{
    class Program
    {
        static void Main(string[] args)
        {
            var ways = findTargetSumWays(new int[]{1, 1, 1, 1, 1}, 3);
        }

        /// <summary>
        /// study code
        /// Nov. 3, 2020
        /// https://leetcode.com/problems/target-sum/discuss/97334/java-15-ms-c-3-ms-ons-iterative-dp-solution-using-subset-sum-with-explanation
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int findTargetSumWays(int[] nums, int s) {
            int sum = nums.Sum();
            if(sum < s)
            {
                return -1; 
            }
            return (s + sum) % 2 > 0 ? 0 : subsetSum(nums, (s + sum) >> 1); 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        private static int subsetSum(int[] nums, int target) 
        {
            int[] dp = new int[target + 1]; 
            dp[0] = 1;  // empty set - sum = 0

            foreach (var n in nums)
            {
                // add n to set one by one
                // how many sets - vary on total sum 
                // 
                for (int i = target; i >= n; i--)
                {
                    // add n to subset with sum (i - n)
                    dp[i] += dp[i - n];
                }
            }

            return dp[target];
        } 
    }
}
