using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _54_Spiral_matrix
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// online code screen - mock interview 4/12/2019             
        public IList<int> SpiralOrder(int[][] matrix)
        {
            if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
                return new List<int>();

            var rows = matrix.Length;
            var columns = matrix[0].Length;

            // right, down, left, up
            var directionX = new int[] { 0, 1, 0, -1 };
            var directionY = new int[] { 1, 0, -1, 0 };

            var visited = new bool[rows, columns];

            var direction = 0;
            var startRow = 0;
            var startCol = -1;

            var list = new List<int>();

            int index = 0;
            while (index < rows * columns)
            {
                var nextRow = startRow + directionX[direction];
                var nextCol = startCol + directionY[direction];

                if (nextRow < 0 || nextRow >= rows || nextCol < 0 || nextCol >= columns || visited[nextRow, nextCol])
                {
                    direction = (direction + 1) % 4;
                    continue;
                }

                list.Add(matrix[nextRow][nextCol]);
                visited[nextRow, nextCol] = true;

                startRow = nextRow;
                startCol = nextCol;

                index++;
            }

            return list;
        }
    }
}
