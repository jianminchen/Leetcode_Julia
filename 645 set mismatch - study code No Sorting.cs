using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _645_setMismatch
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        ///<summary>
        /// ideas from 
        /// https://leetcode.com/problems/set-mismatch/discuss/105513/XOR-one-pass
        /// use extra space O(N) to find duplicate
        /// No need to sort the array to find duplicate one
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] FindErrorNums(int[] nums)
        {
            int n = nums.Length;

            int[] count = new int[n];

            var answers = new int[]{ 0, 0 };

            int xorSum = 0; 
            for (int i = 0; i < n; i++)
            {
                var current = nums[i];

                xorSum ^= (i + 1) ^ current;

                count[current - 1]++;

                if (count[current - 1] == 2)
                    answers[0] = current;
            }

            xorSum ^= answers[0];

            answers[1] = xorSum;

            return answers;
        }
    }
}
