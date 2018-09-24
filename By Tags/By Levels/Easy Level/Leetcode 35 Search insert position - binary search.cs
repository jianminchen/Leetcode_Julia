using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_35_Search_insert_position
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// input array is sorted in ascending order
        /// find index for the target, if it is not in the array, then return next larger one's index
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int SearchInsert(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
                return -1;

            var length = nums.Length;
            var start = 0;
            var end = length - 1;

            var smallestIndex = length; 
            while (start <= end)
            {
                var middle = start + (end - start) / 2;
                var middleValue = nums[middle];

                if (middleValue == target)
                {
                    return middle;
                }

                if (middleValue > target)
                {
                    smallestIndex = middle;
                    end = middle - 1; 
                }
                else
                {
                    start = middle + 1; 
                }
            }

            return smallestIndex;
        }
    }
}
