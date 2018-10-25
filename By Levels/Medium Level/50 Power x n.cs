using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _50_power_x_n
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public double MyPow(double x, int n)
        {
            if (x == 0)
                return 0;
            if (n == 0)
            {
                return 1.0;
            }

            double half = MyPow(x, n / 2);

            if (n % 2 == 0)
            {
                return half * half;
            }
            else if (n > 0)
            {
                return half * half * x;
            }
            else
            {
                return half * half * (1 / x);
            }
        }
    }
}
