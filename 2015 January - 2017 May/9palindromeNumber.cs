using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9palindromeNumber
{
    class Program
    {
        static void Main(string[] args)
        {
        }
        /*
         * source code from blog:
         * http://yucoding.blogspot.ca/2013/04/leetcode-question-62-palindrome-number.html
         * 
         * Palindrome Number:
            Determine whether an integer is a palindrome. Do this without extra space.
            Analysis from the above blog:
            The question requires no extra space, so we cannot convert the number to string and
            check the end and front. But the idea is still check the top and last digit. 
         *  The last digit is easily achieved by x%10(x mod 10).
            To get the next last digit, x=x/10; x%10;  
         *  On the other hand, how to get first digit? 
         *  Similarly, keep x = x/10,  until x<10.  
         *  So, if we can get the first digit and the last digit, then we compare, 
         *  if not equal return false, 
         *  if equal we search the next two digits. 
         *  
         * Recursion seems a good idea to solve the problem. 
         * 2 same number as the parameter is set to get the first and last digit respectively. 
         * So we first recursively get the first digit, then compare to the last digit, 
         * if ok, what we is only deal with the 2nd number in order to get the next last digit (by x=x/10). 
         * 
         * Because the recursion property, when this level is over, return to the earlier level, 
         * the last digit of the  1st number is the next highest digit, so we only need to get mod when comparing.
         * 
         * e.g.

            121   121
            12    121
            1     121
            0     121
            meet 0 return
            1     121  (check if 1==121%10)
            1     12    (121/10, return to earlier level)
            12   12    (check if 12%10 == 12%10)
            12   1     (12/10)
            121  1    (check 121%10 == 1%10)
            OK!
         */
        public static bool check(int x, ref int y){
            if (x==0) {return true;}
            if (check(x/10, ref y)){   // ?? 
                if (x%10 == y%10){  // ? 
                    y=y/10;
                    return true;
                }
            }
            return false;
        }

        public static bool isPalindrome(int x) {
        // Start typing your C/C++ solution below
        // DO NOT write int main() function
        if (x<0){return false;}
        return check(x,ref x);
    }
        /*
         * source code from blog:
         http://codeganker.blogspot.ca/2014/02/palindrome-number-leetcode.html
         * 
         * comment from the above blog: 
         * 这道题跟Reverse Integer差不多，也是考查对整数的操作，相对来说可能还更加简单，
         * 因为数字不会变化，所以没有越界的问题。基本思路是每次去第一位和最后一位，
         * 如果不相同则返回false，否则继续直到位数为0。
         */
        public static bool isPalindrome(int x)
        {
            if (x < 0)
                return false;

            int div = 1;
            while (div <= x / 10)
                div *= 10;  // if x = 1000, then div= 1000; if x = 2000, then div = 1000 => first digit: x / div, last digit: x%10

            while (x > 0)
            {
                int firstDigit = x / div;
                int lastDigit = x % 10;

                if (firstDigit != lastDigit)
                    return false;

                x = (x % div) / 10;  // if x = 121, then div = 100, x%div = 21, and then, 21 /10, get rid of last digit 1, so x = 2 ;

                // thought process: get number after removing first digt and last digit:
                // 121, removing first digit 1 and last digit 1, the new number is 2
                // how to do it: 
                // 1. get rid of first digit:   x%div
                // 2. get rid of last digit: /10, 
                // 3. so, the formula is ( x % div) / 10

                div /= 100;   // now the number is 2 digit less, so div should be changed accordingly as well, /100/ 
            }

            return true;
        }
    }
}
