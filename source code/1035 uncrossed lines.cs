using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1035_uncrossed_lines
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public int MaxUncrossedLines(int[] A, int[] B)
        {
            var rows = A.Length;
            var cols = B.Length;

            var dp = new int[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    var value1 = A[row];
                    var value2 = B[col];

                    var isEqual = value1 == value2;

                    var list = new List<int>();
                    if (row > 0)
                    {
                        list.Add(dp[row - 1, col]);
                    }

                    if (col > 0)
                    {
                        list.Add(dp[row, col - 1]);
                    }

                    var thirdValue = isEqual ? 1 : 0;
                    if (row > 0 && col > 0)
                    {
                        thirdValue += dp[row - 1, col - 1];
                    }

                    list.Add(thirdValue);

                    dp[row, col] = list.ToArray().Max();
                }
            }

            return dp[rows - 1, cols - 1];
        }
    }
}
