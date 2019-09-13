using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _305_island_count_II
{
    class Program
    {
        static void Main(string[] args)
        {
            int m = 3;
            int n = 3;

            var positions = new int[5][];

            positions[0] = new int[] {0,0};
            positions[1] = new int[] {0,1};
            positions[2] = new int[] {1,2};
            positions[3] = new int[] {2,1};
            positions[4] = new int[] {1,1};

            var count = numIsland2(m, n, positions);
            Debug.Assert(count[0] == 1);
            Debug.Assert(count[1] == 1);
            Debug.Assert(count[2] == 2);
            Debug.Assert(count[3] == 3);
            Debug.Assert(count[4] == 1);
        }

        /// <summary>
        /// Leetcode 305 - island count II
        /// Sept. 13, 2019
        /// m - rows of matrix
        /// n - columns of matrix 
        /// positions - element with value > 0 
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <param name="positions"></param>
        /// <returns></returns>
        public static IList<int> numIsland2(int m, int n, int[][] positions)
        {
            var result = new List<int>();
            int count = 0;
            var roots = new int[m * n]; // 0 to (m * n - 1)

            for (int i = 0; i < roots.Length; i++)
            {
                roots[i] = -1; 
            }

            var directions = new List<IList<int>>();
            directions.Add(new List<int>() { 0, -1 }); // left
            directions.Add(new List<int>() {-1,  0 }); // up
            directions.Add(new List<int>() { 0,  1 }); // right
            directions.Add(new List<int>() { 1,  0 }); // down

            var rows = positions.Count();

            // 
            for (int i = 0; i < rows; i++)
            {
                var row = positions[i][0];
                var col = positions[i][1];

                var id = n * row + col;   
                if (roots[id] == -1)
                {
                    roots[id] = id;
                    count++; 
                }
               
                // check four neighbors if union is needed for two disjioint sets. 
                foreach (var direction in directions)
                {
                    int nextRow = row + direction[0];
                    int nextCol = col + direction[1];
                    int current = n * nextRow + nextCol;

                    if (nextRow < 0  || nextRow >= m ||
                        nextCol < 0  || nextCol >= n ||
                        roots[current] == -1)
                    {
                        continue; 
                    }

                    var root = findRoot(roots, id);
                    var rootNext = findRoot(roots, current); 
                    if(root != rootNext)
                    {
                        roots[root] = roots[rootNext]; // union - set one root's parent to another root
                        count--; 
                    }
                }

                result.Add(count); 
            }

            return result; 
        }

        private static int findRoot(int[] roots, int id)
        {
            // recursively search parent node to root node
            return (id == roots[id]) ? id : findRoot(roots, roots[id]);
        }
    }
}
