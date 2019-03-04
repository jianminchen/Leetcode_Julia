using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1004_max_consecutive_ones_III___after_the_contest
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public int LongestOnes(int[] A, int K)
        {
            var length = A.Length;

            var zeroArray = new int[length + 1];
            int countZero = 0;
            for (int i = 0; i < length; i++)
            {
                var current = A[i];
                var isZero = current == 0;
                if (isZero)
                {
                    zeroArray[countZero] = i;
                    countZero++;
                }
            }

            var maxGap = 0;
            if (K == 0)
            {
                for (int i = 0; i + 1 < countZero; i++)
                {
                    var current = zeroArray[i + 1] - zeroArray[i] - 1;
                    maxGap = current > maxGap ? current : maxGap;
                }

                return maxGap;
            }

            if (countZero <= K)
                return length;

            var start0 = zeroArray[0];
            var end0 = zeroArray[K - 1];

            end0 = countZero >= K + 1 ? (zeroArray[K] - 1) : (length - 1);
            var max = end0 + 1;

            for (int i = 1; i + K - 1 < countZero; i++)
            {
                var start = zeroArray[i - 1] + 1;
                var lastOne = i + K - 1;
                var end = zeroArray[lastOne];

                end = i + K - 1 < (countZero - 1) ? (zeroArray[lastOne + 1] - 1) : end;

                var current = end - start + 1;
                max = current > max ? current : max;
            }

            return max;
        }     
    }
}
