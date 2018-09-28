using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _720_longest_word_in_dictionary___using_queue
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = new string[] {"w","wo","wor","worl","world"};
            var result = LongestWord(words); 
        }

        /// <summary>
        /// use queue to search next possible word
        /// http://www.cnblogs.com/grandyang/p/7817011.html
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public static string LongestWord(string[] words) {                     
            Array.Sort(words);
            
            var queue = new Queue<string>();
            foreach(var word in words)
            {
                if(word.Length == 1)
                {
                    queue.Enqueue(word); 
                }
            }

            var unorderedSet = new HashSet<string>(words);

            string search = "";  // maximum length word with all prefixes in dictionary
            int maxLength = 0;

            while (queue.Count > 0)
            {                
                var current = queue.Dequeue();
                var length = current.Length; 

                if (length > maxLength)
                {
                    maxLength = length;
                    search = current; 
                }
                else if (length == maxLength)
                {
                    if (current.CompareTo(search) < 0)
                    {
                        search = current; 
                    }
                }

                // try to append a char from 'a' to 'z'
                for (char c = 'a'; c <= 'z'; c++)
                {
                    var nextWord = current + c.ToString();
                    if (unorderedSet.Contains(nextWord))
                    {
                        queue.Enqueue(nextWord);
                    }
                }
            }

            return search; 
        }
    }
}
