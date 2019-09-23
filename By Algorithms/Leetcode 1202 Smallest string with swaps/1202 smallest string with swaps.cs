using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unionFind
{
    class Program
    {
        static void Main(string[] args)
        {
            RunTestcase1();
            //RunTestcase2(); 
        }

        public static void RunTestcase1()
        {
            var pairs = new List<IList<int>>(); 

            pairs.Add((new int[]{0, 3}).ToList()); 
            pairs.Add((new int[]{1, 2}).ToList()); 

            var result = SmallestStringWithSwaps("dcab", pairs); 
            Debug.Assert(result.CompareTo("bacd") == 0);
        }

        public static void RunTestcase2()
        {
            var pairs = new List<IList<int>>();

            pairs.Add((new int[] { 0, 3 }).ToList());
            pairs.Add((new int[] { 1, 2 }).ToList());
            pairs.Add((new int[] { 0, 2 }).ToList());

            var result = SmallestStringWithSwaps("dcab", pairs);
            Debug.Assert(result.CompareTo("abcd") == 0);
        }

        /// <summary>
        /// Leetcode 1202 - small string 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="pairs"></param>
        /// <returns></returns>
        public static string SmallestStringWithSwaps(string s, IList<IList<int>> pairs)
        {
            var length = s.Length;
            var parent = new int[length];

            for (int i = 0; i < length; i++)
            {
                parent[i] = i;
            }

            foreach (var pair in pairs)
            {
                var first = pair[0];
                var second = pair[1];

                if (findParent(parent, first) != findParent(parent, second))
                {
                    // union two set; 
                    union(parent, parent[first], parent[second]);
                }
            }

            // allow duplicate char in string 
            var disjointSets = new Dictionary<int, List<char>>();

            for (int i = 0; i < length; i++)
            {
                var key = findParent(parent, i);
                if (!disjointSets.ContainsKey(key))
                {
                    disjointSets.Add(key, new List<char>());
                }

                disjointSets[key].Add(s[i]); 
            }

            // sorting 
            var sortedStrings = new Dictionary<int, Queue<char>>();
            foreach (var pair in disjointSets)
            {
                var list = pair.Value;
                var array = list.ToArray(); 
                Array.Sort(array);
                var queue = new Queue<char>(); 
                foreach(var item in array)
                    queue.Enqueue(item); 

                sortedStrings.Add(pair.Key, queue);
            }

            var sb = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                var key = findParent(parent, i);
                var value = sortedStrings[key].Dequeue();

                sb.Append(value);                
            }

            return sb.ToString(); 
        }

        /// <summary>
        /// path compression
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="node"></param>
        /// <returns></returns>
        private static int findParent(int[] parent, int node)
        {
            return node == parent[node] ? node : parent[node] = findParent(parent, parent[node]);
        }

        private static void union(int[] parent, int first, int second)
        {
            int iterate = first;
            var newParent = findParent(parent, second);

            while (iterate != newParent)
            {
                var tmp = findParent(parent, iterate);
                parent[iterate] = newParent;
                iterate = tmp;
            }
        }
    }
}