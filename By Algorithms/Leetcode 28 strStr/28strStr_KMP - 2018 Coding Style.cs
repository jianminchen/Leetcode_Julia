using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strStr_KMP
{
    class Program
    {
        static void Main(string[] args)
        {
        }
        
        /// <summary>
        /// http://yyeclipse.blogspot.ca/2013/02/leetcode-implement-strstr-string.html
        /// </summary>
        /// <param name="haystack"></param>
        /// <param name="needle"></param>
        /// <returns></returns>
        public String strKMP(String haystack, String needle)
        {
            if (needle.Length == 0)
            {
                return haystack;
            }

            //get next array
            var next = generateNext(needle.ToCharArray());
            int len = 0;     // Number of characters matched            

            for (int i = 0; i < haystack.Length; i++)
            {
                while (len > 0 && needle[len] != haystack[i])
                {
                    len = next[len];
                }

                if (needle[len] == haystack[i])
                {
                    len++;
                }

                if (len == needle.Length)
                {
                    return haystack.Substring(i - needle.Length + 1);
                }
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="needle"></param>
        /// <returns></returns>
        private int[] generateNext(char[] needle)
        {
            // next array. next[i] means when match length = i, 
            // the common prefix and real suffix length = next[i] 
            var next = new int[needle.Length + 1];

            //the longest common length of prefix and real suffix.

            int presufix = 0;
            //next[1] = 0, starting from 2. i = match length.

            for (int i = 2; i < next.Length; i++)
            {
                while (presufix > 0 && needle[presufix] != needle[i - 1]) //trickiest part
                {
                    presufix = next[presufix];
                }

                if (needle[presufix] == needle[i - 1])
                {
                    presufix++;
                }

                next[i] = presufix;
            }

            return next;
        }
    }
}
