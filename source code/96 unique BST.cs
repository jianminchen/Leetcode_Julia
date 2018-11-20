using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _96_unique_BST
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// source code is based on the discuss
        /// https://leetcode.com/problems/unique-binary-search-trees/discuss/31666/DP-Solution-in-6-lines-with-explanation.-F(i-n)-G(i-1)-*-G(n-i)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int NumTrees(int n)
        {
            if (n < 0)
            {
                return 0;
            }

            var dp = new int[n + 1];
            dp[0] = 1; 
            dp[1] = 1;
           
            for (int i = 2; i < n + 1; i++)
            {
                dp[i] = 0;
                for (int j = 0; j < i; j++)
                {
                    dp[i] += dp[j] * dp[i - 1 - j];
                }
            }

            return dp[n];
        }        
    }
}
