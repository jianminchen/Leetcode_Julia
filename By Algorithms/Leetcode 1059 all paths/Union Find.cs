using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1059_all_paths
{
    class Program
    {
        static void Main(string[] args)
        {
            RunTestcase2();
        }

        public static void RunTestcase1()
        {
            /*
            4
            [[0,1],[0,2],[1,3],[2,3]]
            0
            3  */
            var edges = new int[4][];

            edges[0] = new int[] { 0, 1 };
            edges[1] = new int[] { 0, 2 };
            edges[2] = new int[] { 1, 3 };
            edges[3] = new int[] { 2, 3 };

            var result = LeadsToDestination(4, edges, 0, 3);
        }

        public static void RunTestcase2()
        {
            /*
             5
 [[0,1],[0,2],[0,3],[0,3],[1,2],[1,3],[1,4],[2,3],[2,4],[3,4]]
 0
 4  */
            var edges = new int[10][];

            edges[0] = new int[] { 0, 1 };
            edges[1] = new int[] { 0, 2 };
            edges[2] = new int[] { 0, 3 };
            edges[3] = new int[] { 0, 3 };
            edges[4] = new int[] { 1, 2 };
            edges[5] = new int[] { 1, 3 };
            edges[6] = new int[] { 1, 4 };
            edges[7] = new int[] { 2, 3 };
            edges[8] = new int[] { 2, 4 };
            edges[9] = new int[] { 3, 4 };

            var result = LeadsToDestination(5, edges, 0, 4);
        }

        public static bool LeadsToDestination(int n, int[][] edges, int source, int destination)
        {
            // union find algorithm
            // destination - parent itself
            // all edges on any path should be less than n
            // find all nodes starts from source - put in a hashset -> BFS 

            var parent = new int[n];
            var edgesFromStart = new HashSet<int>[n];

            for (int i = 0; i < n; i++)
            {
                parent[i] = i;
                edgesFromStart[i] = new HashSet<int>();
            }

            var rows = edges.Length;
            for (int row = 0; row < rows; row++)
            {
                var start = edges[row][0];
                var end   = edges[row][1];

                parent[start] = findParent(parent, end);

                edgesFromStart[start].Add(end);
            }

            // go over all edges again
            // path compression
            for (int i = 0; i < n; i++)
            {
                if (parent[i] != i)
                {
                    parent[i] = findParent(parent, i);
                }
            }

            // all edges after start are recorded
            var afterSource = new HashSet<int>();
            //var levelCount = new int[];

            var childrenSet = new HashSet<int>[n];
            for (int i = 0; i < n; i++)
            {
                childrenSet[i] = new HashSet<int>(); 
            }

            var queue = new Queue<int>();
            queue.Enqueue(source);
            afterSource.Add(source);           

            // make sure that no loop - 
            //int index = 0; 
            while (queue.Count > 0)
            {
                var levelCount = queue.Count;
                for (int i = 0; i < levelCount; i++)
                {
                    var start = queue.Dequeue();
                    foreach (var item in edgesFromStart[start])
                    {    // self-loop         loop 
                        if (item == start || (childrenSet[start].Contains(item)))
                        {
                            return false;
                        }

                        queue.Enqueue(item);
                        afterSource.Add(item);
                        childrenSet[item].Add(start);
                    }
                }

                //index++; 
            }

            // make sure that only one parent for those nodes afterSource
            for (int i = 0; i < n; i++)
            {
                if (afterSource.Contains(i))
                {
                    if (parent[i] != destination)
                    {
                        return false;
                    }
                }
            }

            // make sure that all those nodes does not have loop

            return true;
        }

        private static int findParent(int[] parent, int start)
        {
            int index = start;
            if (parent[index] != index)
            {
                //index = parent[index];
                parent[index] = findParent(parent, parent[index]);
            }

            return parent[index];
        }
    }
}
