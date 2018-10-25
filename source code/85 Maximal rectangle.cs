using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _85_Maximal_rectangle
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public int MaximalRectangle(char[,] matrix)
        {
            var rows = matrix.GetLength(0);
            var columns = matrix.GetLength(1);

            var maximumRectangle = 0;

            //[i, 0] is left; [i, 1] is right; [i, 2] is height
            var threeMetrics = new int[columns, 3];

            for (int i = 0; i < columns; i++)
            {
                threeMetrics[i, 1] = columns;
            }

            for (int row = 0; row < rows; row++)
            {
                var currentLeft = 0;
                var currentRight = columns;

                for (int col = 0; col < columns; col++)
                {
                    var visit = matrix[row, col];
                    bool isOne = visit == '1';

                    // compute height (can do this from either side)
                    threeMetrics[col, 2] = isOne ? (threeMetrics[col, 2] + 1) : 0;

                    if (isOne)     // compute left (from left to right)
                    {
                        threeMetrics[col, 0] = Math.Max(threeMetrics[col, 0], currentLeft);
                    }
                    else
                    {
                        threeMetrics[col, 0] = 0;
                        currentLeft = col + 1;
                    }
                }

                // compute right (from right to left)
                for (int col = columns - 1; col >= 0; col--)
                {
                    var visit = matrix[row, col];
                    bool isOne = visit == '1';

                    if (isOne)
                    {
                        threeMetrics[col, 1] = Math.Min(threeMetrics[col, 1], currentRight);
                    }
                    else
                    {
                        threeMetrics[col, 1] = columns;
                        currentRight = col;
                    }
                }

                // compute the area of rectangle (can do this from either side)
                for (int column = 0; column < columns; column++)
                {
                    var width = threeMetrics[column, 1] - threeMetrics[column, 0];
                    var height = threeMetrics[column, 2];

                    maximumRectangle = Math.Max(maximumRectangle, width * height);
                }
            }

            return maximumRectangle;
        }
    }
}
