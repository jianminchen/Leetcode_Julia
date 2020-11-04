using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _940_distinct_subsequences
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// study code
        /// https://www.geeksforgeeks.org/count-distinct-subsequences/
        public int DistinctSubseqII(string str) {        
            // Returns count of distinct sunsequences of str.     
            // Create an array to store index
            // of last
            var MAX_CHAR = 256;

            int[] last = new int[MAX_CHAR];
            int mod = 1000 * 1000 * 1000 + 7; 

            for (int i = 0; i < MAX_CHAR; i++)
            {
                last[i] = -1;
            }
 
            // Length of input string
            int n = str.Length;
 
            // dp[i] is going to store count of
            // distinct subsequences of length i.
            var dp = new long[n + 1];
 
            // Empty substring has only one subsequence
            dp[0] = 1;
 
            // Traverse through all lengths from 1 to n.
            for (int i = 1; i <= n; i++) 
            {
                // Number of subsequences with substring
                // str[0..i-1]
                dp[i] = (2 * dp[i - 1]) % mod;
 
                // If current character has appeared
                // before, then remove all subsequences
                // ending with previous occurrence.
                var lastDigit = (int)str[i - 1];
                var index = last[lastDigit];
            
                if (index != -1)
                {
                    dp[i] = (dp[i] - dp[index]) % mod;
                }
 
                // Mark occurrence of current character
                last[(int)str[i - 1]] = (i - 1);
            }
        
            return (int)(dp[n] - 1);
        }
    }
}
