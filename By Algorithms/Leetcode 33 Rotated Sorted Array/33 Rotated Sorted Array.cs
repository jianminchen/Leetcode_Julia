using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _33_Rotated_Sorted_Array
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// modified binary search 
        public int Search(int[] numbers, int target)
        {
            if (numbers == null || numbers.Length == 0)
                return -1;

            var start = 0;
            var end = numbers.Length - 1;

            while (start <= end)
            {
                var middle = start + (end - start) / 2;
                var middleValue = numbers[middle];

                if (middleValue == target)
                    return middle;

                // Do not consider middle - 1 or middle + 1, which may be out of range of numbers array
                // two range [start, middle], [middle, end]
                // range can be one value only           
                var leftAsc = middleValue >= numbers[start];
                var rightAsc = numbers[end] >= middleValue;

                if (leftAsc)
                {
                    if (isInRange(target, new int[] { numbers[start], middleValue }))
                    {
                        end = middle - 1;
                    }
                    else
                    {
                        start = middle + 1;
                    }
                }
                else if (rightAsc)
                {
                    if (isInRange(target, new int[] { middleValue, numbers[end] }))
                    {
                        start = middle + 1;
                    }
                    else
                    {
                        end = middle - 1;
                    }
                }
            }

            return -1;
        }

        private static bool isInRange(int target, int[] range)
        {
            return target >= range[0] && target <= range[1];
        }
    }
}
