using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1000_minimum_cost_to_merge_stones
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = MergeStones(new int[]{4, 6, 4, 7, 5}, 2);
        }

        /// <summary>
        /// greedy algorithm written by Julia - 2019-03-04
        /// Fail test case: 
        /// [69,39,79,78,16,6,36,97,79,27,14,31,4]  2
        /// output: 2014
        /// Expected: 1954
        /// </summary>
        /// <param name="stones"></param>
        /// <param name="K"></param>
        /// <returns></returns>
        public static int MergeStones(int[] stones, int K)
        {
            bool cannotFoundMinimum = false;
            var number = findMinimumCost(stones, K, ref cannotFoundMinimum);
            return cannotFoundMinimum ? -1 : number;
        }

        private static int findMinimumCost(int[] stones, int K, ref bool cannotFoundMinimum)
        {
            if (cannotFoundMinimum)
            {
                return -1;
            }

            if (stones == null || stones.Length <= 1)
                return 0;

            var length = stones.Length;

            if (length < K)
            {
                cannotFoundMinimum = true;
                return -1;
            }

            var sum = new int[length];

            var prefix = 0;
            for (int i = 0; i < length; i++)
            {
                sum[i] = prefix + stones[i];
                prefix = sum[i];
            }

            var startIndexes = new HashSet<int>();            
            var minKSum = int.MaxValue;
            for (int i = 0; i + K - 1 < length; i++)
            {
                var kSum = sum[i + K - 1];
                if (i > 0)
                {
                    kSum -= sum[i - 1];
                }

                if (kSum < minKSum)
                {
                    startIndexes.Clear();
                    startIndexes.Add(i);
                    minKSum = kSum;
                }
                else if (kSum == minKSum)
                {
                    startIndexes.Add(i);
                }
            }

            var minCost = int.MaxValue; 
            foreach(var minOne in startIndexes)
            {
                var subArray = new int[length - K + 1];
                int count = 0;
                for (int i = 0; i < minOne; i++)
                {
                    subArray[i] = stones[i];
                    count++;
                }

                subArray[count++] = minKSum;

                for (int i = minOne + K; i < length; i++)
                {
                    subArray[count] = stones[i];
                    count++;
                }

                var currentCost = minKSum + findMinimumCost(subArray, K, ref cannotFoundMinimum);
                minCost = currentCost < minCost? currentCost : minCost;
            }

            return minCost;
        }
    }
}
