using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_448_Find_All_numbers_disappeared
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

        private static void positionElementBasedOnValue(int[] nums) // [4,3,2,7,8,2,3,1]
        {
            int index = 0;

            var replaced = new List<int>();

            while (index < nums.Length)
            {
                if (nums[index] == index + 1)
                {
                    index++;
                    continue;
                }

                var current = nums[index];
                nums[index] = -1; // mark visited

                if (current == -1)
                {
                    index++;
                    continue;
                }

                if (nums[current - 1] != -1)
                {
                    replaced.Add(nums[current - 1]);
                }

                nums[current - 1] = current;                

                index++;
            }

            foreach (var item in replaced)
            {
                nums[item - 1] = item;
            }
        }

        private static int[] findMissingNumbers(int[] nums)
        {
            var missing = new List<int>(); 

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == -1)
                {
                    missing.Add(i + 1);
                }
            }

            return missing.ToArray(); 
        }
    }
}
