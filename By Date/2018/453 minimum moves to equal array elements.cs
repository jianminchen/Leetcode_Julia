using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _453_minimum_moves
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// Let us take different approach 
        /// Find maximum number and minimum number
        /// until maximum one is equal to minimum of the array
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MinMoves(int[] nums)
        {
            if (nums == null || nums.Length <= 1)
                return 0;

            var min = nums.Min();
            var max = nums.Max();
            var length = nums.Length;

            int count = 0;
            for (int i = 0; i < length; i++)
            {
                count += (nums[i] - min);
            }

            return count; 
        }
    }
}
