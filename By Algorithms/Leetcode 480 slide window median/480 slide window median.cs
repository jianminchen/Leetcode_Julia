using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _480_slide_window_median___study
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new int[]{1,3,-1,-3,5,3,6,7}; 
            var result = MedianSlidingWindow(numbers, 3);

            // result should be [1.0,-1.0,-1.0,3.0,5.0,6.0]
        }

        /// <summary>
        /// July 16, 2019
        /// study code:
        /// https://leetcode.com/problems/sliding-window-median/discuss/96357/C-BinarySearch-solution
        /// The idea is to insert the number into the index position found by binary search API.
        /// So the list is sorted in ascending order. 
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static double[] MedianSlidingWindow(int[] numbers, int k)
        {
            var list = new List<double>();

            if (numbers != null && numbers.Length > 0 && k > 0)
            {
                int half = (k >> 1);

                int median = half + (k & 1) - 1;

                var slideWindow = new List<double>();

                // slide window maintenance - put into window with sorted order first
                // remove left pointer value
                for (int i = 0; i < numbers.Length; ++i)
                {
                    if (i >= k)
                    {
                        slideWindow.Remove(numbers[i - k]);
                    }

                    int index = slideWindow.BinarySearch(numbers[i]);
                    if (index < 0)
                    {
                        index = ~index;
                    }

                    slideWindow.Insert(index, numbers[i]);

                    if (i >= k - 1)
                    {
                        list.Add(half == median ? slideWindow[half] : ((slideWindow[half] + slideWindow[median]) / 2));
                    }
                }
            }

            return list.ToArray<double>();
        }
    }
}
