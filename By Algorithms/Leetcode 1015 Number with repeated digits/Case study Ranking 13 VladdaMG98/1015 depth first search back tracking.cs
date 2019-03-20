using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015_number_with_repeated_digits_13
{
    class Program
    {
        static void Main(string[] args)
        {
            NumDupDigitsAtMostN(872427638);
            Debug.Assert(value == 10); 
        }

        public static int    value = 0; 
        public static bool[] taken = new bool[10];

        /// <summary>
        /// March 20, 2019
        /// study code based on ranking No. 13, VladaMG98
        /// https://leetcode.com/contest/weekly-contest-128/ranking/
        /// </summary>
        /// <param name="N"></param>
        /// <returns></returns>
        public static int NumDupDigitsAtMostN(int N)
        {            
            return N - getAllDifferent(N) + 1; 
        }

        private static int getAllDifferent(int N)
        {
            value = 0;
            for (int i = 0; i < taken.Length; i++)
            {
                taken[i] = false; 
            }

            recursive(0, 0, N);
            return value; 
        }

        /// <summary>
        /// Brute force solution
        /// Make sure that all numbers in the integer are distinct, less than and equal N.
        /// Problem statement:
        /// Given a positive integer N, return the number of positive integers less than or 
        /// equal to N that have at least 1 repeated digit.
        /// Start from rightmost digit. 
        /// </summary>
        /// <param name="number"></param>
        /// <param name="digit"></param>
        /// <param name="N"></param>
        private static void recursive(double number, int digit, int N)
        {
            if (number > N)
            {
                return; 
            }

            // current number with value number is the one. 
            value += 1;

            for (int x = 0; x < 10; x++)
            {
                if (taken[x])
                {
                    continue; 
                }

                // make sure that the number is positive number
                var numberIsZero = digit == 0 && x == 0;
                if (numberIsZero)
                {
                    continue;
                }

                taken[x] = true;
                recursive(number * 10 + x, digit + 1, N);
                
                // backtracking
                taken[x] = false; 
            }
        }
    }
}
