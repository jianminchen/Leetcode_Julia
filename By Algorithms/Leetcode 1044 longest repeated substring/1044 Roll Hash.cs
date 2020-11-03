using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1044_longest_repeated_substring_II
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        private static const long q = (long)(1 << 31) - 1;
        private static const long R = 256;

        /// <summary>
        /// Nov. 2, 2020
        /// study code
        /// https://leetcode.com/problems/longest-duplicate-substring/discuss/537065/JAVA-Binary-Search-%2B-Rolling-Hash-%2B-Explain-to-me-like-I'm-5-year-old
        /// </summary>
        /// <param name="S"></param>
        /// <returns></returns>
        public static string LongestDupSubstring(string S)
        {
            int left = 2;
            var length = S.Length;
            int right = length - 1;
            int start = 0;
            int maxLen = 0;
        
            while (left <= right) {
                var middle = left + (right - left) / 2;

                var found = false;
            
                var map = new Dictionary<long, List<int>>();

                long hash = hashString(S, middle);

                map.Add(hash, new List<int>());

                map[hash].Add(0);

                long RM = 1;
                for (int i = 1; i < middle; i++)
                {
                    RM = (R * RM) % q;
                }            
                
                for (int i = 1; i + middle <= length; i++) 
                {
                    hash = (hash + q - RM * S[i - 1] % q) % q;
                    hash = (hash * R + S[i + middle - 1]) % q;

                    if (!map.ContainsKey(hash)) 
                    {
                        map.Add(hash, new List<int>());
                    } 
                    else 
                    {
                        var breakOutLoop = false; 
                        foreach (var j in map[hash]) 
                        {
                            if (compare(S, i, j, middle)) 
                            {
                                found = true;
                                start = i;
                                maxLen = middle;

                                breakOutLoop = true; 
                                break;
                            }
                        }

                        if (breakOutLoop)
                        {
                            break; 
                        }
                    }

                    map[hash].Add(i);
                }

                if (found)
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle - 1;
                }
            }
        
            return S.Substring(start, maxLen);
        }
    
        /// <summary>
        /// 
        /// </summary>
        /// <param name="S"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        private static long hashString(string S, int len) 
        { 
            long h = 0;
            for (int j = 0; j < len; j++)
            {
                h = (R * h + S[j]) % q;
            }

            return h;
        }
    
        private static bool compare(String S, int i, int j, int len) 
        {
            for (int count = 0; count < len; count++) 
            {
                if (S[i] != S[j])
                {
                    i++;
                    j++;

                    return false;                    
                }
            }

            return true ; 
        }
    }
}
