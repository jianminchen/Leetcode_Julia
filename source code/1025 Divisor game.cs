using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1025_divisor_game
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// study rank No. 6 daltao's code
        /// https://leetcode.com/contest/weekly-contest-132/ranking
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
