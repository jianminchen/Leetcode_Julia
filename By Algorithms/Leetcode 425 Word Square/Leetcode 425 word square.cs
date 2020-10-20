using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _435_word_square
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<string>() { "abat", "baba", "atan", "atal" };
            var result = WordSquares(list); 
        }

        public class Trie
        {
            public List<int>  Indexes;
            public Trie[]     Children;

            public Trie()
            {
                Children = new Trie[26];
                Indexes = new List<int>(); 
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="words"></param>
            /// <returns></returns>
            public Trie BuildTrie(List<string> words)
            {
                var root = new Trie();
                for (int i = 0; i < words.Count; i++)
                {
                    var start = root;
                    var word = words[i];
                    for(int j = 0; j < word.Count(); j++)
                    {
                        var next = word[j] - 'a';
                        if (start.Children[next] == null)
                        {
                            start.Children[next] = new Trie(); 
                        }

                        start = start.Children[next];
                        start.Indexes.Add(i); 
                    }
                }

                return root;     
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public static List<List<string>> WordSquares(List<string> words)
        {
            var trie = new Trie();
            var root = trie.BuildTrie(words);
            var length = words[0].Length; 
            var output = new string[length];
            var result = new List<List<string>>(); 

            foreach (var word in words)
            {
                output[0] = word;
                runDFS(words, 1, root, output, result);
            }

            return result; 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="words"></param>
        /// <param name="level"></param>
        /// <param name="root"></param>
        /// <param name="output"></param>
        /// <param name="result"></param>
        private static void runDFS(List<string> words, int level, Trie root, string[] output, List<List<string>> result)
        {
            if (level >= words[0].Count())
            {
                result.Add(new List<string>(output));
                return;
            }

            // baba
            // a
            // b
            // a
            var prefix = "";
            for (int i = 0; i < level; i++)
            {   //            level - index
                prefix += output[i][level].ToString(); // find "a" - level 1
            }

            var start = root; 
            for(int i = 0; i < prefix.Length;i++)
            {
                var next = prefix[i] - 'a';
                if (start.Children[next] == null)
                {
                    return; 
                }

                start = start.Children[next];
            }

            foreach (var item in start.Indexes)
            {
                output[level] = words[item];
                runDFS( words, level + 1, root, output, result); 
            }
        }
    }
}
