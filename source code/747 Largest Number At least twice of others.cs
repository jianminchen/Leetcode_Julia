using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_747_Largest_Number
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// Largest number at least twice the other numbers
        /// return index of largest number, -1 not available
        /// - design
        /// iterate the array once
        /// maxIndex
        /// minimumValue - For largest element
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int DominantIndex(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return -1;

            var maxIndex = 0; 

            var secondLargestIndex = -1;             

            var length = nums.Length;

            // Find maximum vlaue
            // Find smaller one less than maximumum one
            for (int i = 1; i < length; i++)
            {
                var current = nums[i];
                if (current > nums[maxIndex])
                {
                    secondLargestIndex = maxIndex;
                    maxIndex = i;                    
                }
                else if (secondLargestIndex == -1 || current >= nums[secondLargestIndex])
                {
                    secondLargestIndex = i; 
                }
            }

            if (secondLargestIndex == -1 || nums[maxIndex] >= 2 * nums[secondLargestIndex])
                return maxIndex;
            else
                return -1; 
        }
    }
}
