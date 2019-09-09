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
        }

        /// <summary>
        /// Leetcode 126 word ladder II
        /// Sept. 9, 2019
        /// </summary>
        /// <param name="source"></param>
        /// <param name="dest"></param>
        /// <param name="words"></param>
        /// <returns></returns>
        public static IList<IList<string>> FindLadders(
            String source,
            String dest,
            IList<String> words)
        {
            var paths = new List<IList<string>>();

            if (source.CompareTo(dest) == 0)
            {
                var oneWordPath = new List<string>();

                oneWordPath.Add(source);
                paths.Add(oneWordPath);

                return paths;
            }

            var hashSet = new HashSet<string>(words);
            //hashSet.Add(dest);

            var map = new Dictionary<String, int>();

            int dist = runBFS(source, dest, hashSet, map);

            resetDistanceFromEnd(map, dist);
            
            var ladders = new List<IList<string>>();
            var path = new List<string>();
            path.Add(source); 
            runDFS(dist - 1, source, dest, hashSet, map, ladders, path);

            return ladders;
        }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="dictionary"></param>
       /// <param name="dist"></param>
        private static void resetDistanceFromEnd(Dictionary<string, int> dictionary, int dist)
        {
            var keys = dictionary.Keys.ToList(); // make a list to avoid runtime error
            foreach (String key in keys)
            {
                dictionary[key] = dist - 1 - dictionary[key];
            }
        }

        /// <summary>
        /// using BFS to find minimum distance from source to destination word. 
        /// </summary>
        /// <param name="beginWord"></param>
        /// <param name="endWord"></param>
        /// <param name="wordList"></param>
        /// <param name="map"></param>
        /// <returns></returns>
        private static int runBFS(
            String beginWord,
            String endWord,
            ISet<String> wordList,
            Dictionary<String, int> map)
        {
            int length = 0;

            var visited = new HashSet<string>();

            var queue = new Queue<string>();
            var distance = new Queue<int>();

            queue.Enqueue(beginWord);

            distance.Enqueue(0);

            visited.Add(beginWord);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                int currentDistance = distance.Dequeue();

                map[current] = currentDistance;

                if (current.CompareTo(endWord) == 0)
                {
                    length = currentDistance + 1;
                    break;
                }

                // get all neighbors of w, and add them to the queue, if they have not been visited.
                for (int i = 0; i < current.Length; ++i)
                {
                    for (int j = 0; j < 26; j++)
                    {
                        var replacement = (char)('a' + j);

                        var array = current.ToCharArray();

                        if (replacement == array[i])
                            continue;

                        array[i] = replacement;
                        var next = new String(array);

                        if (wordList.Contains(next) && !visited.Contains(next))
                        {
                            queue.Enqueue(next);

                            distance.Enqueue(currentDistance + 1);

                            visited.Add(next);
                        }
                    }
                }
            }

            return length;
        }

        /// <summary>
        /// depth first search 
        /// 
        /// </summary>
        /// <param name="dist"></param>
        /// <param name="source"></param>
        /// <param name="dest"></param>
        /// <param name="dict"></param>
        /// <param name="visited"></param>
        /// <param name="map"></param>
        /// <param name="ladders"></param>
        /// <param name="path"></param>
        private static void runDFS(
            int dist,
            String source,
            String dest,
            ISet<String> dict,           
            Dictionary<String, int> map,
            List<IList<String>> ladders,
            List<String> path)
        {           
            // base case 
            if (source.CompareTo(dest) == 0)
            {
                var copy = new List<string>();

                copy.AddRange(path);
                ladders.Add(copy);
                return; 
            }
            
            if (dist > 0 && map[source] <= dist)
            {                               
                for (int i = 0; i < source.Length; ++i)
                {
                    var array = source.ToCharArray();

                    var replacement = array[i];  
                    var current = source[i];

                    for (int j = 'a'; j <= 'z'; ++j)
                    {
                        if (j == current)
                            continue;

                        array[i] = (char)j;
                        var next = new String(array);

                        if (dict.Contains(next))
                        {                            
                            path.Add(next);
                            dict.Remove(next); 

                            runDFS(dist - 1, next, dest, dict, map, ladders, path);

                            // backtracking 
                            dict.Add(next); 
                            path.RemoveAt(path.Count - 1);
                        }
                    }                   
                }
            }                      
        }
    }
}
