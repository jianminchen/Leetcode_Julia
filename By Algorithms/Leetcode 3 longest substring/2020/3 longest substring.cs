using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_longest_substring
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// code review on June 24, 2020
        /// slide window 
        /// Time complexity: O(N), N is the length of the array
        /// Space complexity: O(N), N is the length of the array
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LengthOfLongestSubstring(string s)
        {
            if (s == null || s.Length == 0)
                return 0;

            // slide window - unique
            int max = 0;
            var set = new HashSet<char>();
            int left = 0;
            int index = 0;
            var length = s.Length;

            // "a"
            // "aa"
            // "baa"
            while (index < length)
            {
                //work on sliding window
                var current = s[index]; // 'a'

                // skip size of window is 1
                while (set.Contains(current) && left < index) // true
                {
                    var leftChar = s[left]; // 'a'
                    if (leftChar == s[index])
                    {
                        set.Remove(leftChar); // {}
                        left++; // 2
                        break;
                    }

                    set.Remove(leftChar); // {'a'}
                    left++; // 1
                }

                //
                set.Add(s[index]); // {'a'}
                var size = index - left + 1; // 1
                max = size > max ? size : max; // 2

                index++; // 2
            }

            return max;
        }
    }
}
