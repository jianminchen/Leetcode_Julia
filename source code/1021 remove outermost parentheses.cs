using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1021_remove_outermost_parentheses
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public string RemoveOuterParentheses(string S)
        {
            if (S == null || S.Length <= 2)
            {
                return "";
            }

            var length = S.Length;
            var openBracket = 0;
            var result = new StringBuilder();
            var isFirstOpen = true;
            for (int i = 0; i < length; i++)
            {
                if (isFirstOpen)
                {
                    isFirstOpen = false;
                    continue;
                }

                var current = S[i];
                var isOpen = current == '(';
                var isClose = current == ')';

                if (isOpen)
                {
                    openBracket++;
                    result.Append(current);
                }
                else
                {
                    if (openBracket > 0)
                    {
                        openBracket--;
                        result.Append(current);
                    }
                    else
                    {
                        isFirstOpen = true;
                    }
                }
            }

            return result.ToString();
        }
    }
}
