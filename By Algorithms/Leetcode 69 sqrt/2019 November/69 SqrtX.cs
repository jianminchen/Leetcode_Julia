using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _69_sqrtX
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// 69 Sqrt(x)
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int MySqrt(int n)
        {
            if (n == 0)
            {
                return 0;
            }

            if (n == 1)
            {
                return 1;
            }

            int start = 0;
            int end = n;
            while (start <= end)
            {
                int middle = start + (end - start) / 2;
                long powerOfTwo = (long)middle * middle; // failed test case: 2147395599

                if (powerOfTwo <= n && (middle == n || (middle + 1) * (middle + 1) > n))
                {
                    return middle; // largest one with power of 2 <= n
                }
                else if (powerOfTwo <= n)
                {
                    start = middle + 1;
                }
                else
                {
                    end = middle - 1;
                }
            }

            return end;
        }
    }
}
