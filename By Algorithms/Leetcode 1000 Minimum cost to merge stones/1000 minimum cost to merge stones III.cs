using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1000_minimum_cost_to_merge_stones_III
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = MergeStones(new int[] { 4, 6, 6, 4 }, 2);
        }

        /// <summary>
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
            int n = stones.Length;

            if ((n - 1) % (K - 1) > 0)
            {
                return -1;
            }

            int[] prefix = new int[n + 1];

            for (int i = 0; i < n; i++)
            {
                prefix[i + 1] = prefix[i] + stones[i];
            }

            var dp = new int[n, n];
            for (int m = K; m <= n; ++m)
            {
                for (int i = 0; i + m <= n; ++i)
                {
                    int j = i + m - 1;

                    dp[i, j] = int.MaxValue;

                    for (int mid = i; mid < j; mid += K - 1)
                    {
                        dp[i, j] = Math.Min(dp[i, j], dp[i, mid] + dp[mid + 1, j]);
                    }

                    if ((j - i) % (K - 1) == 0)
                    {
                        dp[i, j] += prefix[j + 1] - prefix[i];
                    }
                }
            }

            return dp[0, n - 1];
        }
    }
}
