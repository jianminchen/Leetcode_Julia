using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _329_longest_increasing_path_in_a_matrix
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static int[][] directions = new int[4][]{
            new int[]{0, 1}, 
            new int[]{1, 0},  
            new int[]{0, -1},
            new int[]{-1, 0}
        };

        /// <summary>
        /// code review May 23, 2019
        /// Study code:
        /// https://leetcode.com/problems/longest-increasing-path-in-a-matrix/discuss/78308/15ms-Concise-Java-Solution
        /// 1. Run DFS from every cell;
        /// 2. Compare every 4 direction and skip cells that out of boundary or smaller
        /// 3. Get matrix max from every cell's max
        /// 4. Use matrix[x][y] <= matrix[i][j] so we don't need a visited[m][n] array
        /// 5. The key is to cache the distance because it is highly possible to revisit a cell
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public int LongestIncreasingPath(int[][] matrix)
        {
            if (matrix == null || matrix.Length == 0)
                return 0;

            int rows = matrix.Length;
            int columns = matrix[0].Length;

            var cache = new int[rows, columns];
            int max = 1;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    int length = runDepthFirstSearch(matrix, row, col, rows, columns, cache);
                    max = Math.Max(max, length); 
                }
            }

            return max; 
        }

        /// <summary>
        /// Run depth first search to find the maximum length
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="rows"></param>
        /// <param name="columns"></param>
        /// <param name="cache"></param>
        /// <returns></returns>
        private static int runDepthFirstSearch(int[][] matrix, int row, int col, int rows, int columns, int[,] cache)
        {
            if (cache[row, col] != 0)
                return cache[row, col];

            int max = 1;
            foreach (var dir in directions)
            {
                int x = row + dir[0];
                int y = col + dir[1];

                var outOfRangeOrSmaller = x < 0 || x >= rows || y < 0 || y >= columns ||  matrix[x][y] <= matrix[row][col];
                if (outOfRangeOrSmaller)
                    continue;

                int length = 1 + runDepthFirstSearch(matrix, x, y, rows, columns, cache);
                max = Math.Max(max, length); 
            }

            cache[row, col] = max;
            return max; 
        }
    }
}
