using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsomorphicWords
{
    /*
     Leetcode 205:  Isomorphic Strings
     https://leetcode.com/problems/isomorphic-strings/description/
     * 
    Given two strings s and t, determine if they are isomorphic.
    Two strings are isomorphic if the characters in s can be replaced to get t.
    All occurrences of a character must be replaced with another character while 
    preserving the order of characters. 
      
    No two characters may map to the same character but a character may map to itself.
    Example 1:
    Input: s = "egg", t = "add"
    Output: true
    Example 2:
    Input: s = "foo", t = "bar"
    Output: false
    Example 3:
    Input: s = "paper", t = "title"
    Output: true
    Note:
    You may assume both s and t have the same length.
    */
    class Program
    {
        const int SIZE = 256;

        static void Main(string[] args)
        {
            RunTestcase1(); 
            RunTestcase2();
            RunTestcase3();
            RunTestcase4();
        }

        public static void RunTestcase1()
        {
            var result = IsIsomorphic("egg","add"); 
            Debug.Assert(result); 
        }

        public static void RunTestcase2()
        {
            var result = IsIsomorphic("foo","bar"); 
            Debug.Assert(!result); 
        }

        public static void RunTestcase3()
        {
            var result = IsIsomorphic("paper", "title");
            Debug.Assert(result);
        }

        /// <summary>
        /// No two characters may map to the same character but a character may map to itself
        /// </summary>
        public static void RunTestcase4()
        {
            var result = IsIsomorphic("pa", "qq");
            Debug.Assert(!result);
        }

        /// <summary>
        /// Julia wrote the code after mock interivew of May 29, 2018 8:00 AM
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool IsIsomorphic(string s, string t)
        {
            if (s == null || t == null || s.Length != t.Length)
            {
                return false;
            }

            var mapping = new int[SIZE]; // a - z mapping index from 1 to 26
            var mapUsed = new bool[SIZE];

            var length = s.Length;

            int index = 0;
            while (index < length)
            {
                var sChar = s[index];
                var tChar = t[index];
                
                index++;

                var sIndex = toIndex(sChar); //sChar - 'a' + 1;
                var tIndex = toIndex(tChar); //tChar - 'a' + 1;

                var mapToIndex = mapping[sIndex];
                var hasMapping = mapToIndex != 0;

                if (hasMapping)
                {
                    if (tIndex == mapToIndex)
                    {
                        continue;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    //No two characters may map to the same character but a character may map to itself
                    if (mapUsed[tIndex])
                    {
                        return false;
                    }

                    mapping[sIndex] = tIndex;
                    mapUsed[tIndex] = true; 
                }                
            }

            return true;
        }

        private static int toIndex(char c)
        {
            return c - '\0' + 1;
        }
    }
}
