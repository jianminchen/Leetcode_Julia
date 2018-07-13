public class Solution
{
    public void Solve(char[,] board)
    {
        int row, col;

        int rows = board.GetLength(0);
        if (rows == 0)
        {
            return;
        }

        int columns = board.GetLength(1);

        for (row = 0; row < rows; row++)
        {
            check(board, row, 0, rows, columns); // first column

            if (columns > 1) // if more than one column
            {
                check(board, row, columns - 1, rows, columns); // last column 
            }
        }

        for (col = 1; col + 1 < columns; col++)
        {
            check(board, 0, col, rows, columns); // first row 

            if (rows > 1) // if more than one row
            {
                check(board, rows - 1, col, rows, columns); // last row
            }
        }

        for (row = 0; row < rows; row++)
        {
            for (col = 0; col < columns; col++)
            {
                var visit = board[row, col];
                board[row, col] = visit == '1' ? 'O' : 'X';
            }
        }
    }

    /// <summary>
    /// code review on July 14, 2017
    /// depth first search to mark '0' to '1', 
    /// temporary state of '1', visited status
    /// </summary>
    /// <param name="board"></param>
    /// <param name="row"></param>
    /// <param name="column"></param>
    /// <param name="rows"></param>
    /// <param name="cols"></param>
    void check(char[,] board, int row, int column, int rows, int cols)
    {
        if (board[row, column] == 'O')
        {
            board[row, column] = '1';

            if (row > 1)
            {
                check(board, row - 1, column, rows, cols);
            }

            if (column > 1)
            {
                check(board, row, column - 1, rows, cols);
            }

            if (row + 1 < rows)
            {
                check(board, row + 1, column, rows, cols);
            }

            if (column + 1 < cols)
            {
                check(board, row, column + 1, rows, cols);
            }
        }
    }
}