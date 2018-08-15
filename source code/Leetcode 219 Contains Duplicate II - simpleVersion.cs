using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_219_Contains_Duplicate_II
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = ContainsNearbyDuplicate(new int[] { 1, 2, 3, 1 }, 3);
        }

        /// <summary>
        /// time complexity O(N), N is total number of nodes
        /// use extra space, Dictionary<int, HashSet<int>> to look up
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0 || k <= 0)
                return false;

            var length = nums.Length;

            // simplify the design - only save latest index 
            //var prefix = new Dictionary<int, HashSet<int>>();
            var prefix = new Dictionary<int, int>();

            for (int i = 0; i < length; i++)
            {
                var current = nums[i];

                // try not to remove entry from the dictionary, just compare the difference
                if (prefix.ContainsKey(current) && (i - prefix[current]) <= k)
                {
                    return true;
                }

                if (!prefix.ContainsKey(current))
                {
                    prefix.Add(current, -1);
                }

                prefix[current] = i;                
            }

            return false;
        }
    }
}
