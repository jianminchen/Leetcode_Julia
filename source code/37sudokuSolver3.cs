using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudokuSolver3
{
    class sudokuSolver3
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

            
            solveSudokuRe(board, 0, 0);
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    System.Console.Write(board[i][j] + ", ");
                }
                System.Console.WriteLine();
            }

            /*
             * debug through the code 
             */
            char[][] board2 = new char[9][];

            board2[0] = new char[] { '.', '.', '9', '7', '4', '8', '.', '.', '.' };
            board2[1] = new char[] { '7', '.', '.', '.', '.', '.', '.', '.', '.' };
            board2[2] = new char[] { '.', '2', '.', '1', '.', '9', '.', '.', '.' };
            board2[3] = new char[] { '.', '.', '7', '.', '.', '.', '2', '4', '.' };
            board2[4] = new char[] { '.', '6', '4', '.', '1', '.', '5', '9', '.' };
            board2[5] = new char[] { '.', '9', '8', '.', '.', '.', '3', '.', '.' };
            board2[6] = new char[] { '.', '.', '.', '8', '.', '3', '.', '2', '.' };
            board2[7] = new char[] { '.', '.', '.', '.', '.', '.', '.', '.', '6' };
            board2[8] = new char[] { '.', '.', '.', '2', '7', '5', '9', '.', '.' };

            solveSudoku(board2); 
        }
        
        public static void solveSudoku(char[][] board) {
            KeyValuePair<int, int> kvP = new KeyValuePair<int, int>(0, 0); 

            KeyValuePair<int, int> next =
                 (board[0][0] == '.') ? kvP : getNextMissing(board, 0, 0);

            solveSudokuRe(board, next.Key, next.Value);
        }  

     /*
      * source code from blog:
      * https://github.com/yinlinglin/LeetCode/blob/master/SudokuSolver.h
      * convert C++ code to C# code
      *  
      */
    
      public static  bool solveSudokuRe(char[][]board, int row, int col) {
            if (row == 9) return true;

            KeyValuePair<int, int> next = getNextMissing(board, row, col);

            ArrayList possible = new ArrayList();

            getPossibleValues(board, row, col, possible);

            for (int i = 0; i < possible.Count; ++i)
            {
                object o = possible[i];
                int val = Convert.ToInt16(o);

                board[row][col] = (char)val;

                if (solveSudokuRe(board, (int)next.Key, (int)next.Value))
                    return true;

                // back tracking 
                board[row][col] = '.';
            }           

            return false;
        }

        /**
         * source code from blog:
         * https://github.com/yinlinglin/LeetCode/blob/master/SudokuSolver.h
         * 
         * 
             * convert it from c++ to C#
         * Julia comment: 
         * 1. C++ pair<int, int> <-> KeyValuePair<string, string>
         * checked the webpage:
         * http://stackoverflow.com/questions/166089/what-is-c-sharp-analog-of-c-stdpair
         * 2. C++ make_pair  <-> C#  KeyValuePair class
         * 3. C++ make_pair(row, col) <->  C# new KeyValuePair<int, int>(row, col)
         * http://stackoverflow.com/questions/15495165/how-to-initialize-keyvaluepair-object-the-proper-way
              learn template syntax again. 
         */
        private static KeyValuePair<int, int> getNextMissing(char[][] board, int row, int col)
        {
            while (true)
            {
                // julia's comment: formula is very concise, excellent!
                row = (col == 8) ? row + 1 : row;
                col = (col + 1) % 9;

                if (row == 9 || board[row][col] == '.')                                      
                    return  new KeyValuePair<int, int>(row, col);
            }
        }
  
        /**
         * source code from blog: 
         * https://github.com/yinlinglin/LeetCode/blob/master/SudokuSolver.h
         * convert it from c++ to C#
         * julia comment: 
         * 1. Learn difference from C++ and C#
         * 2. this code is fun to play with - 
         *  C++  bool value[9] = {false}; <-> C# Enumerable.Repeat(false, 9).ToArray()
         * 3. retrieve the possible chars for row, col position 
         * 
         */
        private static void getPossibleValues(char[][] board, int row, int col, ArrayList possible)
        {
            //http://stackoverflow.com/questions/1014005/how-to-populate-instantiate-a-c-sharp-array-with-a-single-value
            bool[] value = Enumerable.Repeat(false, 9).ToArray(); 

            for (int i = 0; i < 9; ++i)
            {
                char charInRows = board[i][col];
                if (charInRows != '.')
                    value[charInRows - '1'] = true;

                char charInCols = board[row][i];
                if (charInCols != '.')
                    value[charInCols - '1'] = true;

                //   julia's comment:
                // spend 5 minutes to work out this formula 
                // (row, col) (5,6)
                // newRow = 5/3*3 + 5/3 = 4 
                // newCol = 6/3 * 3 +6%3 = 6+0 = 6
                // still confused ! 
                // small 3 x 3 matrix, left top corner: (row/3, col/3)
                // relative position to the left top corner: (i/3, i%3) 
                // row shift: i/3
                // column shift: i%3 - make sense
                // so let julia rewrite this formula to make more readable 

                /*  code from blog 
                int newRow = row / 3 * 3 + i / 3;  
                int newCol = col / 3 * 3 + i % 3;  
                  */
                /* julia comment: add some explanation variable */
                
                int leftTop_small3x3_x = row / 3 * 3;
                int leftTop_small3x3_y = col / 3 * 3;
                int rowShift = i / 3;
                int colShift = i % 3;

                int newRow = leftTop_small3x3_x + rowShift;
                int newCol = leftTop_small3x3_y + colShift; 
                
                /* end of change by julia */
                char c = board[newRow][newCol];

                if (c != '.') value[c-'1'] = true;
            }

            for (int i = 0; i < 9; ++i)
                if (!value[i])
                {
                    int val = i + '1';
                    possible.Add(val);
                }
            }
        }
}
