using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_39_combination_sum___study_code_7_2018
{
    /// <summary>
    /// Leetcode 39 - 
    /// https://leetcode.com/problems/combination-sum/description/
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            RunTestcase(); 
        }
        /// <summary>
        /// time complexity analysis:
        /// combination starting from 2, target 7, minimum is 2, at most 4 elements in one combination
        /// starting from 2, look for at most another 3 elements -> recursive function, depth first search
        /// at most 3 time, exhaust all options. Each step at most 4 options. So in total will be 4^3 = 64 recursive
        /// calls.
        /// next step, minimum value in combination starts from 3, each step at most 3 options, so in total
        /// will be 3^3 = 27 calls
        /// so the recursive calls should be 4^3 + 3^3 + 2^3 + 1 ^3 
        /// the idea is to sort the candidates first in ascending order. 
        /// </summary>
        public static void RunTestcase()
        {
            var result = CombinationSum(new int[]{2,3,6,7}, 7);
        }

        public static IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            var result = new List<IList<int>>();
            var combination = new List<int>();
            Array.Sort(candidates);

            CombinationSum(result, candidates, combination, target, 0);
            return result;
        }

        /// <summary>
        /// I like to talk about the design:
        /// this algorithm is like brute force solution, using back tracking. 
        /// combination can be bruted force to find solution. Like minimum value in the combination. 
        /// starting from each one. 
        /// </summary>
        /// <param name="result"></param>
        /// <param name="candidates"></param>
        /// <param name="combination"></param>
        /// <param name="target"></param>
        /// <param name="start"></param>
        private static void CombinationSum(
            IList<IList<int>> result, 
            int[] candidates, 
            IList<int> combination, 
            int target, 
            int start)
        {
            if (target == 0)
            {
                result.Add(new List<int>(combination));
                return;
            }

            // enforce the combination numbers in the list will be non-descending order
            // brute force the start value from all possible values starting from start variable
            for (int i = start; i != candidates.Length && target >= candidates[i]; ++i)
            {
                combination.Add(candidates[i]);
                CombinationSum(result, candidates, combination, target - candidates[i], i);
                combination.Remove(combination.Last());
            }
        }
    }
}
