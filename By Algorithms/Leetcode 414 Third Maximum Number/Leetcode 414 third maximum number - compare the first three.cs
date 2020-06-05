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
        /// 2018 August 15
        /// Very good practice to work on basics:
        /// I will add more detail later
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int ThirdMax(int[] nums)
        {
            var first  = long.MinValue;
            var second = long.MinValue;
            var third  = long.MinValue;

            foreach (var value in nums)
            {
                if (value > first)
                {
                    // new maximum value to be added
                    third = second;
                    second = first;
                    first = value;
                }
                else if (value == first)
                {
                    continue;
                }
                else if (value > second)
                {
                    // Second largest value to be added
                    third = second;
                    second = value;
                }
                else if (value == second)
                {
                    continue;
                }
                else if (value > third)
                {
                    // Third largest value to be added 
                    third = value;
                }
            }

            return third == long.MinValue ? (int)first : (int)third;
        }
    }
}
