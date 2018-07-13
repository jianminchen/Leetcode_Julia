using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20ValidParentheses
{
    /*
     * Leetcode 20: Valid Parentheses
     * Problem statement:
     * Leetcode: Valid Parentheses
        Given a string containing just the characters '(', ')', '{', '}', '[' and ']', 
     *  determine if the input string is valid.
        The brackets must close in the correct order, "()" and "()[]{}" are all valid 
     * but * "(]" and "([)]" are not.
     * 
     * 
     * code reference:
     * http://buttercola.blogspot.ca/2014/07/leetcode-valid-parentheses.html
     * 
     * Analysis from the above blog:
     * Analysis:
        1. What is a valid string?
        We can list several examples to show the valid string:
        Empty string is always valid
        For string has only one pair of parentheses, (), [ ], { } are valid. 
        However, (], {], (}, etc.. are not valid
        For string has two pairs of parentheses, ( )[ ], ([ ]), { }[ ] are valid. 
        However, ( [ ) ], ( { } ] are not valid
        For string has  three pairs of parentheses, ( )[ ]{ }, { ( [ ] ) } are valid. 
        However, { [ )} ( ] is not valid
        
        Now we can use these examples to check if a string is valid. In addition, 
        if the length of a given string is odd, it must be invalid. 
        
        2. The problem presumes that the input string has just the characters of parentheses, 
        square brackets, and brace. So we don't need to  consider other characters like 
     *  white space, digit, etc... 
        
     *  3. How to determine if a string is valid?
        There are two conditions that a valid string must fulfill:
        The numbers of parentheses must match. For example, if there is a left parentheses, 
     *  there must have a right one, so does for square brackets and brace. Therefore, 
     *  the number of left parentheses must be equal to the right parentheses. 
        
     *  The brackets must be in the correct closing order. For example, { [ } ], although 
     *  this string fuifills the first requirement, it is not the correct order. So how to 
     *  determine the order is correct? Last-in-First-out. For instance, { ( ) } is valid 
     *  because we see left brace first, we will see the right brace last. So you might 
     *  already come out the idea! Yes, we can use a stack to store the parentheses.
     *  
        Note that the problem does not require the order of the parentheses, i.e. { } should 
     *  be outside of [ ], while [ ] must be outside of ( )
     *  
        Solution from the above blog:
        According to the analysis, we can use the stack to solve this problem. 

        When we see a left parenthesis, (, [, or {, we push it into the stack. 
        When we see a right parenthesis, we pop the top element from the stack, and 
     *  compare it with the right parentheses. If they are matched, check next character 
     *  in the string; otherwise, directly returns the false. 
        
     *  If the stack is empty while the string has not reached the end, it must be the situation 
     *  like ( ) ], then it returns the false.
        If the stack is not empty while the string has already reached the end, it must be the 
     *  situation like ( ( ) then it returns the false. 
     * 
     * Julia's comment:
     * 1. Julia did first implementation of Leetcode 20: valid parenthese on August 22, 2015
     * https://github.com/jianminchen/Leetcode_C-/blob/master/20ValidParentheses.cs
     * 2. She likes to write the very readable code with small functions, which are easy to read, 
     * work on one task only for one function. Similar to modular programming, or S.O.L.I.D. principle 
     * S. - Single Responsibility, or a function is less than 24 lines, do one small task. 
     */
    class Solution
    {
        public bool isValid(string s)
        {
            int length = s.Length;
            if (length == 0) 
                return true; 
            if (length %2 == 1) 
                return false; 

            Stack<char> stack = new Stack<char>(); 

            int index = 0; 
            while (index <length)
            {
                char cur = s[index]; 
                if(isLeftBracket(cur)){
                    stack.Push(cur); 
                    index++; 
                }
                else if(isRightBracket(cur)){
                    if(stack.Count == 0) return false; 

                    char temp = stack.Pop(); 
                    if(!isPair(temp, cur)) 
                        return false; 
                    index++; 
                }
            }

            return stack.Count == 0; 
        }

        /*
         * Determine the given parentheses is right 
         */
        private bool isLeftBracket(char ch)
        {
            if (ch == '(' || ch == '[' || ch == '{')
                return true;
            else
                return false;
        }

        /*
         * Determine the given parentheses is right 
         */
        private bool isRightBracket(char ch)
        {
            if (ch == ')' || ch == ']' || ch == '}')
                return true;
            else
                return false; 
        }

        /*
         * Determine the left and right parentheses is a pair
         */
        private bool isPair(char left, char right)
        {
            if((left == '(' && right ==')') ||
               (left == '[' && right ==']') ||
               (left == '{' && right =='}') 
            )
                return true; 
            else 
                return false; 
        }

        static void Main(string[] args)
        {
            Solution sol = new Solution();

            bool res = sol.isValid("{[]}()");
            bool res1 = sol.isValid("{][][}"); 
        }
    }
}
