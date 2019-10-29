using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _989_Add_To_Array_Form
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = AddToArrayForm(new int[]{1, 2, 3, 4}, 34); 
        }

        /// <summary>
        /// Oct 29, 2019
        /// Leetcode 989 Add to array form
        /// recursive solution 
        /// First time I learn to use IEnumberable.Skip and IEnumberable.Take
        /// </summary>
        /// <param name="A"></param>
        /// <param name="K"></param>
        /// <returns></returns>
        public static IList<int> AddToArrayForm(int[] A, int K) 
        {
            if(K == 0)
            {
                return A.ToList(); 
            }
        
            if(A.Length == 0 && K < 10)
            {
                return new int[]{K}.ToList();
            }
        
            var rightmost = K % 10; 
            var rest = K/10; 
            var sum = 0; 
            if(A.Length == 0)
            {
                sum = rightmost;
            }
            else 
            {
                sum = A[A.Length - 1] + rightmost;
            }
        
            var lessThan10 = sum < 10; 
        
            // recursive solution 
            IList<int> list =  new List<int>();
            var value = rest + (lessThan10 ? 0 : 1);
            var aLength = A.Length;

            if (aLength == 0)
            {
                list = AddToArrayForm(new int[0], value);
            }
            else
            {
                list = AddToArrayForm(A.Take(aLength -1).ToArray(), value);
            }

            list.Add(sum % 10);

            return list;                    
        }
    }
}
