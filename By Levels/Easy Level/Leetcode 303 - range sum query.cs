using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode303_rangeSumQuery
{
    /// <summary>
    /// Leetcode 303 - range sum query 
    /// 
    /// </summary>
    class NumArray
    {
        static void Main(string[] args)
        {
        }

        public static int[] PrefixSum;
        public NumArray(int[] nums)
        {
            if (nums == null)
                return;

            var length = nums.Length;
            PrefixSum = new int[length + 1];

            var previous = 0;
            for (int i = 0; i < length; i++)
            {
                PrefixSum[i] = previous;
                previous = PrefixSum[i] + nums[i];
            }

            PrefixSum[length] = previous;
        }

        /// <summary>
        /// inclusive - include i and j 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public int SumRange(int i, int j)
        {
            return PrefixSum[j + 1] - PrefixSum[i];
        }
    }
}
