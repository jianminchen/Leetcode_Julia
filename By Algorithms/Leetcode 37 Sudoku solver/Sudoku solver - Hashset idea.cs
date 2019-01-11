using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _37_Sudoku_solver
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// code review based on 
        /// http://anothercasualcoder.blogspot.com/2019/01/sudoku-solver-hard-leetcode-problem.html
        /// A lot of good ideas are included in this implementation. 
        /// I can enumerate them one by one. 
        /// 1. Preprocess all rows and columns and quadrants into data structure, O(1) to look up
        /// if the digit is available for next empty slot;
        /// 2. index variable from 0 to 80 is used to track the progress of depth first search, 
        /// help to identify base case;
        /// 3. Step 1 is also very efficient since every element with digit values in the board will 
        /// be added once at the beginning. 
        ///  
        /// </summary>
        /// <param name="board"></param>
        public static void SolveSudoku(char[][] board)
        {
            var rowDigits = new HashSet<int>[9];
            var columnDigits = new HashSet<int>[9];
            var quadrantDigits = new HashSet<int>[9];

            for (int i = 0; i < 9; i++)
            {
                rowDigits[i]      = new HashSet<int>();
                columnDigits[i]   = new HashSet<int>();
                quadrantDigits[i] = new HashSet<int>();
            }

            //Add all current values to the hash set
            int index = 0;
            for (int r = 0; r < 9; r++)
            {
                for (int c = 0; c < 9; c++)
                {
                    if (board[r][c] != '.')
                    {
                        AddNumber(index, (int)(board[r][c] - '0'), rowDigits, columnDigits, quadrantDigits);
                    }

                    index++;
                }
            }

            SolveSudoku(board, 0, rowDigits, columnDigits, quadrantDigits);
        }

        private static bool SolveSudoku(char[][] board,
               int index,
               HashSet<int>[] rowDigits,
               HashSet<int>[] columnDigits,
               HashSet<int>[] quadrantDigits)
        {
            if (index == 81) return true;

            int r = index / 9;
            int c = index % 9;
            if (board[r][c] != '.')
            {
                return SolveSudoku(board, index + 1, rowDigits, columnDigits, quadrantDigits);
            }
            else
            {
                for (int n = 1; n <= 9; n++)
                {
                    if (AddNumber(index, n, rowDigits, columnDigits, quadrantDigits))
                    {
                        board[r][c] = (char)(n + '0');

                        if (SolveSudoku(board, index + 1, rowDigits, columnDigits, quadrantDigits))
                        {
                            return true;
                        }

                        // backtracking 
                        board[r][c] = '.';
                        RemoveNumber(index, n, rowDigits, columnDigits, quadrantDigits);
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// The row and column should not include same digit more than once; quadrant as well.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="number"></param>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        /// <param name="quadrants"></param>
        /// <returns></returns>
        private static bool AddNumber(int index,
              int number,
              HashSet<int>[] rows,
              HashSet<int>[] cols,
              HashSet<int>[] quadrants)
        {
            // one row has 9 columns 
            int r = index / 9;
            int c = index % 9;

            // there are three rows and three columns quadrants.
            // each row will have 27 elements
            // each quadrant will have 9 elements
            // First row quadrant
            // Quadrant1   Quadrant2      Quadrant3
            // 0 - 8       9 - 17          18 - 26
            
            int q = (index / 27) * 3 + (index % 9) / 3;

            if (!rows[r].Contains(number) && 
                !cols[c].Contains(number) && 
                !quadrants[q].Contains(number))
            {
                rows[r].Add(number);
                cols[c].Add(number);

                quadrants[q].Add(number);

                return true;
            }

            return false;
        }

        private static void RemoveNumber(int index,
               int number,
               HashSet<int>[] rows,
               HashSet<int>[] cols,
               HashSet<int>[] quadrants)
        {
            int r = index / 9;
            int c = index % 9;
            int q = (index / 27) * 3 + (index % 9) / 3;

            rows[r].Remove(number);
            cols[c].Remove(number);
            quadrants[q].Remove(number);
        }
    }
}
