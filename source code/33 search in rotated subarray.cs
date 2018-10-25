using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _33_search_in_rotated_subarray
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public int Search(int[] shiftArr, int num)
        {
            if (shiftArr == null || shiftArr.Length == 0)
            {
                return -1;
            }

            return runModifiedBinarySearch(shiftArr, num, 0, shiftArr.Length - 1);
        }

        /// <summary>
        /// code review on Nov. 23, 2017
        /// Make sure that the code is simple as possible. 
        /// No code smell, no copy and paste. 
        /// ONLY CHECK THE FIRST HALF AND SEE IF IT IS IN THE FIRST HALF. 
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="search"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        private static int runModifiedBinarySearch(int[] numbers, int search, int start, int end)
        {
            if (start > end)
            {
                return -1;
            }

            int middle = start + (end - start) / 2;
            bool found = numbers[middle] == search;

            // base case, find one solution. 
            if (found)
            {
                return middle;
            }

            var middleValue = numbers[middle];
            var startValue = numbers[start];
            var endValue = numbers[end];

            var firstHalfAscending = startValue <= middleValue; // the first half can be only one node

            var notSmallerThanStartValue = search >= startValue;
            var smallerThanMiddleValue = search < middleValue;

            var oneRangeChecking = notSmallerThanStartValue && smallerThanMiddleValue; // inclusive
            var twoRangesChecking = notSmallerThanStartValue || smallerThanMiddleValue; // exclusive 

            var firstHalfAscendingChecked = firstHalfAscending && oneRangeChecking;
            var fistHalfNotAscendingChecked = !firstHalfAscending && twoRangesChecking;

            if (firstHalfAscendingChecked || fistHalfNotAscendingChecked)
            {
                return runModifiedBinarySearch(numbers, search, start, middle - 1);
            }
            else
            {
                return runModifiedBinarySearch(numbers, search, middle + 1, end);
            }
        }
    }
}
