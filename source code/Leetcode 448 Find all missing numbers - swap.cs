using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_448_Find_all_missing_numbers___study_code
{
    class Program
    {
        static void Main(string[] args)
        {
            // [4,3,2,7,8,2,3,1]
            var missing = FindDisappearedNumbers(new int[] { 4, 3, 2, 7, 8, 2, 3, 1 });
        }

        /// <summary>
        /// Do not use extra space 
        /// start from index = 0, iterate the array for each element, try
        /// to reposition the element into the position based on its value.
        /// 
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static IList<int> FindDisappearedNumbers(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return new List<int>();
            }

            positionElementBasedOnValue(nums);

            return findMissingNumbers(nums);
        }

        /// <summary>
        /// study code:
        /// https://leetcode.com/problems/find-all-numbers-disappeared-in-an-array/discuss/160034/O(n)-Swap
        /// </summary>
        /// <param name="nums"></param>
        private static void positionElementBasedOnValue(int[] nums) // [4,3,2,7,8,2,3,1]
        {
            for (int i = 0; i < nums.Length; i++)
            {
                // swap two elements 
                while (nums[i] != i + 1 && nums[i] != nums[nums[i] - 1])
                {
                    // i swaps with nums[i] - 1                    
                    var swapTo = nums[i] - 1;

                    int temp = nums[swapTo];
                    nums[swapTo] = nums[i];
                    nums[i] = temp;
                }
            }
        }

        private static int[] findMissingNumbers(int[] nums)
        {
            var missing = new List<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != i + 1)
                {
                    missing.Add(i + 1);
                }
            }

            return missing.ToArray();
        }
    }
}
