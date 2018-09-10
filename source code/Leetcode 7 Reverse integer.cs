using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_Reverse_integer
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// My sharing on Leetcode discuss can be accessed in the following link:         
        /// https://leetcode.com/problems/reverse-integer/discuss/168151/C-Readable-code
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public int Reverse(int x)
        {
            var number = x.ToString();
            var isNegative = number[0] == '-';

            if (isNegative)
                number = number.Substring(1);

            var charArray = number.ToCharArray();
            Array.Reverse(charArray, 0, number.Length);

            long converted = Convert.ToInt64(new string(charArray));
            if ((!isNegative && converted > int.MaxValue) ||
                (isNegative && (-1 * converted) < int.MinValue)
                )
                return 0;

            return isNegative ? (int)(-1 * converted) : (int)converted;
        }
    }
}
