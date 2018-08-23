using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_268_Missing_number
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public int MissingNumber(int[] nums)
        {
            if (nums == null)
                return -1;

            var length = nums.Length;

            var missing = 0;

            for (int i = 0; i < length; i++)
            {
                missing ^= nums[i] ^ i;
            }

            missing ^= length;

            return missing;
        }
    }
}
