using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver8
{
    class SudokuSolver8
    {
        static void Main(string[] args)
        {
            char[][] board = new char[9][];

            board[0] = new char[] { '.', '.', '9', '7', '4', '8', '.', '.', '.' };
            board[1] = new char[] { '7', '.', '.', '.', '.', '.', '.', '.', '.' };
            board[2] = new char[] { '.', '2', '.', '1', '.', '9', '.', '.', '.' };
            board[3] = new char[] { '.', '.', '7', '.', '.', '.', '2', '4', '.' };
            board[4] = new char[] { '.', '6', '4', '.', '1', '.', '5', '9', '.' };
            board[5] = new char[] { '.', '9', '8', '.', '.', '.', '3', '.', '.' };
            board[6] = new char[] { '.', '.', '.', '8', '.', '3', '.', '2', '.' };
            board[7] = new char[] { '.', '.', '.', '.', '.', '.', '.', '.', '6' };
            board[8] = new char[] { '.', '.', '.', '2', '7', '5', '9', '.', '.' };

            solveSudoku(board);
        }

        /*
         * source code from blog:
         * http://bangbingsyb.blogspot.ca/2014/11/leetcode-valid-sudoku-sudoku-solver.html
         * convert C++ code to C# code
         * Julia's comment: 
         * 1. great highlight in the blog on when to do the back tracking. 
         *    extra back tracking is not a bug; just about logic thinking flaw 
         *    one way to minimize the back tracking is to do it only before "return false" statement; 
         *    I just notice that. On July 21, 2015 
         *    
         */
        public static void solveSudoku(char[][] board)
        {
            if (board.Length < 9 || board[0].Length < 9)
                return;
            bool findSol = solSudoku(board, 0, 0);
        }

        public static bool solSudoku(char[][] board, int irow, int icol)
        {
            if (irow == 9) return true;

            int irow2, icol2;
            if (icol == 8)
            {
                irow2 = irow + 1;
                icol2 = 0;
            }
            else
            {
                irow2 = irow;
                icol2 = icol + 1;
            }

            if (board[irow][icol] != '.')
            {
                if (!isValid(board, irow, icol)) return false;
                return solSudoku(board, irow2, icol2);
            }

            for (int i = 1; i <= 9; i++)
            {
                board[irow][icol] = (char)('0' + i);
                if (isValid(board, irow, icol) && solSudoku(board, irow2, icol2)) return true;
            }

            // reset grid 
            board[irow][icol] = '.';
            return false;
        }

        public static bool isValid(char[][] board, int irow, int icol)
        {
            char val = board[irow][icol];
            if (val - '0' < 1 || val - '0' > 9) return false;

            // check row & col
            for (int i = 0; i < 9; i++)
            {
                if (board[irow][i] == val && i != icol) return false;
                if (board[i][icol] == val && i != irow) return false;
            }

            //check 3x3 box
            int irow0 = irow / 3 * 3;
            int icol0 = icol / 3 * 3;
            for (int i = irow0; i < irow0 + 3; i++)
            {
                for (int j = icol0; j < icol0 + 3; j++)
                {
                    if (board[i][j] == val && (i != irow || j != icol)) return false;
                }
            }

            return true;
        }
    }
}
