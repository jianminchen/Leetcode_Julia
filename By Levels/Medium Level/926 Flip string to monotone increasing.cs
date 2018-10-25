using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _926_Flip_string_to_monotone_increasing
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public int MinFlipsMonoIncr(string digits)
        {
            if (digits == null || digits.Length == 0)
                return 0;

            var leftOnes = countOneLeftToRightInclusive(digits);
            var rightZeros = countZeroRightToLeftInclusive(digits);

            // get minimum flips
            var length = digits.Length;
            var minimumFlips = digits.Length;
            for (int i = 0; i < digits.Length; i++)
            {
                var current = rightZeros[i];
                if (i > 0)
                {
                    current += leftOnes[i - 1];
                }

                minimumFlips = current < minimumFlips ? current : minimumFlips;
            }

            var lastOne = leftOnes[length - 1];
            minimumFlips = lastOne < minimumFlips ? lastOne : minimumFlips;

            return minimumFlips;
        }

        private static int[] countOneLeftToRightInclusive(string digits)
        {
            var length = digits.Length;
            var ones = new int[length];

            int count = 0;
            ones[0] = 0;
            for (int i = 0; i < length; i++)
            {
                if (digits[i] - '0' == 1)
                {
                    count++;
                }

                ones[i] = count;
            }

            return ones;
        }

        private static int[] countZeroRightToLeftInclusive(string digits)
        {
            var length = digits.Length;
            var zeros = new int[length];

            int count = 0;
            zeros[0] = 0;
            for (int i = length - 1; i >= 0; i--)
            {
                if (digits[i] - '0' == 0)
                {
                    count++;
                }

                zeros[i] = count;
            }

            return zeros;
        }
    }
}
