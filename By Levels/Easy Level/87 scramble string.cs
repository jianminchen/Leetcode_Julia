using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scrambleString
{
    /// <summary>
    /// Leetcode 87: Scramble string 
    /// It is hard level algorithm and I like to review the algorithm again. 7/30/2018
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var s1 = "great";
            var s2 = "eatgr";

            // how to scramble?
            Debug.Assert(IsScramble(s1, s2));
            
            // how to scramble? - 
            s2 = "rgeat";
            Debug.Assert( IsScramble(s1, s2));
        }


        /**
         * http://fisherlei.blogspot.ca/2013/01/leetcode-scramble-string.html
         * [解题思路]
         首先想到的是递归，简单明了，对两个string进行partition，然后比较四个字符串段。
         但是递归的话，这个时间复杂度比较高。然后想到能否DP，但是即使用DP的话，也要O(n^3)。
         想想算了，还是在递归里做些剪枝，这样就可以避免冗余计算：
         对于每两个要比较的partition，统计他们字符出现次数，如果不相等返回。
         */        
        public static bool IsScramble(string s1, string s2)
        {
            var length1 = s1.Length;
            var length2 = s2.Length;

            if (length1 != length2)
            {
                return false;
            }

            var alphabetic = new int[26];
            
            // do some pruning, assume that two strings have same chars; 
            for (int i = 0; i < 26; i++)
            {
                alphabetic[i] = 0;
            }

            var length = length1;

            for (int i = 0; i < length; i++)
            {
                alphabetic[s1[i] - 'a']++;
                alphabetic[s2[i] - 'a']--;
            }            

            for (int i = 0; i < 26; i++)
            {
                if (alphabetic[i] != 0)
                    return false;
            }

            if (length == 1)
            {
                return true;
            }

            for (int i = 1; i < length; i++)
            {
                // divide s1 into two parts, s11 and s12
                var s11 = s1.Substring(0, i);
                var s12 = s1.Substring(i);

                var s21 = s2.Substring(0, i);
                var s22 = s2.Substring(i);

                if (IsScramble(s11, s21) && IsScramble(s12, s22))
                {
                    return true;
                }

                // another option
                var cut = length - i;

                s21 = s2.Substring(0, cut);
                s22 = s2.Substring(cut);

                if (IsScramble(s11, s22) && IsScramble(s12, s21))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
