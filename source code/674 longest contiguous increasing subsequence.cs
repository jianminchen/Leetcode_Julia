using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_674_Longest_contiguous_increasing_subsequ
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// iterate the array from left to right; 
        /// and then record current increasing continugous length;
        /// update maximum one if need. 
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindLengthOfLCIS(int[] nums)
        {
            if (nums == null)
                return 0;

            var length = nums.Length;
            int max = 0;

            int index = 0; 
            for (int i = 0; i < length; i++)
            {
                var current = nums[i];

                if (i == 0 || current > nums[i - 1])
                {
                    index++;
                    max = index > max ? index : max;
                }
                else if (i > 0 && current <= nums[i - 1])
                {
                    index = 1; 
                }
            }

            return max; 
        }
    }
}
