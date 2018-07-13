using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10RegularExpressionMatching
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /*
            '.' Matches any single character.
            '*' Matches zero or more of the preceding element.

            The matching should cover the entire input string (not partial).

            The function prototype should be:
            bool isMatch(const char *s, const char *p)

            Some examples:
            isMatch("aa","a") → false
            isMatch("aa","aa") → true
            isMatch("aaa","aa") → false
            isMatch("aa", "a*") → true
            isMatch("aa", ".*") → true
            isMatch("ab", ".*") → true
            isMatch("aab", "c*a*b") → true
         * */
        /*
         * source code from blog:
         * http://www.busy-beaver.me/leetcode-10-regular-expression-matching/
         * 
         * Analysis from blog:
         * 动态规划法。

        dp[i+1][j+1]表示s[0..i]是否匹配p[0..j]。状态转移方程如下：

        若p[j] != '*'，dp[i+1][j+1] = (s[i] == p[j] || p[j] == '*') && dp[i][j]
        若p[j] == '*'
        匹配了0个字符。dp[i+1][j+1] = dp[i+1][j-1]（跳过p[j]的*和*前面的p[j-1]。
        匹配了1个字符。dp[i+1][j+1] = dp[i+1][j]（跳过p[j]的*)
        匹配了2个或2个以上的字符。dp[i+1][j+1] = dp[i][j+1] && (p[j-1] == s[i] || p[j-1] == '.')
        （s[0..i-1]与p[0..j]匹配，并且p[j-1]与s[i]匹配）
         */
        bool isMatch(string s, string p) {
            int sLen = s.Length, 
                pLen = p.Length;

            bool[][] dp = new bool[sLen + 1][];   // pLen + 1
            for (int i = 0; i < sLen + 1; i++)
                dp[i] = new bool[pLen + 1]; 

            dp[0][0] = true;
            for (int i = 1; i <= sLen; i++)
                dp[i][0] = false;

            for (int j = 1; j <= pLen; j++)
                dp[0][j] = j > 1 && p[j-1] == '*' && dp[0][j-2];

            for (int i = 0; i < sLen; i++) {
                for (int j = 0; j < pLen; j++) {
                    if (p[j] != '*') {
                        dp[i+1][j+1] = (p[j] == '.' || s[i] == p[j]) && dp[i][j];        
                    } else {
                        dp[i+1][j+1] = j > 0 && dp[i+1][j-1] || dp[i+1][j] || j > 0 && (p[j-1] == '.' || s[i] == p[j-1]) && dp[i][j+1];
                    }
                }
            }
            return dp[sLen][pLen];
       }

        /*
         * source code from blog:
         * http://www.cnblogs.com/yuzhangcmu/p/4105529.html
         * DP:

            D[i][j]: 表示string s中取i长度的字串，string p中取j长度字串，进行匹配。

            状态转移：

            1. j >= 2 && P[j - 1] = *，这时，我们可以选择匹配s中的空字串，或匹配无限个。

            k: 在s中匹配的字符的个数

            所以转移式是：D[i][j] = D[i - k][j - 2] && isSame(s.charAt(i - k), p.charAt(j - 2))   (k: 1-i)

                                            D[i - k][j - 2]  (k = 0) 

            2. p最后一个字符不是*

            那么首先，s中至少还要有一个字符，然后再匹配一个字符，以及上一级也要匹配即可。

            D[i][j] = i >= 1 
            && isSame(s.charAt(i - 1), p.charAt(j - 1))
            && D[i - 1][j - 1];

            3. j = 0;

             D[i][j] = i == 0;  (p为空，则s也是要为空才可以匹配）

            以下是运行时间（LEETCODE这道题目的数据太弱了... orz)，看不出太大的区别。
         * source code from blog:
         * https://github.com/yuzhangcmu/LeetCode/blob/master/string/isMatch_2014_1228.java
         */
        public static bool isMatch(String s, String p) {
            if (s == null || p == null) {
                return false;
            }
        
            int sLen = s.Length, pLen = p.Length; 
           
            bool[][] D = new bool[sLen + 1][];   // pLen + 1
            for (int i = 0; i < sLen + 1; i++)
                D[i] = new bool[pLen + 1]; 
        
            // D[i][j]: i, j, the length of String s and String p.        
            for (int i = 0; i <= sLen; i++) {
                for (int j = 0; j <= pLen; j++) {
                    if (j == 0) {
                        // when p is empty, then s should be empty.
                        D[i][j] = i == 0;
                    } else if (p[j - 1] == '*') {
                        /*
                            P has at least one node.
                        */
                    
                        // The last node in p is '*'
                        if (j < 2) {
                            // a error: there should be a character before *.
                            //return false;
                        }
                    
                        // we can match 0 characters or match more characters.
                        for (int k = 0; k <= i; k++) {
                            // BUG 3: severe! Forget to deal with the empty string!!
                            if (k != 0 && !isSame(s[i - k], p[j - 2])) {
                                D[i][j] = false;
                                break;
                            }
                        
                            if (D[i - k][j - 2]) {
                                D[i][j] = true;
                                break;
                            }
                        }
                    } else {
                        D[i][j] = i >= 1 
                             && isSame(s[i - 1], p[j - 1])
                             && D[i - 1][j - 1];
                    }
                }
            }
        
            return D[sLen][pLen];
        }

        public static bool isSame(char c, char p)
        {
            return p == '.' || c == p;
        }

        /*
         * source code from blog:
         * http://bangbingsyb.blogspot.ca/2014/11/leetcode-regular-expression-matching.html
         * 
         * 关键在于如何处理这个'*'号。

            状态：和Mininum Edit Distance这类题目一样。
            dp[i][j]表示s[0:i-1]是否能和p[0:j-1]匹配。

            递推公式：由于只有p中会含有regular expression，所以以p[j-1]来进行分类。
            p[j-1] != '.' && p[j-1] != '*'：dp[i][j] = dp[i-1][j-1] && (s[i-1] == p[j-1])
            p[j-1] == '.'：dp[i][j] = dp[i-1][j-1]

            而关键的难点在于 p[j-1] = '*'。由于星号可以匹配0，1，乃至多个p[j-2]。
            1. 匹配0个元素，即消去p[j-2]，此时p[0: j-1] = p[0: j-3]
            dp[i][j] = dp[i][j-2]

            2. 匹配1个元素，此时p[0: j-1] = p[0: j-2]
            dp[i][j] = dp[i][j-1]

            3. 匹配多个元素，此时p[0: j-1] = { p[0: j-2], p[j-2], ... , p[j-2] }
            dp[i][j] = dp[i-1][j] && (p[j-2]=='.' || s[i-2]==p[j-2])
         * 
         * julia's comment:
         * 1. Let me try to memorize this DP analysis and code. 
         * 2. Regular express is helpful, at least, I learn '.' rule this time.  
         */
        bool isMatch(string s, string p) {
        int m = s.Length, n = p.Length;

        
         bool[][] dp = new bool[m + 1][];   // pLen + 1
            for (int i = 0; i < m + 1; i++)
                dp[i] = new bool[n+ 1]; 

        dp[0][0] = true;
        
        for(int i=0; i<=m; i++) {
            for(int j=1; j<=n; j++) {
                if(p[j-1]!='.' && p[j-1]!='*') {
                    if(i>0 && s[i-1]==p[j-1] && dp[i-1][j-1])
                        dp[i][j] = true;
                }
                else if(p[j-1]=='.') {
                    if(i>0 && dp[i-1][j-1])
                        dp[i][j] = true;
                }
                else if(j>1) {  //'*' cannot be the 1st element
                    if(dp[i][j-1] || dp[i][j-2])  // match 0 or 1 preceding element
                        dp[i][j] = true;
                    else if(i>0 && (p[j-2]==s[i-1] || p[j-2]=='.') && dp[i-1][j]) // match multiple preceding elements
                        dp[i][j] = true;
                }
            }
        }
        return dp[m][n];
    }
    }
}
