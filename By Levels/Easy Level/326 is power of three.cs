using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode326_isPowerOfThree
{
    /// <summary>
    /// Leetcode 326 is power of three
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
        }

        public bool IsPowerOfThree(int n)
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
                if (iterate % 3 != 0)
                {
                    return false;
                }

                iterate = iterate / 3; 
            }

            return true; 
        }
    }
}
