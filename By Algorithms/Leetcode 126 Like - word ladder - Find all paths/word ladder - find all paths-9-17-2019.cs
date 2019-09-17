using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _126_Word_ladder_II___Sept_16
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new string[]{"bood", "beod", "besd","goot","gost","gest","best"};

            var paths = findAllPaths(dict, "good", "best");
        }

        /// <summary>
        /// Sept. 17, 2019
        /// Study code performed by mock interviwee
        /// https://github.com/jianminchen/100-hard-level-algorithms-2018-summer-campaign/blob/master/leetcode%20126%20like%20-%20word%20ladder%20all%20paths/mock%20interviews/2019-09-16-optimalSolution/word%20ladder%20Find%20all%20paths.java
        /// </summary>
        /// <param name="dict"></param>
        /// <param name="source"></param>
        /// <param name="dest"></param>
        /// <returns></returns>
        public static List<IList<string>> findAllPaths(string[] dict, string source, string dest)
        {
            var set = new HashSet<string>(dict);

            var paths = new List<IList<string>>();
            var path = new List<string>();

            path.Add(source);
            RunDFS(source, dest, path, paths, set, new HashSet<string>());

            return paths;             
        }

        /// <summary>
        /// Make a check list of DFS function:
        /// 1. base case
        /// 2. mark visit
        /// 3. backtracking - dictionary maintenance
        /// 4. space complexity - backtracking 
        /// </summary>
        /// <param name="current"></param>
        /// <param name="dest"></param>
        /// <param name="path"></param>
        /// <param name="paths"></param>
        /// <param name="dict"></param>
        /// <param name="visited"></param>
        private static void RunDFS(string current, string dest, List<string> path, List<IList<string>> paths, HashSet<string> dict, HashSet<string> visited)
        {
            if (visited.Contains(current))
            {
                return;
            }

            if(current.CompareTo(dest) == 0)
            {
                paths.Add(new List<string>(path));
                return; 
            }

            visited.Add(current); 

            foreach(var neighbor in getNeighbors(current, dict))
            {
                path.Add(neighbor); 

                RunDFS(neighbor, dest, path, paths, dict, visited); 

                path.RemoveAt(path.Count - 1); // backtracking - empty the space
            }

            visited.Remove(current);
        }

        /// <summary>
        /// brute force all possible options         
        /// </summary>
        /// <param name="word"></param>
        /// <param name="dict"></param>
        /// <returns></returns>
        private static List<string> getNeighbors(string word, HashSet<string> dict)
        {
            var neighbors = new List<string>();

            var charArray = word.ToCharArray(); // string is immutable, work on char array instead

            for (int i = 0; i < charArray.Length; i++)
            {
                var origin = word[i]; // try all one hop away neighbor, replace the char

                for (int j = 0; j < 26; j++)
                {
                    var option = (char)('a' + j);

                    if (origin == option)
                        continue;

                    charArray[i] = option;
                    var next = new string(charArray);
                    if (dict.Contains(next))
                    {
                        neighbors.Add(next); 
                    }

                    charArray[i] = origin; // restore original char
                }
            }

            return neighbors;
        }
    }
}
