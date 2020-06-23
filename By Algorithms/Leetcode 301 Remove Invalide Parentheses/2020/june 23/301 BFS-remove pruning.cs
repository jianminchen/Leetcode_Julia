using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _301_remove_invalid_parentheses___2020
{
    class Program
    {
        static void Main(string[] args)
        {
            //var reuslt  = RemoveInvalidParentheses("()"); // original one valid or not - step 1
            //var result2 = RemoveInvalidParentheses("())"); // need to remove one parentheses - step 2
            var result3 = RemoveInvalidParentheses("())(()");
        }

        /// <summary>
        /// code review on June 22, 2020
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static IList<string> RemoveInvalidParentheses(string s)
        {
            var set = new HashSet<string>(); 

            // return if it is valid
            if (IsValidParentheses(s))
            {
                set.Add(s);
                return set.ToList();
            }

            // How to design a queue - BFS to solve the problem? 
            // think about a string to remove two parentheses, "())(()", 
            // those strings with one char removed should be enqueued for next removal of char
            var queue = new Queue<Tuple<string, int>>();

            //The 2-Tuple is (string, startIndex)                        
            queue.Enqueue(new Tuple<string, int>(s, 0));            

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                var search = current.Item1;
                var start = current.Item2;               

                // Start from last removal position 
                for (int index = start; index < search.Length; ++index)
                {
                    var visit = search[index];

                    //Not parentheses
                    bool isParenthese = visit == '(' || visit == ')';
                    if (!isParenthese)
                    {
                        continue;
                    }                                        

                    // remove visit char from the string
                    var skipCurrent = search.Remove(index, 1);

                    //Check the string is valid
                    if (IsValidParentheses(skipCurrent))
                    {
                        set.Add(skipCurrent);
                        continue; // continue to iterate all index positions 
                    }

                    // think about test case: ())(() -> minimum is to remove two parentheses
                    // Strings with one char removed are not working, then BFS goes to second remove
                    // Four strings will be in the queue. 
                    // "))(()", 0
                    // "()(()", 1
                    // "()(()", 2
                    // "())()", 3
                    // "())()", 4 
                    // "())((", 5     
                    if (set.Count == 0)
                    {
                        queue.Enqueue(new Tuple<string, int>(skipCurrent, index));
                    }
                }
            }

            return set.ToList();
        }

        /// <summary>
        /// test case: 
        /// "()","(())", "()()"  true
        /// ")(","())"  false
        /// Time complexity: O(N)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsValidParentheses(String s)
        {
            int count = 0;
            for (int i = 0; i < s.Length; ++i)
            {
                var visit = s[i];
                var isOpen = visit == '(';
                var isClose = visit == ')';

                if (isOpen)
                {
                    ++count;
                }

                if (isClose)
                {
                    bool noOpenToMatch = count <= 0;

                    if (noOpenToMatch)
                    {
                        return false;
                    }

                    count--;
                }
            }

            return count == 0;
        }
    }
}
