using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _695_Max_area_of_island
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public int MaxAreaOfIsland(int[,] grid)
        {
            if (grid == null || grid.GetLength(0) == 0 || grid.GetLength(1) == 0)
            {
                return 0;
            }

            var rows = grid.GetLength(0);
            var columns = grid.GetLength(1);

            var maxArea = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    var current = grid[row, col];
                    if (current != 1)
                        continue;

                    int currentArea = 0;
                    visitIsland(grid, row, col, ref currentArea);
                    maxArea = currentArea > maxArea ? currentArea : maxArea;
                }
            }

            return maxArea;
        }

        private static void visitIsland(int[,] grid, int row, int col, ref int currentArea)
        {
            var rows = grid.GetLength(0);
            var columns = grid.GetLength(1);

            if (row < 0 || row >= rows || col < 0 || col >= columns || grid[row, col] != 1)
                return;

            grid[row, col] = 0;
            currentArea++;

            visitIsland(grid, row, col - 1, ref currentArea);
            visitIsland(grid, row, col + 1, ref currentArea);
            visitIsland(grid, row - 1, col, ref currentArea);
            visitIsland(grid, row + 1, col, ref currentArea);
        }
    }
}
