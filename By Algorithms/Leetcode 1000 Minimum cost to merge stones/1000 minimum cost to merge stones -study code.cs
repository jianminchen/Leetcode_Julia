using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1000_merge_stones___study_code
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = MergeStones(new int[]{6, 4, 4, 6}, 2);
        }

        private static int     numberK;
        private static int[]   prefixSum; // preSum[i] is sum of stones[0] to stones[i].
        private static int[,,] memo;

        /// <summary>
        /// study code in the following:
        /// https://leetcode.com/problems/minimum-cost-to-merge-stones/discuss/249606/Top-down-DP-Logical-Thinking
        /// </summary>
        /// <param name="stones"></param>
        /// <param name="K"></param>
        /// <returns></returns>
        public static int MergeStones(int[] stones, int K) {
            if (stones.Length == 1)
            {
                return 0;
            }

            numberK = K;
            int length = stones.Length;
            memo = new int[length + 1, length + 1, K + 1];

            prefixSum = new int[length + 1];
        
            getPrefixSum(stones, K);
        
            int result = mergeStonesToPiles(1, length, 1, stones);
        
            return result == int.MaxValue ? -1 : result;
        }

        private static void getPrefixSum(int[] stones, int K)
        {
            prefixSum[0] = 0;
            for (int i = 1; i < prefixSum.Length; i++)
            {
                prefixSum[i] = prefixSum[i - 1] + stones[i - 1];
            }
        }    
        
        /// <summary>
        /// Minimum cost merging piles from start to end into targetPiles pile.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="targetPiles"></param>
        /// <param name="stones"></param>
        /// <returns></returns>
        public static int mergeStonesToPiles(int start, int end, int targetPiles, int[] stones) 
        {
            if (memo[start, end, targetPiles] != 0)
            {
                return memo[start, end, targetPiles];
            }

            var maxValue = int.MaxValue;  // not found

            if (end - start + 1 < targetPiles)
            {
                return maxValue;
            }

            if (start == end)
            {
                return (targetPiles == 1) ? 0 : maxValue;
            }
        
            if (targetPiles == 1) 
            {
                int subMinCost = mergeStonesToPiles(start, end, numberK, stones);

                if (subMinCost != maxValue)
                {
                    memo[start, end, targetPiles] = prefixSum[end] - prefixSum[start - 1] + subMinCost;
                }
                else
                {
                    memo[start, end, targetPiles] = subMinCost;
                }

                return memo[start, end, targetPiles];
            }

            int minCost = int.MaxValue; // not found

            for (int k = start; k <= end - 1; k++) 
            {
                int leftCost = mergeStonesToPiles(start, k, targetPiles - 1, stones);
                if (leftCost == maxValue)
                {
                    continue;
                }

                int rightCost = mergeStonesToPiles(k + 1, end, 1, stones);
                if (rightCost == maxValue)
                {
                    continue;
                }

                minCost = Math.Min(leftCost + rightCost, minCost);
            }
        
            memo[start, end, targetPiles] = minCost;
            return minCost;
        }
    }
}
