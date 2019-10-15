using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spellCheckerProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var wordList = new string[] { "KiTe", "kite", "hare", "Hare" };
            var queries = new string[] { "kite", "Kite", "KiTe", "Hare", "HARE", "Hear", "hear", "keti", "keet", "keto" };

            var result = Spellchecker(wordList, queries);
        }

        /// <summary>
        /// spellchecker 
        /// Oct. 11, 2019
        /// Timeout bug - need to continue to work on
        /// </summary>
        /// <param name="wordlist"></param>
        /// <param name="queries"></param>
        /// <returns></returns>
        public static string[] Spellchecker(string[] wordlist, string[] queries)
        {
            var lengthWord = wordlist.Length;
            var lengthQuery = queries.Length;

            var hashset = new HashSet<string>(wordlist);

            var lowerHashset = new HashSet<string>();
            var map = new Dictionary<string, List<string>>();
            foreach (var item in wordlist)
            {
                var key = item.ToLower();
                lowerHashset.Add(key);

                if (!map.ContainsKey(key))
                {
                    map.Add(key, new List<string>());
                }

                map[key].Add(item);
            }

            var vowelSet = new HashSet<string>();
            var vowels = new HashSet<char>("aeiou".ToCharArray());
            var vowelMap = new Dictionary<string, string>();

            foreach (var item in wordlist)
            {
                var replaced = vowelReplaced(item);
                vowelSet.Add(replaced);
                if (!vowelMap.ContainsKey(replaced))
                {
                    vowelMap.Add(replaced, item);
                }
            }

            var matchingWords = new string[lengthQuery];

            for (int i = 0; i < lengthQuery; i++)
            {
                var current = queries[i];
                var currentLower = current.ToLower();

                if (hashset.Contains(current))
                {
                    matchingWords[i] = current;
                    continue;
                }

                // Capitalization
                var capitalization = false;
                if (lowerHashset.Contains(currentLower))
                {
                    matchingWords[i] = map[currentLower][0];
                    capitalization = true;
                }

                if (capitalization)
                {
                    continue;
                }

                // Vowel errors
                var vowelErrors = false;
                var replacedKey = vowelReplaced(currentLower);
                if (vowelSet.Contains(replacedKey))
                {
                    matchingWords[i] = vowelMap[replacedKey];
                    vowelErrors = true;
                }

                // edge case - no matching
                if (!vowelErrors)
                {
                    matchingWords[i] = "";
                }
            }

            return matchingWords;
        }

        /// <summary>
        /// convert to lower case, and then replace vowel char
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private static string vowelReplaced(string item)
        {
            var vowels = new HashSet<char>("aeiou".ToCharArray());
            var array = item.ToLower().ToCharArray();
            for (int i = 0; i < array.Length; i++)
            {
                var vowelCheck = array[i];
                if (vowels.Contains(vowelCheck))
                {
                    array[i] = '*';
                }
            }

            return new string(array);
        }

        private static bool isMatchingVowelError(string matching, string source)
        {
            if (matching.Length != source.Length)
                return false;

            var vowels = new HashSet<char>("aeiou".ToCharArray());
            for (int i = 0; i < matching.Length; i++)
            {
                var current = matching[i];
                var sourceChar = source[i];

                if (vowels.Contains(current) != vowels.Contains(sourceChar))
                {
                    return false;
                }

                if (!vowels.Contains(current) && current != sourceChar)
                {
                    return false;
                }
            }

            return true;
        }
    }
}