using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _947_remove_stones___DFS
{
    class Program
    {
        /// <summary>
        /// Leetcode 947 remove stones
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            RunTestcase2(); 
        }

        public static void RunTestcase1()
        {
            var stones = new int[6][]{
                new int[]{0,0},
                new int[]{0,1},
                new int[]{1,0},
                new int[]{1,2},
                new int[]{2,1},
                new int[]{2,2}
            };

            var result = RemoveStones(stones);
        }

        public static void RunTestcase2()
        {
            var stones = new int[5][]{
                new int[]{0,0},
                new int[]{0,2},
                new int[]{1,1},
                new int[]{2,0},
                new int[]{2,2}                
            };

            var result = RemoveStones(stones);
        }

        public static int Rows; 
        public static bool[][] graph = new bool[1005][];
        public static bool[]   visited = new bool[1005];

        /// <summary>
        /// study code
        /// https://leetcode.com/contest/weekly-contest-112/ranking/
        /// Ranking No. 5 joon_young
        /// </summary>
        /// <param name="stones"></param>
        /// <returns></returns>
        public static int RemoveStones(int[][] stones)
        {
            Rows = stones.Length;

            for (int row = 0; row < 1005; row++)
            {
                graph[row] = new bool[1005];
            }

            // reset to false
            for (int row = 0; row < 1005; row++)
            {
                visited[row] = false; 
            }

            for (int row = 0; row < Rows; row++)
            {
                for (int j = row + 1; j < Rows; j++)
                {
                    if (stones[row][0] == stones[j][0] ||
                        stones[row][1] == stones[j][1])
                    {
                        graph[row][j] = true;
                        graph[j][row] = true;
                    }
                }
                }

            int result = 0;
            for (int row = 0; row < Rows; row++)
            {
                if(visited[row])
                {
                    continue;
                }

                result++;

                dfs(row);
            }

            return Rows - result; 
        }

        private static void dfs(int id)
        {
            if (visited[id])
                return;

            visited[id] = true; 

            for (int row = 0; row < Rows; row++)
            {
                if (graph[id][row])
                {
                    dfs(row);
                }
            }
        }
    }
}
