using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _645_set_mismatch
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// sort the array, and then find missing number and duplicate
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] FindErrorNums(int[] nums)
        {
            if (nums == null || nums.Length <= 1)
                return new int[0];

            Array.Sort(nums);

            // should be from 1 to n
            var result = new int[2]; // first one is duplicated number, missing number is the second one.
            var findMissing = false;

            for (int i = 0; i < nums.Length; i++)
            {
                if (!findMissing && (i + 1) != nums[i])
                {                    
                    findMissing = true;
                }

                if(findMissing && (i > 0 && nums[i] == nums[i-1]))
                {
                    result[0] = nums[i];
                }
            }

            var xorSum = 0;
            foreach (var item in nums)
            {
                xorSum ^= item;
            }
            for (int i = 0; i < nums.Length; i++)
            {
                xorSum ^= i + 1;
            }

            result[1] = xorSum ^ result[0];

            return result;
        }
    }
}
