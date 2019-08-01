using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace removeInvalidParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = RemoveInvalidParenthesis("()())()");
        }

        /// <summary>
        /// code review August 1, 2019
        /// https://www.geeksforgeeks.org/remove-invalid-parentheses/
        /// problem statement:
        /// An expression will be given which can contain open and close parentheses and 
        /// optionally some characters, No other operator will be there in string. We need 
        /// to remove minimum number of parentheses to make the input string valid. If more 
        /// than one valid output are possible removing same number of parentheses then print 
        /// all such output.
        ///Examples:
        ///Input  : str = “()())()” -
        ///Output : ()()() (())()
        ///There are two possible solutions
        ///"()()()" and "(())()"
        ///Input  : str = (v)())()
        ///Output : (v)()()  (v())()
        /// </summary>
        /// <param name="str"></param>
        public static IList<string> RemoveInvalidParenthesis(string str)
        {
            if (string.IsNullOrEmpty(str))
                return new List<string>();

            var removed = new List<string>(); 

            var visit = new HashSet<string>();

            bool level = false;
            var queue = new Queue<string>();

            queue.Enqueue(str);

            /* I believe that the level control has a bug - need to count how many nodes 
             * in each level, and process level by level in the while loop
             */
            while (queue.Count > 0)
            {
                var current = queue.Dequeue(); 

                if(isValidString(current))
                {
                    removed.Add(current); 
                    level = true; 
                }

                if (level)
                {
                    continue;
                }

                // brute force solution, go over all possible substrings
                for (int i = 0; i < current.Length; i++)
                {
                    var c = current[i];
                    if (c != '(' && c != ')')
                    {
                        continue;
                    }

                    var substring = current.Substring(0, i) + current.Substring(i + 1);
                    if (!visit.Contains(substring))
                    {
                        queue.Enqueue(substring);
                        visit.Add(substring); 
                    }
                }
            }

            return removed; 
        }

        private static bool isValidString(string s)
        {
            int count = 0;
            foreach (var item in s)
            {
                if (item == '(')
                {
                    count++;
                }

                if (item == ')')
                {
                    count--; 
                }

                if (count < 0)
                    return false; 
            }

            return count == 0; 
        }
    }
}
