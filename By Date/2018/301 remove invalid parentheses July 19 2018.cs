using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode301_removeInvalidParentheses
{
    class Program
    {
        /// <summary>
        /// Leetcode 301: remove invalid parentheses
        /// July 19, 2018
        /// Study Leetcode discussion:
        /// https://leetcode.com/problems/remove-invalid-parentheses/discuss/75027/Easy-Short-Concise-and-Fast-Java-DFS-3-ms-solution
        /// 
        /// Highlights of design:
        /// 1. Use recursive function
        /// 2. Find first unmatched ), and then remove all possible ) from the beginning;
        ///    make recursive call;
        /// 3. After the unmatched close brackets has been removed, and then continue to 
        ///    process unmatched open brackets. Just call the reversed array.
        /// 4. At the end of the recursive function, only when the reversed string is processed, 
        ///    add the string to the valid string list;
        /// 5. Use two pointers left and right to scan through the string, find first char in every
        ///    consecutive unmatched paretheses, add the option to remove it once.
        ///    this is a nice and smart tip to remember, code from line 75 to 83. 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            RunTestcase();
        }

        static void RunTestcase()
        {
            var validStrings = RemoveInvalidParentheses("()())()");

            Debug.Assert(validStrings[0].CompareTo("()()()") == 0 ||
                         validStrings[0].CompareTo("(())()") == 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static List<String> RemoveInvalidParentheses(String source)
        {
            var validStrings = new List<String>();

            var leftIndex  = 0;
            var rightIndex = 0;
            var defaultLeftToRight = new char[] { '(', ')' };

            removeInvalidCloseParenthesesTwoScans(source, validStrings, leftIndex, rightIndex, defaultLeftToRight);
            return validStrings;
        }

        /// <summary>         
        /// code review July 19, 2018
        /// remove invalid close parentheses two scans, 
        /// one is from left to right and the second one is from right to left. 
        /// 
        /// go through the test case to figure out:
        /// "()())()"
        /// write a story how to find valid strings:
        /// 1. First remove extra close one. 
        /// Find the first one unmatched close one, and then use two pointers
        /// to go over all possible places to remove close one. Remove close one. 
        /// for example, ()())(), iterate the string from left to right, find index = 4, 
        /// ) close parenthese is the extra one. What I like to do is to scan left to right
        /// to find all possible ), and then remove it. 
        /// To make time complexity to linear, we can save close one index to a data structure, like a list. 
        /// In case there are hundreds of chars, but only two or three close parentheses. 
        /// 
        /// 
        /// Time complexity:
        /// Think about how many possible valid strings first. 
        /// define close parentheses at most - M
        /// define open parentheses at most  - N
        /// define unmatched close parentheses at most - M1
        /// define unmatched open paretnthese at most  - N1
        /// possible choices: M ^ M1 * N ^N1
        /// </summary>
        /// <param name="s"></param>
        /// <param name="validStrings"></param>
        /// <param name="right"></param>
        /// <param name="left"></param>
        /// <param name="parentheses"></param>
        private static void removeInvalidCloseParenthesesTwoScans(
            String  s, 
            List<String> validStrings, 
            int     right, 
            int     left, 
            char[]  parentheses)
        {
            var openOne  = parentheses[0];
            var closeOne = parentheses[1];

            for (int openCount = 0, rightIndex = right; rightIndex < s.Length; ++rightIndex)
            {
                var current = s[rightIndex];
                if (current == openOne)
                {
                    openCount++;
                }

                if (current == closeOne)
                {
                    openCount--;
                }

                if (openCount >= 0)
                {
                    continue;
                }

                // find first unmatched parenthese, and then go over all the options to remove it.
                // for test case ()())(), close one has two positions, one is index = 1, index = 3 or 4
                // remove index = 1, and index 3 and 4, only remove first one. Since the second one will be the same
                for (int leftIndex = left; leftIndex <= rightIndex; ++leftIndex)
                {
                    if (  s[leftIndex] == closeOne &&
                        ( leftIndex == left || s[leftIndex - 1] != closeOne))
                    {
                        // remove extra close one
                        var stringFiltered = s.Substring(0, leftIndex) + s.Substring(leftIndex + 1);
                        removeInvalidCloseParenthesesTwoScans(stringFiltered, validStrings, rightIndex, leftIndex, parentheses);
                    }
                }

                return;
            }


            var reversed = new String(s.ToCharArray().Reverse().ToArray());

            if (parentheses[0] == '(') // finished left to right
            {
                removeInvalidCloseParenthesesTwoScans(reversed, validStrings, 0, 0, new char[] { ')', '(' });
            }
            else // finished right to left
            {
                validStrings.Add(reversed);
            }
        }
    }
}
