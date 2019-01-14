using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _974_Subarray_sums_divisible_by_K
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static int SubarraysDivByK(int[] numbers, int K)
        {
            var countResidue = new int[K];
            int count = 0;
            int prefixSum = 0;
            countResidue[0] = 1;
            for (int i = 0; i < numbers.Length; i++)
            {
                var current = numbers[i];
                prefixSum += current;
                var residue = prefixSum % K;
                if (residue < 0)
                {
                    residue = K + residue;
                }

                count += countResidue[residue];
                countResidue[residue]++;
            }

            return count;
        }
    }
}
