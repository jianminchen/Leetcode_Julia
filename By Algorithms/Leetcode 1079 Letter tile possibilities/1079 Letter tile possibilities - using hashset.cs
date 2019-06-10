using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1079_Letter_tile_possibilities
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// Leetcode 5087
        /// study code
        /// https://leetcode.com/problems/letter-tile-possibilities/discuss/308377/C-DFS-Readable-Solution
        /// 
        /// Brute force solution 
        /// Try all combination of different length from 1 to 7
        /// </summary>
        /// <param name="tiles"></param>
        /// <returns></returns>
        public int NumTilePossibilities(string tiles)
        {
            var set = new HashSet<string>();
            var list = tiles.ToList();

            // brute force all lengths
            // length options: 1, 2, 3, 4, 5, 6, 7
            for (int i = 1; i <= tiles.Length; i++)
            {
                NumTilePossibilitiesHelper(new StringBuilder(), set, list, i);
            }

            return set.Count;
        }

        /// <summary>
        /// backtracking, depth first search
        /// List class API List.Insert(index, value)
        /// Stringbuilder class API StringBilder(start, length)
        /// </summary>
        /// <param name="sequence"></param>
        /// <param name="set"></param>
        /// <param name="tiles"></param>
        /// <param name="length"></param>
        private static void NumTilePossibilitiesHelper(
            StringBuilder sequence,
            HashSet<string> set,
            List<char> tiles,
            int length)
        {
            // base case 
            if (sequence.Length == length)
            {
                set.Add(sequence.ToString());
                return;
            }

            // please consider the next char for all possible chars
            int backtrackingLength = sequence.Length;

            for (int i = 0; i < tiles.Count; i++)
            {
                var current = tiles[i];

                sequence.Append(current);
                // remove current char from the list
                tiles.RemoveAt(i);

                NumTilePossibilitiesHelper(sequence, set, tiles, length);

                // insert current char to the list
                // List.Insert()
                tiles.Insert(i, current);

                // StringBuilder.Remove(start, length)
                sequence.Remove(backtrackingLength, sequence.Length - backtrackingLength);
            }
        }
    }
}
