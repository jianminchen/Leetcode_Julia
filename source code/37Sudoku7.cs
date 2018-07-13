using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku7
{
    class Sudoku7
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

        /* source code from blog: 
         * http://www.jiuzhang.com/solutions/sudoku-solver  
         * convert Java code to C# code 
         */
        public static void solveSudoku(char[][] board)
        {
            solve(board);
        }

        /* source code from blog: 
         * http://www.jiuzhang.com/solutions/sudoku-solver  
         * convert Java code to C# code 
         * Julia's comment: 
         * 
         */
        public static bool solve(char[][] board)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
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
                            return true;
                        }

                        board[i][j] = '.';  // julia's comment: back tracking 
                    }

                    return false;  // julia's comment: easy to make a bug here, miss return false!
                }
            }
            return true;
        }

        /* source code from blog: 
         * http://www.jiuzhang.com/solutions/sudoku-solver  
         * convert Java code to C# code 
         */
        public static bool isValid(char[][] board, int a, int b)
        {
            HashSet<char> contained = new HashSet<char>();

            for (int j = 0; j < 9; j++)
            {
                if (contained.Contains(board[a][j])) 
                    return false;

                if (board[a][j] > '0' && board[a][j] <= '9')
                    contained.Add(board[a][j]);
            }

            contained = new HashSet<char>();  // julia's comment: instead of clear the set, create a new one
            for (int j = 0; j < 9; j++)
            {
                if (contained.Contains(board[j][b]))
                {
                    return false;
                }
                if (board[j][b] > '0' && board[j][b] <= '9')
                {
                    contained.Add(board[j][b]);
                }
            }

            contained = new HashSet<char>();
            for (int m = 0; m < 3; m++)
            {
                for (int n = 0; n < 3; n++)
                {
                    int x = a / 3 * 3 + m, y = b / 3 * 3 + n;
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
