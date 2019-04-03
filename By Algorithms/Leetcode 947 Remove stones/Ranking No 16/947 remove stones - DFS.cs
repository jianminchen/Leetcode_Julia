using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _947_remove_stones_rank_16
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

        public static List<int>[] graph = new List<int>[1123];
        public static int[] Visited = new int[1123];

        /// <summary>
        /// study code
        /// https://leetcode.com/contest/weekly-contest-112/ranking/
        /// Ranking No. 16 sohelH
        /// Two tips to construct a undirected graph
        /// 1. brute force all possible edges
        /// 2. check if two nodes are in the same row or same column. If it is same row or column, 
        /// then the two nodes are connected. 
        /// </summary>
        /// <param name="stones"></param>
        /// <returns></returns>
        public static int RemoveStones(int[][] stones)
        {
            int length = stones.Length;

            for (int i = 0; i < length; i++)
            {
                graph[i] = new List<int>();
                Visited[i] = 0;
            }

            for (int i = 0; i < length; i++)
            {
                for (int j = i + 1; j < length; j++)
                {
                    int r1 = stones[i][0];
                    int c1 = stones[i][1];
                    int r2 = stones[j][0];
                    int c2 = stones[j][1];

                    if (r1 == r2 || c1 == c2)
                    {
                        graph[i].Add(j);
                        graph[j].Add(i);
                    }
                }
            }

            int components = 0;
            for (int i = 0; i < length; i++)
            {
                if (Visited[i] == 0)
                {
                    dfs(i);
                    components++;
                }
            }

            return length - components;
        }

        private static void dfs(int u)
        {
            if (Visited[u] == 1)
            {
                return;
            }

            Visited[u] = 1;
            for (int i = 0; i < graph[u].Count; i++)
            {
                dfs(graph[u][i]);
            }
        }
    }
}
