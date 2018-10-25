using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode556_nextGreaterElement
{
    /// <summary>
    /// Leetcode 556 - next greater element in the integer 32 bits
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var result5 = NextGreaterElement(230241);
            Debug.Assert(result5 == 230412);

            var result3 = NextGreaterElement(1234);
            Debug.Assert(result3 == 1243);

            var result4 = NextGreaterElement(534976);
            Debug.Assert(result4 == 536479);

            // 14123 -> 14132
            // First find 2 from rightmost to scan left to right
            // 
            var result = NextGreaterElement(14123);
            Debug.Assert(result == 14132);

            var result2 = NextGreaterElement(218765);
            Debug.Assert(result2 == 251678);
        }

        public static int NextGreaterElement(int n)
        {
            if (n < 0)
            {
                return -1;
            }

            var digits = n.ToString();
            var isDescending = isInDescending(digits);
            if (isDescending)
            {
                return -1; 
            }

            var index = findFirstIndexNotDescendingFromRight(digits);
            var substring = digits.Substring(index + 1);
            var sortedDigits = substring.ToCharArray();
            Array.Sort(sortedDigits);

            var smallestLarge = findSmallestLargeAndUpdate(digits[index], sortedDigits);
            var lastPart = new string(sortedDigits);

            var nextGreat = digits.Substring(0, index) + smallestLarge.ToString() + lastPart;

            int numValue;
            bool parsed = Int32.TryParse(nextGreat, out numValue);

            if (parsed)
            {
                return numValue;
            }
            else
            {
                return -1;  // online judge: 1999999999 -> should return -1, not 0
            }
        }

        private static bool isInDescending(string s)
        {
            var digits = s.ToCharArray();
            var previous = 9; 
            for (int i = 0; i < digits.Length; i++)
            {
                var current = s[i] - '0'; // online judge - bug report - missing - '0'
                if (current > previous)
                    return false;

                previous = current; 
            }

            return true; 
        }

        /// <summary>
        /// should call find first index not ascending from right
        /// for example: 534976, find index = 2, 4 < 9, 4 should be replaced by 6
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>
        private static int findFirstIndexNotDescendingFromRight(string digits)
        {
            var previous = -1;

            for (int i = digits.Length - 1; i >= 0; i--)
            {
                var current = digits[i];
                if (current < previous)
                    return i;

                previous = current;
            }

            return -1; 
        }

        /// <summary>
        /// '5' and "3478", smallest large digit should be 5
        /// 
        /// </summary>
        /// <param name="digit"></param>
        /// <param name="sortedDigits"></param>
        /// <returns></returns>
        private static int findSmallestLargeAndUpdate(char digit, char[] sortedDigits)
        {
            var length = sortedDigits.Length;

            var value = digit - '0';

            for (int i = 0; i < length; i++)
            {
                var current = sortedDigits[i] - '0'; // missing - '0', catched by online judge
                if (value < current)
                {
                    sortedDigits[i] = (char)(value +'0');
                    return current;
                }
            }

            return -1;
        }
    }
}
