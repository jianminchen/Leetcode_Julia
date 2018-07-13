using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8StringToInteger_atoi
{
    class Program
    {
        static void Main(string[] args)
        {
            int val = atoi("12A"); 
        }

        /*
         * source code from blog:
         * http://blog.csdn.net/linhuanmars/article/details/21145129
         * comment from the above blog:
         * 注意corner case的处理，整数一般有两点，一个是正负符号问题，
         * 另一个是整数越界问题。思路比较简单，就是先去掉多余的空格字符，
         * 然后读符号（注意正负号都有可能，也有可能没有符号），接下来按顺序读数字，
         * 结束条件有三种情况：
         * （1）异常字符出现（按照C语言的标准是把异常字符起的后面全部截去，保留前面的部分作为结果）；
         * （2）数字越界（返回最接近的整数）；
         * （3）字符串结束。
         * 
         * julia's comment:
         * 1. Let us creat script to quickly memorize the process: 
         *   1. base case check: null point
         *   2. trim the string, extra space is ok, but need to get rid of
         *   3. check string length, 0 length, return 0 
         *   4. check number is negative or not (default is not) - 
         *      check first digit, if it is sign symbol, move to next one
         *   5. Now, it is time to convert string to int (without sign)
         *   Go over an example, 
         *     test case 1: 12, 1*10 + 2 = 12   // mark: step 5C 
         *               2: a -> 0              // mark: step 5A
         *               3: 1a -> 1             // mark: step 5A
         *               4. If the number is overflow,    // mark: step 5B
         *               Int32.MaxValue, Int32.MinValue both case, return max, min 
         *   6. return a value - including negative sign // step 6 
         */
        public static int atoi(String str)
        {
            if (str == null)  // step 1: base case
            {
                return 0;
            }

            str = str.Trim();  // step 2: Trim space 

            int len = str.Length;  // step 3: check length, 0 length return
            if (len == 0)
                return 0;

            bool isNeg = false;  // step 4: 

            int i = 0;    //// step 5
            char firstChar = str[0];  

            if (firstChar == '-' || firstChar == '+')
            {
                i++;
                if (firstChar == '-')
                    isNeg = true;
            }

            int res = 0;
            while (i < len)
            {
                char iChar = str[i];
                if (iChar < '0' || iChar > '9')   // step 5A
                    break;
                int digit = (int)(iChar - '0');   // step 5C 

                if (isNeg && res > -((Int32.MinValue + digit) / 10))   // step 5B - 1 
                    return Int32.MinValue;
                else if (!isNeg && res > (Int32.MaxValue - digit) / 10)  // step 5B - 2
                    return Int32.MaxValue;

                res = res * 10 + digit;
                i++;
            }

            return isNeg ? -res : res;   // step 6
        }  
    }
}
