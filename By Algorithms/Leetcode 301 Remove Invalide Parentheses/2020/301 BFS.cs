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
            var list = new List<String>();

            // return if it is valid
            if (IsValidParentheses(s))
            {
                list.Add(s);
                return list;
            }            
           
            //The queue only contains invalid middle steps
            var queue = new Queue<Tuple<string, int, char>>();

            //The 3-Tuple is (string, startIndex, lastRemovedChar)
            // Default one is close parenthese, since first one should be '(' which should not be removed. 
            // 
            queue.Enqueue(new Tuple<string, int, char>(s, 0, ')'));

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                var search  = current.Item1;
                var start   = current.Item2;
                var removed = current.Item3;

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

                    // Fact 1: Do not repeatedly remove from consecutive ones
                    // For example, ))) - only remove first ), skip rest consecutive ones
                    // same as previous one
                    if (index != start && search[index - 1] == visit)
                    {
                        continue;
                    }

                    //Fact 3: do not remove a pair of valid parentheses
                    // "()()"
                    if (removed == '(' && visit == ')')
                    {
                        continue;
                    }

                    // remove visit char from the string
                    var skipCurrent = search.Substring(0, index) + search.Substring(index + 1);

                    //Check the string is valid
                    if (IsValidParentheses(skipCurrent))
                    {
                        list.Add(skipCurrent);
                        continue; // continue to iterate all index positions 
                    }

                    // think about test case: ())(() -> minimum is to remove two parentheses
                    // Strings with one char removed are not working, then BFS goes to second remove
                    // Four strings will be in the queue. 
                    // "))(()", 0, '('
                    // "()(()", 1, ')'
                    // "())()", 3, '('
                    // "())((", 5, ')'
                    if (list.Count == 0)  
                    {
                        queue.Enqueue(new Tuple<string, int, char>(skipCurrent, index, visit));
                    }
                }
            }

            return list;
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
                var isOpen  = visit == '(';
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
