using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_414_third_maximum_number
{
    /// <summary>
    /// source code from
    /// https://www.jianshu.com/p/e9dfd2494f41
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int ThirdMax(int[] nums)
        {
            var first = long.MinValue;
            var second = long.MinValue;
            var third = long.MinValue;

            foreach (var value in nums)
            {
                if (value > first)
                {
                    third = second;
                    second = first;
                    first = value;
                }
                else if (value == first)
                    continue;
                else if (value > second)
                {
                    third = second;
                    second = value;
                }
                else if (value == second)
                    continue;
                else if (value > third)
                {
                    third = value;
                }
            }

            return third == long.MinValue ? (int)first : (int)third;
        }
    }
}
