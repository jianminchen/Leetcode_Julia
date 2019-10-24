using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _509_Fibonacci_number
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// Oct. 24, 2019
        /// 509 Fibonacci number
        /// </summary>
        /// <param name="N"></param>
        /// <returns></returns>
        public int Fib(int N)
        {
            if (N == 0)
            {
                return 0;
            }

            if (N == 1)
            {
                return 1;
            }

            var previousPrevious = 0;
            var previous = 1;
            var current = 0;
            for (int i = 2; i <= N; i++)
            {
                current = previousPrevious + previous;

                // reset
                previousPrevious = previous;
                previous = current;
            }

            return current;
        }
    }
}
