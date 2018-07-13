using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace medianOfTwoSortedArrays
{
    class Program
    {
        /**
         * Latest update: June 24, 2015
         * Leetcode: median of two sorted arrays
         * http://articles.leetcode.com/2011/01/find-k-th-smallest-element-in-union-of.html
         * Action Items:
         *   1. implement the naive solution: O(m+n) using C#
         *   2. implement the better solution: O(k) using C#
         *   3. implement the best soluton: O(lg m + lg n) using C# (completed on June 24, 2015)
         * 
         * convert C++ code to C#
         * read the article and understand the difference between C++ and C#
         * https://msdn.microsoft.com/en-us/library/yyaad03b(v=vs.90).aspx
         * 
         */
        static void Main(string[] args)
        {
            /* test case 1:
             * array 1: 1, 3, 5, 7, 9
             * array 2: 2, 4, 5, 8, 10
             * so the median is the median of the sorted array 1, 2, 3, 4, 5, 5, 7, 8, 9, 10
             * median of the above array is (5+5)/2 = 5 
             */
            int[] a = new int[]{ 1, 3, 5, 7, 9 };
            int[] b = new int[]{ 2, 4, 5, 8, 10};

            int median1 = findMedianSortedArray(a,5,b,5);

            /* test case 2:
             * array 1: 1, 3, 5, 7, 9
             * array 2: 2, 4, 6, 8
             * actually it is the median of the sorted array: 1, 2, 3, 4, 5, 6, 7, 8, 9
             * median of the above sorted array is: 5
             * 
            */
            int[] a2 = new int[]{ 1, 3, 5, 7, 9 };
            int[] b2 = new int[]{ 2, 4, 6, 8 };

            int median2 = findMedianSortedArray(a2, 5, b2, 4);            
        }

        /**
         * Leetcode: median of two sorted arrays
         * best solution: O(lg m+lg n) 
         * http://articles.leetcode.com/2011/01/find-k-th-smallest-element-in-union-of.html
         */
        public static int findMedianSortedArray(int[] A, int m, int[] B, int n)
        {
            int total = m + n;

            // total is odd
            if (total % 2 == 1)
            {
                return find_kth(A, m, B, n, total / 2 + 1);
            }
            else
            {
                int v1 = find_kth(A, m, B, n, total / 2);
                int v2 = find_kth(A, m, B, n, total / 2 + 1); 
                double value =   (v1+v2)/2.0;
                return Convert.ToInt32(value); 
            }
        }

       
        // take advantage two sorted array, 
        // using binary partition to reduce the algorithm to log(m+n)
        protected static int find_kth(int[] A, int m, int[] B, int n, int k){
            // always assume that m is equal or smaller than n
            if (m > n) return find_kth(B, n, A, m, k);
            
            if (m == 0) return B[k - 1]; // the kth number in B
            
            if (k == 1) return (Math.Min(A[0], B[0]));

            // divide k into two parts
            int ia = Math.Min(k / 2, m), 
                ib = k - ia;

            // proof that those first ia elements in array A must be included. 
            if (A[ia - 1] < B[ib - 1]) 
            {
                // julia comment: on June 24, 2015 first time use Array.Copy method
                // C++ A+ia, but C# takes more time to figure out
                int[] AA = new int[A.Length-ia];
                Array.Copy(A, ia,AA,0,AA.Length);
                return find_kth(AA, m - ia, B, n, k - ia); 
            }
            // proof that those first ib elements in array B must be included.
            else if (A[ia - 1] > B[ib - 1]) 
            {
                int[] BB = new int[B.Length -ib]; 
                Array.Copy(B, ib, BB, 0, BB.Length); 
                return find_kth(A, m, BB, n - ib, k - ib);
            }
            else
                return A[ia - 1];
        }
    }
}

    
   
