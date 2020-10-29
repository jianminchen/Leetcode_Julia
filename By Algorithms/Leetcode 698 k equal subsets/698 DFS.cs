using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _698_partition_k_subset
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// First practice - Oct. 29, 2020
        /// study code
        /// https://leetcode.com/problems/partition-to-k-equal-sum-subsets/discuss/539188/C-recursion
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public bool CanPartitionKSubsets(int[] numbers, int k)
        {            
            var sum = numbers.Sum();

            if (sum % k != 0)
            {
                return false;
            }

            var percentage = sum / k;
            if (percentage < numbers.Max())
            {
                return false;
            }

            Array.Sort(numbers);

            return runDFS(numbers, 0, 0, percentage, k, new HashSet<int>());
        }

        /// <summary>
        /// standard DFS algorithm, mark visit, and also skip duplicate numbers
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="startIndex"></param>
        /// <param name="sum"></param>
        /// <param name="target"></param>
        /// <param name="k"></param>
        /// <param name="visitedIndex"></param>
        /// <returns></returns>
        private bool runDFS(int[] numbers, int startIndex, int sum, int target, int k, HashSet<int> visitedIndex)
        {
            if (k == 1)
            {
                return true;
            }

            if (sum > target)
            {
                return false;
            }

            if (sum == target)
            {
                return runDFS(numbers, 0, 0, target, k - 1, visitedIndex);
            }

            var length = numbers.Length;

            for (var i = startIndex; i < numbers.Length; i++)
            {
                if (visitedIndex.Contains(i))
                {
                    continue;
                }

                visitedIndex.Add(i);
                if (runDFS(numbers, i + 1, sum + numbers[i], target, k, visitedIndex))
                {
                    return true;
                }

                visitedIndex.Remove(i);

                // skip duplicate numbers, why? 
                while (i + 1 < numbers.Length && numbers[i] == numbers[i + 1])
                {
                    i++;
                }
            }

            return false;
        }
    }
}
