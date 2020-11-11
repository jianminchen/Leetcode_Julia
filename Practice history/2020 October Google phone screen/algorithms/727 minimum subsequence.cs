using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _727_minimum_window_subsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = FindMinimumWindowSubSequence("sbsbc", "sbc");
            Debug.Assert(result == 3); // "sbc" is found 

            var result2 = FindMinimumWindowSubSequence("sbsbbc", "sbbc");
            Debug.Assert(result2 == 4); // "sbc" is found 

            var result3 = FindMinimumWindowSubSequence("sbsbabc", "sbbc");
            Debug.Assert(result3 == 5); // "sbc" is found 
        }

        /// <summary>
        /// Nov. 10, 2020
        /// work on "sbsbc", and pattern string "sbc" first
        /// The idea is to define dp array to store start index. 
        /// dp[i] represent p.Substring(0, i) start index (keep updating with biggest one).
        /// For example, pattern string "sbc", dp[1] is to store 's''s information. 
        /// The challenge is to store all subproblems in dp array. 
        /// For example, string s = "sbsbc", when second char "s" shows up in string s, it should be
        /// recorded since it may start another "sbc" with shorter length. 
        /// My idea is to store all chars in pattern string in HashSet<int>[26], and then "b" is visited,
        /// all 'b''s positions in pattern string is traversed by decreasing order, update dp if need.
        /// 'b''s positions in "sbbc" are {1, 2}
        /// </summary>
        /// <param name="s"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static int FindMinimumWindowSubSequence(string s, string p)
        {
            if (s == null || p == null || s.Length < p.Length)
            {
                return -1;
            }

            var pLength = p.Length; 
            var dp = new int[pLength + 1];

            for (int i = 0; i < pLength + 1; i++)
            {
                dp[i] = -1; 
            }

            var count = new HashSet<int>[26];
            for (int i = 0; i < 26; i++)
            {
                count[i] = new HashSet<int>(); 
            }

            for (int i = 0; i < pLength; i++)
            {
                count[p[i] - 'a'].Add(i);
            }             

            for (int i = 0; i < s.Length; i++)
            {
                var current = s[i];
                var index = current - 'a';

                var list = count[index].ToList();
                list.Sort();

                for (int j = 0; j < list.Count; j++ )
                {
                    // reverse order
                    var next = list[list.Count - j - 1];
                    if (next == 0)
                    {
                        dp[1] = i; 
                    }
                    else if (dp[next] > 0)
                    {
                        dp[next + 1] = dp[next];
                        dp[next] = 0; 
                    }                    
                }
            }

            return dp[pLength] == -1 ? -1 : (s.Length - dp[pLength]);
        }
    }
}
