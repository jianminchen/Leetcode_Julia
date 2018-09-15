using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _645_mismatch_study_code_bit_manipulations
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// ideas from the following:
        /// https://leetcode.com/problems/set-mismatch/discuss/113999/C++-True-O(1)-space-O(n)-time-(No-input-modifying)-with-clear-explanation
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] FindErrorNums(int[] nums)
        {
            int xorSum = 0, acc1 = 0, acc2 = 0;

            int length = nums.Length;

            // Get the xor of missing and duplicate numbers
            for (int i = 0; i < nums.Length; ++i)
                xorSum ^= (i + 1) ^ nums[i];

            xorSum &= -xorSum; // We'll use only the last significant set bit

            // Split the numbers in 2 categories and xor them
            for (int i = 0; i < length; ++i)
            {
                var current = nums[i];
                if((current & xorSum) == 0)
                    acc1 ^= nums[i];
                else 
                    acc2 ^= nums[i];

                if(((i + 1) & xorSum) == 0)
                {
                    acc1 ^= i + 1;
                }
                else 
                    acc2 ^= i + 1;
            }

            // Determine which is the duplicate number
            foreach(int n in nums)
            {
                if (n == acc1)
                    return new int[]{acc1, acc2};
            }

            return new int[]{acc2, acc1};
        }
    }
}
