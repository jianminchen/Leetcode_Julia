using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _67_Add_binary___study_2019
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// 2019-July-16
        /// study code
        /// https://leetcode.com/problems/add-binary/discuss/24595/C-simple-adding
        /// A few good ideas are showing in the code:
        /// 1. There is only one loop;
        /// 2. Value is binary value 0 or 1, it is easy to check
        /// 3. No redundant code. 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public string AddBinary(string a, string b)
        {
            int carry = 0;
            string binarySum = "";
            int index = 0;

            var aLength = a.Length;
            var bLength = b.Length;

            while (index < a.Length || index < b.Length || carry > 0)
            {
                int ax = index < aLength && a[aLength - index - 1] == '1' ? 1 : 0;
                int bx = index < bLength && b[bLength - index - 1] == '1' ? 1 : 0;

                int digit = ax + bx + carry;

                carry = digit > 1 ? 1 : 0;
                digit = digit % 2;

                binarySum = digit + binarySum;
                index++;
            }

            return binarySum;
        }
    }
}
