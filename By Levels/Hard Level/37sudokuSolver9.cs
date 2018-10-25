using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudokuSolver9
{
    class sudokuSolver9
    {
        /*  julia's comment: C++ 
        int rowValid[9][10];//rowValid[i][j]表示第i行数字j是否已经使用
        int columnValid[9][10];//columnValid[i][j]表示第i列数字j是否已经使用
        int subBoardValid[9][10];//subBoardValid[i][j]表示第i个小格子内数字j是否已经使用
         */
        public static int[][] rowValid = new int[9][];
        public static int[][] columnValid = new int[9][];
        public static int[][] subBoardValid = new int[9][]; 

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
         * http://www.cnblogs.com/TenosDoIt/p/3800485.html
         * convert C++ to C# code
         */
       public static void solveSudoku(char[][] board) {
           createSecondaryArry(); // julia added

            for(int i = 0; i < 9; i++)
                for(int j = 0; j < 9; j++)
                    if(board[i][j] != '.')
                        fill(i, j, board[i][j] - '0');

            solver(board, 0);
        }

       /*
        * source code from blog:
        * http://www.cnblogs.com/TenosDoIt/p/3800485.html
        * convert C++ to C# code
        */
        public static bool solver(char[][] board, int index)
        {
            // 0 <= index <= 80，index表示接下来要填充第index个格子
            if(index > 80)return true;

            int row = index / 9, col = index - 9*row;

            if(board[row][col] != '.')
                return solver(board, index+1);

            for(int val = '1'; val <= '9'; val++)//每个为填充的格子有9种可能的填充数字
            {
                if(isValid(row, col, val-'0'))
                {
                    board[row][col] = (char)val;
                    fill(row, col, val-'0');
                    if(solver(board, index+1))return true;
                    clear(row, col, val-'0');
                }
            }

            board[row][col] = '.';//注意别忘了恢复board状态
            return false;
        }

        /*
         * source code from blog:
         * http://www.cnblogs.com/TenosDoIt/p/3800485.html
         * convert C++ to C# code
         */
        //判断在第row行col列填充数字val后，是否是合法的状态
        public static bool isValid(int row, int col, int val)
        {
            if(rowValid[row][val] == 0 &&
               columnValid[col][val] == 0 &&
               subBoardValid[row/3*3+col/3][val] == 0)
               return true;
            return false;
        }

        /*
         * source code from blog:
         * http://www.cnblogs.com/TenosDoIt/p/3800485.html
         * convert C++ to C# code
         */
        public static void createSecondaryArry()
        {
            for (int i = 0; i < 9; i++)
            {
                rowValid[i] = new int[10];
                columnValid[i] = new int[10];
                subBoardValid[i] = new int[10];
            }
        }

        /*
         * source code from blog:
         * http://www.cnblogs.com/TenosDoIt/p/3800485.html
         * convert C++ to C# code
         */
        //更新填充状态
        public static void fill(int row, int col, int val)
        {
            rowValid[row][val] = 1;
            columnValid[col][val] = 1;
            subBoardValid[row/3*3+col/3][val] = 1;
        }

        /*
         * source code from blog:
         * http://www.cnblogs.com/TenosDoIt/p/3800485.html
         * convert C++ to C# code
         */
        //清除填充状态
        public static void clear(int row, int col, int val)
        {
            rowValid[row][val] = 0;
            columnValid[col][val] = 0;
            subBoardValid[row/3*3+col/3][val] = 0;
        }        
    }
}
