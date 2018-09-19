using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _507_Perfect_number
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// My sharing of the algorithm can be found here:
        /// https://leetcode.com/problems/perfect-number/discuss/168146/C-learn-to-write-one
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public bool CheckPerfectNumber(int num)
        {
            if (num <= 0)
                return false;

            int sum = 0;
            for (int i = 1; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0)
                {
                    if (i != num)
                        sum += i;

                    var second = num / i;

                    if (i != second && second != num)
                        sum += num / i;
                }
            }

            return sum == num;
        }
    }
}
