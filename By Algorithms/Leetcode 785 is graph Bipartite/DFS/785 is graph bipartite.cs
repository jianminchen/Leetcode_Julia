using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _785_is_graph_bipartite_DFS
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
                bool color = false;
                if (colors[i] == 0 || colors[i] == 1)
                {
                    color = true; 
                }                

                if ( runDFS(i, graph, color, colors) == false)
                {
                    return false; 
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
            // node has color    && (( color should be 1 && color is 2) || (color should be 2 && color is 1)
            if(colors[node] != 0 && ((color && colors[node] == 2) || (!color && colors[node] == 1)))
                return false;

            if(colors[node] != 0 )
                return true; // prevent deadloop 
                
            if(colors[node] == 0)
            {
                colors[node] = color == true? 1 : 2; 
            }
            
            foreach (var neighbor in graph[node])
            {               
                if (runDFS(neighbor, graph, !color, colors) == false)
                    return false;
            }

            return true; 
        }
    }
}
