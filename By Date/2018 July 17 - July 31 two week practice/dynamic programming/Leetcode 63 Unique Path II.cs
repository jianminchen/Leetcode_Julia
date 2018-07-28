using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_63_unique_Path
{
    /// <summary>
    /// Leetcode 63: 
    /// https://leetcode.com/problems/unique-paths-ii/submissions/1
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// can only go down or right
        /// </summary>
        /// <param name="obstacleGrid"></param>
        /// <returns></returns>
        public int UniquePathsWithObstacles(int[,] obstacleGrid)
        {
            if (obstacleGrid == null || obstacleGrid.GetLength(0) == 0 ||
                obstacleGrid.GetLength(1) == 0)
                return 0;

            var rows = obstacleGrid.GetLength(0);
            var columns = obstacleGrid.GetLength(1);

            var paths = new int[rows,columns];

            // base case: first row
            for(int col = 0; col < columns; col++)
            {
                var current = obstacleGrid[0, col];
                if(current == 0 && (col == 0 || paths[0, col - 1] == 1))
                {
                    paths[0, col] = 1;
                }
            }

            // base case: first column
            for(int row = 0; row < rows; row++)
            {
                var current = obstacleGrid[row, 0];
                if(current == 0 && ( row == 0 || paths[row - 1, 0] == 1))
                {
                    paths[row, 0] = 1;
                }
            }

            for(int row = 1; row < rows; row++)
            {              
                for(int col = 1; col < columns; col++)
                {
                    var current = obstacleGrid[row, col];
                    if (current == 1)
                        paths[row, col] = 0;
                    else
                        paths[row, col] = paths[row, col - 1] + paths[row - 1, col];
                }
            }

            return paths[rows - 1, columns - 1];
        }
    }
}
