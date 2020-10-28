using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1049_last_stone
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = LastStoneWeightII(new int[] { 1, 2, 3, 4 });
            Debug.Assert(result == 0); 
        }

        /// <summary>
        /// Oct. 28, 2020
        /// Work on case study [1, 2, 3, 4], whereas array's maximum length <=30, 
        /// element maximum value in the array is 100
        /// Analysis:
        /// Maximum value is 400 = 4 * 100, declare C# bool dp[201]. 
        /// Go through each stone one by one, 
        /// go through dp[200] to dp[stone.value], 
        /// dp[i] is true if dp[i - stone.value] is true. 
        /// sum of stones = 1 + 2 + 3 + 4 = 10, 
        /// check dp[5], dp[5] is true, so minimum difference is 0. 
        /// </summary>
        /// <param name="stones"></param>
        /// <returns></returns>
        public static int LastStoneWeightII(int[] stones)
        {
            var sum = stones.Sum();
            // length <= 30, value of stones [1, 100] 
            var maximum = sum / 2;
            var dp = new bool[maximum + 1];

            dp[0] = true;

            var total = 0;
            foreach (var item in stones)
            {
                total += item;
                for (int i = maximum; i >= item; i--)
                {
                    // For example, [1, 2, 3, 4], dp[10] is true is dp[6] is true, item = 4
                    dp[i] |= dp[i - item];  // logical OR
                }
            }

            // sum/ 2 is minimum difference, greedy search - one by one starting from minimum
            for (int i = sum / 2; i > 0; i--)
            {
                if (dp[i])
                {
                    // difference
                    return sum - i * 2;
                }
            }

            return 0;
        }
    }
}
