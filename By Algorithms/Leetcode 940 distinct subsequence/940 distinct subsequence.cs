using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _940_distinct_subsequence_II
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = DistinctSubseqII("abc");
        }

        /// study code
        /// https://www.geeksforgeeks.org/count-distinct-subsequences/
        /// I could not make it work, so I studid another one
        /// https://leetcode.com/problems/distinct-subsequences-ii/discuss/560060/Simple-C-DP-Solution
        public static int DistinctSubseqII(string s)
        {
            long MOD    = 1000 * 1000 * 1000 + 7; 
            long result = 0;
            var  length = s.Length;

            var dp      = new long[length + 1];
            var visited = new bool[length + 1, 26];

            dp[0] = 1;

            for (int index = 1; index <= s.Length; index++)
            {
                var endIndex = s[index - 1] - 'a';
                    
                for (int start = 0; start < index; start++)
                {
                    // think about the following ways:
                    // distinct subsequence with length = start -> dp[start] (not end with endIndex)
                    // ...
                    if (!visited[start, endIndex])
                    {
                        visited[start, endIndex] = true;

                        dp[index] += dp[start];
                        result    += dp[start];

                        dp[index] %= MOD;
                        result    %= MOD;
                    }
                }
            }
               
            return (int)result;
        }
    }
}
