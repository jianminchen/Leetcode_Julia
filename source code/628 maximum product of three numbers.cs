using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_628_maximum_product_of_three_numbers
{
    /// <summary>
    /// Leetcode 628: maximum product of three numbers
    /// source code is based on the analysis:
    /// https://leetcode.com/problems/maximum-product-of-three-numbers/discuss/104803/2-liner-Python-solution-with-explanations
    /// There are two possible ways to get the largest number:

    /// biggest number * 2nd biggest * 3rd biggest
    /// biggest number * smallest number * 2nd smallest number (if the two smallest numbers 
    /// are negative)
    /// This formula will also work in the case there are all negative numbers, in which the 
    /// smallest negative number will be the result (based on condition 1).

    /// We can simply sort the numbers and retrieve the biggest/smallest numbers at the two 
    /// ends of the array.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {

        }

        public int MaximumProduct(int[] nums)
        {
            if (nums == null || nums.Length < 3)
                return -1;

            Array.Sort(nums);

            // maximum three numbers, smallest two numbers
            var length = nums.Length;
            return Math.Max(nums[length - 1] * nums[length - 2] * nums[length - 3],
                nums[length - 1] * nums[0] * nums[1]);
        }
    }
}
