using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1049_last_stone_weight_II___lee215
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// Oct. 9, 2019
        /// study code
        /// https://leetcode.com/problems/last-stone-weight-ii/discuss/294888/JavaC%2B%2BPython-Easy-Knapsacks-DP
        /// 
        /// The idea is to implement the solution using time complexity O(NS), N is length of the array, S is the sum of the array. 
        /// space complexity is O(S), where S = sum of the array stones. 
        /// </summary>
        /// <param name="stones"></param>
        /// <returns></returns>
        public static int LastStoneWeightII(int[] stones)
        {
            // length <= 30, value of stones [1, 100]
            var dp = new bool[1501];

            dp[0] = true;
            var sum = stones.Sum();

            var prefixSum = 0; 

            foreach (var item in stones)
            {
                prefixSum += item;
                for (int i = Math.Min(1500, prefixSum); i >= item; i--)
                {
                    dp[i] |= dp[i - item];
                }
            }

            for(int i = sum/2; i > 0; i--)
            {
                if(dp[i])
                {
                    return sum - i * 2; 
                }
            }

            return 0; 
        }
    }
}
