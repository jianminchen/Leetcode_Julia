using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrapRainingWater
{
    /// <summary>
    /// Leetcode 42: Trapping raining water
    /// https://leetcode.com/problems/trapping-rain-water/description/
    /// preprocessing the array to store prefix maximum and suffix maximum. 
    /// Time complexity is O(N) where N is the length of the array
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var test = Trap(new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 });
            Debug.Assert(test == 6);
        }

        public static int Trap(int[] height)
        {
            if (height == null || height.Length == 0)
            {
                return 0;
            }

            var length = height.Length;

            // scan left to right to get maximum of prefix
            var prefixMax = ScanLeftToRightPrefixMax(height);

            // scan right to left to get maximum of postfix
            Array.Reverse(height);
            var suffixMax = ScanLeftToRightPrefixMax(height);
            Array.Reverse(height);
            Array.Reverse(suffixMax);

            // add the sum of the difference for each bar
            var maxSum = 0;
            for (int index = 0; index < length; index++)
            {
                var smallOne = Math.Min(prefixMax[index], suffixMax[index]);
                var current = height[index];

                if (smallOne > current)
                {
                    maxSum += smallOne - current;
                }
            }

            return maxSum;
        }

        private static int[] ScanLeftToRightPrefixMax(int[] height)
        {
            var length = height.Length;

            var prefixMax = new int[length];
            var maxValue = height[0];

            prefixMax[0] = height[0];
            for (int index = 1; index < length; index++)
            {
                var visit = height[index - 1];
                maxValue = visit > maxValue ? visit : maxValue;
                prefixMax[index] = maxValue;
            }

            return prefixMax;
        }
    }
}