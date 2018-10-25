using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _918_Maximum_sum_circular_subarray
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public int MaxSubarraySumCircular(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
                return 0;

            var length = numbers.Length;
            var dp = new int[length];
            dp[0] = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                dp[i] = Math.Max(dp[i - 1] + numbers[i], numbers[i]);
            }

            var max = dp.Max();

            // find minimum value
            // use variable dp again to avoid mixing similar two varaibles in one function
            var sum = numbers.Sum();
            if (length > 2)
            {
                dp = new int[length - 2];
                dp[0] = numbers[1];

                for (int i = 1; i < length - 2; i++)
                {
                    dp[i] = Math.Min(dp[i - 1] + numbers[i + 1], numbers[i + 1]);
                }

                var min = dp.Min();

                return Math.Max(max, min <= 0 ? (sum - min) : sum);
            }
            else
            {
                return max;
            }
        }
    }
}
