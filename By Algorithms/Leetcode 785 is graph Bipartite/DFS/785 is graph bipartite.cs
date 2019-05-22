using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _785_is_graph_bipartite_DFS_2
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// Code review: May 21, 2019
        /// use depth first search to visit all nodes in the graph. 
        /// The graph is provided with adjacent list. 
        /// </summary>
        /// <param name="graph"></param>
        /// <returns></returns>
        public static bool IsBipartite(int[][] graph)
        {
            if (graph == null || graph.Length == 0)
                return false;

            var nodes = graph.Length;
            var colors = new int[nodes]; // 0 - not set, 1 - color one, 2 - second color

            /// graph may not be connected 
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
            // if node is visited already, check it's color compatible or not
            var visited = colors[node] != 0;

            if (visited)
            {   
                return (color && colors[node] == 1) || (!color && colors[node] == 2);
            }
            
            // visit the node, set the color, and then visit neighbors
            colors[node] = color == true ? 1 : 2;            

            foreach (var neighbor in graph[node])
            {
                if (runDFS(neighbor, graph, !color, colors) == false)
                    return false;
            }

            return true;
        }
    }
}
