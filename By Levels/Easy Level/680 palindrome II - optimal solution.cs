using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _680_palindrome_II___optimal_solution
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public bool ValidPalindrome(string s)
        {
            if (s == null || s.Length == 0)
                return true;
            if (isPalindrome(s))
                return true;

            var length = s.Length;
            var nonPalindromes = new HashSet<string>();
            var countArray = getCountArray(s);

            var oddCount = getOddCount(s);
            if (oddCount >= 3)
                return false;

                for (int i = 0; i < length; i++)
                {
                    var currentCount = countArray[s[i] - 'a'] % 2;
                    if ((oddCount == 2 && currentCount == 0) ||
                        (oddCount == 1 && currentCount == 0))
                        continue;

                    // remove i
                    var current = "";
                    if (i > 0)
                        current += s.Substring(0, i);

                    if (i + 1 < length)
                        current += s.Substring(i + 1);

                    if (nonPalindromes.Contains(current))
                        continue;

                    if (isPalindrome(current))
                        return true;

                    nonPalindromes.Add(current);
                }

            return false;
        }

        private static int[] getCountArray(string s)
        {
            var countChars = new int[26];
            for (int i = 0; i < s.Length; i++)
            {
                countChars[s[i] - 'a']++;
            }

            return countChars;
        }

        private static int getOddCount(string s)
        {
            var length = s.Length;

            var countChars = new int[26];
            for (int i = 0; i < length; i++)
            {
                countChars[s[i] - 'a']++;
            }

            int oddCount = 0;
            for (int i = 0; i < 26; i++)
            {
                if (countChars[i] % 2 == 1)
                    oddCount++;
            }

            return oddCount; 
        }

        private bool isPalindrome(string s)
        {
            var start = 0;
            var end = s.Length - 1;
            while (start < end)
            {
                if (s[start] != s[end])
                    return false;

                start++;
                end--;
            }

            return true;
        }
    }
}
