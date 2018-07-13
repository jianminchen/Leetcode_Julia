using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindMaximumGap
{
    /// <summary>
    /// Leetcode: Find maximum gap 
    /// July 4, 2018
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var result = MaximumGap(new int[] {3, 6, 9, 1});
        }

        /// <summary>
        /// using bucket sort and apply pigeon hole principle
        /// 
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public static int MaximumGap(int[] numbers)
        {
            if (numbers == null || numbers.Length < 2)
                return 0;
           
            var size = numbers.Length + 1;
            var bucketsFound = new bool[size];

            var buckets = constructBuckets(numbers, bucketsFound);

            var bucketRows = buckets.GetLength(0);

            var maxGap = 0;

            var previousFound = false;

            var previousMin = 0;
            var previousMax = 0;
            for (int i = 0; i < bucketRows; i++)
            {
                if (bucketsFound[i])
                {
                    var currentMin = buckets[i, 0];
                    var currentMax = buckets[i, 1];

                    if (previousFound)
                    {
                        var currentGap = currentMin - previousMax;
                        if (currentGap > maxGap)
                        {
                            maxGap = currentGap;
                        }
                    }

                    previousFound = true;
                    previousMin = currentMin;
                    previousMax = currentMax; 
                }                
            }

            return maxGap; 
        }

        /// <summary>
        /// apply pigeon hole principle 
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        private static int[,] constructBuckets(int[] numbers, bool[] bucketsFound)
        {
            var length = numbers.Length;

            var max = numbers.Max();
            var min = numbers.Min();

            var range = max - min;
            if (range == 0)
            {
                var result = new int[1, 2];

                result[0, 0] = numbers[0];
                result[0, 1] = numbers[0];

                return result;
            }

            var size = length + 1;
            var buckets = new int[size, 2];            

            double bucketRange = range * 1.0 / size;

            for (int i = 0; i < length; i++)
            {
                var current = numbers[i];
                int bucketIndex = Math.Min((int)((current - min) / bucketRange), size - 1);

                if (bucketsFound[bucketIndex])
                {
                    // check minimum 
                    if (current < buckets[bucketIndex, 0])
                    {
                        buckets[bucketIndex, 0] = current;
                    }

                    // check maximum
                    if (current > buckets[bucketIndex, 1])
                    {
                        buckets[bucketIndex, 1] = current;
                    }
                }
                else
                {
                    bucketsFound[bucketIndex] = true;

                    buckets[bucketIndex, 0] = current;
                    buckets[bucketIndex, 1] = current;
                }
            }

            return buckets;
        }
    }
}
