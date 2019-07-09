using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _140_word_break_II
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static void RunTestcase1()
        {
            var orginal = "catsanddog";
            var wordDict = new string[] { "cat", "cats", "and", "sand", "dog" };

            var result = WordBreak(original, wordDict.ToList());
        }

        /// <summary>
        /// code review July 4, 2019
        /// apply depth first search 
        /// </summary>
        /// <param name="original"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public IList<string> WordBreak(string original, IList<string> list)
        {
            var res = new List<string>();

            if (original == null || original.Length == 0)
            {
                return res;
            }

            var dict = new HashSet<string>(list);
            var orginalDict = new HashSet<string>(dict);

            if (RunTLETest(original, dict))
            {
                RunDFS(original, orginalDict, 0, "", res);
            }

            return res;
        }

        /// <summary>
        /// depth first search 
        /// </summary>
        /// <param name="original"></param>
        /// <param name="dict"></param>
        /// <param name="start"></param>
        /// <param name="selected"></param>
        /// <param name="finalBreaks"></param>
        private static void RunDFS(string original, HashSet<string> dict, int start, string selected, IList<string> finalBreaks)
        {
            // base case 
            if (start >= original.Length)
            {
                finalBreaks.Add(selected);
                return;
            }

            var word = new StringBuilder();

            // brute force all possible words starting from start to the end
            for (int i = start; i < original.Length; i++)
            {
                word.Append(original[i]);
                var current = word.ToString();

                if (dict.Contains(current))
                {
                    // current selected
                    var wordBreak = selected.Length > 0 ? (selected + " " + current) : current;

                    RunDFS(original, dict, i + 1, wordBreak, finalBreaks);
                }
            }
        }

        /// <summary>
        /// this function is to do checking to prevent TLE bug 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="wordDict"></param>
        /// <returns></returns>
        private static bool RunTLETest(String s, HashSet<String> wordDict)
        {     //Word Break I
            if (s == null || wordDict == null)
            {
                return false;
            }

            var length = s.Length;

            if (length == 0)
            {
                return true;
            }

            for (int i = 1; i <= length; i++)
            {
                var firstWord = s.Substring(0, i);
                var rest = s.Substring(i, length - i);

                if (wordDict.Contains(firstWord))
                {
                    if (RunTLETest(rest, wordDict))
                    {
                        return true;
                    }

                    wordDict.Remove(firstWord);
                }
            }

            return false;
        }
    }
}
