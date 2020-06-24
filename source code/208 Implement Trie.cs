using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _208_implement_trie
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public class Trie
        {


            private Trie[] Children = new Trie[26];
            private string word;

            /** Initialize your data structure here. */
            public Trie()
            {
                //Children = new Trie[26];

            }

            /** Inserts a word into the trie. */
            public void Insert(string word)
            {
                if (word == null || word.Length == 0)
                    return;

                var root = this;

                foreach (var item in word)
                {
                    if (root.Children[item - 'a'] == null)
                    {
                        root.Children[item - 'a'] = new Trie();
                    }

                    root = root.Children[item - 'a'];
                }

                root.word = word;
            }

            /** Returns if the word is in the trie. */
            public bool Search(string word)
            {
                if (word == null || word.Length == 0)
                    return false;

                var root = this;

                foreach (var item in word)
                {
                    if (root.Children[item - 'a'] == null)
                    {
                        return false;
                    }

                    root = root.Children[item - 'a'];
                }

                return root.word != null;
            }

            /** Returns if there is any word in the trie that starts with the given prefix. */
            public bool StartsWith(string prefix)
            {
                if (prefix == null || prefix.Length == 0)
                    return false;

                var root = this;

                foreach (var item in prefix)
                {
                    if (root.Children[item - 'a'] == null)
                    {
                        return false;
                    }

                    root = root.Children[item - 'a'];
                }

                return true;
            }
        }
    }
}
