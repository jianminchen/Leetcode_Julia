using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_longest_substring_2015_5
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = LengthOfLongestSubstring("aab"); 
        }

        /// <summary>
        /// code review on June 24, 2020
        /// code written in May 2015
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int LengthOfLongestSubstring(string s)
        {
            int len = s.Length;

            if (s == null || len == 0)
            {
                return 0;
            }

            // visited[char's ASCII] = char's index  
            int[] visited = new int[256];
            arraysFill(visited, -1);

            int sw_len = 1;
            int maxLen = 1;
            int lastVisit_index = 0;
            visited[s[0]] = 0;
            int sw_start = 0;
            for (int i = 1; i < len; i++)
            {
                lastVisit_index = visited[s[i]];

                bool isInSlideWindow = lastVisit_index >= sw_start;
                if (lastVisit_index == -1 || !isInSlideWindow)
                {
                    // do nothing  // test case: baab
                }
                else
                {
                    // julia comment: 
                    // before sliding window left sw_start moves to next position, 
                    // record the length of sliding window, compared to 
                    // maxLen; update it if need
                    // test case: aba - 012 
                    // sw_len = 2 - 0 = 2, sw_start = 1  
                    sw_len = i - sw_start;
                    maxLen = Math.Max(maxLen, sw_len);

                    // then, move sliding window left point 
                    sw_start = lastVisit_index + 1;
                }

                // julia comment: update visited extra space - array 
                // test case: aba, visit['a'] = 2
                visited[s[i]] = i;

                // test case: aba, sw_len = 2 
                sw_len = i - sw_start + 1;
            }

            // 最后一次  
            maxLen = Math.Max(maxLen, sw_len);

            return maxLen;
        }

        public static void arraysFill(int[] a, int val)
        {
            for (int i = 0; i < 256; i++)
                a[i] = val;
        }
    }
}
