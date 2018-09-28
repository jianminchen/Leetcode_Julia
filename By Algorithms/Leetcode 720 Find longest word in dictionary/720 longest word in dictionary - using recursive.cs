using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _720_longest_word_in_dictionary___using_recursive
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = new string[]{"a","banana","app","appl","ap","apply","apple"};

            var result = LongestWord(words); 
        }

        /// <summary>
        /// use recursive function to search next possible word
        /// http://www.cnblogs.com/grandyang/p/7817011.html
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public static string LongestWord(string[] words) {
            string search = "";
            int maxLength = 0; 
            var unorderedSet = new HashSet<string>(words); 

            foreach(var word in words)
            {
                if(word.Length == 1)
                {
                    runDepthFirstSearch(unorderedSet, word, ref maxLength, ref search); 
                }
            }

            return search; 
        }

        /// <summary>
        /// recursive function
        /// bug: 
        /// fail the test case
        /// "a","banana","app","appl","ap","apply","apple"
        /// The code failed to get result "apple", instead the result is "apply".
        /// Bug fix: 
        /// change int maxLength to 
        /// ref int maxLength
        /// </summary>
        /// <param name="set"></param>
        /// <param name="word"></param>
        /// <param name="maxLength"></param>
        /// <param name="search"></param>
        private static void runDepthFirstSearch(HashSet<string> set, string word, ref int maxLength, ref string search)
        {
            var length = word.Length;
            if(length > maxLength)
            {
                maxLength = word.Length;
                search = word; 
            }
            else if(length == maxLength)
            {
                if(word.CompareTo(search) < 0)
                {
                    search = word; 
                }
            }

            for(char c = 'a'; c <= 'z'; c++)
            {
                var nextWord = word + c.ToString(); 
                if(set.Contains(nextWord))
                {
                    runDepthFirstSearch(set, nextWord, ref maxLength, ref search); 
                }
            }
        }      
    }
}
