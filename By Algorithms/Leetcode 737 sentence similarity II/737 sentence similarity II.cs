using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _737_sentence_similarity_II
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * words1 = ["great", "acting", "skills"]
             * words2 = ["fine", "drama", "talent"] are similar, 
             * if the similar word pairs are pairs = [["great", "good"], ["fine", "good"], 
             * ["acting","drama"], ["skills","talent"]]
             * */
            var words1 = new string[] { "great", "acting", "skills" };
            var words2 = new string[] { "fine", "drama", "talent" };
            var pairs = new List<IList<string>>(); 
            var pair1 = new string[]{"great", "good"};
            var pair2 = new string[]{"fine", "good"};
            var pair3 = new string[]{"acting","drama"};
            var pair4 = new string[]{"skills","talent"};

            pairs.Add(new List<string>(pair1));
            pairs.Add(new List<string>(pair2));
            pairs.Add(new List<string>(pair3));
            pairs.Add(new List<string>(pair4));

            var result = AreSentencesSimilarTwo(words1, words2, pairs); 
        }

        /// <summary>
        /// Nov. 19, 2020
        /// study code
        /// https://leetcode.com/problems/sentence-similarity-ii/solution/
        /// Time Complexity: O(NP), where N is the maximum length of words1 and words2, 
        /// and P is the length of pairs. Each of N searches could search the entire graph.
        /// </summary>
        /// <param name="words1"></param>
        /// <param name="words2"></param>
        /// <param name="pairs"></param>
        /// <returns></returns>
        public static bool AreSentencesSimilarTwo(string[] words1, string[] words2, IList<IList<string>> pairs) {             
            var length1 = words1.Length;
            var length2 = words2.Length;

            if (length1 != length2)
            {
                return false;
            }

            var graph = new Dictionary<string, List<string>>();

            foreach (var pair in pairs) 
            {
                var first = pair[0];
                var second = pair[1];

                foreach (var p in pair)
                {
                    if (!graph.ContainsKey(p)) 
                    {
                        graph.Add(p, new List<string>());
                    }
                }

                graph[first].Add(second);
                graph[second].Add(first);
            }

            for (int i = 0; i < length1; ++i) 
            {
                var w1 = words1[i];
                var w2 = words2[i];

                // think carefully how to use stack to apply DFS
                // need some time to figure out ...
                // instead of using recursive function, using a stack
                var stack = new Stack<string>();
                var seen  = new HashSet<string>();

                stack.Push(w1);
                seen.Add(w1);
                var found = false;
                
                while (stack.Count > 0) 
                {
                    var word = stack.Pop();

                    if (word.CompareTo(w2) == 0)
                    {
                        found = true; 
                        break;  // while loop
                    }

                    if (graph.ContainsKey(word)) 
                    {
                        foreach (var neighbor in graph[word]) 
                        {
                            if (!seen.Contains(neighbor)) 
                            {
                                stack.Push(neighbor);
                                seen.Add(neighbor);
                            }
                        }
                    }
                }

                if (!found)
                {
                    return false; 
                }
            }

            return true;        
        }
    }
}
