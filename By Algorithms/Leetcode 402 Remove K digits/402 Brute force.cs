using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _402_remove_K_digits_naive
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// Leetcode 402 remove K digits
        /// 4/19/2019
        /// I learned two lessons. 
        /// first I should evaluate time complexity; if I choose to use stack then it will much easy to write;
        /// Second the edge case is not handled time efficent way. 
        /// </summary>
        /// <param name="num"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public string RemoveKdigits(string num, int k)
        {
            if (k == 0)
                return num;
            if (num == null || num.Length == 0)
                return num;

            var length = num.Length;
            var chose = new StringBuilder();

            // time complexity is not efficient O(removed * removed) + O(length)
            int start = 0;
            int removed = k;
            while (removed > 0)
            {
                // 10200 - k = 1, only choose the first two digits
                // find the minimum digit from start position
                // removed + 1 digits
                // reserve digits for 
                var range = removed + 1;
                var minIndex = start;
                var minValue = 10;

                // edge case: "10", 2
                var end = start + range;
                if (end > length)
                {
                    if (chose.ToString().Length == 0)
                        return "0";
                    else
                        return chose.ToString();
                }

                for (int i = start; i < end; i++)
                {
                    var current = num[i] - '0';
                    var isSmaller = current < minValue;
                    minValue = isSmaller ? current : minValue;
                    minIndex = isSmaller ? i : minIndex;
                }

                // edge case: "0200" -> "20"
                var leadingZero = chose.ToString().CompareTo("0") == 0;
                if (leadingZero)
                {
                    chose.Clear();
                    chose.Append(num[minIndex]);
                }
                else
                    chose.Append(num[minIndex]);

                // count how many digits removed
                removed -= minIndex - start;
                start = minIndex + 1;
            }

            for (int i = start; i < length; i++)
            {
                // edge case: "0200" -> "20"
                var leadingZero = chose.ToString().CompareTo("0") == 0;
                if (leadingZero)
                {
                    chose.Clear();
                    chose.Append(num[i]);
                }
                else
                    chose.Append(num[i]);
            }

            return chose.ToString();
        }
    }
}
