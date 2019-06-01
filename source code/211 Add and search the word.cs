using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _211_Add_and_Search_the_word
{
    /// <summary>
    /// May 31, 2019
    /// study code
    /// https://leetcode.com/problems/add-and-search-word-data-structure-design/discuss/59582/simple-c-trie-solution
    /// </summary>
    public class WordDictionary
    {
        public TrieNode Root;

        /** Initialize your data structure here. */
        public WordDictionary()
        {
            this.Root = new TrieNode();
        }

        /** Adds a word into the data structure. */
        public void AddWord(string word)
        {
            var node = this.Root;
            foreach (var c in word)
            {               
                int index = c - 'a';
                if (c == '.')
                {
                    index = 26; // last one is reserved for '.' character
                }

                if (node.Children[index] == null)
                {
                    node.Children[index] = new TrieNode();
                }

                node = node.Children[index];                
            }

            // last one is set as leaf node
            node.IsEnd = true;
        }

        /** Returns if the word is in the data structure. A word could contain the dot character '.' to represent any one letter. */
        public bool Search(string word)
        {
            return Search(word, this.Root);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="word"></param>
        /// <param name="node"></param>
        /// <returns></returns>
        private bool Search(string word, TrieNode node)
        {
            for (var i = 0; i < word.Length; i++)
            {
                var current = word[i];
                var index = current - 'a';
                var isDot = current == '.';

                if (!isDot)
                {
                    if (node.Children[index] == null)
                    {
                        return false;
                    }

                    // go to next iteration
                    node = node.Children[index];
                }
                else // is '.' 
                {
                    // last char in the word
                    if (i == word.Length - 1)
                    {
                        foreach (var child in node.Children)
                        {
                            if (child != null && child.IsEnd)
                            {
                                return true;
                            }
                        }

                        return false;
                    } 
                    
                    var restOfWord = word.Substring(i + 1); // skip current char '.'

                    foreach (var child in node.Children)
                    {
                        if (child == null)
                        {
                            continue;
                        }

                        // recursive call -> depth first search 
                        if (Search(restOfWord, child))
                        {
                            return true;
                        }
                    }

                    return false;
                }
            }

            return node.IsEnd;
        }

        /// <summary>
        /// choose to use Trie data structure
        /// </summary>
        public class TrieNode
        {
            public TrieNode[] Children;
            public bool IsEnd;

            public TrieNode()
            {
                // 0 - 25 for letter characters, 26 for '.'
                this.Children = new TrieNode[27];
            }
        }
    }
}
