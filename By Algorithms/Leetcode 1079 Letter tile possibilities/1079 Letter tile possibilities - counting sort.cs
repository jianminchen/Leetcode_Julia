using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1079_letter_tile_possibilities___counting_sort
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// Leetcode 1079 Letter tile possibilities
        /// June 9, 2019
        /// study code:
        /// https://leetcode.com/problems/letter-tile-possibilities/discuss/308284/Concise-java-solution
        /// </summary>
        /// <param name="tiles"></param>
        /// <returns></returns>
        public int NumTilePossibilities(string tiles)
        {
            int[] count = new int[26];
            foreach (var item in tiles)
            {
                count[item - 'A']++;
            }

            return depthFirstSearch(count);
        }

        /// <summary>
        /// case study: "AAB"
        /// count: A -> 2, B->1
        /// length 1: "A", "B"
        /// length 2: 
        /// For "A":
        ///   count:  A->1, B->1
        ///   We can still pick either A, or B
        ///   So we have "AA,"AB"
        /// For "B":
        ///   count: A->2, B->0
        ///   We can only pick A
        ///   So we have "BA"
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        private static int depthFirstSearch(int[] numbers)
        {
            int sum = 0;
            for (int i = 0; i < 26; i++)
            {
                if (numbers[i] == 0)
                {
                    continue;
                }

                sum++; // 
                numbers[i]--;
                sum += depthFirstSearch(numbers);
                numbers[i]++;
            }

            return sum;
        }
    }
}
