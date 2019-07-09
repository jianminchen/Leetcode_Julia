using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _140_word_break_II___study_code
{
    class Program
    {
        static void Main(string[] args)
        {
            RunTestcase(); 
        }

        public static void RunTestcase()
        {
            var s = "catsanddog";
            var wordDict = new string[]{"cat", "cats", "and", "sand", "dog"};

            var result = WordBreak(s, wordDict.ToList()); 
        }

        /// <summary>
        /// July 5, 2019
        /// study code: 
        /// https://leetcode.com/problems/word-break-ii/discuss/44167/My-concise-JAVA-solution-based-on-memorized-DFS
        /// </summary>
        /// <param name="s"></param>
        /// <param name="wordDict"></param>
        /// <returns></returns>
        public static IList<string> WordBreak(string s, IList<string> wordDict)
        {
            return DFS(s, wordDict, new Dictionary<string, LinkedList<string>>());
        }        
        
        /// <summary>
        /// DFS function returns an array including all substrings derived from s.
        /// I need to get comfortable to use Double Linked List class LinkedList class
        /// Also I need to push myself to put together a memoization plan when I try to apply DFS search. 
        /// Focus on more using string class API like StartsWith, same as Java class. 
        /// LinkedList is a good choice to manage the collection in-between given function argument and final result. 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="wordDict"></param>
        /// <param name="map"></param>
        /// <returns></returns>
        private static IList<string> DFS(string s, IList<string> wordDict, Dictionary<string, LinkedList<String>> map) 
        {
            // Look up cache 
            if (map.ContainsKey(s)) 
            {                
                return map[s].ToList();
            }
        
            var list = new LinkedList<String>();     

            // base case 
            if (s.Length == 0) 
            {
                list.AddLast("");
                return list.ToList();
            }               

            // go over each word in dictionary
            foreach (string word in wordDict) 
            {
                if (s.StartsWith(word)) 
                {
                    var sublist = DFS(s.Substring(word.Length), wordDict, map);

                    foreach (string sub in sublist) 
                    {
                        list.AddLast(word + (string.IsNullOrEmpty(sub) ? "" : " ") + sub);               
                    }
                }
            }       

            // memoization
            map.Add(s, list);

            return list.ToList();
        }
    }
}
