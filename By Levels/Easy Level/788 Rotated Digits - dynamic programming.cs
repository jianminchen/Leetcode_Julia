using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _788.Rotated_Digits
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// convert integer to string
        /// go over each string to determine if it is a good number
        /// 0, 1, 8 -> rotate to itself
        /// 2<->5
        /// 6<->9
        /// 3, 4, 7, 8 does not apply rotation
        /// </summary>
        /// <param name="N"></param>
        /// <returns></returns>
        public int RotatedDigits(int N)
        {
            // dp[i] = 0, invalid number
            // dp[i] = 1, valid and same number
            // dp[i] = 2, valid and different number
            int[] dp = new int[N + 1];

            int count = 0;
            for (int i = 0; i <= N; i++)
            {
                if (i < 10)
                {
                    if (i == 0 || i == 1 || i == 8)
                    {
                        dp[i] = 1;
                    }
                    else if (i == 2 || i == 5 || i == 6 || i == 9)
                    {
                        dp[i] = 2;
                        count++;
                    }
                }
                else
                {
                    int a = dp[i / 10];
                    int b = dp[i % 10];

                    if (a == 1 && b == 1)
                    {
                        dp[i] = 1;
                    }
                    else if (a >= 1 && b >= 1)
                    {
                        dp[i] = 2;
                        count++;
                    }
                }
            }

            return count;
        }
    }
}
