using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _33_Rotated_Sorted_Array___onsite
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
                
                // two range [start, middle - 1], [middle + 1, end]
                // range can be one value only           
                var leftAsc  = numbers[middle - 1] >= numbers[start]; // bug: out-of-range error
                var rightAsc = numbers[end] >= numbers[middle + 1];

                // missing cases
                if (leftAsc && isInRange(target, new int[] { numbers[start], numbers[middle - 1] }))
                {                    
                    end = middle - 1;                    
                }
                else if (rightAsc && isInRange(target, new int[] { numbers[middle + 1], numbers[end] }))
                {
                    start = middle + 1; 
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
