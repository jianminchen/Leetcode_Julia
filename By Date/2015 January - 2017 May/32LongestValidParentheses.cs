using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _32LongestValidParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /*
         * code references:
         * http://shanjiaxin.blogspot.ca/2014/04/longest-valid-parentheses-leetcode.html
         * 
         * Analysis from the above blog:
         * * Solution: 判断 ')' 的情况, 挺麻烦的一道题，考虑corner比较多，只需要循环一边 O(n).
         * 这题目麻烦的地方在于在碰到')'时候如何判断合法序列. 另外用stack 存index值，很关键
         * 1. stack isEmpty --> 当前 ')' 无合法序列, 更新start, 只有inValid才更新start
         * 2. stack !isEmpty, pop()
         * 		isEmpty like (), (() ) --> length = index-start+1 
         * 		!isEmpty like (() --> length = index-stack.peek();  这里就不能用start 标记了
         * 		
         *  Julia's comment:
         *  
         * 1. Make some test cases to help understand the calculation: 
         * case 1: (), length = index - start +1, whereas, start = 0; so, length = 2; 
         * case 2: ()), visit last char ')', stack is empty, no change on maxLength, set start = 3
         * case 3: ((), stack is not empty discussion
         *   push '(''s index 0, and then push '(''s index 1, and then, visit ')', pop '(', stack with one value 0, 
         *   i = 2, (int)stack.peek() = 0, and then, maxLength = Max(maxLength, 2 - 0) = 2. 
         *   Memorize the algorithm right now. 
         *   
         * 2. Pass online judge 
         */


        public static int longestValidParentheses(String s)
        {
            if (s == null || s.Length == 0)
            {
                return 0;
            }

            Stack stack = new Stack();

            int start = 0;
            int maxLength = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    stack.Push(i);
                }
                else
                {
                    if ( stack.Count == 0 )  // skip current ')'
                    {
                        start = i + 1;
                    }
                    else
                    {
                        stack.Pop();   // clear one '('

                        bool stackIsEmpty = stack.Count == 0;

                        int num1 = Math.Max(maxLength, i - start + 1);  // if stack is empty, then, calculate a value: start, current index i
                        int num2 = stackIsEmpty? 0: Math.Max(maxLength, i - (int)stack.Peek());  // if stack is not empty, get last '(''s index, then ...
                                                                  // if stack is empty, stack.Peek() will throw exception. 
                        maxLength = stackIsEmpty ? num1 : num2;
                    }
                }
            }

            return maxLength;
        }
    }
}
