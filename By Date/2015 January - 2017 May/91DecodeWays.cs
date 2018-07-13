using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecodeWays
{
    class Program
    {
        /*
         Leetcode: Decode way
         *  A message containing letters from A-Z is being encoded 
         *  to numbers using the following mapping:
	        'A' -> 1
	        'B' -> 2
	        ...
	        'Z' -> 26
	        Given an encoded message containing digits, determine the 
            total number of ways to decode it.
	        For example,
	        Given encoded message "12", it could be decoded as "AB" (1 2) or "L" (12).
	        The number of ways decoding "12" is 2. 
         * Julia's comment:
         *  1. Learn to solve the problem using brute force solution first; 
         *     know base cases bugs
         *  2. Then, how to improve it. 
         * Blogs references:
         * 1. https://github.com/patrickyao1988/LeetCode-Java/blob/master/DecodeWays.java
         */
        static void Main(string[] args)
        {
        }

        /*
         * Latest update: July 10, 2015 
         */
        public static int numDecodings(String s)
        {
            if (s != null && s.Length != 0)
            {
                return getDecode_bug1(s, 0);
            }
            else
            {
                return 0;
            }
        }

        /*
         * Latest update: July 10, 2015
         * brute force recursive. a lot of duplicated computation
         * Julia's comment: 
         * 1. base case is only return 0, no number in the formula; 
         *    never will return value bigger than 0; 
         * 2. Review the code, including ensuring that the program will work!
         * 3. Julia made mistakes on base cases; she missed the base cases:
         *    return 1;
         *    return 2;
         *    cover all cases: if there is 1 or 2 digits left, then, need to resolve; 
         *    no more recursive calls. 
         */
        private static int getDecode_bug2(String s, int start)
        {
            int len = s.Length; 
            if (start == s.Length)
            {
                return 0;
            }
                        
            bool twoCharsOk = false;             

            //if there is second char and integer is in the range of (0,25)
            if (len - start >= 2)
            {
                int number = s[start] - '0';
                    number =number*10+ (s[start + 1] - '0');               

                if ( number >= 0 && number <= 25 )
                    twoCharsOk = true; 
            }


            if (twoCharsOk)
            {
                return getDecode_bug2(s, start + 1) + getDecode_bug2(s, start + 2); 
            }            
            else
                return getDecode_bug2(s, start + 1);
        }

        /**
         * Julia comment on July 10, 2015
         * Brute force solution with bugs:
         * The base case is not covering all possibilities:
         * if the number is 31, then, it is one of base cases; return 1, the string is CA
         * Now the bug is there. 31 > 26, no return at all. 
         * Other issues:
         *  1. need to discuss if there is 0 in the string
         *  2. The mapping is starting from 1,not 0, A->1, B->2, ..., Z->26
         */
        private static int getDecode_bug1(String s, int start)
        {
            int len = s.Length;
            if (start == s.Length)
            {
                return 0;
            }

            if (len - start == 1)            
                return 1;             

            bool twoCharsOk = false;

            //if there is second char and integer is in the range of (0,25)
            int leftStrLen = len - start;
            if (leftStrLen >= 2)
            {
                int number = s[start] - '0';
                number = number * 10 + (s[start + 1] - '0');

                if (number >= 0 && number <= 25)
                    twoCharsOk = true;
            }

            if (leftStrLen == 2 && twoCharsOk)
                return 2; 

            if (twoCharsOk)
            {
                return getDecode_bug2(s, start + 1) + getDecode_bug2(s, start + 2);
            }
            else
                return getDecode_bug2(s, start + 1);
        }

        /**
         * source code from blog:
         * http://www.acmerblog.com/leetcode-solution-decode-ways-6209.html
         * Julia's comment:
         * Convert Java code to C# code
         */
        public int numDecodings(String s) {

            int len = s.Length;
            if (len == 0) return 0;
 
	        if(s[0] == '0') return 0;
 
	        if(s.Length == 1) return s[0] > '0' ? 1:0;
 
	        int[] dp = new int[s.Length+1];
 
	        dp[0] = dp[1] = 1;
 
	        for(int i=2; i<=s.length(); i++){
 
	            dp[i] = dp[i-1];
 
	            if(s.charAt(i-1) == '0')
 
	                if (s.charAt(i-2) == '1' || s.charAt(i-2) == '2')
 
	                    dp[i] = dp[i-2];
 
	                else return 0;
 
	            else if(s.charAt(i-2) == '0'){
 
	                dp[i] = dp[i-1];
 
	                continue;
 
	            }
 
	            else if(s.charAt(i-2) < '2' || (s.charAt(i-2) == '2' && s.charAt(i-1) < '7') )
 
	                dp[i] += dp[i-2];
 
	        }
 
	        return dp[s.length()];
 
	    }

    }
}
