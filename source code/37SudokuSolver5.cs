using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver5
{
    class SudokuSolver5
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
       * https://github.com/zwxxx/LeetCode/blob/master/Sudoku_Solver.cpp
       * convert it to C#
       * julia's comment: 
        * 1. replace C++ List class using C# LinkedList, not ArrayList; 
        * 2. julia uses LinkedList in C# first time; 
       */
        public static void solveSudoku(char[][] board)
        {
            LinkedList<Int16> blank = new LinkedList<Int16>();

            for (int i = 0, count = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (board[i][j] == '.')
                    {
                        blank.AddLast(Convert.ToInt16(count));
                    }
                    count++;
                }
            }

            recursion_DFS_backtracking(board, blank);
        }

        /*
         * source code from blog:
         * https://github.com/zwxxx/LeetCode/blob/master/Sudoku_Solver.cpp
         * convert it to C#
         * 
         * julia's comment:
         * 1. find C# class similar to C++ list
         * http://stackoverflow.com/questions/6320622/does-c-have-anything-like-liststring-in-c
         *   use LinkedList class (a doubly linked list)
         * 2. Add all blank nodes to a LinkedList, so it is easy to manipulate the list. 
         *    record the number as one integer, value = row * 9 + col 
         */
        protected static bool recursion_DFS_backtracking(char[][] board, LinkedList<Int16> blank) {
		    if (blank.Count ==0) {
			    return true;
		    }

		    int cell = (Int16)blank.First(); 

		    int x = cell / 9, y = cell % 9;

		    bool[] available = new bool[10];

		    for (int i = 1; i <= 9; i++) {
			    available[i] = true;
		    }

		    for (int i = 0; i < 9; i++) {
			    if (board[i][y] != '.') {
				    available[board[i][y] - '0'] = false;
			    }
			    if (board[x][i] != '.') {
				    available[board[x][i] - '0'] = false;
			    }
		    }

		    for (int i = 0, mx = x / 3 * 3, my = y / 3 * 3; i < 3; i++) {
			    for (int j = 0; j < 3; j++) {
				    if (board[mx + i][my + j] != '.') {
					    available[board[mx + i][my + j] - '0'] = false;
				    }
			    }
		    }

		    for (int i = 1; i <= 9; i++) {
			    if (available[i]) {
				    blank.RemoveFirst();

				    board[x][y] = (char)('0' + i);

				    if (recursion_DFS_backtracking(board, blank)) {
					    return true;
				    }

				    blank.AddFirst(Convert.ToInt16(cell));

				    board[x][y] = '.';
			    }
		    }

		    return false;
	    }       
    }
}
