using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _784_Letter_case_permutation___recursive
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public IList<string> LetterCasePermutation(string source)
        {
            if (source == null)
            {
                return new List<string>();
            }

            var list = new List<string>();

            iterateString(source, list, "", 0);

            return list;
        }

        /// <summary>
        /// recursive solution
        /// </summary>
        /// <param name="source"></param>
        /// <param name="options"></param>
        /// <param name="prefix"></param>
        /// <param name="index"></param>
        private static void iterateString(string source, IList<string> options, string prefix, int index)
        {
            if (index == source.Length)
            {
                options.Add(prefix);
                return;
            }

            var current = source[index];
            var lowercaseLetter = current >= 'a' && current <= 'z';
            var uppercaseLetter = current >= 'A' && current <= 'Z';

            if (lowercaseLetter || uppercaseLetter)
            {
                var next = prefix + current.ToString();
                char nextAlternateCase = (char)('A' + current - 'a');
                if (uppercaseLetter)
                {
                    nextAlternateCase = (char)('a' + current - 'A');
                }

                iterateString(source, options, next, index + 1);
                iterateString(source, options, prefix + nextAlternateCase.ToString(), index + 1);
            }
            else
            {
                var next = prefix + source[index].ToString();
                iterateString(source, options, next, index + 1);
            }
        }
    }
}
