using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _97_interleave_string
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// July 4, 2019
        /// I warm up the algorithm using a case study, and I share a post here first:
        /// https://leetcode.com/problems/interleaving-string/discuss/326347/C-dynamic-programming-practice-in-August-2018-with-interesting-combinatorics-warmup
        /// Now it is time for me to write a version in 2019. 
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <param name="s3"></param>
        /// <returns></returns>
        public bool IsInterleave(string s1, string s2, string s3)
        {
            if (s1 == null || s2 == null || s3 == null)
                return false;

            var length1 = s1.Length;
            var length2 = s2.Length;
            var length3 = s3.Length;

            if (length1 == 0)
                return s2.CompareTo(s3) == 0;
            if (length2 == 0)
                return s1.CompareTo(s3) == 0;

            if (length1 + length2 != length3)
                return false;  // caught by online judge, index out of range

            var dp = new bool[length1 + 1, length2 + 1];

            dp[0,0] = true;

            // base case: first column, go over s1 first
            for (int row = 1; row < length1 + 1; row++)
            {
                dp[row, 0] = s1[row - 1] == s3[row - 1] && dp[row - 1, 0];
            }

            // base case: first row
            for (int col = 1; col < length2 + 1; col++)
            {
                dp[0, col] = s2[col - 1] == s3[col - 1] && dp[0, col - 1];
            }

            for (int row = 1; row < length1 + 1; row++)
            {
                for (int col = 1; col < length2 + 1; col++)
                {
                    var index = row + col - 1; // work on base case: "a", "b", "ab"

                    dp[row, col] = (s1[row - 1] == s3[index] && dp[row - 1, col]) ||
                                   (s2[col - 1] == s3[index] && dp[row, col - 1]); 
                }
            }

            return dp[length1, length2];    
        }
    }
}
