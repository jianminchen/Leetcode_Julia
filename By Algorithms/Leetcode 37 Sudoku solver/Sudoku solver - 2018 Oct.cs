using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_solver_2018_Oct
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public void SolveSudoku(char[,] board)
        {
            sudokuSolveHelper(board, 0, 0);
        }

        private static bool sudokuSolveHelper(char[,] board, int row, int col)
        {
            // base case 
            if (row > 8)
            {
                return true;
            }
            var isLastColumn = col == 8;
            int nextRow = isLastColumn ? (row + 1) : row;
            int nextCol = isLastColumn ? 0 : col + 1;

            var current = board[row, col];
            bool isDot = current == '.';
            bool isNumber = (current - '0') >= 0 & (current - '0') <= 9;
            if (isNumber)
            {
                return sudokuSolveHelper(board, nextRow, nextCol);
            }

            foreach (var digit in getAvaiableDigits(board, row, col))
            {
                board[row, col] = digit;

                if (sudokuSolveHelper(board, nextRow, nextCol))
                {
                    return true;
                }

                board[row, col] = '.';
            }

            return false;
        }

        private static IEnumerable<char> getAvaiableDigits(char[,] board, int currentRow, int currentCol)
        {
            var hashSet = new HashSet<char>("123456789".ToCharArray());

            for (int index = 0; index < 9; index++)
            {
                // remove current row used char
                hashSet.Remove(board[currentRow, index]);
                hashSet.Remove(board[index, currentCol]);
            }

            // small 3 x 3 matrix 
            var smallRow = currentRow / 3 * 3; // 0, 3, 6
            var smallCol = currentCol / 3 * 3; // 0, 3, 6
            for (int row = smallRow; row < smallRow + 3; row++)
            {
                for (int col = smallCol; col < smallCol + 3; col++)
                {
                    hashSet.Remove(board[row, col]);
                }
            }

            return hashSet;
        }    
    }
}
