using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _999_available_captures_for_rook
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// Oct. 24, 2019
        /// 999 available captures for rook
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public int NumRookCaptures(char[][] board)
        {
            var rowR = 0;
            var columnR = 0;

            var found = false;
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (board[row][col] == 'R')
                    {
                        rowR = row;
                        columnR = col;
                        found = true;
                        break;
                    }
                }

                if (found)
                {
                    break;
                }
            }

            var directionsRow = new int[] { 0, -1, 0, 1 };
            var directionsCol = new int[] { -1, 0, 1, 0 };

            var count = 0;

            for (int i = 0; i < 4; i++)
            {
                var startRow = rowR;
                var startCol = columnR;
                var incrementRow = directionsRow[i];
                var incrementCol = directionsCol[i];

                while (startRow >= 0 && startRow < 8 &&
                      startCol >= 0 && startCol < 8
                     )
                {
                    var element = board[startRow][startCol];
                    if (element == 'B')
                    {
                        break;
                    }

                    if (element == 'p')
                    {
                        count++;
                        break;
                    }

                    startRow += incrementRow;
                    startCol += incrementCol;
                }
            }

            return count;
        }
    }
}
