using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1012
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public int BitwiseComplement(int N)
        {
            string binary = Convert.ToString(N, 2);

            var length = binary.Length;

            var value = 0;
            // iterate from left to right
            for (int i = 0; i < length; i++)
            {
                int current = binary[length - 1 - i] - '0';
                current = current == 0 ? 1 : 0;

                value += current * (int)Math.Pow(2, i);
            }

            return value;
        }
    }
}
