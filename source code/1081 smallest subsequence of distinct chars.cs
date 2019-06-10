using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1081_Smallest_subsequence_of_distinct_chars
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// 1081 - June 10, 2019
        /// 5086 - Smallest Subsequence of Distinct Characters
        /// use stack, count sorting first
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string SmallestSubsequence(string text)
        {
            if (text == null || text.Length == 0)
                return "";

            var length = text.Length;
            var count = new int[26];

            foreach (var item in text)
            {
                count[item - 'a']++;
            }

            var stack = new Stack<char>();
            var selected = new HashSet<char>();

            foreach (var item in text)
            {
                if (selected.Contains(item))
                {
                    count[item - 'a']--;
                    continue;
                }

                while (stack.Count > 0 && stack.Peek() > item && count[stack.Peek() - 'a'] >= 1)
                {
                    var removed = stack.Peek();
                    stack.Pop();
                    // count[removed - 'a']--;  // caught by online judge
                    selected.Remove(removed);
                }

                stack.Push(item);
                count[item - 'a']--;
                selected.Add(item);
            }

            return Reverse(String.Join("", stack.ToArray()));
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
