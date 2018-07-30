using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_343_power_of_four
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public bool IsPowerOfFour(int n)
        {
            if (n <= 0)
                return false;

            if (n == 1)
            {
                return true;
            }

            var iterate = n;
            while (iterate > 1)
            {
                if (iterate % 4 != 0)
                {
                    return false;
                }

                iterate = iterate / 4;
            }

            return true;
        }
    }
}
