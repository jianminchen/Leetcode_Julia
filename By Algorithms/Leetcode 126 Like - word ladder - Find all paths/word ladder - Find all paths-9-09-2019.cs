using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wordLadderInterview
{
    class Program
    {
        static void Main(string[] args)
        {
            var source = "good";
            var dest = "best";

            var words = new string[] {"bood", "beod", "besd","goot","gost","gest","best"};

            var result = FindAllPaths(source, dest, words); 
            // two paths
            // good->bood->beod->besd->best
            // good->goot->gost->gest->best
        }

        /// <summary>
        /// Given a dictionary with a lot of words, two words, find all paths from first word to second word. 
        /// Assuming that each time only one char can be replaced by another char, each word should be in the dictionary. 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="dest"></param>
        /// <param name="words"></param>
        /// <returns></returns>
        public static IList<IList<string>> FindAllPaths(string source, string dest, string[] words)
        {
            if(source == null || dest == null || source.Length != dest.Length || words == null || words.Length == 0)
                return new List<IList<string>>();

            var dict = new HashSet<string>(words);

            var path = new List<string>();
            var paths = new List<IList<string>>();
            path.Add(source);
            runDFS(source, dest, dict, path, paths);

            return paths; 
        }

        /// <summary>
        /// In order to search next replacable char, all options should be considered. 
        /// So all options are 26 * source's length. 
        /// For example, source string is "good", the number of replacement is 26 * 4 = 104, not
        /// 26. The first char in "good" may not be replacable, but there is still a path from source to destination word. 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="dest"></param>
        /// <param name="dict"></param>
        /// <param name="path"></param>
        /// <param name="paths"></param>
        private static void runDFS(string source, string dest, HashSet<string> dict, IList<string> path, IList<IList<string>> paths)
        {            
            // base case 
            if (source.CompareTo(dest) == 0)
            {
                var copyPath = new List<string>(path);
                paths.Add(copyPath);

                return; 
            }

            // brute force all possible paths 
            for (int i = 0; i < source.Length; i++)
            {
                var array = source.ToCharArray();                 

                for (int j = 0; j < 26; j++)
                {
                    var replacement = (char)('a' + j);
                    if (array[i] == replacement)
                        continue;
                    
                    array[i] = replacement;
                    var next = new string(array);  
                    if (dict.Contains(next))
                    {
                        dict.Remove(next);  // avoid deadloop 
                        path.Add(next); 
                        runDFS(next, dest, dict, path, paths); 

                        // backtracking 
                        dict.Add(next);
                        path.RemoveAt(path.Count - 1); 
                    }                    
                }
            }
        }
    }
}
