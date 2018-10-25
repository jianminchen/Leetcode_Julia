using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solveSudoku_2
{
    class solveSudoku_2
    {
        static void Main(string[] args)
        {
            /**
             * Latest update: July 20, 2015 
             * Test case:  
             *   
             */
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
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    System.Console.Write(board[i][j] + ", ");
                }
                System.Console.WriteLine();
            }
        }

        /**
         * source code from the blog:
         * http://blog.csdn.net/linhuanmars/article/details/20748761
         * convert the code from Java to C#
         * 
         * julia comment: 
         */

        public static void solveSudoku(char[][] board)
        {
            if (board == null || board.Length != 9 || board[0].Length != 9)
                return;
            DFS_BackTracking_helper(board, 0, 0);
        }

        /**
         * source code from the blog: 
         * http://blog.csdn.net/linhuanmars/article/details/20748761
         * comment from the blog:
         * 这道题的方法就是用在N-Queens中介绍的常见套路。简单地说思路就是循环处理子问题，
         * 对于每个格子，带入不同的9个数，然后判合法，如果成立就递归继续，结束后把数字设回空。
         * 大家可以看出代码结构和N-Queens是完全一样的。判合法可以用Valid Sudoku做为subroutine，
         * 但是其实在这里因为每次进入时已经保证之前的board不会冲突，所以不需要判断整个盘，只
         * 需要看当前加入的数字和之前是否冲突就可以，这样可以大大提高运行效率，毕竟判合法在程序
         * 中被多次调用。实现的代码如下：
         * 
         * julia's comment:
         * 1. Learn DFS, backtracking algorithm by writing the code
         * 2. base cases discussion here is more clever: 
         *    code is more clean, easy to read
         * 3. this implementation is much more easy to memorize. 
         */
        private static bool DFS_BackTracking_helper(char[][] board, int row, int col)
        {
            if (col >= 9)  // julia comment: column 9 is the last coloum, and then, go to next row 
                return DFS_BackTracking_helper(board, row + 1, 0);

            if (row == 9)  // julia comment: finish all the rows from 0 - 8 - done! 
            {
                return true;
            }

            if (board[row][col] == '.')
            {
                // julia's comment: DFS searching 
                for (int k = 1; k <= 9; k++)
                {
                    board[row][col] = (char)(k + '0');

                    if (isValid(board, row, col))
                    {
                        // julia's comment: check this edge in DFS graph 
                        if (DFS_BackTracking_helper(board, row, col + 1))
                            return true;
                    }

                    // julia's comment: back tracking 
                    board[row][col] = '.';
                }
            }
            else
            {
                return DFS_BackTracking_helper(board, row, col + 1);
            }
            return false;
        }

        /*
         * comment from the blog: 
         * http://blog.csdn.net/linhuanmars/article/details/20748761
         * 但是其实在这里因为每次进入时已经保证之前的board不会冲突，所以不需要判断整个盘，只
         * 需要看当前加入的数字和之前是否冲突就可以，这样可以大大提高运行效率，毕竟判合法在程序
         * 中被多次调用
         * julia's comment: 
         * no repetition in a row, or a column, or in 9 of 3x3 submatrix
         * instead of checking whole board, only check current node in the input argument (i,j)
         * see if this node is ok to fit in. 
         * 
         */
        private static bool isValid(char[][] board, int i, int j)
        {
            for (int k = 0; k < 9; k++)
            {
                if (k != j && board[i][k] == board[i][j])
                    return false;
            }

            for (int k = 0; k < 9; k++)
            {
                if (k != i && board[k][j] == board[i][j])
                    return false;
            }

            for (int row = i / 3 * 3; row < i / 3 * 3 + 3; row++)
            {
                for (int col = j / 3 * 3; col < j / 3 * 3 + 3; col++)
                {
                    if ((row != i || col != j) && board[row][col] == board[i][j])
                        return false;
                }
            }
            return true;
        }  

    }
}
