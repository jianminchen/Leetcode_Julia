using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _48_rotate_image___II
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// submission date: 2017 June
        /// 48 rotate image
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        public void Rotate(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int index = 0;
            while (2 * index < rows)
            {
                reverseRows(index, rows - 1 - index, matrix);
                index++;
            }

            for (int row = 0; row < rows; ++row)
            {
                for (int col = row + 1; col < cols; ++col)
                {
                    swap(row, col, matrix);
                }
            }
        }

        private void reverseRows(int row1, int row2, int[,] matrix)
        {
            int cols = matrix.GetLength(1);
            for (int col = 0; col < cols; col++)
            {
                int tmp = matrix[row1, col];
                matrix[row1, col] = matrix[row2, col];
                matrix[row2, col] = tmp;
            }
        }

        private void swap(int row, int col, int[,] matrix)
        {
            int tmp = matrix[row, col];
            matrix[row, col] = matrix[col, row];
            matrix[col, row] = tmp;
        }
    }
}
