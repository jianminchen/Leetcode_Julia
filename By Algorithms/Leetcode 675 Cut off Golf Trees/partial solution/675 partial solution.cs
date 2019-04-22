using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _675_Cut_off_Glof_Trees
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public int CutOffTree(IList<IList<int>> forest)
        {
            if (forest == null)
                return 0;

            var rows = forest.Count;
            if (rows == 0)
                return 0;

            var cols = forest[0].Count;

            var steps = 0;
            startWalkMinimumFirst(forest, rows, cols, 0, 0, ref steps);

            // check if there is no tree left
            var foundTree = false;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < forest[i].Count; j++)
                {
                    if (forest[i][j] > 1)
                    {
                        foundTree = true;
                        break;
                    }
                }
            }

            // return -1 if there is a tree left at least
            return foundTree ? -1 : steps - 1;
        }

        private void startWalkMinimumFirst(IList<IList<int>> forest, int rows, int cols, int row, int col, ref int steps)
        {
            if (isOutOfRange(forest, rows, cols, row, col, ref steps))
                return;

            steps++;
            forest[row][col] = 1;

            var candidates = new List<int[]>();
            var c1 = new int[] { row - 1, col };
            var c2 = new int[] { row + 1, col };
            var c3 = new int[] { row, col - 1 };
            var c4 = new int[] { row, col + 1 };
            candidates.Add(c1);
            candidates.Add(c2);
            candidates.Add(c3);
            candidates.Add(c4);

            var minHeight = int.MaxValue;
            var minIndex = -1;
            for (int i = 0; i < candidates.Count; i++)
            {
                var current = candidates[i];
                var row1 = current[0];
                var col1 = current[1];
                if (!isOutOfRange(forest, rows, cols, current[0], current[1], ref steps) && forest[row1][col1] > 1)
                {
                    var treeHeight = forest[row1][col1];
                    if (treeHeight < minHeight)
                    {
                        minHeight = treeHeight;
                        minIndex = i;
                    }
                }
            }

            if (minIndex == -1)
                return;

            startWalkMinimumFirst(forest, rows, cols, candidates[minIndex][0], candidates[minIndex][1], ref steps);
        }

        private bool isOutOfRange(IList<IList<int>> forest, int rows, int cols, int row, int col, ref int steps)
        {
            return row < 0 || row >= rows || col < 0 || col >= forest[row].Count || forest[row][col] == 0;
        }    
    }
}
