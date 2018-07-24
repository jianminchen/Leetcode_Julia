using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode438_FindAllAnagramsInAString
{
    /// <summary>
    /// Leetcode 438 - find all anagrams in a string 
    /// https://leetcode.com/problems/find-all-anagrams-in-a-string/description/
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static int SIZE = 26; 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static IList<int> FindAnagrams(string s, string p)
        {
            if (s == null || p == null || s.Length < p.Length)
                return new List<int>();

            var sLength = s.Length;
            var pLength = p.Length;

            var source = getCountingSort(p);
            var counting = getCountingSort(s.Substring(0, pLength));
            var anagrams = new List<int>();
            if (checkAnagram(source, counting))
            {
                anagrams.Add(0);
            }

            for (int i = 1; i < sLength && (pLength + i - 1) < sLength; i++)
            {
                counting[s[i - 1] - 'a']--;
                counting[s[pLength + i - 1] - 'a']++;
                if (checkAnagram(source, counting))
                {
                    anagrams.Add(i);
                }
            }

            return anagrams;
        }

        private static bool checkAnagram(int[] source, int[] second)
        {
            for (int i = 0; i < SIZE; i++)
            {
                if (source[i] != second[i])
                    return false; 
            }

            return true; 
        }

        private static int[] getCountingSort(string p)
        {
            if (p == null)
            {
                return new int[0];
            }

            var counting = new int[SIZE];
            foreach(var item in p)
            {
                counting[item - 'a']++;
            }

            return counting;
        }
    }
}
