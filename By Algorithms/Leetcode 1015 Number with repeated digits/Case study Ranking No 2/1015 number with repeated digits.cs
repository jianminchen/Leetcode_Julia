using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015_number_with_repeated_digits_2
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static int givenNumber;
        /// <summary>
        /// study code of ranking No. 2, lg52931
        /// https://leetcode.com/contest/weekly-contest-128/ranking
        /// </summary>
        /// <param name="N"></param>
        /// <returns></returns>
        public static int NumDupDigitsAtMostN(int N)
        {
            givenNumber = N;
            return N + 1 - countNumberWithUniqueDigits(0, 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mask">using binary number to mask the digit from 0 to 9</param>
        /// <param name="number"></param>
        /// <returns></returns>
        private static int countNumberWithUniqueDigits(int mask, long number)
        {
            if (number > givenNumber)
            {
                return 0; 
            }

            // Fix timeout bug 
            if (number * 10 > givenNumber)
            {
                return 1; 
            }

            int count = 1;
            for (int digit = number == 0 ? 1 : 0; digit < 10; digit++)
            {
                // mask contains digit bit or not. 
                if (((mask >> digit) & 1) == 0)
                {
                    count += countNumberWithUniqueDigits(mask | (1 << digit), number * 10 + digit);
                }
            }

            return count; 
        }
    }
}
