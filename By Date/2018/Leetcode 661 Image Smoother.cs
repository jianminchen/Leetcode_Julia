using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_661_Image_smoother
{
    public class Solution
    {
        public int[,] ImageSmoother(int[,] M)
        {
            if (M == null || M.GetLength(0) == 0 || M.GetLength(1) == 0)
                return new int[0, 0];

            var rows = M.GetLength(0);
            var columns = M.GetLength(1);

            var smoothers = new int[rows, columns];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    int count = 0;
                    int sum = 0;

                    var rowsDiff = new int[] { -1, 0, 1 };
                    var colsDiff = new int[] { -1, 0, 1 };

                    foreach (var rowDiff in rowsDiff)
                    {
                        foreach (var colDiff in colsDiff)
                        {
                            var rowNeighbor = row + rowDiff;
                            var colNeighbor = col + colDiff;

                            if (isValid(rowNeighbor, colNeighbor, rows, columns))
                            {
                                count++;
                                sum += M[rowNeighbor, colNeighbor];
                            }
                        }
                    }

                    smoothers[row, col] = sum / count;
                }
            }

            return smoothers;
        }

        private static bool isValid(int row, int col, int rows, int cols)
        {
            return row >= 0 && row < rows && col >= 0 && col < cols;
        }
    }
}
