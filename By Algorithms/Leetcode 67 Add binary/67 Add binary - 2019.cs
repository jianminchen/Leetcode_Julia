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
            var result = AddBinary("11","1"); 
        }

        /// <summary>
        /// code review in July 16, 2019
        /// binary sum
        /// best place to write a smart for loop on two variables 
        /// 1. backward
        /// 2. ...
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static string AddBinary(string a, string b)
        {                        
            int aLength = a.Length;
            int bLength = b.Length;
            string binarySum = "";

            int carry = 0;
            // from rightmost digit to left
            for (int i = aLength - 1, j = bLength - 1; i >= 0 || j >= 0; --i, --j )
            {
                int aDigit = i >= 0 ? a[i] - '0' : 0;
                int bDigit = j >= 0 ? b[j] - '0' : 0;

                int value = (aDigit + bDigit + carry) % 2;
                carry = (aDigit + bDigit + carry) / 2;

                var current = (char)(value + '0');

                // add as leftmost digit
                binarySum = current.ToString() + binarySum;
            }

            if (carry == 1)
            {
                binarySum = "1" + binarySum; ;
            }

            return binarySum;
        }
    }
}
