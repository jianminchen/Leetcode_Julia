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
        /// warm up practice on 2019-July-16
        /// The idea is to traverse the whole graph, which may be connected in multipled disjoint set. 
        /// Make sure that all nodes in the graph will be traversed and node will be assigned the color. 
        /// 
        /// </summary>
        /// <param name="graph"></param>
        /// <returns></returns>
        public bool IsBipartite(int[][] graph)
        {
            if (graph == null || graph.Length == 0)
                return false;

            var nodes = graph.Length;
            var colors = new int[nodes]; // 0 - not set, 1 - color one, 2 - second color

            // graph may more than one disjoint set, search all possible sets please!
            for (int i = 0; i < nodes; i++)
            {
                // node is unvisited node
                if (colors[i] == 0)
                {
                    // choose color 1 for node i - true/ 1, false/ 2
                    if (runDFS(i, graph, true, colors) == false)
                    {
                        return false;
                    }
                }
            }

            return true; 
        }

        /// <summary>
        /// color - true - 1, false - 2
        /// </summary>
        /// <param name="node"></param>
        /// <param name="graph"></param>
        /// <param name="color"></param>
        /// <param name="colors"></param>
        /// <returns></returns>
        private static bool runDFS(int node, int[][] graph, bool color, int[] colors)
        {
            // if node is visited already, check it's color compatiable or not
            var visited = colors[node] != 0;

            if (visited)
            {
                return (color && colors[node] == 1) || (!color && colors[node] == 2);  // should be 2, not 0
            }

            // visit the node, set the color, and then visit neighbors
            colors[node] = color == true ? 1 : 2;

            foreach(var neighbor in graph[node])
            {
                // alternate the color for neighbor node - !color
                if (runDFS(neighbor, graph, !color, colors) == false)
                    return false;
            }

            return true; 
        }
    }
}
