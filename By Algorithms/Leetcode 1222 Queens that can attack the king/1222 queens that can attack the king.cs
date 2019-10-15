using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1222_Queens_that_can_attack_the_king
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public IList<IList<int>> QueensAttacktheKing(int[][] queens, int[] king)
        {
            var hashSet = new HashSet<int>();

            var rows = queens.Length;
            for (int i = 0; i < rows; i++)
            {
                hashSet.Add(queens[i][0] * 10 + queens[i][1]);
            }

            var result = new List<IList<int>>();

            // L, R, Up, down, LT, RT, LD, RD
            var directionsRow = new int[] { 0, 0, -1, 1, -1, -1, 1, 1 };
            var directionsCol = new int[] { -1, 1, 0, 0, -1, 1, -1, 1 };

            for (int i = 0; i < 8; i++)
            {
                var startRow = king[0];
                var startCol = king[1];

                int step = 0;

                int rowIncrement = directionsRow[i];
                int colIncrement = directionsCol[i];

                var nextRow = startRow + rowIncrement;
                var nextCol = startCol + colIncrement;

                while (nextRow < 8 && nextRow >= 0 && nextCol < 8 && nextCol >= 0)
                {
                    var key = nextRow * 10 + nextCol;
                    if (hashSet.Contains(key))
                    {
                        var list = new List<int>();
                        list.Add(nextRow);
                        list.Add(nextCol);

                        result.Add(list);
                        break;
                    }

                    nextRow += rowIncrement;
                    nextCol += colIncrement;
                }
            }

            return result;
        }
    }
}
