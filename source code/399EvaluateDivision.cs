using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _399_evaluate_division
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// code written on 5/24/2019
        /// study code
        /// https://leetcode.com/problems/evaluate-division/discuss/88231/C-recursive-undirected-graph-DFS-with-backtracking-use-map-of-maps
        /// </summary>
        /// <param name="equations"></param>
        /// <param name="values"></param>
        /// <param name="queries"></param>
        /// <returns></returns>
        public static double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
        {
            // build undirected graph lookup 
            var nodes = new Dictionary<string, Dictionary<string, double>>();

            for (int i = 0; i < equations.Count; i++)
            {
                var start = equations[i][0];
                var end   = equations[i][1];

                if (!nodes.ContainsKey(start))
                {
                    nodes[start] = new Dictionary<string, double>();
                }

                if (!nodes.ContainsKey(end))
                {
                    nodes[end] = new Dictionary<string, double>(); 
                }

                var value = values[i];

                nodes[start][end] = value;
                nodes[end][start] = 1.0 / value; 
            }

            var count = queries.Count; 
            var result = new double[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = runDFS(queries[i][0], queries[i][1], nodes);
            }

            return result; 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="allNodes"></param>
        /// <returns></returns>
        private static double runDFS(string start, string end, Dictionary<string, Dictionary<string, double>> allNodes)
        {
            if (!allNodes.ContainsKey(start) || !allNodes.ContainsKey(end))
            {
                return -1; 
            }

            if (start == end)
            {
                return 1.0;
            }

            double result = -1; 
            var items = allNodes[start];

            // remove to prevent to use this node again
            allNodes.Remove(start); 

            // DFS - search all children
            foreach (var child in items.Keys)
            {
                result = runDFS(child, end, allNodes);

                if (result != -1)
                {
                    result *= items[child];
                    break;
                }
            }

            // backtracking - add back in
            allNodes[start] = items;

            return result; 
        }
    }
}
