using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_267_Alien_Dictionary_2018
{
    /// <summary>
    /// Leetcode 267 Alien dictionary
    /// write C# code based on Java code in the following:
    /// https://gist.github.com/jianminchen/70fc354acfa38d918498172e5d4b67c9
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
        }

        public string alienOrder(string[] words)
        {
            var graph = new Dictionary<char, HashSet<char>>();
            var indegree = new Dictionary<char, int>();

            var order = new StringBuilder();

            initialize(words, graph, indegree);

            buildGraphAndGetIndegree(words, graph, indegree);

            topologicalSort(order, graph, indegree);

            // check if there is a loop
            return order.Length == indegree.Count ? order.ToString() : "";
        }

        private void initialize(
            string[] words,
            Dictionary<char, HashSet<char>> graph,
            Dictionary<char, int> indegree)
        {
            foreach (string word in words)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    var current = word[i];

                    if (!graph.ContainsKey(current))
                    {
                        graph.Add(current, new HashSet<char>());
                    }

                    if (!indegree.ContainsKey(current))
                    {
                        indegree.Add(current, 0);
                    }
                }
            }
        }

        private void buildGraphAndGetIndegree(
            string[] words,
            Dictionary<char, HashSet<char>> graph,
            Dictionary<char, int> indegree)
        {
            var edges = new HashSet<String>();

            for (int i = 0; i < words.Length - 1; i++)
            {
                var word1 = words[i];
                var word2 = words[i + 1];

                for (int j = 0; j < word1.Length && j < word2.Length; j++)
                {
                    var from = word1[j];
                    var to = word2[j];

                    if (from == to)
                    {
                        continue;
                    }

                    if (!edges.Contains(from + "" + to))
                    {
                        var set = graph[from];

                        set.Add(to);

                        graph.Add(from, set);

                        var toin = indegree[to];

                        toin++;

                        indegree.Add(to, toin);

                        edges.Add(from + "" + to);

                        break;
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="order"></param>
        /// <param name="graph"></param>
        /// <param name="indegree"></param>
        private void topologicalSort(
            StringBuilder order,
            Dictionary<char, HashSet<char>> graph,
            Dictionary<char, int> indegree)
        {
            var queue = new Queue<char>();

            foreach (var key in indegree.Keys)
            {
                if (indegree[key] == 0)
                {
                    queue.Enqueue(key);
                }
            }

            while (queue.Count > 0)
            {
                var curr = queue.Dequeue();

                order.Append(curr);

                var set = graph[curr];

                if (set != null)
                {
                    foreach (var c in set)
                    {
                        var val = indegree[c];
                        val--;

                        if (val == 0)
                        {
                            queue.Enqueue(c);
                        }

                        indegree.Add(c, val);
                    }
                }
            }
        }
    }
}
