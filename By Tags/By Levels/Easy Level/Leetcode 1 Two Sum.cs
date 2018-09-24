using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_1_Two_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// the array is not sorted. To avoid using time complexity more than linear, 
        /// a hashset can be used to lower down the time complexity to optimal, linear time
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSum(int[] nums, int target)
        {
            if(nums == null || nums.Length < 2)
                return new int[0];

            var visited = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                var current = nums[i];
                var search = target - current;

                if (visited.ContainsKey(search))
                {
                    return new int[] { visited[search], i };
                }
                else
                {
                    if (!visited.ContainsKey(current))
                    {
                        visited.Add(current, i); 
                    }
                }
            }

            return new int[0];
        }
    }
}
