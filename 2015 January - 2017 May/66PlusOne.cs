using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathPlusOne
{
    class Program
    {
        static void Main(string[] args)
        {
            /**
             * Latest update: June 22, 2015
             * Test cases:
             */
            int[] digits = new int[5]{1,2,3,4,5};
            int[] testPlusOne = plusOne(digits);

            int[] digits2 = new int[5] { 9, 9, 9, 9, 9 };
            int[] testPlusOne2 = plusOne(digits2);

            int[] digits3 = new int[5] { 1, 2, 3, 4, 9 };
            int[] testPlusOne3 = plusOne(digits3);

            /**
             */
            int[] digits2B = new int[5] { 9, 9, 9, 9, 9 };
            int[] testPlusOne2B = plusOne2(digits2B);

            int[] digits4B = new int[5] { 9, 9, 9, 9, 9 };
            int[] testPlusOne4B = plusOne4(digits4B);

            /* try to figure out the code by debugging*/
            int[] digits6B = new int[5] { 9, 9, 9, 9, 9 };
            int[] testPlusOne6B = plusOne6(digits6B);

            /*
             * Latest update: June 22, 2015
             * 
             */
            int[] digits3B = new int[5] { 1, 2, 9, 9, 9 };
            int[] testPlusOneB = plusOne6(digits3B);

        }

        /**
         * Latest update: June 22, 2015
         * Leetcode: Plus one 
         * http://blog.csdn.net/linhuanmars/article/details/22365957
         * 这是一道比较简单的题目，对一个数组进行加一操作。但是可不要小看这个题，
         * 这个题被称为“Google最喜欢的题”，因为在google面试中出现的频率非常高。
         * 我们先说说这道题的解法。思路是维护一个进位，对每一位进行加一，然后判断进位，
         * 如果有继续到下一位，否则就可以返回了，因为前面不需要计算了。
         * 有一个小细节就是如果到了最高位进位仍然存在，那么我们必须重新new一个数组，
         * 然后把第一个为赋成1（因为只是加一操作，其余位一定是0，否则不会进最高位）。
         * 因为只需要一次扫描，所以算法复杂度是O(n)，n是数组的长度。而空间上，
         * 一般情况是O(1)，但是如果数是全9，那么是最坏情况，需要O(n)的额外空间。
         * 
         * 后续可以问一些比较基本的扩展问题，比如可以扩展这个到两个数组相加，
         * 或者问一些OO设计，假设现在要设计一个BigInteger类，那么需要什么构造函数，
         * 然后用什么数据结构好，用数组和链表各有什么优劣势。这些问题虽然不是很难，
         * 但是可以考到一些基本的理解，
         */
        public static int[] plusOne(int[] digits)
        {
            int len = digits.Length;

            if (digits == null || len == 0)
                return digits;

            int carry = 1;
            for (int i = len - 1; i >= 0; i--)
            {
                int digit = (digits[i] + carry) % 10;

                carry = (digits[i] + carry) / 10;
                digits[i] = digit;
                if (carry == 0)
                    return digits;
            }

            int[] res = new int[len + 1];
            res[0] = 1;

            return res;
        }

        /**
         * Leetcode: plus one
         * http://www.cnblogs.com/springfor/p/3888002.html
         * julia comment: 
         *   %10, /10 is one way to check; here, check ==10
         */
        public static int[] plusOne2(int[] digits) {
              int len = digits.Length; 
                
              for(int i=len-1;i>=0;i--){
                  digits[i] =1+digits[i];
                  
                  if(digits[i]==10)  // julia comment: compared to %10, /10, carry, module, it is quick and clear
                      digits[i]=0;   // julia comment: imply that continue to next bit in the left
                  else
                      return digits; // julia comment: stop, and return
              }
 
             //don't forget over flow case
             int[] newdigit = new int[len+1];

             newdigit[0]=1;

             /*julia comment: 1. this is not necessary, array initilization set all digits 0
               2. digits[] each digit is 9, after plus one operation, all zero*/
             for(int i=1;i<newdigit.Length;i++){
                 newdigit[i] = digits[i-1];
             }

             return newdigit;
         }

        /**
         * Latest update: June 22, 2015
         * Leetcode: plus one 
         * http://www.cnblogs.com/springfor/p/3888002.html
         */
        public int[] plusOne3(int[] digits) {
              
              int len = digits.Length;
              for(int i = len-1; i>=0; i--){
                  if(digits[i]<9){
                      digits[i]++;
                      break;
                  }else{
                      digits[i]=0;
                 }
             }
             
             int[] newdigits;
             if(digits[0]==0){
                 newdigits = new int[len+1];
                 newdigits[0]=1;

                 for(int i=1;i<newdigits.Length;i++){
                     newdigits[i]=digits[i-1];
                 }
             }else{
                 newdigits = new int[len];
                 for(int i=0;i<len;i++){
                     newdigits[i]=digits[i];
                 }
             }

             return newdigits;
         }

        /**
         * Leetcode: plus one
         * http://www.programcreek.com/2014/05/leetcode-plus-one-java/
         * julia comment: function code style, 
         */
        public static int[] plusOne4(int[] digits)
        {
            int len = digits.Length;
            bool flag = true; // flag if the digit needs to be changed

            for (int i = len - 1; i >= 0; i--)
            {
                if (flag)
                {
                    if (digits[i] == 9)
                    {
                        digits[i] = 0;
                    }
                    else
                    {
                        digits[i] = digits[i] + 1;
                        flag = false;
                    }

                    if (i == 0 && digits[i] == 0)
                    {
                        int[] y = new int[len + 1];
                        y[0] = 1;
                        for (int j = 1; j <= len; j++)
                        {
                            y[j] = digits[j - 1];
                        }
                        digits = y;
                    }
                }
            }

            return digits;
        }

        /**
         * leetcode: plus one 
         * http://gongxuns.blogspot.ca/2012/12/leetcode-plus-one.html
         */
        public static int[] plusOne5(int[] digits)
        {
            // Start typing your Java solution below
            // DO NOT write main() function
            int carry = 0, i = digits.Length - 1;

            digits[i] += 1;
            while (digits[i] >= 10)  //julia comment: while loop is overflow check;             
            {
                digits[i--] -= 10;
                if (i >= 0)
                    digits[i] += 1;
                else
                {
                    carry = 1;
                    break;
                }
            }

            if (carry == 0) return digits;

            int[] res = new int[digits.Length + 1];

            for (i = 0; i < digits.Length; i++)
            {
                res[i + 1] = digits[i];
            }

            res[0] = 1;
            return res;
        }

        /**
         * Leetcode: plus one
         * http://www.acmerblog.com/leetcode-solution-plus-one-6271.html
         * Test case: test case {1,2,9,9,9}
         * The value of plus one will be in the format of
         * n0, ...,nk,0,...,0; if there is 0 from rightmost, k-1 of 0
         */
        public static int[] plusOne6(int[] digits) {
            int len = digits.Length; 
            int k = len-1;

            for(; k >= 0; k--)
                if(digits[k] != 9) break; // julia comment: help to read the code, solution n0, ...,nk,0,...,0; if there is 0 from rightmost, k-1 of 0. 

            // julia comment: all digits are 9 
            if(k == -1){
                int[] newDigits = new int[len + 1];

                newDigits[0] = 1;

                return newDigits;

            }else{
                int[] newDigits = new int[len]; // julia comment: array initilization, value 0

                // julia comment: 1 bit change
                for(int i=0; i <= k ; i++)
                    newDigits[i] = digits[i];

                newDigits[k]++;  // julia comment: test case {1,2,9,9,9}, k=1, result: 1,3,0,0,0

                return newDigits;
            }
        }
    }
}
