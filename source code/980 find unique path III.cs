using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _980_find_unique_path_III
{
    class Program
    {
        static void Main(string[] args)
        {
        }
        
        int paths = 0;
        int empty = 1;
        int sx, sy, ex, ey;

        /// <summary>
        /// learn the idea to solve the problem
        /// https://leetcode.com/problems/unique-paths-iii/discuss/221946/JavaPython-Brute-Force-Backstracking
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int UniquePathsIII(int[][] grid)
        {
            var rows = grid.Length;
            int columns = grid[0].Length;

            for (int row = 0; row < rows; ++row)
            {
                for (int column = 0; column < columns; ++column)
                {
                    var visit = grid[row][column];

                    if (visit == 0)
                    {
                        empty++;
                    }
                    else if (visit == 1)
                    {
                        sx = row;
                        sy = column;
                    }
                    else if (visit == 2)
                    {
                        ex = row;
                        ey = column;
                    }
                }
            }

            dfs(grid, sx, sy);
            return paths;
        }

        /// <summary>
        /// depth first search
        /// learn how to do back tracking 
        /// tip: no visted element marking 
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="x0"></param>
        /// <param name="y0"></param>
        public void dfs(int[][] grid, int x0, int y0)
        {
            if (check(grid, x0, y0) == false)
            {
                return;
            }

            if (x0 == ex && y0 == ey && empty == 0)
            {
                paths++;
                return;
            }

            grid[x0][y0] = -2;

            empty--;

            dfs(grid, x0 + 1, y0);
            dfs(grid, x0 - 1, y0);
            dfs(grid, x0,     y0 + 1);
            dfs(grid, x0,     y0 - 1);

            // backtracking 
            grid[x0][y0] = 0;

            empty++;
        }

        private static bool check(int[][] grid, int i, int j)
        {
            int m = grid.Length;
            int n = grid[0].Length;

            return 0 <= i && i < m && 0 <= j && j < n && grid[i][j] >= 0;
        }
    }
}
