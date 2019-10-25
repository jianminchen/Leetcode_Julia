using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _985_sum_even_number
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// Oct. 25, 2019
        /// 985 sum even numbers after queries
        /// </summary>
        /// <param name="A"></param>
        /// <param name="queries"></param>
        /// <returns></returns>
        public int[] SumEvenAfterQueries(int[] A, int[][] queries)
        {
            var rows = queries.Length;

            var evenNumbersSum = new int[rows];

            var sum = 0;
            for (int j = 0; j < A.Length; j++)
            {
                if (A[j] % 2 == 0)
                {
                    sum += A[j];
                }
            }

            for (int i = 0; i < rows; i++)
            {
                var index = queries[i][1];
                var value = queries[i][0];

                var origin = A[index];
                if (origin % 2 == 0)
                {
                    sum -= origin;
                }

                A[index] += value;

                if (A[index] % 2 == 0)
                {
                    sum += A[index];
                }

                evenNumbersSum[i] = sum;
            }

            return evenNumbersSum;
        }
    }
}
