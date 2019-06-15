using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _377_combination_sum___bottom_up
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// Leetcode 377 - combination sum 
        /// bottom up - dynamic programming 
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int CombinationSum4(int[] nums, int target) {
            var combinations = new int[target + 1];

            combinations[0] = 1;

            // go over all options
            for (int i = 1; i < combinations.Length; i++)
            {
                for (int j = 0; j < nums.Length; j++)
                {
                    var number = i - nums[j];

                    if (number >= 0)
                    {
                        combinations[i] += combinations[number];
                    }
                }
            }

            return combinations[target];
        }        
    }
}
