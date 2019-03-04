using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1004_Max_Consecutive_ones_III
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// wrong answer
        /// </summary>
        /// <param name="A"></param>
        /// <param name="K"></param>
        /// <returns></returns>
        public int LongestOnes(int[] A, int K)
        {

            var length = A.Length;

            var zeroArray = new int[length + 1];
            int countZero = 0;
            for (int i = 0; i < length; i++)
            {
                var current = A[i];
                var isZero = current == 0;
                countZero++;
                zeroArray[countZero] = i;
            }

            if (countZero < K)
                return length;

            var max = zeroArray[K] - zeroArray[1] + 1;
            for (int i = 1; i + K <= countZero; i++)
            {

                var current = zeroArray[i + K] - zeroArray[i] + 1;
                max = current > max ? current : max;
            }

            return max;
        }
    }
}
