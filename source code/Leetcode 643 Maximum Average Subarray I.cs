using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode634MaximumSubarrayI
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// using dynamic programming to calculate the sum of k continguous elements in the array, 
        /// first maximum one, and then get the avarage value
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public double FindMaxAverage(int[] nums, int k)
        {
            if (nums == null || k <= 0)
            {
                return 0; 
            }

            var length = nums.Length;
            double sum = 0;

            double maximumSum = double.MinValue;

            for (int i = 0; i < length; i++)
            {                                
                sum += nums[i];

                if (i > k - 1)
                {
                    sum -= nums[i - k]; // first one is at index 0
                }

                if (i >= k - 1)
                {
                    maximumSum = sum > maximumSum ? sum : maximumSum;
                }
            }

            return maximumSum / k; 
        }
    }
}
