using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximumSubArray2
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        /*
         Latest update: July 6, 2015 
         题目: 最大连续子段和
         难度: Easy
         链接: http://www.itint5.com/oj/#8
         问题: 
         有一个包含n个元素的数组arr，计算最大的子段和（允许空段）。
         Solution: 与leetcode中的Maximum Subarray类似（dp）。
         Julia comment: 
         * dp  - maximum sum ending at ith int in the array
         * res - maximum value in all dp values from 0 to i
         * O(n) solution - go through the array once. 
        */

        public static int maxConsSum(int[] arr)
        {
            int dp = 0;
            int res = 0;
            for (int i = 0; i < arr.Length; ++i)
            {
                dp = max(arr[i], dp + arr[i]);
                res = max(dp, res);
            }
            return res;
        }

        public static int max(int a, int b)
        {
            return Math.Max(a, b);
        }
    }
}
