using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _377_combination_sum
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// Leetcode 377 - combination sum
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int CombinationSum4(int[] nums, int target)
        {
            if (target == 0)
            {
                return 1;
            }

            int result = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                var current = nums[i];

                if (target >= current)
                {
                    result += CombinationSum4(nums, target - current);
                }
            }

            return result;
        }
    }
}
