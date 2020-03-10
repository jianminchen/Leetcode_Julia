using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _996_rotten_oranges
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public int OrangesRotting(int[][] grid)
        {
            int rows = grid.Length;
            int columns = grid[0].Length;

            var freshOranges = new HashSet<int>();
            var customColumns = rows + columns; 

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    var current = grid[i][j];
                    if (current == 1)
                    {
                        /* - added on March 10, 2020 
                        * what if columns > 10? The code is not extendable. 
                        * three solutions: using 10, or using columns, or using Math.Max(rows, columns)
                        * in your training, consider which one is less error-prone? Last one 
                        * My opinion, last one using Math.Max(rows, columns) is best
                        * second one: columns, if it is confused as rows instead, the bug is not easy to be spotted 
                        * last one: using 10 */
                        var key = i * customColumns + j;
                        freshOranges.Add(key);
                    }
                }
            }

            if (freshOranges.Count == 0)
                return 0;

            int index = 0;
            while (freshOranges.Count > 0)
            {
                // check left, right, up, down four neighbors
                var foundOne = false;
                var newRotten = new HashSet<int>();
                foreach (var item in freshOranges)
                {
                    var row = item / customColumns;
                    var col = item - customColumns * row;

                    if ((col - 1 >= 0 && grid[row][col - 1] == 2) ||   // left
                       (col + 1 < columns && grid[row][col + 1] == 2) ||  // right
                       (row - 1 >= 0 && grid[row - 1][col] == 2) ||  // up
                       (row + 1 < rows && grid[row + 1][col] == 2)     // down
                        )
                    {
                        newRotten.Add(item);

                        foundOne = true;
                    }
                }

                if (foundOne == false)
                {
                    return -1;
                }

                foreach (var item in newRotten)
                {
                    var row = item / customColumns;
                    var col = item - customColumns * row;
                    grid[row][col] = 2;
                    freshOranges.Remove(item);
                }

                index++;
            }

            return index;
        }
    }
}
