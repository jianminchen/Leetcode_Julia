﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _91_decode_ways
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// 5/2/2019 code review 
        /// 91 Decode ways
        /// I came cross three bugs and I had to use debugger to help me to figure out
        /// 1. mix char with integer, s[i] - '0' is to convert to integer
        /// 2. all results are zero, forget to increment one for the start
        /// 3. apply step 1 for all instances, miss a few place
        /// 4. missing edge case, tenth digit should exclude 0, 3 to 9. 0 is not considered by mistake. 
        /// 5. missing edge case, 00 is not valid 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int NumDecodings(string s)
        {
            if (s == null || s.Length == 0)
                return 0;

            var length = s.Length;
            var dp = new int[length + 1];

            for (int i = 1; i < length + 1; i++)
            {
                var index = i - 1;

                // convert to integer from char
                var current = s[index] - '0';
                var isZero = current == 0;

                // 00 -> not valid, 0 - not valid, exclude 0 and 3 to 9 for tenth digit
                if (isZero && (index == 0 || (s[index - 1] - '0') > 2 || (s[index - 1] - '0') == 0))
                {
                    return 0;
                }

                // make sure that increment one somewhere, otherwise all will be zero. 
                if (isZero)
                {
                    dp[i] = dp[i - 2] == 0 ? 1 : dp[i - 2];
                }
                else
                {
                    dp[i] = dp[i - 1] == 0 ? 1 : dp[i - 1];

                    if (index > 0 && ((s[index - 1] - '0') * 10 + current) <= 26 && (s[index - 1] - '0') != 0)
                    {
                        dp[i] += dp[index - 1] == 0 ? 1 : dp[index - 1];
                    }
                }
            }

            return dp[length];
        }
    }
}
