using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1025_divisor_game___dp
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// It is better for me to write a dynamic programming solution, so I can have more time 
        /// to write other algorithms in the weekly contest. 
        /// </summary>
        /// <param name="N"></param>
        /// <returns></returns>
        public bool DivisorGame(int N)
        {
            var dp = new bool[N + 1];
            dp[1] = false;

            for (int i = 1; i <= N; i++)
            {
                for (int j = 1; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        dp[i] = dp[i] || !dp[i - j];
                    }
                }
            }

            return dp[N];
        }    
    }
}
