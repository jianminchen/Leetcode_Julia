using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _300_longest_increasing_subsequence___BS
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = LengthOfLIS(new int[]{10, 9, 2, 5, 3, 7, 101, 18}); 
        }

        /// <summary>
        /// study code
        /// https://leetcode.com/problems/longest-increasing-subsequence/discuss/74824/JavaPython-Binary-search-O(nlogn)-time-with-explanation
        /// Each time we only do one of the two:
        /// 1. if x is larger than all tails, append it, increase the size by 1
        /// 2. if tails[i-1] < x <= tails[i], update tails[i]
        /// 
        /// Time complexity: O(nlogn), n is the length of input argument array
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public static int LengthOfLIS(int[] numbers)
        {
            var sorted = new int[numbers.Length];

            int length = 0;
            foreach (var number in numbers)
            {
                var index = Array.BinarySearch(sorted, 0, length, number);

                if (index < 0)
                {
                    index = ~index;
                }

                // add new element into the array - increment length variable
                if (index == length)
                {
                    length++;
                }

                // every number will be updated ...
                sorted[index] = number;
            }

            return length;
        }
    }
}
