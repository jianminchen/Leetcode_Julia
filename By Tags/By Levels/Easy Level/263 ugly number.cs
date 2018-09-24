using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _263_ugly_number
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// prime factor 2, 3, 5 only
        /// 1 is ugly number
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public bool IsUgly(int num)
        {
            if (num < 1)
                return false;
            if (num == 1)
                return true;

            int index = num;
            while (index > 1)
            {
                var divisors =  new int[]{2, 3, 5};
                var foundOne = false; 
                foreach (var divisor in divisors)
                {
                    if (index % divisor == 0)
                    {
                        index = index / divisor;
                        foundOne = true;
                        break;
                    }
                }

                if (!foundOne)
                    return false;
            }

            return true; 
        }
    }
}
