using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver6
{
    class SudokuSolver6
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
         * http://shanjiaxin.blogspot.ca/2014/04/sudoku-solver-leetcode.html
         * convert the java code to C# 
         * 
         */
        public static void solveSudoku(char[][] board)
        {
            if (board == null || board.Length == 0 || board[0].Length == 0)
            {
                return;
            }
            solve(board);
        }

        /*
         * source code from blog:
         * http://shanjiaxin.blogspot.ca/2014/04/sudoku-solver-leetcode.html
         * convert the java code to C# 
         * Julia's comment: 
         * 1. 3 loops, question about line 61: return false - debug the code and then try to figure out? 
         * 
         */
        protected static bool solve(char[][] board)
        {
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board.Length; j++)
                {
                    if (board[i][j] != '.')
                    {
                        continue;
                    }

                    for (int k = 1; k <= 9; k++)
                    {
                        board[i][j] = (char)(k + '0');
                        if (isValid(board, i, j) && solve(board))
                        {
                            return true; // last step return,
                            // it will go back with true until the first one, return final result
                        }

                        // julia's comment: back tracking if there is no solution on this number k
                        board[i][j] = '.';
                    }
                    
                    return false; // tried 1-9, just return false and don't try next, return to previous.

                }
            }

            return true; // all points are filled --> true. the last step
        }

        /*
         * source code from blog:
         * http://shanjiaxin.blogspot.ca/2014/04/sudoku-solver-leetcode.html
         * convert the java code to C# 
         * Julia's comment: 
         * 1. great idea to use HashSet, and then, check if there is any duplicate char in the hash set
         */
        private static bool isValid(char[][] board, int a, int b)
        {
            HashSet<Char> contained = new HashSet<Char>();
            // Check a row
            for (int i = 0; i < 9; i++)
            {
                if (contained.Contains(board[a][i]))
                {
                    return false;
                }
                if (board[a][i] > '0' && board[a][i] <= '9')
                {
                    contained.Add(board[a][i]);
                }
            }


            // Check b column
            contained.Clear();
            for (int i = 0; i < 9; i++)
            {
                if (contained.Contains(board[i][b]))
                {
                    return false;
                }
                if (board[i][b] > '0' && board[i][b] <= '9')
                {
                    contained.Add(board[i][b]);
                }
            }

            // Check sub-box board[a][b] located.
            contained.Clear();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    int x = a / 3 * 3 + i, y = b / 3 * 3 + j;
                    if (contained.Contains(board[x][y]))
                    {
                        return false;
                    }

                    if (board[x][y] > '0' && board[x][y] <= '9')
                    {
                        contained.Add(board[x][y]);
                    }
                }
            }

            return true;
        }
    }
}
