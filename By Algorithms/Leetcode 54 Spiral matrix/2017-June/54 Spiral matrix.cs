using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _54_Spiral_matrix__2017_June
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// code written in 2017-June
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public IList<int> SpiralOrder(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int total = rows * cols;
            var spiral = new int[total];

            int index = 0;

            int leftCol = 0;
            int rightCol = cols - 1;
            int topRow = 0;
            int bottomRow = rows - 1;

            // the idea is to simplify the while loop - one variable checking, check the length of spiral 
            // array intead of compared to the start position of spiral layer. 
            // test cases: one node in the array, one row, one column
            while (index < total)
            {
                // top row - go right, 
                for (int col = leftCol; col <= rightCol; col++)
                {
                    var current = matrix[topRow, col];
                    spiral[index++] = current;
                }

                // right col - go down
                for (int row = topRow + 1; row <= bottomRow; row++)
                {
                    var current = matrix[row, rightCol];
                    spiral[index++] = current;
                }

                // go left
                for (int col = rightCol - 1; col >= leftCol && bottomRow > topRow; col--)
                {
                    var current = matrix[bottomRow, col];
                    spiral[index++] = current;
                }

                // go up 
                for (int row = bottomRow - 1; row > topRow && leftCol < rightCol; row--)
                {
                    var current = matrix[row, leftCol];
                    spiral[index++] = current;
                }

                leftCol++;
                rightCol--;
                topRow++;
                bottomRow--;
            }

            return new List<int>(spiral);
        }
    }
}
