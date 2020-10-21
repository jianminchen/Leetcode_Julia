using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _358_rearrange_string_k_distance_apart
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = "aaadbbcc";
            var k = 2;

            var result = rearrangeString(s, k);
            Debug.Assert(result.CompareTo("abacabcd") == 0);

            var result2 = rearrangeString("aabbcc", 2);
            Debug.Assert(result2.CompareTo("abcabc") == 0);

            var result3 = rearrangeString("aaabc", 3);
            Debug.Assert(result3.CompareTo("") == 0); 
        }

        /// <summary>
        /// Oct. 21, 2020
        /// 358 rearrange string k distance apart
        /// study code:
        /// https://github.com/YaokaiYang-assaultmaster/LeetCode/blob/master/LeetcodeAlgorithmQuestions/358.%20Rearrange%20String%20k%20Distance%20Apart.md
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static String rearrangeString(String s, int k)
        {
            var length = s.Length;
            var count  = new int[26];
            var nextPosition = new int[26];

            for (int i = 0; i < length; i++)
            {
                count[s[i] - 'a']++;
            }

            var sb = new StringBuilder();

            for (int index = 0; index < length; index++)
            {
                var candidate = findCandidate(count, nextPosition, index);

                if (candidate == -1)
                {
                    return "";
                }

                count[candidate]--;
                nextPosition[candidate] = index + k;
                sb.Append((char)('a' + candidate));
            }

            return sb.ToString();
        }

        /// <summary>
        /// Find character with largest count value and also fit in the distance constraint;
        /// if two characters have same distance, then smaller one in lexicographic order will be selected. 
        /// </summary>
        /// <param name="count"></param>
        /// <param name="nextPosition"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private static int findCandidate(int[] count, int[] nextPosition, int index)
        {
            int max = Int32.MinValue;

            int candidate = -1;
            for (int i = 0; i < count.Length; i++)
            {
                if (count[i] > 0 && count[i] > max && index >= nextPosition[i])
                {
                    max = count[i];
                    candidate = i;
                }
            }

            return candidate;
        }
    }
}
