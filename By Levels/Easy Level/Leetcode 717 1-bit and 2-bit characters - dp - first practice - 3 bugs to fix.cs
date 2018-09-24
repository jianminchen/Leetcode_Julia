using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_717_1_bit_and_2_bit
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = IsOneBitCharacter(new int[] { 1, 1, 1, 0 });
        }

        /// <summary>
        /// using dynamic programming method
        /// </summary>
        /// <param name="bits"></param>
        /// <returns></returns>
        public static bool IsOneBitCharacter(int[] bits)
        {
            if (bits == null || bits.Length == 0)
                return false;

            var length = bits.Length;
            if(length == 1)
            {
                return bits[0] == 0;
            }

            if (length == 2)
            {
                return bits[0] == 0 && bits[1] == 0; // bug fix 3: last character is one bit character
            }

            var dp = new bool[length];
            dp[0] = bits[0] == 0;
            dp[1] = !(bits[0] == 0 && bits[1] == 1);

            for (int i = 2; i < length; i++)
            {
                if (!dp[i - 1] && !dp[i - 2])
                {
                    return false; //bug fix 1: online judge shows failed test case [1, 1, 1, 0]
                }

                var current = bits[i];
                dp[i] = ( dp[i - 2]  && !(bits[i - 1] == 0 && current == 1)) ||
                        (!dp[i - 2]  && dp[i - 1]          && current == 0);
            }

            //return bits[length - 1] == 0 && dp[length - 1]; //Bug fix 2: last character is one bit character
            return dp[length - 2] && bits[length - 1] == 0; // last character is one bit character. 
        }
    }
}
