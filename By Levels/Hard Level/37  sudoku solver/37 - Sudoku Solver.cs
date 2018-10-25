public class Solution
{
    public void SolveSudoku(char[,] board)
    {

        // your code goes here
        sudokuSolveHelper(board, 0, 0);
    }

    // 
    private static bool sudokuSolveHelper(char[,] board, int row, int col)
    {
        // base case 
        if (row > 8)  // 0 - 8 , row = 9
        {
            return true;
        }

        var current = board[row, col];
        bool isEmtpy = current == '.';
        bool isNumber = (current - '0') >= 0 & (current - '0') <= 9;
        if (isNumber) // 3 
        {
            bool isLastColumn = col == 8;
            int nextRow = isLastColumn ? (row + 1) : row;
            int nextCol = isLastColumn ? 0 : col + 1;

            return sudokuSolveHelper(board, nextRow, nextCol); // 0, 1, (0, 2)
        }
        else // 
        {
            for (int number = 1; number <= 9; number++)
            {
                if (isAvailable(board, number, row, col))
                {
                    board[row, col] = (char)(number + '0');  // add '0' 
                    if (sudokuSolveHelper(board, row, col))
                    {
                        return true;
                    }
                    else
                    {
                        board[row, col] = '.';
                    }
                }
            }

            return false;
        }

        // unreachable code
    }

    private static bool isAvailable(char[,] board, int number, int row, int col)
    {
        // check row 
        for (int column = 0; column < 9; column++)
        {
            if (board[row, column] - number == '0')
            {
                return false;
            }
        }

        // check column
        for (int rowIndex = 0; rowIndex < 9; rowIndex++)
        {
            if (board[rowIndex, col] - number == '0')
            {
                return false;
            }
        }

        // check 3 * 3 matrix 
        // row -> row/3
        // col -> col/3 
        int smallMatrixRow = row / 3; // 0
        int smallMatrixCol = col / 3; // 2 

        int startRow = smallMatrixRow * 3;
        int startCol = smallMatrixCol * 3;
        for (int r = startRow; r < startRow + 3; r++) // 5, 3, 6, 8, 9 - 1 avaiable 
        {
            for (int c = startCol; c < startCol + 3; c++)
            {
                if (board[r, c] - number == '0')
                {
                    return false;
                }
            }
        }

        return true;
    }

}