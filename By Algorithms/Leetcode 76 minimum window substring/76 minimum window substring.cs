using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _76_minimum_window_substring_optimal
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// July 15, 2019
        /// study code
        /// https://www.youtube.com/watch?v=9odu9ImG9oY
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public string MinWindow(string s, string t)
        {
            if (s == null || s.Length == 0 ||
                t == null || t.Length == 0)
            {
                return "";
            }

            var bank = new int[256];
            
            int left = 0;
            int right = 0;
            int count = 0;

            int min = Int32.MaxValue;
            string minString = "";

            var pLength = t.Length;
            var length = s.Length;

            for (int i = 0; i < pLength; i++)
            {
                bank[t[i]]++;
            }

            while (right < length)
            {   
                var rightChar = s[right];
                right++; // always advance one to next iteration 
                if (bank[rightChar] > 0)
                {
                    count++;
                }

                bank[rightChar]--; // always decrement one no matter char is in pattern t or not                              

                // move left pointer until missing one char from string t
                while (count == pLength)
                {
                    var size = right - left;
                    if (min > size)
                    {
                        min = size;
                        minString = s.Substring(left, right - left);
                    }

                    // shift our window
                    var leftChar = s[left];
                    left++;  // always move left pointer
                    bank[leftChar]++; // always increment one no matter char is in pattern t or not                    

                    if (bank[leftChar] > 0) // that means left char is one of chars in pattern, also count as one
                    {
                        count--;
                    }
                }
            }

            return minString;
        }
    }
}
