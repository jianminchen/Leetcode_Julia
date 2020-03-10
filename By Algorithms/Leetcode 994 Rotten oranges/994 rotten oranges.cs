using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _994_rotten_oranges___III
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// My idea is to save all fresh oranges in a hashset, so it takes O(1) to remove any one of them. 
        /// Next working on original rotten oranges, next minutes how many new rotten ones; 
        /// Continue to work on those new rotten ones to see if fresh one can be rotten. Count minutes until
        /// no fresh ones. 
        /// 0 - empty space
        /// 1 - a fresh orange
        /// 2 - a rotten orange
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int OrangesRotting(int[][] grid)
        {
            var rows = grid.Length;
            var columns = grid[0].Length;

            var freshOranges = new HashSet<int>();
            var rottenOranges = new HashSet<int>();

            var customColumns = rows + columns; 

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    var current = grid[row][col];
                    if (current == 1)
                    {
                        freshOranges.Add(row * customColumns + col);
                    }
                    else if (current == 2)
                    {
                        rottenOranges.Add(row * customColumns + col); 
                    }
                }
            }

            if (freshOranges.Count == 0)
            {
                return 0; 
            }

            int minutes = 0;
            while (freshOranges.Count > 0)
            {
                var foundOne = false;
                var nextMinuteRotten = new HashSet<int>();

                foreach (var item in rottenOranges)
                {
                    var row = item / customColumns;
                    var col = item - row * customColumns;

                    var leftOneFresh  = (col - 1) >= 0      && grid[row][col - 1] == 1;
                    var rightOneFresh = (col + 1) < columns && grid[row][col + 1] == 1;
                    var upOneFresh    = (row - 1) >= 0      && grid[row - 1][col] == 1;
                    var downOneFresh = (row + 1) < rows && grid[row + 1][col] == 1;

                    if (leftOneFresh)
                    {
                        var key = row * customColumns + (col - 1);

                        nextMinuteRotten.Add(key);
                        freshOranges.Remove(key);
                        grid[row][col - 1] = 2; 
                    }

                    if(rightOneFresh)
                    {
                        var key = row * customColumns + (col + 1); 
                        nextMinuteRotten.Add(key); 
                        freshOranges.Remove(key);
                        grid[row][col + 1] = 2; 
                    }

                    if(upOneFresh)
                    {
                        var key = (row - 1) * customColumns + col;
                        nextMinuteRotten.Add(key);  
                        freshOranges.Remove(key);
                        grid[row - 1][col] = 2; 
                    }

                    if(downOneFresh)
                    {
                        var key = (row + 1) * customColumns + col;
                        nextMinuteRotten.Add(key);  
                        freshOranges.Remove(key);
                        grid[row + 1][col] = 2; 
                    }

                    foundOne = foundOne || leftOneFresh || rightOneFresh || upOneFresh || downOneFresh;
                }

                if (!foundOne)
                {
                    return -1; 
                }

                rottenOranges = new HashSet<int>(nextMinuteRotten); 
                minutes++;
            }

            return minutes; 
        }
    }
}
