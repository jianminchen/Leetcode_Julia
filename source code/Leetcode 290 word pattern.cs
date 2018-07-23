using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_290_Word_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// Leetcode 290 word pattern
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public bool WordPattern(string pattern, string str)
        {
            if (pattern == null || str == null)
                return false;

            var pLength = pattern.Length;
            var words = str.Split(' ');
            var wLength = words.Length;

            if(pLength != wLength)
                return false;

            var dict = new Dictionary<char, string>();
            var existingWords = new HashSet<string>(); 

            for(int i = 0; i < pLength; i++)
            {
                var current     = pattern[i];
                var currentWord = words[i];

                if(dict.ContainsKey(current))
                {
                    var value = dict[current];
                    if (value.CompareTo(currentWord) != 0)
                        return false;
                }
                else
                {
                    if (existingWords.Contains(currentWord))
                        return false; 

                    dict.Add(current, currentWord);
                    existingWords.Add(currentWord); 
                }
            }

            return true; 
        }
    }
}
