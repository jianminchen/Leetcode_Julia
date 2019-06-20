using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _518_coin_change_2___memoization
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// June 20, 2019
        /// study code 
        /// https://leetcode.com/problems/coin-change-2/discuss/99239/C-DFS-with-memorization-of-course-DP-is-better
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="coins"></param>
        /// <returns></returns>
        public int Change(int amount, int[] coins)
        {
            // order coins in order to prune recursion
            Array.Sort(coins);

            // init memorization to -1 (unvisited)
            var map = new int[amount + 1, coins.Length];

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = -1;
                }
            }

            // DFS
            return CountUsingDepthFirstSearch(coins, amount, 0, map);
        }

        /// <summary>
        /// depth first search
        /// </summary>
        /// <param name="coins"></param>
        /// <param name="amount"></param>
        /// <param name="index"></param>
        /// <param name="map"></param>
        /// <returns></returns>
        private int CountUsingDepthFirstSearch(int[] coins, int amount, int index, int[,] map)
        {
            if (amount == 0)
            {
                return 1;
            }

            if (index == coins.Length)
            {
                return 0;
            }

            if (map[amount, index] != -1)
            {
                return map[amount, index];
            }

            int count = 0;
            for (int i = index; i < coins.Length; i++)
            {
                if (coins[i] > amount) break;

                // using this coin as many times as possible before going to next coin
                int times = 1;
                while (times * coins[i] <= amount)
                {
                    var nextAmont = amount - times * coins[i];
                    count += CountUsingDepthFirstSearch(coins, nextAmont, i + 1, map);
                    times++;
                }
            }

            // memorize
            map[amount, index] = count;
            return count;
        }
    }
}
