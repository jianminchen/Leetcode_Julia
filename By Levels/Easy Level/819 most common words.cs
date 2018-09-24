using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _819_most_common_words
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = MostCommonWord("Bob hit a ball, the hit BALL flew far after it was hit.", new string[] { "hit" }); 
        }

        /// <summary>
        /// the idea is the following:
        /// 1. lower the case of each char in the paragraph
        /// 2. remove punctures
        /// 3. split string using space char
        /// 4. only save words not in banned words in hashmap
        /// 5. get max value in the dictionary
        /// 6. retrieve the key with max value      
        /// punctures: !?',;.
        /// Similar to the discuss post
        /// https://leetcode.com/problems/most-common-word/discuss/123854/C++JavaPython-Easy-Solution-with-Explanation
        /// </summary>
        /// <param name="paragraph"></param>
        /// <param name="banned"></param>
        /// <returns></returns>
        public static string MostCommonWord(string paragraph, string[] banned)
        {            
            if (paragraph == null)
                return string.Empty;

            var hashset = new HashSet<string>();
            foreach (var item in banned)
            {
                hashset.Add(item.ToLower());
            }

            var lowercase = paragraph.ToLower();
            lowercase = stripPunctation(lowercase);

            var split = lowercase.Split(' ');

            var dict = new Dictionary<string, int>(); 

            foreach (var item in split)
            {
                if (hashset.Contains(item))
                    continue; 

                if (!dict.ContainsKey(item))
                {
                    dict.Add(item, 0);
                }

                dict[item]++; 
            }

            var max = dict.Values.Max();
            foreach (var pair in dict)
            {
                if (pair.Value == max)
                    return pair.Key; 
            }

            return string.Empty; 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        private static string stripPunctation(string document)
        {
            var sb = new StringBuilder();

            foreach (var item in document)
            {
                var isSpace = item == ' ';
                int current = item - 'a';
                var isEnglishLetter = current >= 0 && current < 26;
                
                if(isSpace || isEnglishLetter)
                {
                    sb.Append(item);
                }
            }

            return sb.ToString();
        }
    }
}
