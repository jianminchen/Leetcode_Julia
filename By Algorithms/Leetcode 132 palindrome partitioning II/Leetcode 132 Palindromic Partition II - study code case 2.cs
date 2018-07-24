using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindrome2
{
    /// <summary>
    /// Leetcode 132 Palindrome partition II 
    /// code review 7.24.2018
    /// source code from 
    /// https://leetcode.com/problems/palindrome-partitioning-ii/discuss/42198/My-solution-does-not-need-a-table-for-palindrome-is-it-right-It-uses-only-O(n)-space.
    /// (Inspring by LC 5. Longest Palindromic Substring), we can expand from the center to left and right. 
    /// If s.charAt(left) == s.charAt(right), that means the s.substring.(left, right + 1) is palindrome, then 
    /// f[right] = f[left - 1] + 1, adding 1 because the substring between left and right needed that 1 cut. 
    /// And if left == 0, that means s.substring(0, right + 1) is palindrom, so no cut will be needed, so 
    /// f[right] = 0. We need to consider both even and odd length of the string so we expand from [i, i] and 
    /// [i, i+1]
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int n = minCut("a");
            int n2 = minCut("leet");
            int n3 = minCut("labac");
        }

        public static int minCut(string s)
        {
            var length = s.Length;

            var minimumCuts = new int[length];

            for (int i = 0; i < length; i++)
            {
                minimumCuts[i] = i;
            }

            for (int i = 0; i < length; i++)
            {
                search(s, minimumCuts, i, i);
                search(s, minimumCuts, i, i + 1);
            }
            
            return minimumCuts[length - 1];
        }

        /// <summary>
        /// understand the time complexity of the function
        /// </summary>
        /// <param name="s"></param>
        /// <param name="minimumCuts"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        private static void search(String s, int[] minimumCuts, int left, int right)
        {
            while (left >= 0  && right < s.Length && s[left] == s[right])
            {
                if (left == 0)
                {
                    // left == 0, substring(0, right+1) is palindrom, no cut needed
                    minimumCuts[right] = 0;
                }
                else
                {
                    minimumCuts[right] = Math.Min(minimumCuts[right], minimumCuts[left - 1] + 1);
                }

                left--;
                right++;
            }
        }
    }
}