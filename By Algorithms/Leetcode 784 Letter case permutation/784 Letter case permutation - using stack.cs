using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _784_letter_caser_permutation
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public IList<string> LetterCasePermutation(string source)
        {
            var list = new List<string>();
            if (source == null || source.Length == 0)
            {
                list.Add("");
                return list;
            }

            var length = source.Length;
            var stack = new Stack<string>();

            stack.Push(source[0].ToString());
            while (stack.Count > 0)
            {
                var prefix = stack.Pop();
                var length1 = prefix.Length;

                var lastChar = prefix[length1 - 1];

                var lowerCase = lastChar >= 'a' && lastChar <= 'z';
                var upperCase = lastChar >= 'A' && lastChar <= 'Z';
                var isLastChar = length1 == length;

                if (lowerCase || upperCase)
                {
                    // asumme that it is upper case
                    var char1 = (char)('a' + lastChar - 'A');
                    if (lowerCase)
                    {
                        char1 = (char)('A' + lastChar - 'a');
                    }

                    var alternate = prefix.Substring(0, length1 - 1) + char1.ToString();
                    if (isLastChar)
                    {
                        list.Add(alternate);
                        list.Add(prefix);
                    }
                    else
                    {
                        var next = source[length1].ToString();
                        stack.Push(alternate + next);
                        stack.Push(prefix + next);
                    }
                }
                else
                {
                    if (isLastChar)
                    {
                        list.Add(prefix);
                    }
                    else
                    {
                        var next = source[length1].ToString();
                        stack.Push(prefix + next);
                    }
                }
            }

            return list;
        }
    }
}
