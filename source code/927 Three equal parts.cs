using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _927_Three_equal_parts
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public int[] ThreeEqualParts(int[] digits)
        {
            var notFound = new int[] { -1, -1 };

            if (digits == null)
                return notFound;

            var countof1 = 0;
            var length = digits.Length;
            var map = new Dictionary<int, int>();
            for (int i = 0; i < length; i++)
            {
                if (digits[i] == 1)
                {
                    map.Add(countof1, i);
                    countof1++;
                }
            }

            if (countof1 % 3 != 0)
                return notFound;

            if (countof1 == 0)
                return new int[] { 0, 2 };

            int number1 = countof1 / 3;

            // narrow down the number without considering leading zero
            int thirdNumberStart = map[countof1 - number1];

            // constraint
            int minimumLength = length - thirdNumberStart; // substring of number, there are some leading 0s maybe. 

            // compare the first number with third number            
            int index1 = map[0];
            int index2 = map[number1];
            int index3 = map[countof1 - number1]; // test using countof1 = 3, 2 ; 6;

            if (length - index1 + 1 < 3 * minimumLength)
                return notFound;

            var digitsString = string.Join(string.Empty, digits); // look up stackoverflow.com

            var number = digitsString.Substring(thirdNumberStart);
            var firstNumber = digitsString.Substring(index1, minimumLength);
            var secondNumber = digitsString.Substring(index2, minimumLength);

            var result = number.CompareTo(firstNumber) == 0 && number.CompareTo(secondNumber) == 0;
            if (!result)
            {
                return notFound;
            }
            //               last digit of first number   third number's first digit
            return new int[] { index1 + minimumLength - 1, index2 + minimumLength };
        }
    }
}
