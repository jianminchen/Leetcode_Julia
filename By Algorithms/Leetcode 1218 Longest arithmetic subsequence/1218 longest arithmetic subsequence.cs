using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1218_Longest_arithmetic_subsequence
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// Leetcode 1218 Longest arithmetic subsequence
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="difference"></param>
        /// <returns></returns>
        public int LongestSubsequence(int[] arr, int difference)
        {
            var length = arr.Length;

            // key - value
            // value - longest subsequence
            var dict = new Dictionary<int, int>();
            var dp = new int[length];

            for (int i = 0; i < length; i++)
            {
                var current = arr[i];
                var previous = current - difference;
                int currentMax = 1;

                if (dict.ContainsKey(previous))
                {
                    currentMax = 1 + dict[previous];
                }

                dp[i] = currentMax;

                if (dict.ContainsKey(current))
                {
                    var previousLength = dict[current];
                    if (currentMax > previousLength)
                    {
                        dict[current] = currentMax;
                    }
                }
                else
                {
                    dict.Add(current, currentMax);
                }
            }


            return dp.Max();
        }
    }
}
