using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _126_word_ladder_II
{
    class Program
    {
        static void Main(string[] args)
        {
            var source = "good";
            var dest = "best";

            var words = new string[] { "bood", "beod", "besd", "goot", "gost", "gest", "best" };

            var result = FindLadders(source, dest, words);
            // two paths
            // good->bood->beod->besd->best
            // good->goot->gost->gest->best
        }

        /// <summary>
        /// Sept. 9, 2019
        /// study code
        /// https://leetcode.com/problems/word-ladder-ii/discuss/375730/C-BFS-Solution-faster-than-94-and-less-than-100-memory
        /// </summary>
        /// <param name="beginWord"></param>
        /// <param name="endWord"></param>
        /// <param name="wordList"></param>
        /// <returns></returns>
        public static IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList)
        {
            var graph = new Dictionary<string, HashSet<string>>();

            preprocessGraph(beginWord, graph);

            foreach (var word in wordList)
            {
                preprocessGraph(word, graph);
            }

            //Queue For BFS
            var queue = new Queue<string>();

            //Dictionary to store shortest paths to a word
            var shortestPaths = new Dictionary<string, IList<IList<string>>>();

            queue.Enqueue(beginWord);
            // do not confuse () with {} - fix compiler error
            shortestPaths[beginWord] = new List<IList<string>>() { new List<string>() { beginWord } };

            var visited = new HashSet<string>();

            while (queue.Count > 0)
            {
                var visit = queue.Dequeue();

                //we can terminate loop once we reached the endWord as all paths leads here already visited in previous level 
                if (visit.Equals(endWord))
                {
                    return shortestPaths[endWord];
                }

                if (visited.Contains(visit))
                    continue;

                visited.Add(visit);

                //Transform word to intermediate words and find matches
                // case study: var source = "good";  
                // go over all keys related to visit = "good" for example,
                // keys: "*ood","g*od","go*d","goo*"
                for (int i = 0; i < visit.Length; i++)
                {
                    var sb = new StringBuilder(visit);

                    sb[i] = '*';

                    var key = sb.ToString();

                    if (!graph.ContainsKey(key))
                    {
                        continue;
                    }

                    //brute force all adjacent words
                    foreach (var neighbor in graph[key])
                    {
                        if (visited.Contains(neighbor))
                        {
                            continue;
                        }

                        //fetch all paths leads current word to generate paths to adjacent/child node 
                        foreach (var path in shortestPaths[visit])
                        {
                            var newPath = new List<string>(path);

                            newPath.Add(neighbor);

                            if (!shortestPaths.ContainsKey(neighbor))
                            {
                                shortestPaths[neighbor] = new List<IList<string>>() { newPath };
                            }        // reasoning ? 
                            else if (shortestPaths[neighbor][0].Count >= newPath.Count) // // we are interested in shortest paths only
                            {
                                shortestPaths[neighbor].Add(newPath);
                            }
                        }

                        queue.Enqueue(neighbor);
                    }
                }
            }

            return new List<IList<string>>();
        }

        /// <summary>
        /// Time complexity is biggest challenge. It is a good idea to use O(N) time to preprocess a graph for the search. 
        /// How to define the graph? It is kind of creative idea to use wildchar * to replace one char for each word.
        /// 
        /// For example word "hit" can be written as "*it", "h*t", "hi*". 
        /// graph["*it"] = new HashSet<string>{"hit"}
        /// graph["h*t"] = new HashSet<string>{"hit"}
        /// graph["hi*"] = new HashSet<string>{"hit"}
        /// 
        /// git can be written as "*it", "g*t","gi*"
        /// so graph["*it"] = new HashSet<string>{"hit","git"}
        /// ...
        /// 
        /// </summary>
        /// <param name="word"></param>
        /// <param name="graph"></param>
        private static void preprocessGraph(string word, Dictionary<string, HashSet<string>> graph)
        {
            //For example word hit can be written as *it,h*t,hi*. 
            //This method genereates a map from each intermediate word to possible words from our wordlist
            for (int i = 0; i < word.Length; i++)
            {
                var sb = new StringBuilder(word);
                sb[i] = '*';

                var key = sb.ToString();

                if (graph.ContainsKey(key))
                {
                    graph[key].Add(word);
                }
                else
                {
                    var set = new HashSet<string>();
                    set.Add(word);
                    graph[key] = set;
                }
            }
        }
    }
}