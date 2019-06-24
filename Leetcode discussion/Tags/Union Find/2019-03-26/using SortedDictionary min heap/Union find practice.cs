using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unionFindPractice
{
    /// <summary>
    /// 2019-03-26
    /// I look up my Tsinghua coach sessions, and here is the session for union join:
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var existingRoads = new List<int[]>();

            existingRoads.Add(new int[] { 1, 4 });
            existingRoads.Add(new int[] { 2, 3 });
            existingRoads.Add(new int[] { 4, 5 });

            var newRoads = new List<int[]>();
            newRoads.Add(new int[] { 1, 2, 5 });
            newRoads.Add(new int[] { 1, 3, 10 });
            newRoads.Add(new int[] { 5, 6, 5 });
            newRoads.Add(new int[] { 1, 6, 2 });

            var result = getMinimumCost(6, existingRoads, 4, newRoads);
            Debug.Assert(result == 7);
        }

        /// <summary>
        /// assume that maximum number of cities is 50
        /// Map new road as integer quickly. 
        /// using SortedDictionary 
        /// https://github.com/jianminchen/Leetcode_Julia/blob/master/source%20code/23%20Merge%20K%20sorted%20lists%20-%20using%20minimum%20heap.cs
        /// </summary>
        /// <param name="noCities"></param>
        /// <param name="existingRoads"></param>
        /// <param name="newRoads"></param>
        /// <param name="roadWithCost"></param>
        /// <returns></returns>
        public static int getMinimumCost(
            int noCities,
            List<int[]> existingRoads,
            int newRoads,
            List<int[]> roadWithCost)
        {
            var quickUnion = new QuickUnion(noCities);
            foreach (var item in existingRoads)
            {
                // adjust the value of id from 0 to N - 1
                quickUnion.Union(item[0] - 1, item[1] - 1);
            }

            int count = quickUnion.GetCount();
           
            var newRoadMap = new SortedDictionary<int, Queue<int[]>>();
            foreach (int[] item in roadWithCost)
            {
                var id1 = item[0] - 1;
                var id2 = item[1] - 1;
                var roadCost = item[2];
                
                if (!newRoadMap.ContainsKey(roadCost))
                {
                    newRoadMap.Add(roadCost, new Queue<int[]>());
                }

                newRoadMap[roadCost].Enqueue(new int[]{id1, id2});
            }

            var totalCost = 0; 
            while (newRoadMap.Count > 0)
            {
                int minCost = newRoadMap.First().Key;
                var ids = newRoadMap[minCost].Dequeue();

                if (newRoadMap[minCost].Count == 0)
                {
                    newRoadMap.Remove(minCost);
                }

                var id1 = ids[0];
                var id2 = ids[1];

                var connected = quickUnion.Connected(id1, id2);
                if (connected)
                {
                    continue;
                }

                totalCost += minCost;
                quickUnion.Union(id1, id2); // Union, not Connected

                if (quickUnion.GetCount() == 1)
                {
                    break;
                }
            }

            if (quickUnion.GetCount() > 1)
            {
                return -1;
            }

            return totalCost;
        }

        /// <summary>
        /// 2019-March 26
        /// Union API is updated. 
        /// 
        /// May 28, 2018
        /// 
        /// Julia likes to write her own union find algorithm
        /// The coach spent almost 100 minutes in the mock interview to show her 
        /// the solution, and also he wrote two functions called 
        /// QuickFind() and Union()
        /// 
        /// source code reference used:
        /// https://gist.github.com/jianminchen/cb889def70be4563581113daa8a8fb2a
        /// </summary>
        internal class QuickUnion
        {
            private int[] parent { get; set; }
            private int count { get; set; }

            public QuickUnion(int number)
            {
                if (number <= 0)
                {
                    return;
                }

                count = number;
                parent = new int[number];

                for (int i = 0; i < number; i++)
                {
                    parent[i] = i;
                }
            }

            public int GetCount()
            {
                return count;
            }

            /// <summary>
            /// Find group id given the node value
            /// </summary>
            /// <returns></returns>
            public int QuickFind(int search)
            {
                if (search < 0)
                {
                    return -1;
                }

                if (search == parent[search])
                {
                    return search;
                }

                return QuickFind(parent[search]);
            }

            /// <summary>
            /// Reset all parent node's to its original ancestor
            /// path compression - all node's parent will be reset to its ancestor
            /// </summary>
            /// <returns></returns>
            public int QuickFindAndPathCompression(int search)
            {
                if (search == parent[search])
                {
                    return search;
                }

                int root = QuickFindAndPathCompression(parent[search]);

                parent[search] = root;

                return root;
            }

            /// <summary>
            /// code review March 26, 2019
            /// </summary>
            /// <param name="p"></param>
            /// <param name="q"></param>
            public void Union(int p, int q)
            {
                //int pRoot = QuickFind(p);
                //int qRoot = QuickFind(q);

                int pRoot = QuickFindAndPathCompression(p);
                int qRoot = QuickFindAndPathCompression(q);

                if (pRoot == qRoot)
                {
                    return;
                }

                // set one tree to another tree's subtree
                parent[pRoot] = qRoot;

                // update count of groups
                count--;
            }

            /// <summary>
            /// code review March 6, 2019
            /// </summary>
            /// <param name="p"></param>
            /// <param name="q"></param>
            /// <returns></returns>
            public bool Connected(int p, int q)
            {
                return QuickFind(p) == QuickFind(q);
            }
        }
    }
}
