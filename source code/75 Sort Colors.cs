using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _75_Sort_Colors
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// my discuss link is here:
        /// https://leetcode.com/problems/sort-colors/discuss/278391/C-Work-on-test-case-2-0-1-2-and-then-figure-out-the-idea
        /// </summary>
        /// <param name="nums"></param>
        public void SortColors(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return;
            var length = nums.Length;

            var zeroIndex = 0;
            var twoIndex = length - 1;
            for (int i = 0; i <= twoIndex; i++)
            {
                while (nums[i] == 2 && i < twoIndex)
                {
                    swap(nums, i, twoIndex);
                    twoIndex--;
                }

                while (nums[i] == 0 && i > zeroIndex)
                {
                    swap(nums, i, zeroIndex);
                    zeroIndex++;
                }
            }
        }

        private static void swap(int[] nums, int start, int end)
        {
            var tmp = nums[start];

            nums[start] = nums[end];
            nums[end] = tmp;
        }
    }
}
