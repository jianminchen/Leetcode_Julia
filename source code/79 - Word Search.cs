public class Solution
{
    public bool Exist(char[,] board, string word)
    {
        if (board == null ||
                board.GetLength(0) == 0 ||
                board.GetLength(1) == 0 ||
                word == null ||
                word.Length == 0)
        {
            return false;
        }

        int rows = board.GetLength(0);
        int cols = board.GetLength(1);

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                var visit = board[row, col];
                bool startSearch = visit == word[0];

                if (!startSearch)
                {
                    continue;
                }

                var memo = new bool[rows, cols];
                bool foundOne = searchWord(board, word, row, col, 0, memo);

                if (foundOne)
                {
                    return true;
                }
            }
        }

        return false;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="board"></param>
    /// <param name="word"></param>
    /// <param name="startRow"></param>
    /// <param name="startCol"></param>
    /// <returns></returns>
    private static bool searchWord(
        char[,] board,
        string word,
        int startRow,
        int startCol,
        int index,
        bool[,] memo)
    {
        int rows = board.GetLength(0);
        int cols = board.GetLength(1);

        if (!isInBoundary(board, startRow, startCol) || memo[startRow, startCol])
        {
            return false;
        }

        var visit = board[startRow, startCol];
        var length = word.Length;

        bool isEqual = index < length && visit == word[index];
        bool isLastChar = index == (length - 1);

        if (!isEqual)
        {
            return false;
        }

        memo[startRow, startCol] = true;

        // base case 
        if (isLastChar)
        {
            return true;
        }

        var nextIndex = index + 1; // bug found through debug - nextIndex++ in four recursive calls
        var result =
               searchWord(board, word, startRow, startCol - 1, nextIndex, memo) ||
               searchWord(board, word, startRow, startCol + 1, nextIndex, memo) ||
               searchWord(board, word, startRow - 1, startCol, nextIndex, memo) ||
               searchWord(board, word, startRow + 1, startCol, nextIndex, memo);

        if (!result)
        {
            memo[startRow, startCol] = false;
        }

        return result;
    }

    private static bool isInBoundary(char[,] board, int startRow, int startCol)
    {
        int rows = board.GetLength(0);
        int cols = board.GetLength(1);

        return startRow >= 0 && startRow < rows &&
                startCol >= 0 && startCol < cols;
    }
}