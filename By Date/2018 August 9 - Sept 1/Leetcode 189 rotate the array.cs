using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_189_rotate_the_array
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// in place, based on in place reverse the array
        /// How to handle the case when k >= array's length?
        /// if the array has length 2, [1, 2], k = 3
        /// then we know 2 steps to right will go back to original array. 
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        public void Rotate(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0 || k < 0)
                return;             

            var length = nums.Length;

            var steps = k % length;

            reverseArray(nums, 0, length - 1);
            reverseArray(nums, 0, steps - 1);
            reverseArray(nums, steps, length - 1);
        }

        private static void reverseArray(int[] numbers, int start, int end)
        {
            while (start < end)
            {
                var temp = numbers[start];
                numbers[start] = numbers[end];
                numbers[end] = temp;
                start++;
                end--; 
            }
        }
    }
}
