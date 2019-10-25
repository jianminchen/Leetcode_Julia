using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1128_Number_of_dominos
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// Oct. 25, 2019
        /// 1128. Number of Equivalent Domino Pairs
        /// </summary>
        /// <param name="dominoes"></param>
        /// <returns></returns>
        public int NumEquivDominoPairs(int[][] dominoes)
        {
            var rows = dominoes.Length;

            var keyCount = new int[100];

            int count = 0;
            for (int i = 0; i < rows; i++)
            {
                var first = dominoes[i][0];
                var second = dominoes[i][1];

                var reversedKey = second * 10 + first;
                var key = first * 10 + second;

                count += keyCount[key];

                if (key != reversedKey)
                {
                    count += keyCount[reversedKey];
                }

                keyCount[key]++;
            }

            return count;
        }
    }
}
