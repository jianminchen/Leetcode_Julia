using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _720_longest_word_in_dictionary___trie
{
    class Program
    {
        /// <summary>
        /// source code is based on
        /// https://leetcode.com/problems/longest-word-in-dictionary/discuss/112720/JAVA-16ms-(99)-@-20180108-Trie+DFS:-clean-easy-explained-and-illustrated
        /// </summary>
        internal class TrieNode
        {
            public string Word { get; set; }

            public TrieNode[] Children = new TrieNode[26];

            /// <summary>
            /// Insert a word into trie
            /// </summary>
            /// <param name="s"></param>
            public void Insert(String s)
            {
                var charArray = s.ToCharArray();
                var iterate = this;

                for (int i = 0; i < charArray.Length; i++)
                {
                    int index = charArray[i] - 'a';

                    if (iterate.Children[index] == null)
                    {
                        iterate.Children[index] = new TrieNode();
                    }

                    // iteratet to next, move forward in the trie
                    iterate = iterate.Children[index];
                }

                iterate.Word = s;
            }
        }

        static void Main(string[] args)
        {           
            var words = new string[] { "w", "wo", "wor", "worl", "world" };
            var longestOne = LongestWord(words);
            Debug.Assert(longestOne.CompareTo("world") == 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public static string LongestWord(string[] words) {
            var root = new TrieNode ();
            root.Word = "-";

            foreach (string word in words)
            {             
                root.Insert (word);
            }

            return findLongestWordThroughTrie (root, "");
        }

        /// <summary>
        /// still confuse about the design of the depth first search algorithm
        /// Hold on it and will figure out later
        /// </summary>
        /// <param name="node"></param>
        /// <param name="accum"></param>
        /// <returns></returns>
        private static string findLongestWordThroughTrie(TrieNode node, string accum) {
            if (node == null || node.Word == null || node.Word.Length == 0)
            {
                return accum;
            }

            // longest one, and also same length lexicographic smallest one
            string optimal = "";

            if (node.Word.CompareTo ("-") != 0)
            {
                accum = node.Word;
            }

            foreach (var child in node.Children) 
            {
                var current = findLongestWordThroughTrie(child, accum);

                // longer                                  same length                      smaller in lexicographic order
                if (current.Length > optimal.Length || (current.Length == optimal.Length && current.CompareTo(optimal) < 0))
                {
                    optimal = current;
                }
            }   

            return optimal;
        }        
    }
}
