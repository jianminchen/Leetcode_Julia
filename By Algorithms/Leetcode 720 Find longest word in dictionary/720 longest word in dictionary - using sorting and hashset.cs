using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _720_longest_word_in_dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// study code: 
        /// 
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public string LongestWord(string[] words) {
            if(words == null)
                return null;

            Array.Sort(words); 

            // word with prefixes in the dictionary
            var visitedPrefix = new HashSet<string>(); 

            string maximumWord = "";

            foreach(var word in words)
            {
                var length = word.Length;

                // think carefully about this reasoning using w, wo, wor, word
                if(length == 1 || visitedPrefix.Contains(word.Substring(0, length - 1)))
                {
                    // keep lexico order - apple will be checked before apply
                    maximumWord = word.Length > maximumWord.Length? word : maximumWord; 
                    visitedPrefix.Add(word); 
                }
            }

            return maximumWord;
        }
    }
}
