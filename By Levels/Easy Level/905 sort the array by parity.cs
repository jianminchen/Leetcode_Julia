using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _905_sort_the_array_by_parity
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public int[] SortArrayByParity(int[] A)
        {
            if (A == null || A.Length <= 1)
                return A;

            var length = A.Length;
            var start = 0;
            var end = length - 1;
            while (start < end)
            {
                var startValue = A[start];
                var endValue = A[end];
                if (startValue % 2 == 0)
                {
                    start++;
                    continue;
                }
                else if (endValue % 2 == 1)
                {
                    end--;
                    continue;
                }
                else
                {
                    var tmp = A[start];
                    A[start] = A[end];
                    A[end] = tmp;
                    start++;
                    end--;
                }
            }

            return A;
        }
    }
}
