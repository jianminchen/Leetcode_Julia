using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7ReverseInteger
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /*
         * http://www.cnblogs.com/TenosDoIt/p/3735866.html
         * 
         * 
         */

        /*
         * 
        http://yucoding.blogspot.ca/2013/04/leetcode-question-84-reverse-integer.html
         * 
         */
        public static int reverse(int x)
        {
            int res = 0;
            while (x != 0)
            {
                if (res > Int32.MaxValue / 10 || res < Int32.MinValue / 10)
                {
                    return 0;
                }

                res = res * 10 + x % 10;  // x = 12, so s % 10 = 2, 
                x = x / 10;
            }

            return res;
        }

        /*
         * http://www.cnblogs.com/TenosDoIt/p/3735866.html
         */
        int reverse2(int x) {
            bool isPositive = true;

            if(x < 0){
                isPositive = false; 
                x *= -1;
            }

            long  res = 0;//为了防止溢出，用long long
            while(x > 0)
            {
                res = res*10 + x%10;
                x /= 10;
            }

            if(res > Int32.MaxValue)
                return isPositive ? Int32.MaxValue : Int32.MinValue;

            if(!isPositive)
                return (int) res * (-1);

            else return (int)res;
        }


    }
}
