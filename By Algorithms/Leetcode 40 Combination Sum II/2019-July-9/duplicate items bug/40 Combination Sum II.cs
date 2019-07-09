using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _40_Combination_sum_II
{
    class Program
    {
        static void Main(string[] args)
        {            
            RunTestcase(); 
        }

        public static void RunTestcase()
        {
            var numbers = new int[] { 14, 6, 25, 9, 30, 20, 33, 34, 28, 30, 16, 12, 31, 9, 9, 12, 34, 16, 25, 32, 8, 7, 30, 12, 33, 20, 21, 29, 24, 17, 27, 34, 11, 17, 30, 6, 32, 21, 27, 17, 16, 8, 24, 12, 12, 28, 11, 33, 10, 32, 22, 13, 34, 18, 12 };
            var result  = CombinationSum2(numbers, 27);
        }

        /// <summary>
        /// July 9, 2019
        /// It takes time for me to master backtracking algorithm. 
        /// The combination sum - 
        /// First find a combination using DFS
        /// Second avoid duplicate, two tips:
        /// tip 1: sort the array
        /// tip 2: avoid digit if it is same as previous, since it is the subset of previous step. 
        /// tip 3: DFS + pruning - the idea of pruning is not too tough to recall!
        /// </summary>
        /// <param name="candidates"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            if (candidates == null)
                return new List<IList<int>>();

            Array.Sort(candidates); 

            var result = new List<IList<int>>();
            var list = new List<int>(); 

            RunDFS(candidates, 0, target, result, list);

            return result; 
        }

        /// <summary>
        /// DFS + pruning
        /// wrong answer
        /// [[1,1,6],[1,2,5],[1,5,2],[1,7],[2,1,5],[2,6],[5,1,2],[6,2],[7,1]]
        /// should be
        /// [[1,1,6],[1,2,5],[1,7],[2,6]]
        /// </summary>
        /// <param name="candidates"></param>
        /// <param name="index"></param>
        /// <param name="target"></param>
        /// <param name="result"></param>
        private static void RunDFS(int[] candidates, int index, int target, List<IList<int>> result, IList<int> list)
        {
            var length = candidates.Length;            

            // base case
            if (target == 0)
            {
                // need a copy of list 
                var copyList = new List<int>(list);
                result.Add(copyList); //caught by debugger, forget to use copyList variable name
                return; 
            }                       
            
            for (int start = index; start < length; start++)
            {
                var current = candidates[start];
                 
                // prune idea is simple to follow 
                var isDuplicate = start > index && candidates[start] == candidates[start - 1];
                if (isDuplicate )
                    continue;                 

                list.Add(current);
                RunDFS(candidates, index + 1, target - current, result, list);  // caught by debugger - index + 1 is wrong                

                // backtracking 
                list.RemoveAt(list.Count - 1);
            }
        }
    }
}
