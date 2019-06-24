using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _947_remove_stones___ranking_58
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// https://leetcode.com/contest/weekly-contest-112/ranking
        /// rank No. 58 BigBallerBrand
        /// 
        /// </summary>
        /// <param name="stones"></param>
        /// <returns></returns>
        public static int RemoveStones(int[][] stones)
        {
            var length = stones.Length;
            var visited = new bool[length];

            int count = 0;
            for (int i = 0; i < length; i++)
            {
                var stone = stones[i];

                if (!visited[i])
                {
                    visited[i] = true;
                    count += dfs(stone, visited, stones);
                }
            }

            return count;
        }

        /// <summary>
        /// code review April 3, 2019
        /// </summary>
        /// <param name="source"></param>
        /// <param name="visited"></param>
        /// <param name="stones"></param>
        /// <returns></returns>
        private static int dfs(int[] source, bool[] visited, int[][] stones)
        {
            int count = 0; 

            var length = stones.Length;

            var startRow = source[0];
            var startColumn = source[1];

            for (int i = 0; i < length; i++)
            {
                if (visited[i])
                {
                    continue;
                }               

                var row    = stones[i][0];
                var column = stones[i][1];

                var sameRow = row == startRow;
                var sameColumn = column == startColumn;

                if (sameRow && sameColumn)
                {
                    continue;
                }

                if (sameRow || sameColumn)
                {
                    visited[i] = true;
                    count += dfs(stones[i], visited, stones) + 1;
                }
            }

            return count; 
        }
    }
}
