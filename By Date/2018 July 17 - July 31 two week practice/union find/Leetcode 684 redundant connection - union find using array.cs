using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_684_redundant_connection___union_find
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public int[] findRedundantConnection(int[,] edges)
        {
            var parent = new int[2001];

            for (int i = 0; i < parent.Length; i++)
            {
                 parent[i] = i;
            }

            var rows = edges.GetLength(0);
            var redundant = new int[0];

            for (int row = 0; row < rows; row++)
            {
                var v1 = edges[row, 0];
                var v2 = edges[row, 1];

                if (find(parent, v1) == find(parent, v2))
                {
                    redundant = new int[]{Math.Min(v1, v2), Math.Max(v1, v2)};
                }
                else
                {
                    parent[find(parent, v1)] = find(parent, v2);
                }
            }
        
            return redundant;
        }

        /// <summary>
        /// find function - 
        /// root node - it's parent is itself
        /// path compression 
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private int find(int[] parent, int index)
        {
            if (index != parent[index])
            {
                parent[index] = find(parent, parent[index]);
            }

            return parent[index];
        }
    }
}
