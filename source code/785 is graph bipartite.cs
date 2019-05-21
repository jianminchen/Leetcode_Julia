using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _785_is_graph_bipartite
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// code study
        /// https://leetcode.com/problems/is-graph-bipartite/discuss/176266/Clean-and-easy-unionfind-in-JAVA
        /// </summary>
        /// <param name="graph"></param>
        /// <returns></returns>
        public bool IsBipartite(int[][] graph)
        {
            var length = graph.Length;

            var unionFind = new UnionFind(length);

            // traverse all vertex
            for (int i = 0; i < graph.Length; i++)
            {
                int[] adjs = graph[i];

                // for a given vertex graph[i], if it's connected with its any adj vertex, it's not bipartite
                for (int j = 0; j < adjs.Length; j++)
                {
                    if (unionFind.find(i) == unionFind.find(adjs[j]))
                    {
                        return false;
                    }

                    unionFind.union(adjs[0], adjs[j]);
                }
            }
            return true;
        }

        internal class UnionFind
        {
            int[] parent;

            public UnionFind(int n)
            {
                parent = new int[n];
                for (int i = 0; i < n; i++)
                {
                    parent[i] = i;
                }
            }

            public int find(int i)
            {
                if (parent[i] == i)
                {
                    return parent[i];
                }

                parent[i] = find(parent[i]);

                return parent[i];
            }

            public void union(int i, int j)
            {
                int parentI = find(i);
                int parentJ = find(j);

                if (parentI != parentJ)
                {
                    parent[parentI] = parentJ;
                }
            }
        }
    }
}
