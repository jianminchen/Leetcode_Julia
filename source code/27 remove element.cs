using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_27_remove_element
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// Scan the array from left to right, and then also increment index from 0 to save 
        /// the array with removed value specified by function argument val
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public int RemoveElement(int[] nums, int val)
        {
            if (nums == null || nums.Length == 0)
                return 0;

            int index = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                var current = nums[i];
                if (val != current)
                {
                    nums[index++] = current;
                }
            }

            return index; 
        }
    }
}
