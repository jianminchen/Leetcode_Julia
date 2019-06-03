using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1073_add_two_binary_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = AddNegabinary(new int[]{1}, new int[]{1, 1, 0, 1}); 
        }

        /// <summary>
        /// Leetcode 1073 add two binary numbers - negative two based
        /// There are four possible values for the sum:
        ///  0 - 0
        ///  1 - 1
        ///  2 - 0 with carry -1
        ///  3 - 1 with carry -1
        /// -1 - 1 with carry  1
        /// How to introduce carry -1 instead of 1? How to understand that the carry can be 
        /// expressed in negative value? What is the advantage to use -1? 
        /// Two possible carry values, -1 and 1. 
        /// 
        /// </summary>
        /// <param name="arr1"></param>
        /// <param name="arr2"></param>
        /// <returns></returns>
        public static int[] AddNegabinary(int[] arr1, int[] arr2)
        {
            if (arr1 == null || arr2 == null)
                return new int[0];

            var length1 = arr1.Length;
            var length2 = arr2.Length;

            if (length1 > length2)
            {
                return AddNegabinary(arr2, arr1); 
            }

            var result = new List<int>(); 

            int carry = 0; 
            // from rightmost digit to start to add two numbers digit by digit
            for (int i = 0; i < length2; i++)
            {
                var digit1 = arr2[length2 - 1 - i];
                var digit2 = i < length1 ? arr1[length1 - 1 - i] : 0;

                var sum = digit1 + digit2 + carry;

                if (sum == 0 || sum == 1)
                {
                    result.Add(sum);
                    carry = 0; // reset, caught by online judge
                }                
                else if (sum == 2)
                {
                    result.Add(0);
                    carry = -1; 
                }
                else if (sum == 3)
                {
                    result.Add(1);
                    carry = -1; // caght by online judge
                }
                else if (sum == -1)
                {
                    result.Add(1);
                    carry = 1;
                }
            }

            if (carry == 1)
            {
                result.Add(1);
            }
            else if (carry == -1)
            {
                result.Add(1);
                result.Add(1);
            }

            var count = result.Count; 
            var reversed = new int[count];
            for (int i = 0; i < count; i++)
            {
                reversed[i] = result[count - 1 - i];
            }

            // remove leading 0
            var index = -1; 
            for (int i = 0; i < count; i++)
            {
                if (reversed[i] != 0)
                {
                    break;
                }

                index = i; 
            }

            var removedLeadingZero = 0; 
            if (index >= 0) 
            {
                removedLeadingZero = index;

                if (index != (count - 1))
                {
                    removedLeadingZero++;
                }
            }


            var removed = new int[count - removedLeadingZero];
            for (int i = 0; i < removed.Length; i++)
            {
                removed[i] = reversed[i + removedLeadingZero];
            }

            return removed;
        }
    }
}
