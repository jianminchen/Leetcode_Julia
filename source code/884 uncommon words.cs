using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _884_uncommon_words
{
    class Program
    {
        static void Main(string[] args)
        {
            // input: A = "this apple is sweet", B = "this apple is sour"
            // Output: ["sweet","sour"]
            var A = "this apple is sweet";
            var B = "this apple is sour";

            var result = UncommonFromSentences(A, B); 
        }

        /// <summary>
        /// Nov. 14, 2019
        /// 884 uncommon words
        /// 
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static string[] UncommonFromSentences(string A, string B)
        {
            var wordsA = A.Split(' ');
            var wordsB = B.Split(' ');

            var hashSetA = new HashSet<string>(wordsA);
            var hashSetB = new HashSet<string>(wordsB);    

            //  it appears exactly once in one of the sentences
            var onceA = keepExactlyOnce(wordsA);
            var onceB = keepExactlyOnce(wordsB);                    

            foreach (var word in hashSetB)
            {
                if (onceA.Contains(word))
                {
                    onceA.Remove(word);
                }
                else if(onceB.Contains(word) && !hashSetA.Contains(word))
                {
                    onceA.Add(word);
                }
            }

            return onceA.ToArray(); 
        }

        /// <summary>
        /// it appears exactly once in one of the sentences
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        private static HashSet<string> keepExactlyOnce(string[] words)
        {
            var hashSet   = new HashSet<string>(words);
            var duplicate = new HashSet<string>();
            var prefix    = new HashSet<string>();

            for (int i = 0; i < words.Length; i++)
            {
                var current = words[i];

                if (prefix.Contains(words[i]))
                {
                    duplicate.Add(current);
                }
                else
                {
                    prefix.Add(current);
                }
            }

            hashSet.ExceptWith(duplicate);

            return hashSet; 
        }
    }
}
