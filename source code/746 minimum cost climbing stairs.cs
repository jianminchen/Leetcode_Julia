using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_746_minimum_cost_climbing_stairs
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// using dynamic programming method to solve the problem
        /// </summary>
        /// <param name="cost"></param>
        /// <returns></returns>
        public int MinCostClimbingStairs(int[] cost)
        {
            if (cost == null)
                return 0;
            
            var length = cost.Length;
            if (length == 1)
            {
                return 0;
            }

            var dp = new int[length];            
            
            for (int i = 0; i < length; i++)
            {
                if (i <= 1)
                {
                    dp[i] = cost[i];
                }
                else
                {
                    dp[i] = cost[i] + Math.Min(dp[i - 1], dp[i - 2]);
                }
            }

            return Math.Min(dp[length - 1], dp[length - 2]);
        }
    }
}
