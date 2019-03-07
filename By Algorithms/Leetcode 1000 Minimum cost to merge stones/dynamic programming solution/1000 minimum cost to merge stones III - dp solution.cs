using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_1000_minimum_cost_to_merge_stones
{
    class Program
    {        
        static void Main(string[] args)
        {
            var result = MergeStones(new int[] { 4, 6, 6, 4 }, 2);
        }            

        /// <summary>
        /// code review March 7, 2019
        /// code is based on the following
        /// https://leetcode.com/problems/minimum-cost-to-merge-stones/discuss/247567/JavaC%2B%2BPython-DP
        /// No matter how to split the two piles, the sum is always the sum of the two piles.
        /// Now the only thing that matters is how to get the minimum cost to split to two piles.
        /// So we need to know the minimum cost of merging left part to 1 pile, 
        /// and minimum cost of merging right part to 1 pile, this is a typical sub problem.
        /// State: Minimum cost merging piles from i to j to 1 pile.
        /// Function: dp[i][j] = min(sum[i][j] + dp[i][k] + dp[k + 1][j]) (i <= k < j)
        /// Init: dp[i][i] = 0 (Already a pile)
        /// Answer: dp[1][len] (len is the stones number)
        /// </summary>
        /// <param name="stones"></param>
        /// <param name="K"></param>
        /// <returns></returns>
        public static int MergeStones(int[] stones, int K)
        {
            int length = stones.Length;

            // complicated formula? How to get the formula? 
            if ((length - 1) % (K - 1) > 0)
            {
                return -1;
            }

            var prefix = new int[length + 1];

            for (int i = 0; i < length; i++)
            {
                prefix[i + 1] = prefix[i] + stones[i];
            }

            var dp = new int[length, length];

            // Fact 1: dp[start, end] is 0 if span < K
            // Fact 2: ...
            for (int span = K; span <= length; ++span)
            {
                for (int start = 0; start + span <= length; ++start)
                {
                    int end = start + span - 1;

                    dp[start, end] = int.MaxValue;

                    // Julia likes to write some notes to help understand the code and reasoning here:
                    // 1. brute force solution
                    // 2. all subproblems will be exhausted
                    // 3. argue that all subproblems will be solved already 
                    // since for loop for variable span starts from K to go up
                    for (int split = start; split < end; split += K - 1)
                    {
                        dp[start, end] = Math.Min(dp[start, end], dp[start, split] + dp[split + 1, end]);
                    }

                    // add all elements together only if there are K elements. 
                    // this is base case. Otherwise everything will be 0 all the time
                    // we need to add some value to dp output 
                    if ((end - start) % (K - 1) == 0)
                    {
                        dp[start, end] += prefix[end + 1] - prefix[start];
                    }
                }
            }

            return dp[0, length - 1];
        }
    }
}

