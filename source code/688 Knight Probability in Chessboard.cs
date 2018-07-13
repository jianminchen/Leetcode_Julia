public class Solution
{
    public double KnightProbability(int size, int kSteps, int startRow, int startCol)
    {
        var moves = new int[][] { new int[] {  1, 2 }, new int[] {  1, -2 }, new int[] {  2, 1 }, new int[] {  2, -1 }, 
                                      new int[] { -1, 2 }, new int[] { -1, -2 }, new int[] { -2, 1 }, new int[] { -2, -1 } };

        var dp0 = new double[size, size];

        for (int row = 0; row < size; row++)
        {
            for (int col = 0; col < size; col++)
            {
                dp0[row, col] = 1;
            }
        }

        for (int step = 0; step < kSteps; step++)
        {
            var dp1 = new double[size, size];

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    foreach (int[] move in moves)
                    {
                        var currentRow = row + move[0];
                        var currentCol = col + move[1];

                        if (isLegal(currentRow, currentCol, size))
                        {
                            dp1[currentRow, currentCol] += dp0[row, col];
                        }
                    }
                }
            }

            arrayCopy(dp1, dp0);
        }

        return dp0[startRow, startCol] / Math.Pow(8, kSteps);
    }

    private static void arrayCopy(double[,] source, double[,] destination)
    {
        int rows = source.GetLength(0);
        int columns = source.GetLength(1);

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                destination[row, col] = source[row, col];
            }
        }
    }

    private static bool isLegal(int r, int c, int len)
    {
        return r >= 0 && r < len && c >= 0 && c < len;
    }
}