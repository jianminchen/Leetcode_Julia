using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_solver_37___August_2015
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public void SolveSudoku(char[,] board)
        {
            // Julia comment on July 20, 2015: 
            // C#, keep forgetting how to get multidimension array length - 
            // next time, look for GetLength function with an argument - dimension 
            // https://social.msdn.microsoft.com/Forums/vstudio/en-US/a7ddde89-35cc-4a29-9aab-ac42b8fd75fe/c-30-two-dimensional-array-length?forum=csharpgeneral
            int n = board.GetLength(0);
            int m = board.GetLength(1);

            char[][] boardJagged = new char[n][];

            for (int i = 0; i < n; i++)
                boardJagged[i] = new char[m];

            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    boardJagged[i][j] = board[i, j];

            solveSudoku_jaggedArray(boardJagged);

            // need to update two dimension array with the sudoku result:
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    board[i, j] = boardJagged[i][j];
        }

        /**
         * Latest update: July 20, 2015 
         * Source code from the following blog:
         * http://blog.csdn.net/fightforyourdream/article/details/16916985
         * convert it from Java to C# code 
         * Julia comment: 
         *  1. algorithm:  DFS, backtracking 
         */
        public void solveSudoku_jaggedArray(char[][] board)
        {
            dfs(board, 0, 0);
        }

        /**
         * Latest update: July 20, 2015 
         * Source code from the following blog:
         * http://blog.csdn.net/fightforyourdream/article/details/16916985
         * convert it from Java to C# code 
         * Julia comment: 
         */
        public bool dfs(char[][] board, int x, int y)
        {
            // base case: 
            if (x > 8 || y > 8)
            {       // 全部深搜完毕  
                return true;
            }

            if (board[x][y] == '.')
            {       // 如果当前是空格  
                for (int k = 1; k <= 9; k++)
                {

                    char tryItOut = (char)('0' + k);

                    if (isValid(board, x, y, tryItOut))
                    { // 说明在当前空格找到一个满足条件的数字  
                        board[x][y] = tryItOut;

                        int nextX = x;
                        int nextY = y + 1;
                        if (nextY == 9)
                        {
                            nextY = 0;
                            nextX++;
                        }
                        if (dfs(board, nextX, nextY))
                        { // 对下一个空格搜索数字，如果下一个位置找到满足条件的数字，就此返回。
                            // 否则改变当前空格的数字继续测试
                            return true;
                        }

                        board[x][y] = '.';
                    }
                }

                return false;           // 对于当前空格，如果所有的数字都不满足，则无解！  
            }
            else
            {                     // 如果当前已经有数字，就跳过继续深搜  
                int nextX = x;
                int nextY = y + 1;
                if (nextY == 9)
                {
                    nextY = 0;
                    nextX++;
                }
                return dfs(board, nextX, nextY);
            }

        }

        public bool isValid(char[][] board, int x, int y, char k)
        {
            for (int i = 0; i < 9; i++)
            {          // 同列检查  
                if (board[i][y] == k)
                {
                    return false;
                }
                if (board[x][i] == k)
                {           // 同行检查  
                    return false;
                }
            }

            for (int i = 0; i < 3; i++)
            {  // 九宫格检查 -julia comment: x/3 value set {0,1,2}, y/3 value set {0,1,2} since x is 0-8
                for (int j = 0; j < 3; j++)
                {
                    if (board[3 * (x / 3) + i][3 * (y / 3) + j] == k)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
