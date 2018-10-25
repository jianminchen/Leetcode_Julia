using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _42_Trap_rain_water
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public int Trap(int[] height)
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
