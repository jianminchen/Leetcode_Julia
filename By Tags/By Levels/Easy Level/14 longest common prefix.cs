using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_longest_common_prefix
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// brute force solution 
        /// O(N * K), N is the length of string array, K is common prefix length
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public string LongestCommonPrefix(string[] strs)
        {
            if (strs == null || strs.Length == 0)
                return string.Empty;

            for (int i = 0; i < strs[0].Length; i++)
            {
                var current = strs[0][i];

                for (int j = 1; j < strs.Length; j++)
                {
                    if (strs[j].Length < i + 1 || current != strs[j][i])
                        return strs[0].Substring(0, i);
                }
            }

            return strs[0];
        }
    }
}
