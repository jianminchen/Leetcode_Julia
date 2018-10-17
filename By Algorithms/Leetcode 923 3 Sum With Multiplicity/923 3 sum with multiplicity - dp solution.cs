using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _923_3_sum_with_multiplicity
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// dp[i][j][k] represents number of combinations using k numbers within 
        /// A[0] ... A[i] with the sum of j.
        /// Then dp[n][target][3] is the result. 
        /// Time complexity: O(n * target)
        /// three dimension array, first dimension there is n options, n <= 3000
        /// second option, target <= 300, 301 option. 
        /// 
        /// The idea is from 
        /// https://leetcode.com/problems/3sum-with-multiplicity/discuss/181125/Knapsack-O(n-*-target)-or-Straightforward-O(n2)
        /// How to think about the dynamic programming solution?
        /// Go over each element in the array, for each sum from 0 to target, 
        /// consider if current element is counted or not. If it is not counted, then the ways 
        /// should be previous one, the same value; if it is counted, then the ways should be added by the value
        /// of smaller value (sum - currentValue). 
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int ThreeSumMulti(int[] numbers, int target)
        {
            int n = numbers.Length; 
            int maximum = (int)1e9 + 7;

            var dp = new int[n + 1, target + 1, 4]; // n+1, target + 1, 4

            for (int i = 0; i <= n; i++) {
                dp[i, 0, 0] = 1;  // why?
            }

            for (int i = 1; i < n + 1; i++) 
            {
                for (int sum = 0; sum <= target; sum++) 
                {
                    for (int k = 1; k <= 3; k++) 
                    {
                        dp[i, sum, k]  = dp[i - 1, sum, k]; // based on the same sum 
                        dp[i, sum, k] %= maximum;

                        var current = numbers[i - 1];

                        if (sum >= current)
                        {
                            var smallerSum = sum - current; // based on the smaller sum

                            dp[i, sum, k] += dp[i - 1, smallerSum, k - 1];  // increment the value 
                            dp[i, sum, k] %= maximum;
                        }
                    }
                }
            }

            return dp[n, target, 3];
        }
    }
}
