using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015_number_with_repeated_digits_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = NumDupDigitsAtMostN(20);
        }

        public static int n;
        public static int uniqueDigitis;

        /// <summary>
        /// study code on weekly contest 128 rank No. 1 waakaaka
        /// https://leetcode.com/contest/weekly-contest-128/ranking
        /// </summary>
        /// <param name="N"></param>
        /// <returns></returns>
        public static int NumDupDigitsAtMostN(int N)
        {
            uniqueDigitis = 0;
            n = N;
            runDepthFirstSearchRightMostFirst(0, 0);
            return N + 1 - uniqueDigitis; 
        }

        /// <summary>
        /// code review March 21, 2019
        /// Here are a few tips:
        /// 1. using one binary number to store all unique digits in the number; mapping is described in the comment
        /// 2. using & operator to avoid any duplicated digit
        /// 3. using or to include current digit into the binary number
        /// </summary>
        /// <param name="value"></param>
        /// <param name="binaryShift"></param>
        private static void runDepthFirstSearchRightMostFirst(long value, int binaryShift)
        {
            if (value <= n)
            {
                uniqueDigitis++;
            }

            if (value * 10 > n)
            {
                return;
            }

            for (int digit = 0; digit <= 9; digit++)
            {
                // no 0 for first digit
                if (binaryShift == 0 && digit == 0)
                {
                    continue;
                }

                // every number from 0 to 9 is represented using binary number
                // 0 is expressed in 0
                // 1 is expressed in 10
                // 2 is expressed in 100
                // 3 is expressed in 1000
                // 4 is expressed in 10000
                // 5 is expressed in 100000
                // 6 is expressed in 1000000
                // 7 is expressed in 10000000
                // 8 is expressed in 100000000
                // 9 is expressed in 1000000000
                var currentDigitExpression = 1 << digit; 
               
                // number with unique digits, for example, 123 or 321 or 213. 
                // all digits in the number can be expressed using one binary number 1110
                // so next digit should avoid duplication of those three digits
                // if current digit is 4, the exiting digits include {1, 2, 3}, then 1110 & (1 << 4) = 1110 & 10000 = 0, 
                // since there is no duplication of digits                
                // any digit from {1, 2, 3} & 1110 > 0 
                if ((binaryShift & currentDigitExpression) > 0)
                {
                    continue; 
                }

                // using | to include current digit
                var nextBinary = binaryShift | currentDigitExpression;
                runDepthFirstSearchRightMostFirst(value * 10 + digit, nextBinary); 
            }
        }
    }
}
