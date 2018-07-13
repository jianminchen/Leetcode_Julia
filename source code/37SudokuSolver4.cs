using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver4
{
    class SudokuSolver4
    {
        const int BoardSize = 9;
        const string ALL_CANDI = "123456789";
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
         * https://github.com/xiaoxq/leetcode-cpp/blob/master/src/SudokuSolver.cpp
         * convert it from C++ to C#
         * julia's comment:  
         * 1. the code is more flexible, now BoardSize is defined in constant, 
         *    easy to change, and also the string in the board; excellent idea. 
         * 2. 
         * */
        public static void solveSudoku(char[][] board)
	    {
		    dfs_backtracking_helper( board, 0, 0 );
	    }
 
        /*
         * source code from blog:
         * https://github.com/xiaoxq/leetcode-cpp/blob/master/src/SudokuSolver.cpp
         * convert it from C++ to C#
         * julia's comment:
         * 1. C++ string::const_iterator  <->  C#  
         */
	    public static bool dfs_backtracking_helper(char[][] board, int row, int col)
	    {
            // julia's comment: find next empty slot
		    while( row < BoardSize && board[row][col]!='.' )
		    {
			    if( ++col == BoardSize )
			    {
				    col = 0;
				    ++ row;
			    }
		    }

		    if( row==BoardSize )
			    return true;
		    
            foreach(char c in ALL_CANDI)
		    {
			    if( !checkPlacing( board, row, col, c ) )
				    continue;

			    board[row][col] = c;
			    // try the remain
			    int nextCol = col+1, nextRow = row;
			    if( nextCol==BoardSize )
			    {
				    nextCol = 0;
				    ++nextRow;
			    }
			    
                if( dfs_backtracking_helper(board, nextRow, nextCol) )
				    return true;

                board[row][col] = '.';
		    }
		    
		    return false;
	    }

        /* 
         * check if candidate can be placed at board[row][col]
         * source code from blog:
         * https://github.com/xiaoxq/leetcode-cpp/blob/master/src/SudokuSolver.cpp
         */
        private static bool checkPlacing( char[][] board, int row, int col, char candidate )
	    {
		    // actually, only those in the candi should be checked
		    // check left
		    for( int i=0; i<BoardSize; ++i )
			    if( board[row][i] == candidate )
				    return false;

		    // check upper
		    for( int i=0; i<BoardSize; ++i )
			    if( board[i][col] == candidate )
				    return false;

		    // check 3x3's top area            
		    int topLeftRow = row / 3 * 3;
		    int topLeftCol = col / 3 * 3;

		    for( int i=topLeftRow; i<topLeftRow+3; ++i )
		    {
			    for( int j=topLeftCol; j<topLeftCol+3; ++j )
			    {
				    if( board[i][j] == candidate )
					    return false;
			    }
		    }
		    return true;
	    }
    }
}
