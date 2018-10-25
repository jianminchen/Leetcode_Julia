using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_283_move_zeros
{
    /// <summary>
    /// Leetcode 283 - move zeros
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// iterate the array from left to right once, fill nonzero element starting from 0
        /// 
        /// </summary>
        /// <param name="nums"></param>
        public void MoveZeroes(int[] nums)
        {
            if (nums == null)
                return;

            var nonZeroCount = 0;
            var length = nums.Length;

            for(int i = 0; i < length; i++)
            {
                var current = nums[i];
                if (current == 0)
                    continue;

                nums[nonZeroCount] = current;
                nonZeroCount++;
            }

            for(int i = nonZeroCount; i < length; i++)
            {
                nums[i] = 0;
            }
        }
    }
}
