using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1034_coloring_a_border
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public int[][] ColorBorder(int[][] grid, int r0, int c0, int color)
        {
            var rows = grid.Length;
            var origin = grid[r0][c0];

            visitGridDFS(grid, r0, c0, grid[r0][c0]);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < grid[row].Length; col++)
                {
                    var current = grid[row][col];
                    // -1 change color
                    if (current == -1)
                    {
                        grid[row][col] = color;
                    }
                    else if (current == -2)
                    {
                        grid[row][col] = origin;
                    }
                }
            }
            return grid;
        }

        private void visitGridDFS(int[][] grid, int row, int col, int color)
        {
            var rows = grid.Length;
            if (row < rows && row >= 0 && col >= 0 && col < grid[row].Length &&
                (grid[row][col] == color)
                )
            {
                var firstLastRow = row == 0 || row == (rows - 1);
                var firstLastCol = col == 0 || col == (grid[row].Length - 1);

                grid[row][col] = -2;

                // -1 change color, mark visited
                // -2 keep color, mark visited
                if (firstLastCol || firstLastRow ||
                    ((grid[row - 1][col] != color && grid[row - 1][col] > 0) ||
                     (grid[row + 1][col] != color && grid[row + 1][col] > 0) ||
                     (grid[row][col - 1] != color && grid[row][col - 1] > 0) ||
                     (grid[row][col + 1] != color && grid[row][col + 1] > 0)))
                {
                    grid[row][col] = -1;
                }

                visitGridDFS(grid, row, col - 1, color);
                visitGridDFS(grid, row, col + 1, color);
                visitGridDFS(grid, row - 1, col, color);
                visitGridDFS(grid, row + 1, col, color);
            }
        }    
    }
}
