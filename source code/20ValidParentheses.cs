using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20ValidParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /*
         * cod reference:
         * http://blog.csdn.net/fightforyourdream/article/details/13011825
         * 
         * julia's comment: 
         * 1. pass online judge
         *  65 / 65 test cases passed.
            Status: Accepted
            Runtime: 124 ms
         */
        public static bool isValid(String s)
        {
            Stack stack = new Stack();

            for (int i = 0; i < s.Length; i++)
            {
                char current = s[i];

                // 如果遇到前括号就压入栈  
                if (current == '(' || current == '[' || current == '{')
                {
                    stack.Push(current);
                }
                else if (current == ')' || current == ']' || current == '}')
                {       // 遇到后括号就出栈  
                    if (stack.Count == 0)
                    {  
                        //  说明后括号太多了  
                        return false;
                    }

                    char previous = (char)stack.Pop();

                    if (previous == '(' && current == ')')
                    {
                        continue;
                    }
                    else if (previous == '[' && current == ']')
                    {
                        continue;
                    }
                    else if (previous == '{' && current == '}')
                    {
                        continue;
                    }

                    return false;
                }
            }

            return stack.Count == 0;
        }  
    }
}
