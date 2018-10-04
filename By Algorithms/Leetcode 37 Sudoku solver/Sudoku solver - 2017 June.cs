using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_solver_2017_June
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public void SolveSudoku(char[,] board)
        {

            // your code goes here      
            SudokuSolveHelper(board, 0, 0);
        }

        /// <summary>
        /// recursive design, start from left top corner of board, and go 
        /// through one row from left to right, top to down. 
        /// </summary>
        /// <param name="board"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public static bool SudokuSolveHelper(char[,] board, int row, int col)
        {
            // base case 
            if (row == 9)
            {
                return true;
            }

            var nextOne = getNextOne(row, col);
            var visit = board[row, col];
            bool isEmpty = visit == '.';

            if (!isEmpty)
            {
                // recursive to next one -> lastColumn, next column/ next row 
                return SudokuSolveHelper(board, nextOne[0], nextOne[1]);
            }

            for (int value = 1; value <= 9; value++)
            {
                var current = (char)('0' + value);

                // pass 3 checking - column checking/ row checking/ small check
                if (checkConstraints(board, row, col, current))
                {
                    board[row, col] = current;
                    // next col/  next col                
                    if (SudokuSolveHelper(board, nextOne[0], nextOne[1]))
                    {
                        return true;
                    }
                }

                board[row, col] = '.'; // backtracking 
            }

            return false; // compiler error - not all path returns value                
        }

        private static int[] getNextOne(int row, int col)
        {
            const int SIZE = 8;
            int nextRow = (col == SIZE) ? (row + 1) : row;
            int nextCol = (col == SIZE) ? 0 : (col + 1);

            return new int[] { nextRow, nextCol };
        }

        private static bool checkConstraints(char[,] board, int row, int col, int search)
        {
            const int SIZE = 8;

            // check row         
            for (int index = 0; index <= SIZE; index++)
            {
                var current = board[row, index];
                if (current == search)
                {
                    return false;
                }
            }

            // check column 
            for (int index = 0; index <= SIZE; index++)
            {
                var current = board[index, col];
                if (current == search)
                {
                    return false;
                }
            }

            // check 3*3 small matrix 
            int startX = row / 3 * 3;
            int startY = col / 3 * 3;
            for (int i = startX; i < startX + 3; i++)
            {
                for (int j = startY; j < startY + 3; j++)
                {
                    var current = board[i, j];
                    if (current == search)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
