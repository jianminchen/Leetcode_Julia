using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximumSubArray
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Test case 1: 
             */
            int[] a = {-2, -3, 4, -1, -2, 1, 5, -3};
            int n = a.Length;
            int max_sum = maxSubArraySum(a, n);
            Console.WriteLine("Maximum contiguous sum is %d\n", max_sum);
            
        }

        

        /*
         * Latest update: July 7, 2015
         * Pseudo code is so clear to read! 
         * Kadane’s Algorithm:
             Initialize:
            max_so_far = 0
            max_ending_here = 0

            Loop for each element of the array
            (a) max_ending_here = max_ending_here + a[i]
            (b) if(max_ending_here < 0)
                    max_ending_here = 0
            (c) if(max_so_far < max_ending_here)
                    max_so_far = max_ending_here
            return max_so_far
         * source code from blog:
         * http://www.geeksforgeeks.org/largest-sum-contiguous-subarray/
         * blog comment:
         * Algorithm doesn't work for all negative numbers. 
         * It simply returns 0 if all numbers are negative. 
         * Dynamic programming - DP
        */
        public static int maxSubArraySum(int[] a, int size)
        {
           int max_so_far = 0, max_ending_here = 0;
           int i;
           for(i = 0; i < size; i++)
           {
                 max_ending_here = max_ending_here + a[i];
                 if(max_ending_here < 0)
                    max_ending_here = 0;
                 if(max_so_far < max_ending_here)
                    max_so_far = max_ending_here;
            }
            return max_so_far;
        } 
    }
}
