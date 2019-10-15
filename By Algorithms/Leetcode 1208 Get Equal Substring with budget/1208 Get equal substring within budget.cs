using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1208_Get_Equal_substrings_with_budget
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// 1208 Get equal substrings within budget
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <param name="maxCost"></param>
        /// <returns></returns>
        public int EqualSubstring(string s, string t, int maxCost)
        {
            int length = s.Length;

            int left = 0;
            int index = 0;

            int sum = 0;
            int max = 0;

            while (index < length)
            {
                var diff = Math.Abs(s[index] - t[index]);

                var current = sum + diff;
                if (current <= maxCost)
                {
                    var newlength = index - left + 1;
                    if (newlength > max)
                    {
                        max = newlength;
                    }

                    sum = current;
                    index++;
                }

                // move left pointer 
                while (current > maxCost && left < length)
                {
                    var leftValue = Math.Abs(s[left] - t[left]);
                    sum -= leftValue;
                    left++;
                    current -= leftValue;
                }
            }

            return max;
        }
    }
}
