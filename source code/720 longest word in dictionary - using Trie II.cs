using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace longest_word_in_dictionary_trie_II
{
    /// <summary>
    /// 720 longest word in dictionary - trie
    /// 
    /// source code is based on
    /// https://leetcode.com/problems/longest-word-in-dictionary/discuss/109118/Java-solution-with-Trie
    /// </summary>
    class Program
    {
        /// <summary>
        /// Trie class called Node
        /// </summary>
        class Node
        {                       
            public bool   IsWord   { get; set; }
            public char   Value    { get; set; }
            public Node[] Children { get; set; }

            public Node()
            {
                this.Value = '\u0000';
                this.Children = new Node[26];
                this.IsWord = false;
            }

            public Node(char c)
            {
                this.Value = c;
                this.Children = new Node[26];
                this.IsWord = false;
            }
            
            /// <summary>
            /// Find longest word, and also all prefix of the word should be 
            /// in the dictionary
            /// The length of words will be in the range [1, 1000].
            /// The length of words[i] will be in the range [1, 30].
            /// It is fine to use recursive function since the depth of trie is less than 31. 
            /// </summary>
            /// <param name="sb"></param>
            /// <returns></returns>
            public StringBuilder LookForLongestWordAllPrefixesPrerequisite()
            {
                var max = new StringBuilder();

                for (int i = 0; i < 26; i++)
                {
                    /// each word should start from all prefixes, they all should be in 
                    /// the dictionary
                    if (Children[i] != null && Children[i].IsWord)
                    {
                        var temp = new StringBuilder();

                        var currentNode = Children[i];

                        temp.Append(currentNode.Value);
                        temp.Append(currentNode.LookForLongestWordAllPrefixesPrerequisite());

                        // temp.Length should be the word's length 
                        if (temp.Length > max.Length)
                        {
                            max = temp;
                        }
                    }
                }

                return max;
            }
        }

        static void Main(string[] args)
        {
            var words = new string[] { "w", "wo", "wor", "worl", "world" };
            var longestOne = LongestWord(words);
            Debug.Assert(longestOne.CompareTo("world") == 0);
        }

        public static string LongestWord(string[] words)
        {
            var root = new Node();

            // put into Trie first
            foreach(var word in words){
                var iterate = root;

                for(int i = 0; i < word.Length;i++){
                    var current = word[i];
                    var index = current - 'a';

                    if (iterate.Children[index] == null)
                    {
                        var temp = new Node(current);
                        iterate.Children[index] = temp;
                    }

                    iterate = iterate.Children[index];

                    if (i == word.Length - 1)
                    {
                        iterate.IsWord = true;
                    }
                }
            }                       
            
            var result = root.LookForLongestWordAllPrefixesPrerequisite();
        
            return result.ToString();
        }
    }
}
