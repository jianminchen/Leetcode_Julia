using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode231_PowerOfTwo
{
    /// <summary>
    /// Leetcode 231: Power of two 
    /// https://leetcode.com/problems/power-of-two/description/
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// 0 - false
        /// 1 - true
        /// 2 - true
        /// 3 - false
        /// 4 - true        
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool IsPowerOfTwo(int n)
        {
            if( n <= 0 )
                return false;

            if( n == 1 )
                return true;

            if (n % 2 == 1)
                return false;

            return IsPowerOfTwo(n / 2);
        }
    }
}
