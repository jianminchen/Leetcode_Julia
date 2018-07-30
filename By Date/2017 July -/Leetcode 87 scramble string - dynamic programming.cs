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
    /// the dynamic programming solution will be reviewed later. Just pass online judge first. 
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
            Debug.Assert(IsScramble(s1, s2));
        }        

        /*
         * http://blog.csdn.net/fightforyourdream/article/details/17707187
         * http://blog.csdn.net/linhuanmars/article/details/24506703
         * http://qiang129.blogspot.ca/2013/05/leetcode-scramble-string.html
         * DP time complexity O(n^3) space complexity O(n^3)
         */
        public static bool IsScramble(String s1, String s2)
        {
            var length1 = s1.Length;
            var length2 = s2.Length;

            if (length1 != length2)
            {
                return false;
            }

            var length = length1;

            if (length == 0)
            {
                return true;
            }

            /* Julia first time to use toCharArray function on June 5, 2015 */
            var array1 = s1.ToCharArray();
            var array2 = s2.ToCharArray();

            // canTransform 第一维为子串的长度delta，第二维为s1的起始索引，第三维为 s2 的起始索引  
            // canTransform[k][i][j]表示 s1[i...i+k] 是否可以由 s2[j...j+k] 变化得来。  
            var canT = new bool[length, length, length];
           

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {    // 如果字符串总长度为1，则取决于唯一的字符是否想到  
                    canT[0, i, j] = array1[i] == array2[j];
                }
            }

            for (int k = 2; k <= length; k++)
            {       // 子串的长度  
                for (int i = length - k; i >= 0; i--)
                {         // s1[i...i+k]  
                    for (int j = length - k; j >= 0; j--)
                    { // s2[j...j+k]  
                        var canTransform = false;

                        for (int m = 1; m < k; m++)
                        {  // 尝试以m为长度分割子串  
                            // canT[k][i][j]  
                            //                                       前前后后匹配 
                            canTransform = (canT[m - 1, i, j]         && canT[k - m - 1, i + m, j + m]) ||
                            //                                       前后后前  匹配 
                                           (canT[m - 1, i, j + k - m] && canT[k - m - 1, i + m, j]);  
      
                            if (canTransform)
                            {
                                break;
                            }
                        }

                        canT[k - 1, i, j] = canTransform;
                    }
                }
            }

            return canT[length1 - 1, 0, 0];
        }
    }
}