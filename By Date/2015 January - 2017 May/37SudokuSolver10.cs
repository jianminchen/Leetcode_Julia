using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver10
{
    class SudokuSolver10
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
         * convert it from Java to C# code 
         * 
         https://github.com/rffffffff007/leetcode/blob/master/Sudoku%20Solver.java
         
          
         * 
         * Java final keyword <->  C# readonly 
         * For a final class or method, the C# equivalent is sealed.
           For a final field, the C# equivalent is readonly.
           For a final local variable or method parameter, there's no direct C# equivalent.
         * http://stackoverflow.com/questions/1327544/what-is-the-equivalent-of-javas-final-in-c
         */
        static readonly int N = 9;

        public static void solveSudoku(char[][] board) {
            solveSudoku(board, 0);
        }

         /* 
         * source code from blog: 
         * convert it from Java to C# code 
         */
        private static bool solveSudoku(char[][] board, int n) {
            if (n == N * N) 
                return true;

            int x = n / N;
            int y = n % N;

            if (board[x][y] != '.') 
                return solveSudoku(board, n + 1);

            int xi, yi;
            int[] choices = new int[N];

            for (int i = 0; i < N; i++) {
                if (board[x][i] != '.') 
                    choices[board[x][i] - '1'] = 1;

                if (board[i][y] != '.') 
                    choices[board[i][y] - '1'] = 1;

                xi = x / 3 * 3 + i / 3;
                yi = y / 3 * 3 + i % 3;

                if (board[xi][yi] != '.') 
                    choices[board[xi][yi] - '1'] = 1;
            }

            for (int i = 0; i < N; i++) 
                if (choices[i] == 0) {
                    board[x][y] = (char) ('1' + i);

                    if (solveSudoku(board, n + 1)) 
                        return true;

                    board[x][y] = '.';
                }

            return false;
        }
    }
}
