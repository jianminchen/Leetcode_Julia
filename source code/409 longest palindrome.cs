using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _409.Longest_Palindrome
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public int LongestPalindrome(string s)
        {
            if (s == null || s.Length == 0)
                return 0;

            var length = s.Length;
            var countLowerCaseLetters = new int[26];
            var countUpperCaseLetters = new int[26];

            foreach (var letter in s)
            {
                var isLower = letter >= 'a' && letter <= 'z';
                if (isLower)
                {
                    countUpperCaseLetters[letter - 'a']++;
                }
                else
                {
                    countLowerCaseLetters[letter - 'A']++;
                }
            }

            var totalCount = 0;

            for (int i = 0; i < 26; i++)
            {
                var lowerOne = countLowerCaseLetters[i];
                var upperOne = countUpperCaseLetters[i];

                if (lowerOne > 1)
                {
                    totalCount += lowerOne / 2 * 2;
                }

                if (upperOne > 1)
                {
                    totalCount += upperOne / 2 * 2;
                }
            }

            if (totalCount < s.Length)
                totalCount++;

            return totalCount;
        }
    }
}
