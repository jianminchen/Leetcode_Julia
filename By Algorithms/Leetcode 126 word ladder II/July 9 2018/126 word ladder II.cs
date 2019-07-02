using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode126_LadderLength_DFS_II_rehearsal
{
    class Program
    {
        static void Main(string[] args)
        {
            string beginWord = "hit";
            string endWord = "cog";
            string[] arr = new string[5] { "hot", "dot", "dog", "lot", "log" };
            HashSet<string> wordList = new HashSet<string>(arr);

            List<List<string>> result = findLadders(beginWord, endWord, wordList);

        }

        /*
         * May 29, 2016, 8:31pm
         * http://juliachencoding.blogspot.com/2016/05/leetcode-126-word-ladder-ii-warm-up_52.html
         * Use test case to help write the code 
          * hit -> cog 
         * Two transformation paths:
         *               dot -> dog 
         * hit -> hot ->            -> cog 
         *               lot -> log 
         *               
         * dist value is 5 
         * Dictionary<string, int> 
         * key    value      new value 
         * hit     0            4
         * hot     1            3
         * dot     2            2
         * lot     2            2
         * dog     3            1
         * log     3            1
         * cog     4            0
         */
        public static List<List<string>> findLadders(
            string beginWord,
            string endWord,
            HashSet<string> wordList
            )
        {
            if (beginWord == null || beginWord.Length == 0 ||
               endWord == null || endWord.Length == 0 ||
               wordList == null || wordList.Count == 0)
                return null;

            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            HashSet<string> wordListExtended = new HashSet<string>(wordList);
            wordListExtended.Add(endWord);   // May 29, 2016, add endWord into the HashSet, otherwise, dist = 0; 

            int dist = findDistAndPrepareDictionary_BFS_UsingQueue(
                beginWord,
                endWord,
                wordListExtended,
                dictionary
                );

            resetDictionaryFromEnd(dictionary, dist);

            List<List<string>> ladders = new List<List<string>>();
            List<string> ladderHelp = new List<string>();

            HashSet<string> visitedHelper = new HashSet<string>();

            getLadder_DFS_Backtracking(beginWord, endWord, wordListExtended, dictionary, dist, visitedHelper, ladders, ladderHelp);

            return ladders;
        }

        /*
         * Using Queue, BFS to search the minimal conversion  length
         * 
         * * Two transformation paths:
         *               dot -> dog 
         * hit -> hot ->            -> cog 
         *               lot -> log 
         *               
         * dist value is 5 
         * Dictionary<string, int> 
         * key    value      new value 
         * hit     0            4
         * hot     1            3
         * dot     2            2
         * lot     2            2
         * dog     3            1
         * log     3            1
         * cog     4            0
         * 
         * Need to create a variable called visitedHelper HashSet to help tracking, avoid redundant checking. 
         */
        public static int findDistAndPrepareDictionary_BFS_UsingQueue(
                string beginWord,
                string endWord,
                HashSet<string> wordList,
                Dictionary<string, int> dictionary
                )
        {
            int length = 0;
            ISet<string> visitedHelper = new HashSet<string>(); // 

            Queue<Tuple<string, int>> queue = new Queue<Tuple<string, int>>();

            queue.Enqueue(new Tuple<string, int>(beginWord, 0));

            visitedHelper.Add(beginWord);

            while (queue.Count > 0)
            {
                Tuple<string, int> runner = queue.Dequeue();
                string key = runner.Item1;
                int value = runner.Item2;

                dictionary[key] = value;

                bool isEndWord = key.CompareTo(endWord) == 0;

                if (isEndWord)
                {
                    return value + 1;
                }

                // use BFS, search all neighbor nodes from 'a' to 'z'
                for (int i = 0; i < key.Length; i++)
                {
                    for (int nextChar = 'a'; nextChar <= 'z'; nextChar++)
                    {
                        char[] arr = key.ToCharArray();

                        if (nextChar == arr[i])
                            continue;

                        arr[i] = (char)nextChar;

                        string trial = new string(arr);

                        if (wordList.Contains(trial) && !visitedHelper.Contains(trial))
                        {
                            queue.Enqueue(new Tuple<string, int>(trial, value + 1));
                            visitedHelper.Add(trial);
                        }
                    }
                }
            }

            return 0;   // should not return here. 

        }

        /*
         * * Two transformation paths:
         *               dot -> dog 
         * hit -> hot ->            -> cog 
         *               lot -> log 
         *               
         * dist value is 5 
         * Dictionary<string, int> 
         * key    value      new value 
         * hit     0            4
         * hot     1            3
         * dot     2            2
         * lot     2            2
         * dog     3            1
         * log     3            1
         * cog     4            0 
         * 
         */
        private static void resetDictionaryFromEnd(Dictionary<string, int> dictionary, int dist)
        {
            List<string> keyArr = new List<string>(dictionary.Keys);

            foreach (string s in keyArr)
            {
                dictionary[s] = dist - 1 - dictionary[s];
            }
        }

        /*
         * * Two transformation paths:
         *               dot -> dog 
         * hit -> hot ->            -> cog 
         *               lot -> log 
         *               
         * dist value is 5 
         * Dictionary<string, int> 
         * key    value      new value 
         * hit     0            4
         * hot     1            3
         * dot     2            2
         * lot     2            2
         * dog     3            1
         * log     3            1
         * cog     4            0 
         * 
         * recursive 
        */
        private static void getLadder_DFS_Backtracking(
            string runner,
            string endWord,
            HashSet<string> wordList,
            Dictionary<string, int> dictionary,
            int dist,
            HashSet<string> visitedHelper,
            List<List<string>> ladders,
            List<string> ladderHelp
            )
        {
            visitedHelper.Add(runner);
            ladderHelp.Add(runner);

            bool isEndWord = runner.CompareTo(endWord) == 0;
            //  bool isBeforeEndWord = dist > 0 && dictionary[runner] <= dist; // dictionary[runner] < dist, cannot choose = 
            bool isBeforeEndWord = dist > 0 && dictionary[runner] < dist;

            if (isEndWord)
            {
                List<string> list = new List<string>();

                list.AddRange(ladderHelp);
                ladders.Add(list);
            }
            else if (isBeforeEndWord)
            {
                char[] arr = runner.ToCharArray();

                // ready to go through DFS backtracking process to find one, make recursive call
                for (int i = 0; i < runner.Length; i++)
                {
                    char backtracking_char = arr[i];
                    char replace = runner[i];

                    for (int j = 'a'; j <= 'z'; j++)
                    {
                        if (j == replace)
                            continue;

                        arr[i] = (char)j;
                        string ij_word = new string(arr);

                        if (wordList.Contains(ij_word) &&
                           !visitedHelper.Contains(ij_word))
                        {
                            getLadder_DFS_Backtracking(
                                ij_word,
                                endWord,
                                wordList,
                                dictionary,
                                dist - 1,
                                visitedHelper,
                                ladders,
                                ladderHelp);
                        }
                    }

                    arr[i] = backtracking_char; // restore, backtracking No. 1
                }
            }

            visitedHelper.Remove(runner);

            ladderHelp.RemoveAt(ladderHelp.Count - 1);
        }
    }
}