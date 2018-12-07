using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _856_score_of_parentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            RunTestcases();
        }

        public static void RunTestcases()
        {
            //var result1 = ScoreOfParentheses("()");
            //var result2 = ScoreOfParentheses("()()");
            //var result3 = ScoreOfParentheses("(())");
            var result4 = ScoreOfParentheses("(())()");
        }

        /// <summary>
        /// Given a balanced parentheses string S, compute the score of the string 
        /// based on the following rule:
        /// 1. () has score 1
        /// 2. AB has score A + B, where A and B are balanced parentheses strings.
        /// 3. (A) has score 2 * A, where A is a balanced parentheses string.
        /// </summary>
        /// <param name="S"></param>
        /// <returns></returns>
        public static int ScoreOfParentheses(string text)
        {
            if (text == null || text.Length == 0)
                return 0;

            var stack = new Stack<string>();

            var length = text.Length;   

            stack.Push(text[0].ToString());

            int index = 1;
            var sum = 0; 
            while (stack.Count > 0 && index < length)
            {                
                var current = text[index++];
                var isClose = current == ')';
                var isOpen  = current == '(';

                if (isOpen)
                {
                    stack.Push(current.ToString());
                }
                else if (isClose)
                {                   
                    // options: ( or number 1
                    var addition = 0;
                    while (stack.Count > 0 && stack.Peek().CompareTo("(") != 0)
                    {
                        var number = stack.Pop();                         
                        addition += Convert.ToInt32(number);
                    }

                    if (stack.Peek().CompareTo("(") == 0)
                    {
                        stack.Pop();
                        sum = addition == 0 ? 1 : 2 * addition;
                        stack.Push(sum.ToString());
                    }
                }               
            }

            sum = 0;
            while(stack.Count > 0)
            {
                sum += Convert.ToInt32(stack.Pop());
            }           

            return sum; 
        }
    }
}
