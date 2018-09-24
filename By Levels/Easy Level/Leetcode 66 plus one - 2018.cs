using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_66_plus_one
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>
        public int[] PlusOne(int[] digits)
        {
            if (digits == null)
                return new int[0];

            var length = digits.Length;

            for(int i = 0; i < length; i++)
            {
                var index = length - 1 - i;
                var current = digits[index];
                digits[index] = (current + 1) % 10; 

                if (current + 1 <= 9)
                {                    
                    return digits;
                }
                
                // continue 
            }

            var output = new int[length + 1];
            output[0] = 1;

            Array.Copy(digits, 0, output, 1, length);
            
            return output;
        }
    }
}
