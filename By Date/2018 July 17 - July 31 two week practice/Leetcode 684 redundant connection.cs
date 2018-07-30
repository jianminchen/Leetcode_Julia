using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_684_redundant_connection
{
    /// <summary>
    /// Leetcode 684 redundant connection 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            runTestcase();
        }

        public static void runTestcase()
        {
            var edges = new int[,]{{3,4},{1,2},{2,4},{3,5},{2,5}};

            var result = FindRedundantConnection(edges);
        }

        public static int[] FindRedundantConnection(int[,] edges)
        {
            if(edges == null || edges.GetLength(0) == 0 || edges.GetLength(1) < 2)
            {
                return new int[0];
            }

            var dict = new Dictionary<int, HashSet<int>>();             

            var redundant = new int[2];

            var rows = edges.GetLength(0);
            for(int row = 0 ; row < rows; row++)
            {
                var v1 = edges[row, 0];
                var v2 = edges[row, 1];

                if(dict.ContainsKey(v1) && dict.ContainsKey(v2))
                {
                    var set1 = new HashSet<int>(dict[v1]);
                    var set2 = new HashSet<int>(dict[v2]);                    

                    if (set1.Contains(v1) && set1.Contains(v2))
                    {                       
                        redundant = new int[] { Math.Min(v1, v2), Math.Max(v1, v2) };
                    }

                    set1.UnionWith(set2);
                    foreach (var item in set1)
                    {
                        dict[item]= set1;                       
                    }
                }
                else
                {
                    if(!dict.ContainsKey(v1) && !dict.ContainsKey(v2))
                    {
                        var set = new HashSet<int>();
                        set.Add(v1);
                        set.Add(v2);
                        dict.Add(v1, set);
                        dict.Add(v2, set);
                    }
                    else if(!dict.ContainsKey(v1))                    
                    {
                        dict[v2].Add(v1);
                        dict.Add(v1, dict[v2]);
                    }
                    else
                    {
                        dict[v1].Add(v2);
                        dict.Add(v2, dict[v1]);
                    }
                }
            }

            return redundant;
        }
    }
}
