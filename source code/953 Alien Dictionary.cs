using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _953_Alien_dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public bool IsAlienSorted(string[] words, string order)
        {
            var dict = new int[26];
            int index = 0;
            foreach (var item in order)
            {
                dict[item - 'a'] = index;
                index++;
            }

            var length = words.Length;

            for (int i = 0; i < length - 1; i++)
            {
                var current = words[i];
                var next = words[i + 1];

                if (!compareLexicoOrder(current, next, dict))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool compareLexicoOrder(string current, string next, int[] dict)
        {
            var currentLength = current.Length;
            var nextLength = next.Length;

            for (int i = 0; i < Math.Min(currentLength, nextLength); i++)
            {
                var firstChar = dict[current[i] - 'a'];
                var nextChar = dict[next[i] - 'a'];

                if (firstChar > nextChar)
                    return false;
                else if (firstChar < nextChar)
                    return true;
            }

            return currentLength <= nextLength;
        }
    }
}
