using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximumSubArrayLeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            * Test case: 
            * given the array [−2,1,−3,4,−1,2,1,−5,4],
              the contiguous subarray [4,−1,2,1] has the largest sum = 6.
            */
            int[] test = new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 };

            int t2 = maxSubArray(test, 9);  
        }

        /**
         * Problem: http://leetcode.com/onlinejudge#question_53
         * 
         * source code from blog:
         * https://github.com/xiaoxq/leetcode-cpp/blob/master/src/MaximumSubarray.cpp
         * 
         * julia comment:
         * 1. convert it to C# 
         * 2. Save sum as an array, sum[i] is sum of array A from 0 to i
         * 3. Does this extra space, extra array of sum saves time complexity? Interesting idea! 
         * 
         */
        public static int maxSubArray(int[] A, int n)
	    {
		    // A[0]+..+A[i] stores in sum[i]
		    int[] sum = new int[n];
		    sum[0] = A[0];
		    for( int i=1; i<n; ++i )
			    sum[i] = sum[i-1] + A[i];

		    // divide and conquer
		    return maxSubArray( A, sum, 0, n, n );
	    }

	    // return max sum in [start,end)
	    public static int maxSubArray(int[] A,  int[] sum, int start, int end, int n)
	    {
		    // solve directly
		    switch( end-start )
		    {
		        case 1: return A[start];
		        case 2: return max( max( A[start], A[start+1] ), A[start] + A[start+1] );
		    }

		    int middle = (start + end) / 2;
		    int childResult = max( 
                    maxSubArray( A, sum, start,    middle, n ),
				    maxSubArray( A, sum, middle+1,    end, n ));

		    // find max in sum after middle (julia comment: middle, ..., n-1)
		    int maxSum = max_element( sum, middle, n );
		    // find min in sum before middle (julia comment: 0, 1, ..., middle-1)
		    int minSum = min_elment( sum, 0, middle );
		    return max( childResult, maxSum - minSum );
	    }

        public static int max(int a, int b)
        {
            return Math.Max(a, b);
        }

        public static int max_element(int[] a, int start, int end)
        {
            int max = Int32.MinValue;
            for (int i = start; i <end; i++)
            {
                if (a[i] > max)
                    max = a[i]; 
            }
            return max; 
        }

        public static int min_elment(int[] a, int start, int end)
        {
            int min = Int32.MaxValue;
            for (int i = 0; i < end; i++)
            {
                if (a[i] < min)
                    min = a[i]; 
            }
            return min; 
        }
    }
}
