
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _126WordLadderII_P1
{
    /// <summary>
    /// Leetcode 126: Word ladder II
    /// code review on July 9, 2018
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            string beginWord = "hit";
            string endWord = "cog";
            var words = new string[5] { "hot", "dot", "dog", "lot", "log" };
            var wordList = new HashSet<string>(words);

            var result = FindLadders(beginWord, endWord, wordList); 
        }
                
        private static List<List<String>> Ladders   = new List<List<string>>();
        private static List<String>       Words     = new List<string>();        

        public static List<List<String>> FindLadders(
            String beginWord, 
            String endWord, 
            ISet<String> wordList) {

            var ladders = new List<List<string>>();

            if (beginWord.CompareTo(endWord) == 0 ) {
                var words = new List<string>();

                words.Add(beginWord);
                ladders.Add(words);
                return ladders;
            }

            var dict = new HashSet<string>();

            dict = new HashSet<string>(wordList);
            dict.Add(endWord);

            var dictionary  = new Dictionary<String, int>();
            int dist = getLadderLengthAndDictionary(beginWord, endWord, dict, dictionary);

            var keys = new List<string> (dictionary.Keys);
            foreach (string key in keys)
            {
                dictionary[key] = dist - 1 - dictionary[key];
            }

            var visited = new HashSet<string>();

            getLadders(dist - 1, beginWord, endWord, dict, visited, dictionary);

            return Ladders;
       }       

        /// <summary>
        /// 
        /// </summary>
        /// <param name="beginWord"></param>
        /// <param name="endWord"></param>
        /// <param name="wordList"></param>
        /// <param name="ladderDictionary"></param>
        /// <returns></returns>
        private static int getLadderLengthAndDictionary(
            String beginWord, 
            String endWord, 
            ISet<String> wordList,
            Dictionary<String, int> ladderDictionary)
        {
            int length = 0;

            var visited = new HashSet<string>();

            var queue = new Queue<string>();
            var queueDist = new Queue<int>();

            queue.Enqueue(beginWord);

            queueDist.Enqueue(0);

            visited.Add(beginWord);
        
            while (queue.Count > 0) {

                var word = queue.Dequeue();
                int len  = queueDist.Dequeue();

                ladderDictionary[word] = len;

                if (word.CompareTo(endWord) == 0 ) {
                    length = len + 1;
                    break;
                }

                // get all neighbors of w, and add them to the queue, 
                // if they have not been visited.
                for (int i = 0; i < word.Length; ++i) {
                    for (int iterate = 'a'; iterate <= 'z'; ++iterate) {
                        var characters = word.ToCharArray();

                        if (iterate != characters[i]) {
                            characters[i]   = (char) iterate;         // don't forget type conversion.
                            var current = new String(characters);

                            if (wordList.Contains(current) && !visited.Contains(current)) {
                                queue.Enqueue(current);

                                queueDist.Enqueue(len + 1);

                                visited.Add(current);
                            }
                        }
                    }
                }
            }

            return length;
        }
    
        /// <summary>
        /// code review on July 9, 2018
        /// </summary>
        /// <param name="dist"></param>
        /// <param name="word"></param>
        /// <param name="endWord"></param>
        /// <param name="dict"></param>
        /// <param name="visited"></param>
        /// <param name="ladderDictionary"></param>
        private static void getLadders(
            int             dist, 
            String          word, 
            String          endWord, 
            ISet<String>    dict, 
            ISet<String>    visited,
            Dictionary<String, int> ladderDictionary)
        {
    	    visited.Add(word);
    	    Words.Add(word);

    	    if (word.CompareTo(endWord) == 0) {
    		    var list = new List<string>();

    		    list.AddRange(Words);
    		    Ladders.Add(list);
    	    } 
            else if (dist == 0 || ladderDictionary[word] > dist) {
                // do nothing. 
            }
    	    else 
            {
			    var characters = word.ToCharArray();

    		    for (int i = 0; i < word.Length; ++i) {
    			    var current = characters[i];
                    var currentChar = word[i];

    			    for (int iterate = 'a'; iterate <= 'z'; ++iterate) {
                        if (iterate != currentChar)
                        {
    					    characters[i] = (char) iterate;
    					    var currentWord = new String (characters);

    					    if (dict.Contains(currentWord) && !visited.Contains(currentWord)) {
                                getLadders(dist - 1, currentWord, endWord, dict, visited, ladderDictionary);
    					    }
    				    }
    			    }

    			    characters[i] = current; // restore.
    		    }
    	    }

    	    visited.Remove(word);
    	    Words.RemoveAt(Words.Count - 1);
        }
    }
}
 