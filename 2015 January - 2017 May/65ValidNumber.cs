using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _65ValidNumber
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /*
         * source code from blog:
         * http://www.jiuzhang.com/solutions/valid-number/
         * 
         * julia's comment:
         * 1. online judge:
         * 1481 / 1481 test cases passed.
            Status: Accepted
            Runtime: 148 ms
         * 2. Write down the thought process:
         *    First, skip leading white space; ( step 1 ) 
         *    base case, if all white space string, not number, return.  ( step 2 ) 
         *    return false if all chars are space chars . ( step 3 )
         *    skip first +/- if there is one (step 4) 
         *    and then, 
         *    1. if there is e flag, then there is a digit before e flag, cannot have any e.
                Also, there is a digit followed.
                2. if . shows up, then it is a small fraction number, so neither . nor e is before .
                3. if +, -, then it must be first one, or the previous one is e,
                for example: "005047e+6".
         * 
         */
        public static bool isNumber(String s)
        {
            int len = s.Length;

            int i = 0, e = len - 1;

            while (i <= e && isWhitespace(s[i]))   // step 1:  skip leading white space chars if there are some. 
                i++;

            if (i > len - 1)                       // step 2: return false if all chars are space chars 
                return false;

            while (e >= i && isWhitespace(s[e]))   // step 3: skip trailing white space chars 
                e--;

            // skip leading +/-
            if (s[i] == '+' || s[i] == '-') i++;    // step 4: skip leading +/-

            bool isNum = false; // is a digit
            bool isDot = false; // is a '.'
            bool isExp = false; // is a 'e'

            while (i <= e)      // 
            {
                char c = s[i];
                if (isDigit(c))
                {
                    isNum = true;
                }
                else if (c == '.')
                {
                    if (isExp || isDot) 
                        return false;

                    isDot = true;
                }
                else if (c == 'e')
                {
                    if (isExp || isNum == false) 
                        return false;

                    isExp = true;
                    isNum = false;
                }
                else if (c == '+' || c == '-')
                {
                    if (s[i - 1] != 'e') return false;
                }
                else
                {
                    return false;
                }

                i++;
            }
            return isNum;
        }

        public static bool isWhitespace(char c)
        {
            return c == ' '; 
        }

        public static bool isDigit(char c)
        {
            int no = c - '0';

            return no >= 0 && no <= 9; 
        }
    }
}
