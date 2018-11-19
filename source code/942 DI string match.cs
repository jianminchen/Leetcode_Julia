using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _942_DI_string_match
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public int[] DiStringMatch(string digits)
        {
            if (digits == null || digits.Length == 0)
                return new int[0];

            var length = digits.Length;

            var numbers = new int[length + 1];

            for (int i = 0; i < length + 1; i++)
            {
                numbers[i] = i;
            }

            var result = new List<int>();
            var last = length;
            int iIndex = 0;
            int dIndex = 0;
            while (dIndex < length)
            {
                var c = digits[dIndex++];
                if (c == 'I')
                {
                    result.Add(numbers[iIndex]);
                    iIndex++;
                }
                else if (c == 'D' && last > iIndex)
                {
                    result.Add(numbers[last--]);
                }
            }

            result.Add(numbers[last]);

            return result.ToArray();
        }
    }
}
