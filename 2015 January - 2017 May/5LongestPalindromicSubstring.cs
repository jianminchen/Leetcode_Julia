using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5LongestPalindromicSubstring
{
    class Program
    {
        static void Main(string[] args)
        {
        }
        /*
         * http://blog.csdn.net/linhuanmars/article/details/20888595
         * 
         * analysis from the above blog:
         * 这道题是比较常考的题目，求回文子串，一般有两种方法。 第一种方法比较直接，
         * 实现起来比较容易理解。基本思路是对于每个子串的中心（可以是一个字符，或者
         * 是两个字符的间隙，比如串abc,中心可以是a,b,c,或者是ab的间隙，bc的间隙）
         * 往两边同时进行扫描，直到不是回文串为止。假设字符串的长度为n,那么中心的个数
         * 为2*n-1(字符作为中心有n个，间隙有n-1个）。对于每个中心往两边扫描的复杂度
         * 为O(n),所以时间复杂度为O((2*n-1)*n)=O(n^2),空间复杂度为O(1)，
         * 
         * julia's comment:
         * 1. Write a script to do this brute force solution:
         *    step 1: base case, string is empty or lenght is 0 
         *    step 2: total cases, 2*len-1, go through each case one time
         *       two cases: A. one char in center
         *                  B. two char in center
         *    step 3: each case, call palindrome function once, 
         *    checking from center to both side, left and right two pointers
         *    step 4: each iteration, refresh maximum length and also string content
         */
        public static String longestPalindrome(String s)
        {
            int len = s.Length;  

            if (s == null || len == 0)   // step 1 
                return "";

            int maxLen = 0;
            String res = "";

            int centerCount = 2 * len - 1;

            for (int i = 0; i < centerCount; i++)    // step 2 
            {
                int left  = i / 2;
                int right = i / 2;   // case A: 1 char in center (total n choice) 

                if (i % 2 == 1)      // case B: two chars in the center (total n-1 choice)
                    right++;

                String str = lengthOfPalindrome(s, left, right);  // step 3 

                int l2 = str.Length; 
                if (maxLen < l2)    // step 4 
                {
                    maxLen = l2;
                    res = str;
                }
            }

            return res;
        }
        /*
         * julia's comment:
         * 1. go through a loop, starting from input arguments: left, right
         * 2. check if left and right is in the string length range, 
         * 3. if it is, then, left point moves left, right point moves right 
         * 4. return substring of s with start position and length in C# 
         */
        private static String lengthOfPalindrome(String s, int left, int right)
        {
            int len = s.Length;

            while (left >= 0 && right < len && s[left] == s[right])
            {
                left--;
                right++;
            }

            int start = left + 1;
            int length = right - left;

            return s.Substring(start, length);  // C# Substring (int start, int length)
        }

        /*
         * Dynamic programming solution - DP solution 
         * http://blog.csdn.net/linhuanmars/article/details/20888595
         * comment from the above blog:
         * 基本思路是外层循环i从后往前扫，内层循环j从i当前字符扫到结尾处。
         * 过程中使用的历史信息是从i+1到n之间的任意子串是否是回文已经被记录下来，
         * 所以不用重新判断，只需要比较一下头尾字符即可。这种方法使用两层循环，
         * 时间复杂度是O(n^2)。而空间上因为需要记录任意子串是否为回文，
         * 需要O(n^2)的空间
         * 
         * julia's comment: 
         * 1. The thought process to use DP method: 
         *   Total problems are n^2 in total, s[i][j] is palindromic, i<=j, s[i][j] is substring s from i to j; 
         *   1. base case discussion 
         *   2. construct a two dimension array to express all subproblems - substring are palindormic or not
         *   using jagged array, default initialization is 0 - false
         *   3. construct a two nested loops:
         *      one loop for i: decreasing order, starting position
         *      inside loop for j: increasing order, j>==i, ending position
         *     
         *   palin[i][j] is about string's substring from position i to j, 0 <= i <= j <= n-1, is palindrome
         *   if s[i] = s[j], then subproblem of palin[i][j] should be palin[i+1][j-1] is true or not 
         *   (assuming i+1<=j-1  => j-i>=2)
         *   
         * http://www.programcreek.com/2013/12/leetcode-solution-of-longest-palindromic-substring-java/
         * start condition:
         *  table[i][i] == 1;
            table[i][i+1] == 1  => s[i] == s[i+1] 
         * 
         * Changing condition:
         * table[i+1][j-1] == 1 && s[i] == s[j]
           =>
           table[i][j] == 1
         * 
         * Time complexity: O(n^2), space complexity: O(n^2) 
         */
        public static String longestPalindrome_2(String s) { 
            int len = s.Length; 

            if(s == null || len == 0)  
                return "";  

            bool[][] table = new bool[len][];

            for (int i = 0; i < len; i++ )  // array table[i][j] stands for DP 2-dimension array
            {
                table[i] = new bool[len]; 
            }

            int maxLen = 0;
            String res = "";

            //every single letter is palindrome
            for (int i = 0; i < len; i++)
            {
                table[i][i] = true;
            }          

            //e.g. bcba
            //two consecutive same letters are palindrome
            for (int i = 0; i <= len - 2; i++)
            {
                if (s[i] == s[i + 1])
                {
                    table[i][i + 1] = true;
                    res = s.Substring(i,  2);
                }
            }

            //condition for calculate whole table
            for (int l = 3; l <= len; l++)
            {
                for (int i = 0; i <= len - l; i++)
                {
                    int j = i + l - 1;
                    if (s[i] == s[j])
                    {
                        table[i][j] = table[i + 1][j - 1];

                        if (table[i][j] == true && l > maxLen)
                            res = s.Substring(i, j -i + 1);
                    }
                    else
                    {
                        table[i][j] = false;
                    }
                    
                }
            }           

            return res;  
        }
    }
}
