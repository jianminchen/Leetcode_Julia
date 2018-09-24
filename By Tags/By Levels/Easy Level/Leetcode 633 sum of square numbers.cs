using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _633_sum_of_square_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// my sharing on Leetcode discuss is 
        /// https://leetcode.com/problems/sum-of-square-numbers/discuss/168097/C-my-favorite-algorithm
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public bool JudgeSquareSum(int c)
        {
            if (c < 0)
                return false;

            int start = 0;
            int end = (int)Math.Sqrt(c);
            while (start <= end)
            {
                var smaller = start * start;
                var bigger = end * end;
                var sum = smaller + bigger;
                if (sum == c)
                    return true;
                if (sum < c)
                    start++;
                else
                    end--;
            }

            return false;
        }
    }
}
