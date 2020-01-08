using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1249_minimumToRemove
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = MinRemoveToMakeValid("lee(t(c)o)d)e"); 
        }

        /// <summary>
        /// lee(t(c)o)de) -> lee(t(c)o)de* -> remove * in the string
        /// put ( in stack, and if there is matched ), then pop ( otherwise replace stringBuilder index position with *
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static String MinRemoveToMakeValid(String s)
        {
            var sb = new StringBuilder(s);
            var stack = new Stack<int>();

            var length = s.Length;
            for (int i = 0; i < length; i++)
            {
                var current = s[i];
                var isOpen = current == '(';
                var isClose = current == ')';

                if (isOpen)
                {
                    stack.Push(i); 
                }

                if (isClose)
                {
                    if (stack.Count > 0)
                    {
                        stack.Pop();
                    }
                    else
                    {
                        sb.Replace(')','*',i,1);
                    }
                }
            }

            // remove extract ((, for example ))((
            while (stack.Count > 0)
            {                
                sb.Remove(stack.Pop(), 1); 
            }

            return sb.Replace("*","",0,sb.Length).ToString();
        }
    }
}
