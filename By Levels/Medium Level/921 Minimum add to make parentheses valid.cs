using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _921_Maximum_add_to_make_parentheses_valid
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public int MinAddToMakeValid(string symbols)
        {
            if (symbols == null || symbols.Length == 0)
            {
                return 0;
            }

            int openBracket = 0;
            int unmatchedClose = 0;
            for (int i = 0; i < symbols.Length; i++)
            {
                var isOpen = symbols[i] == '(';
                if (isOpen)
                {
                    openBracket++;
                }
                else
                {
                    if (openBracket > 0)
                        openBracket--;
                    else
                        unmatchedClose++;
                }
            }

            return openBracket + unmatchedClose;
        }
    }
}
