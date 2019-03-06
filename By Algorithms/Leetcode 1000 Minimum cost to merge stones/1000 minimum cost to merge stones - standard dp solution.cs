using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1000_minimum_cost_to_merge_stones_V
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// source code is based on the following:
        /// https://leetcode.com/problems/minimum-cost-to-merge-stones/discuss/247657/JAVA-Bottom-Up-%2B-Top-Down-DP-With-Explaination
        /// No matter how to split the two piles, the sum is always the sum of the two piles.
        /// Now the only thing that matters is how to get the minimum cost to split to two piles.
        /// So we need to know the minimum cost of merging left part to 1 pile, and minimum cost of merging right part to 1 pile, this is a typical sub problem.
        /// State: Minimum cost merging piles from i to j to 1 pile.
        /// Function: dp[i][j] = min(sum[i][j] + dp[i][k] + dp[k + 1][j]) (i <= k < j)
        /// Init:     dp[i][i] = 0 (Already a pile)
        /// Answer:   dp[1][len] (len is the stones number)
        /// </summary>
        /// <param name="stones"></param>
        /// <param name="K"></param>
        /// <returns></returns>        
        public int MergeStonesWhenKIs2(int[] stones, int K)
        {
            if (stones == null || stones.Length == 0) 
            {
                return 0;
            }

            int length = stones.Length;
            if ((length - 1) % (K - 1) != 0)  // K = 3, ok
            {
                return -1;
            } 

            int max    = int.MaxValue;

            var dp = new int[length + 1, length + 1];
            var prefixSum = new int[length + 1];
            
            for (int i = 1; i <= length; i++) 
            {
                prefixSum[i] = prefixSum[i - 1] + stones[i - 1];
            }
    
            for (int i = 1; i <= length; i++) 
            {
                dp[i, i] = 0;
            }
    
            // code review on March 5, 2019
            // build a table from span = 2 upper to length
            for (int span = 2; span <= length; span++) 
            {
                for (int start = 1; start + span - 1 <= length; start++) 
                {
                    int end = start + span - 1;

                    dp[start, end] = max;

                    int sum = prefixSum[end] - prefixSum[start - 1];

                    for (int number = start; number < end; number++) 
                    {
                        dp[start, end] = Math.Min(dp[start, end], dp[start, number] + dp[number + 1, end] + sum);
                    }
                }
            }
    
            return dp[1, length];
        }

        /// <summary>
        /// code review March 5, 2019
        /// 
        /// </summary>
        /// <param name="stones"></param>
        /// <param name="K"></param>
        /// <returns></returns>
        public int MergeStones(int[] stones, int K)
        {
            if (stones == null || stones.Length == 0)
            {
                return 0;
            }

            int length = stones.Length;
            if ((length - 1) % (K - 1) != 0)  // K = 3, ok
            {
                return -1;
            }

            int max = int.MaxValue;

            var dp = new int[length + 1, length + 1, K + 1];
            var prefixSum = new int[length + 1];

            for (int i = 1; i <= length; i++)
            {
                prefixSum[i] = prefixSum[i - 1] + stones[i - 1];
            }

            for (int i = 1; i <= length; i++)
            {
                for (int j = 1; j <= length; j++)
                {
                    for (int k = 1; k <= K; k++)
                    {
                        dp[i, j, k] = max;
                    }
                }
            }

            for (int i = 1; i <= length; i++)
            {
                dp[i, i, 1] = 0;
            }

            // code review on March 5, 2019
            // build a table from span = 2 upper to length
            for (int span = 2; span <= length; span++)
            {
                for (int start = 1; start + span - 1 <= length; start++)
                {
                    int end = start + span - 1;                    

                    int sum = prefixSum[end] - prefixSum[start - 1];                    

                    // new code to adjustify K instead of 2
                    for (int k = 2; k <= K; k++)
                    {                       
                        for (int number = start; number < end; number++)
                        {
                            dp[start, end, k] = Math.Min(dp[start, end, k], dp[start, number, k - 1] + dp[number + 1, end, 1]);
                        }

                        //dp[start, end, k] += sum;
                    }

                    dp[start, end, 1] = dp[start, end, K] + sum; // only apply to k = 1
                }
            }

            return dp[1, length, 1];
        }
    }
}
