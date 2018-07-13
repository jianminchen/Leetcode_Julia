using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wordLadder
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Latest update: June 19, 2015
             * Test case: 
             * start = "hit"
end = "cog"
dict = ["hot","dot","dog","lot","log"]
As one shortest transformation is "hit" -> "hot" -> "dot" -> "dog" -> "cog",
return its length 5.
             */
            HashSet<string> hs = new HashSet<string>{"hit", "hot", "dot", "dog", "cog"};
            int result = ladderLength("hit", "cog", hs); 
        }

        /**
         * Latest update: June 19, 2015
         * Try to learn how to code in 10 minutes in C# using other people's idea and code
         * 
         * code source: 
         * http://shanjiaxin.blogspot.ca/2014/04/word-ladder-leetcode.html
         * 
         * Bug: Time Limit Exceeded
         */
        public static int ladderLength(String beginWord, String endWord, ISet<String> wordDict)
        {
            if (beginWord == null || endWord == null || wordDict == null || wordDict.Count == 0)
            {
                return 0;
            }

            Queue<String> queue = new Queue<string>();

            queue.Enqueue(beginWord);
            wordDict.Remove(beginWord);

            int length = 1;

            while ( queue.Count > 0 )
            {
                int count = queue.Count;

                // Check each adjacent string
                for (int i = 0; i < count; i++) // julia comment: BFS, each layer visit each node
                {
                    String current = queue.Dequeue();
                    // Check if there's adjacent string
                    for (int j = 0; j < current.Length; j++)
                    {
                        for (char c = 'a'; c <= 'z'; c++)
                        {
                            if (c == current[j])
                            {
                                continue;
                            }

                            String temp = replace(current, j, c);
                            if (temp.CompareTo(endWord) ==0)
                            {
                                return length + 1;
                            }

                            if (wordDict.Contains(temp))
                            {
                                queue.Enqueue(temp);
                                wordDict.Remove(temp);
                            }
                        }
                    }
                }
                length++; // julia comment: BFS, go to next layer
            }
            return 0;
        }

        private static String replace(String s, int index, char c)
        {
            char[] chars = s.ToCharArray();
            chars[index] = c;
            return new String(chars);
        }

        /**
         * http://www.programcreek.com/2012/12/leetcode-word-ladder/
         */
    }
}
