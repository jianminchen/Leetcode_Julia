using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1170_Compare_strings
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// Oct. 25, 2019
        /// 1170 Comapre strings 
        /// </summary>
        /// <param name="queries"></param>
        /// <param name="words"></param>
        /// <returns></returns>
        public int[] NumSmallerByFrequency(string[] queries, string[] words)
        {
            var length = queries.Length;
            var smallerCount = new int[length];

            var numbers = countFreqencyOfArray(words);

            for (int i = 0; i < length; i++)
            {
                var count = countFreqency(queries[i]);

                var smaller = 0;
                for (int j = 0; j < numbers.Length; j++)
                {
                    if (count < numbers[j])
                        smaller++;
                }

                smallerCount[i] = smaller;
            }

            return smallerCount;
        }

        private static int[] countFreqencyOfArray(string[] words)
        {
            var length = words.Length;
            var frequency = new int[length];

            for (int i = 0; i < length; i++)
            {
                frequency[i] = countFreqency(words[i]);
            }

            return frequency;
        }

        private static int countFreqency(string word)
        {
            // sort the string 
            var characters = word.ToArray();
            Array.Sort(characters);

            int count = 1;
            var c = characters[0];
            for (int i = 1; i < characters.Length; i++)
            {
                if (characters[i] != c)
                {
                    break;
                }

                count++;
            }

            return count;
        }
    }
}
