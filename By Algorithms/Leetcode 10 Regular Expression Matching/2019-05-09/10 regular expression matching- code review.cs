using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_10_regular_expression_match___3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine(IsMatch("a","a"));
            // Console.WriteLine(IsMatch("a","."));
            // Console.WriteLine(IsMatch("b","b*")); 
            //Console.WriteLine(IsMatch("", "b*a*"));

            // special test case: abaa, "a.*a*"
            Console.WriteLine(IsMatch("aa", "a*"));
        }

        /// <summary>
        /// code review May 9, 2019
        /// review the blog
        /// https://juliachencoding.blogspot.com/2018/01/leetcode-10-regular-expression-matching_26.html
        /// </summary>
        /// <param name="text"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static bool IsMatch(string text, string pattern)
        {
            if (text == null || pattern == null) // false 
            {
                return false;
            }

            var tLength = text.Length; // 0 
            var pLength = pattern.Length; // 4

            var dp = new bool[tLength + 1, pLength + 1]; // 1, 5

            dp[0, 0] = true; // 

            for (int i = 1; i < tLength + 1; i++)
            {
                dp[i, 0] = false;
            }

            // "" matches "a*b*" etc. 
            for (int i = 1; i < pLength + 1; i++)
            {                
                dp[0, i] = i >= 2 && pattern[i - 1] == '*' && dp[0, i - 2]; 
            }

            for (int row = 1; row < tLength + 1; row++)
            {
                for (int col = 1; col < pLength + 1; col++)
                {
                    var visitChar = text[row - 1];
                    var patternChar = pattern[col - 1];

                    var isStar = patternChar == '*';
                    if (!isStar)
                    {                        
                        dp[row, col] = (patternChar == '.' || visitChar == patternChar) && dp[row - 1, col - 1];                        
                    }
                    else
                    {                                  
                        dp[row, col] = col >= 2 &&
                             // zero time
                            (( dp[row, col - 2]) ||
                             //                                                                  one time         || more than one time
                             ((pattern[col - 2] == '.' || visitChar == pattern[col - 2]) && (dp[row - 1, col - 2] || dp[row - 1, col])));
                    }

                    /*
                     * code review on May 9, 2019
                     * "mississippi"
                       "mis*is*p*."
                    else
                    {                            //   zero time          one time           more then one time        
                        dp[row, col] = col >= 2 && (dp[row, col - 2] || dp[row, col - 1] || dp[row - 1, col]);
                    } 
                     */
                }
            }

            return dp[tLength, pLength];
        }
    }
}
