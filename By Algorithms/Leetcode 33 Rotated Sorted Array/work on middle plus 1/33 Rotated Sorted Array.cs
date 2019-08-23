using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _33_Rotated_sorted_Array___Catchup
{
    class Program
    {
        static void Main(string[] args)
        {
            RunTestcase(); 
        }

        /// <summary>
        ///  TLE - time limit exceeded 
        /// </summary>
        public static void RunTestcase()
        {
            var result = Search(new int[] {4, 5, 6, 7, 0, 1, 2}, 3);
        }

        /// modified binary search 
        public static int Search(int[] numbers, int target)
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

                // Avoid time limit exceeded bug
                if (start == end)
                    return -1; 

                // two range [start, middle - 1], [middle + 1, end]
                // range can be one value only   
                // Range definition should be added
                var leftAsc  = (middle - 1) >= start && numbers[middle - 1] >= numbers[start]; 
                var rightAsc = (middle + 1 <= end) && numbers[end] >= numbers[middle + 1];

                // missing cases
                if (leftAsc)
                {
                    if (isInRange(target, new int[] { numbers[start], numbers[middle - 1] }))
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
                    if (isInRange(target, new int[] { numbers[middle + 1], numbers[end] }))
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
