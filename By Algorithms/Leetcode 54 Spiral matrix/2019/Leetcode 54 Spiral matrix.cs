using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _54_Spiral_matrix___2019_Warmup
{
    class Program
    {
        static void Main(string[] args)
        {
            RunTestcase();
        }

        public static void RunTestcase()
        {
            var matrix = new int[3][];
            matrix[0] = new int[] { 1, 2, 3 };
            matrix[1] = new int[] { 8, 9, 4 };
            matrix[2] = new int[] { 7, 6, 5 };

            var spiral = SpiralOrder(matrix);

            Debug.Assert(String.Join("", spiral).CompareTo("123456789") == 0);
        }

        /// <summary>
        /// warm up practice in Oct. 2019
        /// https://leetcode.com/problems/spiral-matrix/discuss/407992/C-Using-direction-array-and-no-extra-space-for-visit-marking-practice-in-2018
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static IList<int> SpiralOrder(int[][] matrix)
        {
            if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
            {
                return new int[0];
            }

            int rows = matrix.Length;
            int columns = matrix[0].Length;

            var spiral = new int[rows * columns];
            //                               Right    down    left      up 
            var directions = new int[4, 2] { { 0, 1 }, { 1, 0 }, { 0, -1 }, { -1, 0 } };

            // define four corners of matrix and increment/ decrement when changing directions
            int firstRow = 0;
            int lastRow = rows - 1;
            int firstColumn = 0;
            int lastColumn = columns - 1;

            int total = rows * columns;
            int index = 0;

            // visit node
            int row = 0;
            int column = 0;

            int direction = 0;

            while (index < total)
            {
                spiral[index] = matrix[row][column];
                index++;

                var nextRow = row + directions[direction, 0];
                var nextCol = column + directions[direction, 1];

                // not in range of spiral matrix 
                if (!(nextRow >= firstRow && nextRow <= lastRow && nextCol >= firstColumn && nextCol <= lastColumn))
                {
                    // change direction - increment/ decrement four corners
                    switch (direction)
                    {
                        case 0:
                            firstRow++;
                            break;
                        case 1:
                            lastColumn--;
                            break;
                        case 2:
                            lastRow--;
                            break;
                        case 3:
                            firstColumn++;
                            break;
                    }

                    direction = (direction + 1) % 4;
                }

                // reset row, column
                row += directions[direction, 0];
                column += directions[direction, 1];
            }

            return spiral;
        } 
    }
}
