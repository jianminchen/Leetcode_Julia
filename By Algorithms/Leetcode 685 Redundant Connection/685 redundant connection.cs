using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _685_redundant_connection___Java_code
{
    class Program
    {
        static void Main(string[] args)
        {
            RunTestcase3();
        }

        public static void RunTestcase1()
        {
            //[[1,2], [1,3], [2,3]]
            var edges = new int[3][];

            edges[0] = new int[] { 1, 2 };
            edges[1] = new int[] { 1, 3 };
            edges[2] = new int[] { 2, 3 };

            var result = findRedundantDirectedConnection(edges);
        }

        // [[1,2], [2,3], [3,4], [4,1], [1,5]]
        public static void RunTestcase2()
        {
            //[[1,2], [1,3], [2,3]]
            var edges = new int[5][];

            edges[0] = new int[] { 1, 2 };
            edges[1] = new int[] { 2, 3 };
            edges[2] = new int[] { 3, 4 };
            edges[3] = new int[] { 4, 1 };
            edges[4] = new int[] { 1, 5 };

            var result = findRedundantDirectedConnection(edges);
        }

        /// <summary>
        /// 
        /// </summary>
        public static void RunTestcase3()
        {
            var edges = new int[4][];

            edges[0] = new int[] { 2, 1 };
            edges[1] = new int[] { 3, 1 };
            edges[2] = new int[] { 4, 2 };
            edges[3] = new int[] { 1, 4 };

            var result = findRedundantDirectedConnection(edges);
        }

        /// <summary>
        /// study code
        /// https://leetcode.com/problems/redundant-connection-ii/discuss/141897/3ms-Union-Find-with-Explanations
        /// Three cases:
        /// 1. two-parent problem such that an error node is with two parents
        /// - remove the second parentEdge of the node with two parents
        /// 2. cyclic problem such taht there is a cycle in the graph
        /// - remove the edge that forms the cycle
        /// 3. two-parent and cyclic problem
        /// </summary>
        /// <param name="edges"></param>
        /// <returns></returns>
        public static int[] findRedundantDirectedConnection(int[][] edges)
        {
            int numNodes = edges.Length;
            int edgeRemoved = -1;
            int edgeMakesCycle = -1;

            var parent = new int[numNodes + 1];

            for (int i = 0; i < numNodes; i++)
            {
                int parentId = edges[i][0];
                int childId  = edges[i][1];

                if (parent[childId] != 0)
                {
                    /* Assume we removed the second edge. */
                    edgeRemoved = i;
                    break;
                }
                else
                    parent[childId] = parentId;
            }

            var unionFind = new UnionFind(numNodes);
            for (int i = 0; i < numNodes; i++)
            {
                if (i == edgeRemoved)
                {
                    continue;
                }

                int u = edges[i][0];
                int v = edges[i][1];

                if (!unionFind.Union(u, v))
                {
                    edgeMakesCycle = i;
                    break;
                }
            }

            /* Handle with the cyclic problem only. */
            if (edgeRemoved == -1)
            {
                return edges[edgeMakesCycle];
            }

            /* Handle with the cyclic problem when we remove the wrong edge. */
            if (edgeMakesCycle != -1)
            {
                int v = edges[edgeRemoved][1];
                int u = parent[v];
                return new int[] { u, v };
            }

            /* CHandle with the cyclic problem when we remove the right edge. */
            return edges[edgeRemoved];    
        }

        /// <summary>
        /// code review March 29, 2019
        /// </summary>
        internal class UnionFind
        {
            private int[] parent;
            private int[] rank;

            public UnionFind(int n)
            {
                parent = new int[n + 1];
                rank = new int[n + 1];
                for (int i = 1; i < n + 1; i++)
                {
                    parent[i] = i;
                    rank[i] = 1;
                }
            }

            private int find(int x)
            {
                if (parent[x] == x)
                    return x;
                return parent[x] = find(parent[x]);
            }

            public bool Union(int x, int y)
            {
                int rootX = find(x);
                int rootY = find(y);

                if (rootX == rootY)
                    return false;
                if (rank[rootX] < rank[rootY])
                {
                    parent[rootX] = rootY;
                    rank[rootY] += rank[rootX];
                }
                else
                {
                    parent[rootY] = rootX;
                    rank[rootX] += rank[rootY];
                }

                return true;
            }
        }
    }
}
