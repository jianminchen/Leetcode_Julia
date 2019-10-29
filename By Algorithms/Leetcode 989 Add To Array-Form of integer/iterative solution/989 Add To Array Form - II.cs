using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _989_Add_To_Array_Form_III
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// 989. Add to Array-Form of Integer
        /// iterative solution
        /// study code
        /// https://leetcode.com/problems/add-to-array-form-of-integer/discuss/234521/C
        /// </summary>
        /// <param name="words"></param>
        /// <param name="chars"></param>
        /// <returns></returns>
        public IList<int> AddToArrayForm(int[] A, int K)
        {
            var length = A.Length;

            var result = new List<int>();

            int index = length - 1;
            while (index >= 0 || K > 0)
            {
                var sum = K % 10;
                sum += (index >= 0 ? A[index] : 0);

                if (sum >= 10)
                {
                    K += 10; 
                }
                
                index--;

                result.Add(sum % 10);
                K /= 10;
            }

            result.Reverse();
            return result;
        }
    }
}
