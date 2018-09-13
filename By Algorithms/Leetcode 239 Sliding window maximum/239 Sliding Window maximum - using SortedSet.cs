using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _239_Sliding_window_maximum___Sortedset___logK_N
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// the solution does not have optimal time complexity
        /// 
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            if (k < 1 || nums.Length == 0)
            {
                return new int[0];
            }

            var result = new int[nums.Length - k + 1];

            var map = new Dictionary<int, int>(nums.Length);

            var binarySearchTree = new SortedSet<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                var visit = nums[i];

                binarySearchTree.Add(visit);   // O(LogK)

                map[visit] = i;       // O(1), duplicate number will be updated with latest index

                if (i < k - 1)
                {
                    continue;
                }

                if (i >= k && map[nums[i - k]] == (i - k))  // O(1)
                {
                    var kStepAway = nums[i - k];

                    binarySearchTree.Remove(kStepAway);    // O(logK)

                    map.Remove(kStepAway);        // O(1)
                }

                result[i - k + 1] = binarySearchTree.Max;    // O(1)
            }

            return result;
        }
    }
}
