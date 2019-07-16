using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _67_Add_binary___2015B
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// code written in 2015
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public string AddBinary(string a, string b)
        {
            int carry = 0;
            string result = "";

            int aLen = a.Length;
            int bLen = b.Length;

            for (int i = aLen - 1, j = bLen - 1;    // from rightmost digit to left
                 i >= 0 || j >= 0;
                 --i, --j
               )
            {
                int ai = i >= 0 ? a[i] - '0' : 0;
                int bj = j >= 0 ? b[j] - '0' : 0;
                int val = (ai + bj + carry) % 2;
                carry = (ai + bj + carry) / 2;
                char c = (char)(val + '0');

                result = c.ToString() + result;
            }

            if (carry == 1)
            {
                result = "1" + result; ;
            }

            return result;
        }
    }
}
