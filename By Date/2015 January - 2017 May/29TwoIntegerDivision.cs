using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoIntegerDivision
{

    public class Solution
    {
        static void Main(string[] args)
        {
            int dividend = 12, divisor = 2;

            int solution = divide(dividend, divisor);

            int solution2 = divide2(dividend, divisor);

            int solution3 = divide3(dividend, divisor); 
        }

        public static int divide(int dividend, int divisor)
        {
            return (int)divideL(dividend, divisor);
        }

        public static long divideL(long dividend, long divisor)
        {
            if (divisor == 1) return dividend;
            if (divisor < 0) return -divideL(dividend, -divisor);
            if (dividend < 0) return -divideL(-dividend, divisor);
            if (divisor > dividend) return 0;
            if (divisor == 0) return int.MaxValue;
            long d = divisor;
            long bitcnt = 1;
            long ans = 0;
            while (d < dividend)
            {
                d <<= 1;
                bitcnt <<= 1;
            }
            while (d >= divisor)
            {
                while (dividend >= d)
                {
                    dividend -= d;
                    ans += bitcnt;
                }
                d >>= 1;
                bitcnt >>= 1;
            }
            return ans;
        }

        static int divide2(int dividend, int divisor) {

            long  a = dividend >= 0 ? dividend : -(long )dividend;
            long  b = divisor >= 0 ? divisor : -(long )divisor;

            long result = 0;
            while (a >= b) {
                long c = b;
                
                for (int i = 0; a >= c; ++i, c <<= 1) {
                    a -= c;
                    result += 1 << i;
                }
            }
            
            return (int)result;
        }

        /*
         * first time using uint in C# - June 4, 2015 
         * The sbyte data type is an 8-bit signed integer. 
            The byte data type is an 8-bit unsigned integer. 
            The short data type is a 16-bit signed integer. 
            The ushort is a 16-bit unsigned integer. 
            The int data type is a 32-bit signed integer. 
            The uint is a 32-bit unsigned integer. 
            The long data type is a 64-bit signed integer. 
            The ulong is a 64-bit unsigned integer. 
            The char data type is a Unicode character (16 bits). 
            The float data type is a single-precision floating point. 
            The double data type is a double-precision floating point. 
            The bool data type is a Boolean (true or false). 
            The decimal data type is a decimal type with 28 significant digits (typically used for financial purposes).

         */
        static int divide3( int dividend, int divisor) {
            int result = 0; 
            bool sign = (dividend > 0 && divisor < 0) ||  (dividend < 0 && divisor > 0);  
 
            uint a = (uint)(dividend >= 0 ? dividend : -dividend);
            uint b = (uint)(divisor >= 0 ? divisor : -divisor);
            
            /*
             * Try to figure out what we are doing in loops:
             * 
             */
            while (a >= b) {
                int multi = 1;
                uint bb = b;
                
                while (a >= bb) {
                    a -= bb;
                    result += multi;
                    if (bb < int.MaxValue >> 1)
                    { 
                        bb += bb;
                        multi += multi;
                    }
                }
            }
            
            if (sign) return -result;
            else return result;
        }
    }

}
