using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1071_great_common_divisor_of_string
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// June 3, 2019
        /// 1071. Great common divisor of string
        /// Use brute force solution, try all substring length possible
        /// - return largest string 
        /// 
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        public string GcdOfStrings(string str1, string str2)
        {
            if(str1 == null || str2 == null || str1.Length == 0 || str2.Length == 0)
                return "";

            var length1 = str1.Length;
            var length2 = str2.Length;

            var min = Math.Min(length1, length2);

            // return largest substring
            for (int i = min; i >= 0; i--)
            {
                var length = i + 1;
                if (!(length1 % length == 0 && length2 % length == 0))
                    continue;

                var number1 = length1/ length;
                var number2 = length2/ length;

                var unit = str1.Substring(0, i + 1);
                var s1 = unit;
                for (int j = 0; j < number1 - 1; j++)
                {
                    s1 += unit;
                }

                var s2 = unit;
                for (int j = 0; j < number2 - 1; j++)
                {
                    s2 += unit;
                }

                if(s1.CompareTo(str1) == 0 && (s2.CompareTo(str2) == 0))
                    return unit; 
            }

            return "";
        }
    }
}
