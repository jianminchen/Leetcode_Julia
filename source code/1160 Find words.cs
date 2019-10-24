using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1160_Find_Words
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// Oct. 24, 2019
        /// 1160 Find Words that can be formed by characters
        /// </summary>
        /// <param name="words"></param>
        /// <param name="chars"></param>
        /// <returns></returns>
        public int CountCharacters(string[] words, string chars)
        {
            var countSource = countChars(chars);
            var length = words.Length;

            var sum = 0;
            for (int i = 0; i < length; i++)
            {
                var current = words[i];
                var count = countChars(current);
                if (compareTwoCounts(count, countSource))
                {
                    sum += current.Length;
                }
            }

            return sum;
        }

        private static int[] countChars(string chars)
        {
            var count = new int[26];
            foreach (var item in chars)
            {
                count[item - 'a']++;
            }

            return count;
        }

        private static bool compareTwoCounts(int[] count, int[] countSource)
        {
            for (int i = 0; i < 26; i++)
            {
                if (count[i] > countSource[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
