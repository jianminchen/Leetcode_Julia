using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _541_reverse_string_II
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = "abcdefg";
            var result = reverseStr(test, 2); 
        }

        /// <summary>
        /// Every 2k chars, first k char will be reversed
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static String reverseStr(String s, int k)
        {
            if (s == null || s.Length == 0 || k < 0)
                return string.Empty;

            if (k == 0)
                return s;

            var length = s.Length;
            int index = 0;
            var sb = new StringBuilder(); 

            while (index < length)
            {
                // check first k numbers
                var reversedCount = Math.Min(k, length - index);
                var charArray = s.ToCharArray();
                reverseStringGivenRange(charArray, index, reversedCount);

                for (int i = index; i < index + reversedCount; i++ )
                    sb.Append(charArray[i]);

                // rest of 2k numbers
                for (int i = index + reversedCount; i < index + 2 * k && i < length; i++)
                {
                    sb.Append(s[i]);
                }

                index += 2 * k; 
            }

            return sb.ToString(); 
        }

        private static void reverseStringGivenRange(char[] original, int startIndex, int length)
        {
            int start = startIndex;
            int end = startIndex + length - 1;

            while (start < end)
            {
                var tmp = original[start];
                original[start] = original[end];
                original[end] = tmp;

                start++;
                end--; 
            }
        }
    }
}
